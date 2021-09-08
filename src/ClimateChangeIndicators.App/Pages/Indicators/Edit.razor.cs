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


        public List<Owner> Owners { get; set; } = new();
        public List<UnitOfMeasurement> UnitsOfMeasurement { get; set; } = new();
        public List<Data.Entities.Action> Actions { get; set; } = new();
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
                Actions = await _context.Actions.ToListAsync();
                Indicator = await _context.Indicators.Include(i => i.Target).FirstOrDefaultAsync(i => i.Id == Id);
                double[] Data1 = { 26, 42, 49, 72 };
                Series.Add(new ChartSeries() { Name = $"{Indicator.Title} ({Indicator.UnitOfMeasurement})", Data = Data1});
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                _isLoaded = true;
            }

            await base.OnInitializedAsync();
        }

        private async Task Update()
        {
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
