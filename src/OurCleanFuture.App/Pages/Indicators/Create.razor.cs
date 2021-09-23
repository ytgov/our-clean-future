using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.App.Pages.Indicators
{
    public partial class Create
    {
        private bool _isLoaded;
        private AppDbContext _context = null!;

        public List<Lead> Leads { get; set; } = new();

        private readonly CollectionInterval[] _collectionIntervals = (CollectionInterval[])Enum.GetValues(typeof(CollectionInterval));

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try {
                _context = ContextFactory.CreateDbContext();
                Leads = await _context.Leads.Include(o => o.Organization).Include(o => o.Branch).ThenInclude(b => b!.Department).OrderBy(o => o.Branch!.Name).ToListAsync();
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

    }
}