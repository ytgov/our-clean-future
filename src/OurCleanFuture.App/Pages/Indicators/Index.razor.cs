using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace OurCleanFuture.App.Pages.Indicators
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
        private MudBlazor.MudSwitch<bool> ViewInactiveIndicators = null!;

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public NavigationManager Navigation { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try {
                _context = ContextFactory.CreateDbContext();
                _indicators = await _context.Indicators
                .Include(i => i.Action)
                .Include(i => i.Owner)
                .ThenInclude(o => o.Organization)
                .Include(i => i.Owner)
                .ThenInclude(o => o.Branch)
                .ThenInclude(b => b!.Department)
                .AsNoTracking()
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