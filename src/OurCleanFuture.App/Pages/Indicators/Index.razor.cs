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
        private bool isLoaded;
        private bool mayRender = true;
        private AppDbContext context = null!;
        private List<Indicator> indicators = null!;
        private string searchString = "";
        private Indicator selectedItem = null!;

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public NavigationManager Navigation { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try {
                context = ContextFactory.CreateDbContext();
                indicators = await context.Indicators
                .Include(i => i.Action)
                .Include(i => i.Leads)
                .ThenInclude(l => l.Organization)
                .Include(i => i.Leads)
                .ThenInclude(l => l.Branch)
                .ThenInclude(b => b!.Department)
                .AsNoTracking()
                .AsSingleQuery()
                .ToListAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                isLoaded = true;
            }

            await base.OnInitializedAsync();
        }

        protected override bool ShouldRender() => mayRender;

        private static DateTime? GetDateLastEntry(Indicator indicator)
        {
            return indicator.Entries.OrderByDescending(e => e.Date).FirstOrDefault()?.Date;
        }

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
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            foreach(var lead in indicator.Leads) {
                if (lead.Organization.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    return true;
                if (lead.Branch?.Department.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                    return true;
                if (lead.Branch?.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                    return true;
            }
            if (indicator.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}