using ClimateChangeIndicators.Data;
using ClimateChangeIndicators.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeIndicators.App.Pages.Indicators
{
    public partial class Index : IDisposable
    {
        private bool _bordered;
        private bool _dense = true;
        private bool _hover = true;
        private bool _striped = true;
        private bool _isLoaded;
        private bool _mayRender = true;
        private AppDbContext _context;
        private List<Indicator> _indicators;
        private string _searchString = "";
        private Indicator _selectedItem;

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try {
                _context = ContextFactory.CreateDbContext();
                _indicators = await _context.Indicators
                    .Include(i => i.OurCleanFutureReference)
                    .Include(i => i.Owner)
                    .ThenInclude(o => o.Organization)
                    .Include(i => i.Owner)
                    .ThenInclude(o => o.Branch)
                    .ThenInclude(b => b.Department)
                    .AsSingleQuery()
                    .ToListAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                _isLoaded = true;
            }

            await base.OnInitializedAsync();
        }

        protected override bool ShouldRender() => _mayRender;

        private bool FilterFunc(Indicator indicator)
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;
            if (indicator.Owner.Organization.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (indicator.Owner.Branch.Department.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (indicator.Owner.Branch.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}