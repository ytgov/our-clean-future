using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = OurCleanFuture.Data.Entities.Action;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace OurCleanFuture.App.Pages.Indicators
{
    public partial class Edit : IDisposable
    {
        private bool isLoaded;
        private AppDbContext context = null!;
        private ClaimsPrincipal user = null!;

        [Parameter]
        public int Id { get; set; }

        public string AuthorizedRoles { get; set; } = "Administrator, ENV-CCS.Writer";
        public string SelectedParentType { get; set; } = "";
        public IEnumerable<Lead> SelectedLeads { get; set; } = new List<Lead>();


        public List<Lead> Leads { get; set; } = new();
        public List<UnitOfMeasurement> UnitsOfMeasurement { get; set; } = new();
        public List<Goal> Goals { get; set; } = new();
        public List<Objective> Objectives { get; set; } = new();
        public List<Action> Actions { get; set; } = new();
        public Indicator Indicator { get; set; } = null!;
        public Target Target { get; set; } = null!;

        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        [Inject]
        public NavigationManager Navigation { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try {
                context = ContextFactory.CreateDbContext();
                Leads = await context.Leads.Include(l => l.Organization).Include(l => l.Branch).ThenInclude(b => b!.Department).OrderBy(l => l.Branch!.Name).ToListAsync();
                UnitsOfMeasurement = await context.UnitsOfMeasurement.ToListAsync();
                Goals = await context.Goals.OrderBy(g => g.Title).ToListAsync();
                Objectives = await context.Objectives.Include(o => o.Area).OrderBy(o => o.Area.Title).ThenBy(o => o.Title).ToListAsync();
                Actions = await context.Actions.ToListAsync();
#pragma warning disable CS8601 // Possible null reference assignment.
                Indicator = await context.Indicators.Include(i => i.Target).Include(i => i.Leads).FirstOrDefaultAsync(i => i.Id == Id);
                Target = Indicator.Target;
#pragma warning restore CS8601 // Possible null reference assignment.
                foreach (var lead in Indicator.Leads) {
                    SelectedLeads = SelectedLeads.Append(lead);
                }
                GetSelectedParentType();
                await GetUserPrincipal();
                AuthorizedRoles += GetAuthorizedRoles();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                isLoaded = true;
            }

            await base.OnInitializedAsync();
        }

        private string GetAuthorizedRoles()
        {
            var authorizedRoles = "";
            foreach (var lead in Indicator.Leads) {
                switch (lead.Branch?.Department.ShortName) {
                    case "CS":
                        authorizedRoles += ", CS.Writer";
                        break;
                    case "EcDev":
                        authorizedRoles += ", EcDev.Writer";
                        break;
                    case "EDU":
                        authorizedRoles += ", EDU.Writer";
                        break;
                    case "EMR":
                        authorizedRoles += ", EMR.Writer";
                        break;
                    case "ENV":
                        authorizedRoles += ", ENV.Writer";
                        break;
                    case "ECO":
                        authorizedRoles += ", ECO.Writer";
                        break;
                    case "FIN":
                        authorizedRoles += ", FIN.Writer";
                        break;
                    case "HSS":
                        authorizedRoles += ", HSS.Writer";
                        break;
                    case "HPW":
                        authorizedRoles += ", HPW.Writer";
                        break;
                    case "JUS":
                        authorizedRoles += ", JUS.Writer";
                        break;
                    case "PSC":
                        authorizedRoles += ", PSC.Writer";
                        break;
                    case "TC":
                        authorizedRoles += ", TC.Writer";
                        break;
                    case "YDC":
                        authorizedRoles += ", YDC.Writer";
                        break;
                    case "YEC":
                        authorizedRoles += ", YEC.Writer";
                        break;
                    case "YHC":
                        authorizedRoles += ", YHC.Writer";
                        break;
                    default:
                        break;
                }
            }
            return authorizedRoles;
        }

        private async Task GetUserPrincipal()
        {
            var authState = await AuthenticationStateTask;
            user = authState.User;
        }

        private void GetSelectedParentType()
        {
            if (Indicator.Goal is not null) {
                SelectedParentType = "Goal";
            }
            else if (Indicator.Objective is not null) {
                SelectedParentType = "Objective";
            }
            else if (Indicator.Action is not null) {
                SelectedParentType = "Action";
            }
        }

        private async Task Update()
        {
            switch (SelectedParentType) {
                case "Goal":
                    Indicator.Objective = null;
                    Indicator.Action = null;
                    break;
                case "Objective":
                    Indicator.Goal = null;
                    Indicator.Action = null;
                    break;
                case "Action":
                    Indicator.Goal = null;
                    Indicator.Objective = null;
                    break;
                default:
                    Indicator.Goal = null;
                    Indicator.Objective = null;
                    Indicator.Action = null;
                    break;
            }

            Indicator.Leads.Clear();
            foreach (var lead in SelectedLeads) {
                Indicator.Leads.Add(lead);
            }

            // Don't update Indicator.UpdatedBy if only the Entries were modified.
            if (context.Entry(Indicator).State == EntityState.Modified
                || context.Entry(Target).State == EntityState.Added
                || context.Entry(Target).State == EntityState.Modified
                || context.Entry(Target).State == EntityState.Deleted) {
                Indicator.UpdatedBy = user.FindFirst("name")?.Value ?? "";
            }

            await context.SaveChangesAsync();
            Snackbar.Add($"Successfully updated indicator: {Indicator.Title}", Severity.Success);
            Navigation.NavigateTo($"/indicators/details/{Id}");
        }

        private void CreateTarget()
        {
            Indicator.Target = new Target();
            Target = Indicator.Target;
        }

        private void DeleteTarget()
        {
            Indicator.Target = null;
            context.Entry(Target).State = EntityState.Deleted;
        }

        private async Task CreateEntry()
        {
            var parameters = new DialogParameters { ["Indicator"] = Indicator };

            var dialog = DialogService.Show<CreateEntryDialog>("Add entry", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled) {
                var newEntry = (Entry)result.Data;
                newEntry.UpdatedBy = user.FindFirst("name")?.Value ?? "";
                Indicator.Entries.Add(newEntry);
                Snackbar.Add($"Click submit to confirm adding entry dated {newEntry.Date.ToLongDateString()}", Severity.Info);
            }
        }

        private async Task EditEntry(Entry entry)
        {
            var parameters = new DialogParameters { ["Indicator"] = Indicator, ["Entry"] = entry };

            var dialog = DialogService.Show<EditEntryDialog>("Edit entry", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled) {
                var editedEntry = (Entry)result.Data;
                editedEntry.UpdatedBy = user.FindFirst("name")?.Value ?? "";
                Snackbar.Add($"Click submit to confirm update of entry dated {editedEntry.Date.ToLongDateString()}", Severity.Info);
            }
        }

        private async Task DeleteEntry(Entry entry)
        {
            bool? result = await DialogService.ShowMessageBox(
                $"Delete entry dated {entry.Date.ToLongDateString()}?",
                "",
                yesText: "Delete", cancelText: "Cancel");
            if (result == true) {
                Indicator.Entries.Remove(entry);
                Snackbar.Add($"Click submit to confirm deletion of entry dated {entry.Date.ToLongDateString()}", Severity.Info);
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
