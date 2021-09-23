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

namespace OurCleanFuture.App.Pages.Indicators
{
    public partial class Edit : IDisposable
    {
        private bool _isLoaded;
        private AppDbContext _context = null!;

        [Parameter]
        public int Id { get; set; }

        public string SelectedParentType { get; set; } = "";
        public HashSet<Lead> SelectedLeads { get; set; } = new();


        public List<Lead> Leads { get; set; } = new();
        public List<UnitOfMeasurement> UnitsOfMeasurement { get; set; } = new();
        public List<Goal> Goals { get; set; } = new();
        public List<Objective> Objectives { get; set; } = new();
        public List<Action> Actions { get; set; } = new();
        public Indicator Indicator { get; set; } = null!;
        public Target Target { get; set; } = null!;

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
                _context = ContextFactory.CreateDbContext();
                Leads = await _context.Leads.Include(l => l.Organization).Include(l => l.Branch).ThenInclude(b => b!.Department).OrderBy(l => l.Branch!.Name).ToListAsync();
                UnitsOfMeasurement = await _context.UnitsOfMeasurement.ToListAsync();
                Goals = await _context.Goals.OrderBy(g => g.Title).ToListAsync();
                Objectives = await _context.Objectives.Include(o => o.Area).OrderBy(o => o.Area.Title).ThenBy(o => o.Title).ToListAsync();
                Actions = await _context.Actions.ToListAsync();
#pragma warning disable CS8601 // Possible null reference assignment.
                Indicator = await _context.Indicators.Include(i => i.Target).Include(i => i.Leads).FirstOrDefaultAsync(i => i.Id == Id);
#pragma warning restore CS8601 // Possible null reference assignment.
                foreach (var lead in Indicator.Leads) {
                    SelectedLeads.Add(lead);
                }
                GetSelectedParentType();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                _isLoaded = true;
            }

            await base.OnInitializedAsync();
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

            await _context.SaveChangesAsync();
            Snackbar.Add($"Successfully updated indicator: {Indicator.Title}", Severity.Success);
            Navigation.NavigateTo($"/indicators/details/{Id}");
        }

        private void CreateTarget()
        {
            Indicator.Target = new Target();
        }

        private void DeleteTarget()
        {
            Indicator.Target = null;
        }

        private async Task CreateEntry()
        {
            var parameters = new DialogParameters { ["Indicator"] = Indicator };

            var dialog = DialogService.Show<CreateEntryDialog>("Add entry", parameters);
            var result = await dialog.Result;

            if (!result.Cancelled) {
                Indicator.Entries.Add((Entry)result.Data);
            }
        }

        private async Task EditEntry(Entry entry)
        {
            var parameters = new DialogParameters { ["Indicator"] = Indicator, ["Entry"] = entry };

            var dialog = DialogService.Show<EditEntryDialog>("Edit entry", parameters);
            _ = await dialog.Result;
        }

        private async Task DeleteEntry(Entry entry)
        {
            bool? result = await DialogService.ShowMessageBox(
                $"Delete entry dated {entry.Date.ToLongDateString()}?",
                "",
                yesText: "Delete", cancelText: "Cancel");
            if (result == true) {
                Indicator.Entries.Remove(entry);
                Snackbar.Add($"Deleted entry dated {entry.Date.ToLongDateString()}", Severity.Success);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
