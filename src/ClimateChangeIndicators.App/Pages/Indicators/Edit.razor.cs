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
    public partial class Edit
    {
        private bool _isLoaded;
        private AppDbContext _context = null!;

        [Parameter]
        public int Id { get; set; }

        public List<Owner> Owners { get; set; } = new();
        public List<UnitOfMeasurement> UnitsOfMeasurement { get; set; }
        public List<OurCleanFutureReference> OurCleanFutureReferences { get; set; }
        public Indicator _indicator { get; set; }

        private readonly CollectionInterval[] _collectionIntervals = (CollectionInterval[])Enum.GetValues(typeof(CollectionInterval));

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public NavigationManager Navigation { get; set; }

        [Inject]
        public ISnackbar Snackbar { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try {
                _context = ContextFactory.CreateDbContext();
                Owners = await _context.Owners.Include(o => o.Organization).Include(o => o.Branch).ThenInclude(b => b!.Department).OrderBy(o => o.Branch!.Name).ToListAsync();
                UnitsOfMeasurement = await _context.UnitsOfMeasurement.ToListAsync();
                OurCleanFutureReferences = await _context.OurCleanFutureReferences.ToListAsync();
                _indicator = await _context.Indicators.FindAsync(Id);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                _isLoaded = true;
            }

            await base.OnInitializedAsync();
        }

        private Task<IEnumerable<CollectionInterval>> SearchCollectionIntervals(string value)
        {
            return Task.FromResult(_collectionIntervals.Where(p => p.ToString().StartsWith(value, StringComparison.InvariantCultureIgnoreCase)));
        }

        private async Task Update()
        {
            await _context.SaveChangesAsync();
            //Navigation.NavigateTo($"/indicators/details/{_indicator.Id}");
            Snackbar.Add($"Successfully updated indicator: {_indicator.Title}", Severity.Success);
            Navigation.NavigateTo($"/indicators");
        }
    }
}
