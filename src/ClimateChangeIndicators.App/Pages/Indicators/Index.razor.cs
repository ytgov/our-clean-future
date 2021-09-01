using ClimateChangeIndicators.Data;
using ClimateChangeIndicators.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace ClimateChangeIndicators.App.Pages.Indicators
{
    public partial class Index : IDisposable
    {
        private bool _isLoaded;
        private bool _mayRender = true;
        private AppDbContext _context = null!;
        private List<Indicator> _indicators = null!;
        private string _searchString = "";
        private Indicator _selectedItem = null!;
        private Random _rand = new();
        private MudBlazor.MudSwitch<bool> ShowInactiveIndicators = null!;

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public NavigationManager Navigation { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try {
                _context = ContextFactory.CreateDbContext();
                _indicators = await _context.Indicators
                .Where(i => i.IsActive)
                .Include(i => i.Action)
                .Include(i => i.Owner)
                .ThenInclude(o => o.Organization)
                .Include(i => i.Owner)
                .ThenInclude(o => o.Branch)
                .ThenInclude(b => b!.Department)
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

        private void Create()
        {
            Navigation.NavigateTo("/indicators/create/");
        }

        private void Details(int indicatorId)
        {
            Navigation.NavigateTo("/indicators/details/" + indicatorId);
        }

        private void Edit(int indicatorId)
        {
            Navigation.NavigateTo("/indicators/edit/" + indicatorId);
        }

        private async void ToggleInactiveIndicators()
        {
            if (ShowInactiveIndicators.Checked) {
                _indicators = await _context.Indicators
                    .Include(i => i.Action)
                    .Include(i => i.Owner)
                    .ThenInclude(o => o.Organization)
                    .Include(i => i.Owner)
                    .ThenInclude(o => o.Branch)
                    .ThenInclude(b => b!.Department)
                    .AsSingleQuery()
                    .ToListAsync();
                StateHasChanged();
            }
            else {
                _indicators = await _context.Indicators
                   .Where(i => i.IsActive)
                   .Include(i => i.Action)
                   .Include(i => i.Owner)
                   .ThenInclude(o => o.Organization)
                   .Include(i => i.Owner)
                   .ThenInclude(o => o.Branch)
                   .ThenInclude(b => b!.Department)
                   .AsSingleQuery()
                   .ToListAsync();
                StateHasChanged();
            }
        }

        private bool FilterFunc(Indicator indicator)
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;
            if (indicator.Owner.Organization.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (indicator.Owner.Branch?.Department.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
                return true;
            if (indicator.Owner.Branch?.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
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