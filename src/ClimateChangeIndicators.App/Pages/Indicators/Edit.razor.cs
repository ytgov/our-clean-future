using ClimateChangeIndicators.Data;
using ClimateChangeIndicators.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = ClimateChangeIndicators.Data.Entities.Action;

namespace ClimateChangeIndicators.App.Pages.Indicators
{
    public partial class Edit : IDisposable
    {
        public List<ChartSeries> Series = new List<ChartSeries>();
        public ChartOptions Options = new ChartOptions();
        public string[] XAxisLabels = { "2019", "2020", "2021", "2022", "2023", "2024" };

        private bool _isLoaded;
        private AppDbContext _context = null!;

        [Parameter]
        public int Id { get; set; }

        public string SelectedParentType { get; set; } = "";

        public List<Owner> Owners { get; set; } = new();
        public List<UnitOfMeasurement> UnitsOfMeasurement { get; set; } = new();
        public List<Goal> Goals { get; set; } = new();
        public List<Objective> Objectives { get; set; } = new();
        public List<Action> Actions { get; set; } = new();
        public Indicator Indicator { get; set; } = null!;
        public Target Target { get; set; } = null!;

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public NavigationManager Navigation { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try {
                _context = ContextFactory.CreateDbContext();
                Owners = await _context.Owners.Include(o => o.Organization).Include(o => o.Branch).ThenInclude(b => b!.Department).OrderBy(o => o.Branch!.Name).ToListAsync();
                UnitsOfMeasurement = await _context.UnitsOfMeasurement.ToListAsync();
                Goals = await _context.Goals.OrderBy(g => g.Title).ToListAsync();
                Objectives = await _context.Objectives.OrderBy(o => o.Title).ToListAsync();
                Actions = await _context.Actions.ToListAsync();
                Indicator = await _context.Indicators.Include(i => i.Target).FirstOrDefaultAsync(i => i.Id == Id);
                GetSelectedParentType();
                double[] Data1 = { 26, 42, 49, 72 };
                Series.Add(new ChartSeries() { Name = $"{Indicator.Title} ({Indicator.UnitOfMeasurement})", Data = Data1 });
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
            if (SelectedParentType == "Goal") {
                Indicator.Objective = null;
                Indicator.Action = null;
            }
            else if (SelectedParentType == "Objective") {
                Indicator.Goal = null;
                Indicator.Action = null;
            }
            else if (SelectedParentType == "Action") {
                Indicator.Goal = null;
                Indicator.Objective = null;
            } else {
                Indicator.Goal = null;
                Indicator.Objective = null;
                Indicator.Action = null;
            }
            await _context.SaveChangesAsync();
            //Navigation.NavigateTo($"/indicators/details/{_indicator.Id}");
            Snackbar.Add($"Successfully updated indicator: {Indicator.Title}", Severity.Success);
            Navigation.NavigateTo($"/indicators");
        }

        private void CreateTarget()
        {
            Indicator.Target = new Target();
        }

        private void DeleteTarget()
        {
            Indicator.Target = null;
        }

        private void CreateEntry()
        {
            Indicator.Entries.Add(new Entry());
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
