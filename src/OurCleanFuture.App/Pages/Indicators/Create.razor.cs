using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.App.Pages.Indicators;

public partial class Create : IDisposable
{
    private bool isLoaded;
    private AppDbContext context = null!;

    public List<Lead> Leads { get; set; } = new();

    private readonly CollectionInterval[] collectionIntervals = (CollectionInterval[])Enum.GetValues(typeof(CollectionInterval));

    [Inject]
    public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try {
            context = ContextFactory.CreateDbContext();
            Leads = await context.Leads.Include(l => l.Organization).Include(l => l.Branch).ThenInclude(b => b!.Department).OrderBy(l => l.Branch!.Name).ToListAsync();
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
        }
        finally {
            isLoaded = true;
        }

        await base.OnInitializedAsync();
    }

    private Task<IEnumerable<CollectionInterval>> SearchCollectionIntervals(string value)
    {
        return Task.FromResult(collectionIntervals.Where(p => p.ToString().StartsWith(value, StringComparison.InvariantCultureIgnoreCase)));
    }

    public void Dispose()
    {
        context.DisposeAsync();
    }
}
