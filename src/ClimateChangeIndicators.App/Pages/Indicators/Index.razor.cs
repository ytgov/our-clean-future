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
        private Indicator _selectedItem;

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try {
                _context = ContextFactory.CreateDbContext();
                _indicators = await _context.Indicators.AsSingleQuery().ToListAsync();
            }
            finally {
                _isLoaded = true;
            }

            await base.OnInitializedAsync();
        }

        protected override bool ShouldRender() => _mayRender;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}