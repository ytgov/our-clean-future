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
using OurCleanFuture.App;
using OurCleanFuture.App.Shared;
using MudBlazor;
using OurCleanFuture.Data;
using Microsoft.EntityFrameworkCore;
using OurCleanFuture.Data.Entities;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Indicators
{
    public partial class Details
    {
        public List<ChartSeries> Series = new();
        public ChartOptions Options = new();
        public string[] XAxisLabels = { "2019", "2020", "2021", "2022", "2023", "2024" };
        private bool _isLoaded;
        private AppDbContext _context = null!;
        private Target _target = null!;

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
                    .Include(i => i.Leads)
                    .ThenInclude(l => l.Branch)
                    .ThenInclude(b => b!.Department)
                    .Include(i => i.Leads)
                    .ThenInclude(l => l.Organization)
                    .Include(i => i.Goal)
                    .Include(i => i.Objective)
                    .ThenInclude(o => o!.Goals)
                    .Include(i => i.Objective)
                    .ThenInclude(o => o!.Area)
                    .Include(i => i.Action)
                    .ThenInclude(a => a!.Objective)
                    .ThenInclude(o => o.Area)
                    .Include(i => i.Action)
                    .ThenInclude(a => a!.Objective)
                    .ThenInclude(o => o.Goals)
                    //.AsNoTracking()
                    .AsSingleQuery()
                    .FirstOrDefaultAsync(i => i.Id == Id);
                _target = Indicator.Target;
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

        private DateTime GetLastUpdatedDate()
        {
            var indicatorUpdatedDate = _context.Entry(Indicator).Property<DateTime>("PeriodStart").CurrentValue;
            //An indicator might not have a target, in which case we return the indicatorUpdatedDate
            var targetUpdatedDate = DateTime.MinValue;
            if(_target is not null) {
                targetUpdatedDate = _context.Entry(_target).Property<DateTime>("PeriodStart").CurrentValue;
            }
            return indicatorUpdatedDate > targetUpdatedDate ? indicatorUpdatedDate : targetUpdatedDate;
        }

        private void Edit()
        {
            Navigation.NavigateTo("/indicators/edit/" + Indicator.Id);
        }

        private void ViewAction(Action action)
        {
            Navigation.NavigateTo("/actions/details/" + action.Id);
        }
    }
}