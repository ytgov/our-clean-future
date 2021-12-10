using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Pages.Indicators;

public partial class Create : IDisposable
{
    private bool isLoaded;
    private AppDbContext context = null!;

    private List<Lead> Leads { get; set; } = new();

    private readonly CollectionInterval[] collectionIntervals = (CollectionInterval[])Enum.GetValues(typeof(CollectionInterval));

    [Inject]
    private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

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
        context.Dispose();
    }
}