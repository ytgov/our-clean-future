using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using System.Security.Claims;
using OurCleanFuture.App.Extensions;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Indicators;

public partial class Edit : IDisposable
{
    private bool isLoaded;
    private AppDbContext context = null!;
    private ClaimsPrincipal user = null!;
    private bool targetIsDeleted = false;

    private int[] Years { get; } = Enumerable.Range(2009, (DateTime.Now.Year - 2008)).Reverse().ToArray();

    [Parameter]
    public int Id { get; set; }

    private string AuthorizedRoles { get; set; } = "Administrator, ENV-CCS.Writer";
    private string SelectedParentType { get; set; } = "";
    private IEnumerable<Lead> SelectedLeads { get; set; } = new List<Lead>();

    private List<Lead> Leads { get; set; } = new();
    private List<UnitOfMeasurement> UnitsOfMeasurement { get; set; } = new();
    private List<Goal> Goals { get; set; } = new();
    private List<Objective> Objectives { get; set; } = new();
    private List<Action> Actions { get; set; } = new();
    private Indicator Indicator { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

    [Inject]
    private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject]
    private IDialogService DialogService { get; set; } = null!;

    [Inject]
    private NavigationManager Navigation { get; set; } = null!;

    [Inject]
    private ISnackbar Snackbar { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try {
            context = ContextFactory.CreateDbContext();
            Leads = await context.Leads.Include(l => l.Organization).Include(l => l.Branch).ThenInclude(b => b!.Department).OrderBy(l => l.Branch!.Department.ShortName).ThenBy(l => l.Branch!.Name).ToListAsync();
            UnitsOfMeasurement = await context.UnitsOfMeasurement.ToListAsync();
            Goals = await context.Goals.OrderBy(g => g.Title).ToListAsync();
            Objectives = await context.Objectives.Include(o => o.Area).OrderBy(o => o.Area.Title).ThenBy(o => o.Title).ToListAsync();
            Actions = await context.Actions.ToListAsync();
#pragma warning disable CS8601 // Possible null reference assignment.
            Indicator = await context.Indicators.Include(i => i.Target).Include(i => i.Leads).FirstOrDefaultAsync(i => i.Id == Id);
#pragma warning restore CS8601 // Possible null reference assignment.
            if (Indicator != null) {
                foreach (var lead in Indicator.Leads) {
                    SelectedLeads = SelectedLeads.Append(lead);
                }
                GetSelectedParentType();
                await GetUserPrincipal();
                AuthorizedRoles += GetAuthorizedRoles();
            }
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
        try {
            if (context.Entry(Indicator).State == EntityState.Modified) {
                Indicator.UpdatedBy = user.GetFormattedName();
            }
            else if (Indicator.Target is not null) {
                Console.WriteLine($"Indicator.Target state is: {context.Entry(Indicator.Target).State}");
                if (context.Entry(Indicator.Target).State == EntityState.Added
                || context.Entry(Indicator.Target).State == EntityState.Modified) {
                    Indicator.UpdatedBy = user.GetFormattedName();
                }
            }
            else if (targetIsDeleted) {
                Indicator.UpdatedBy = user.GetFormattedName();
            }

            await context.SaveChangesAsync();
            Snackbar.Add($"Successfully updated indicator: {Indicator.Title}", Severity.Success);
        }
        catch (Exception ex) {
            switch (ex) {
                case InvalidOperationException:
                    Snackbar.Add("The entry changes were not saved. Two entries cannot have the same period.", Severity.Error);
                    break;

                case DbUpdateException:
                    Snackbar.Add(ex.Message, Severity.Error);
                    break;

                default:
                    throw;
            }
        }
        Navigation.NavigateTo($"/indicators/details/{Id}");
    }

    private void CreateTarget()
    {
        Indicator.Target = new Target();
        context.Attach(Indicator.Target);
    }

    private void DeleteTarget()
    {
        // This flag is used by the Update() method instead of checking EntityState, as we cannot check the EntityState of a null reference (Indicator.Target).
        targetIsDeleted = true;
        Indicator.Target = null;
        StateHasChanged();
    }

    private async Task CreateEntry()
    {
        var parameters = new DialogParameters { ["Indicator"] = Indicator, ["Years"] = Years };

        var dialog = DialogService.Show<CreateEntryDialog>("Add entry", parameters);
        var result = await dialog.Result;

        if (!result.Cancelled) {
            var newEntry = (Entry)result.Data;
            newEntry.UpdatedBy = user.GetFormattedName();
            Indicator.Entries.Add(newEntry);
            Snackbar.Add($"Click submit to confirm adding entry dated {newEntry.StartDate.ToLongDateString()}", Severity.Info);
        }
    }

    private async Task EditEntry(Entry entry)
    {
        var parameters = new DialogParameters { ["Indicator"] = Indicator, ["Entry"] = entry, ["Years"] = Years };

        var dialog = DialogService.Show<EditEntryDialog>("Edit entry", parameters);
        var result = await dialog.Result;

        if (!result.Cancelled) {
            var editedEntry = (Entry)result.Data;
            editedEntry.UpdatedBy = user.GetFormattedName();
            Snackbar.Add($"Click submit to confirm update of entry dated {editedEntry.StartDate.ToLongDateString()}", Severity.Info);
        }
    }

    private async Task DeleteEntry(Entry entry)
    {
        bool? result = await DialogService.ShowMessageBox(
            $"Delete entry dated {entry.StartDate.ToLongDateString()}?",
            "",
            yesText: "Delete", cancelText: "Cancel");
        if (result == true) {
            Indicator.Entries.Remove(entry);
            Snackbar.Add($"Click submit to confirm deletion of entry dated {entry.StartDate.ToLongDateString()}", Severity.Info);
        }
    }

    public void Dispose()
    {
        context.Dispose();
    }
}