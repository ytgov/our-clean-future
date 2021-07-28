using AutoMapper;
using ClimateChangeIndicators.App.ViewModels;
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
        private AppDbContext _context = null!;
        private List<IndicatorIndexViewModel> _indicators = null!;
        private string _searchString = "";
        private IndicatorIndexViewModel _selectedItem = null!;

        private Random _rand = new();

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public NavigationManager Navigation { get; set; } = null!;

        [Inject]
        public IMapper Mapper { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try {
                _context = ContextFactory.CreateDbContext();
                var result = await _context.Indicators
                    .Include(i => i.OurCleanFutureReference)
                    .Include(i => i.Owner)
                    .ThenInclude(o => o.Organization)
                    .Include(i => i.Owner)
                    .ThenInclude(o => o.Branch)
                    .ThenInclude(b => b!.Department)
                    .AsSingleQuery()
                    .ToListAsync();

                _indicators = Mapper.Map<List<IndicatorIndexViewModel>>(result);
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

        private void Create()
        {
            Navigation.NavigateTo("/indicators/create/");
        }

        private void Details(int indicatorId)
        {
            Navigation.NavigateTo("/indicators/details/" + indicatorId);
        }

        private bool FilterFunc(IndicatorIndexViewModel indicator)
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;
            if (indicator.Organization.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (indicator.Department?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
                return true;
            if (indicator.Branch?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
                return true;
            if (indicator.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}