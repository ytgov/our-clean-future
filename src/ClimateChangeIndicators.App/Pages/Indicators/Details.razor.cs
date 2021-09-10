using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using ClimateChangeIndicators.App;
using ClimateChangeIndicators.App.Shared;
using MudBlazor;
using ClimateChangeIndicators.Data;
using Microsoft.EntityFrameworkCore;
using ClimateChangeIndicators.Data.Entities;

namespace ClimateChangeIndicators.App.Pages.Indicators
{
    public partial class Details
    {
        public List<ChartSeries> Series = new List<ChartSeries>();
        public ChartOptions Options = new ChartOptions();
        public string[] XAxisLabels = { "2019", "2020", "2021", "2022", "2023", "2024" };
        private bool _isLoaded;
        private AppDbContext _context = null!;

        [Parameter]
        public int Id { get; set; }

        public Indicator Indicator { get; set; } = null!;

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public NavigationManager Navigation { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try {
                _context = ContextFactory.CreateDbContext();
#pragma warning disable CS8601 // Possible null reference assignment.
                Indicator = await _context.Indicators
                    .Include(i => i.Target)
                    .Include(i => i.UnitOfMeasurement)
                    .Include(i => i.Owner)
                    .ThenInclude(o => o.Branch)
                    .ThenInclude(b => b!.Department)
                    .Include(i => i.Owner)
                    .ThenInclude(o => o.Organization)
                    .Include(i => i.Goal)
                    .Include(i => i.Objective)
                    .ThenInclude(o => o!.Goals)
                    .Include(i => i.Objective)
                    .ThenInclude(i => i!.Area)
                    .Include(i => i.Action)
                    .ThenInclude(a => a!.Objective)
                    .ThenInclude(o => o.Area)
                    .Include(i => i.Action)
                    .ThenInclude(a => a!.Objective)
                    .ThenInclude(o => o.Goals)
                    .AsNoTracking()
                    .AsSingleQuery()
                    .FirstOrDefaultAsync(i => i.Id == Id);
#pragma warning restore CS8601 // Possible null reference assignment.
                double[] Data1 = { 26, 42, 49, 72 };
                Series.Add(new ChartSeries() { Name = $"{Indicator?.Title} ({Indicator?.UnitOfMeasurement})", Data = Data1 });
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                _isLoaded = true;
            }

            await base.OnInitializedAsync();
        }
    }
}