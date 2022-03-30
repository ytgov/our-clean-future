using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Indicators;

public partial class Details : IDisposable
{
    private bool _isLoaded;
    private AppDbContext _context = null!;

    [Parameter]
    public int Id { get; set; }

    private Indicator Indicator { get; set; } = null!;

    private string IndicatorLastUpdatedBy { get; set; } = "";

    [Inject]
    private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject]
    private NavigationManager Navigation { get; set; } = null!;

    [Inject]
    private StateContainer StateContainer { get; init; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _context = ContextFactory.CreateDbContext();
            Indicator = await _context.Indicators
                .Include(i => i.Target)
                .Include(i => i.UnitOfMeasurement)
                .Include(i => i.Leads)
                .ThenInclude(l => l.Branch)
                .ThenInclude(b => b!.Department)
                .Include(i => i.Leads)
                .ThenInclude(l => l.Organization)
                .Include(i => i.Goal)
                .Include(i => i.Objective)
                .ThenInclude(o => o!.Goals)
                .Include(i => i.Objective)
                .ThenInclude(o => o!.Area)
                .Include(i => i.Action)
                .ThenInclude(a => a!.Objective)
                .ThenInclude(o => o.Area)
                .Include(i => i.Action)
                .ThenInclude(a => a!.Objective)
                .ThenInclude(o => o.Goals)
                .AsSingleQuery()
                .FirstAsync(i => i.Id == Id);
            IndicatorLastUpdatedBy = await GetIndicatorLastUpdatedBy();
        }
        catch (Exception ex)
        {
            Log.Error("{Exception}", ex);
            throw;
        }
        finally
        {
            _isLoaded = true;
        }
        Log.Information("{User} is viewing indicator {IndicatorId}: {IndicatorTitle}", StateContainer.ClaimsPrincipalEmail, Indicator.Id, Indicator.Title);

        await base.OnInitializedAsync();
    }

    private async Task<string> GetIndicatorLastUpdatedBy()
    {
        if (!string.IsNullOrWhiteSpace(Indicator.UpdatedBy))
        {
            return $"{Indicator.UpdatedBy} on {(await GetIndicatorLastUpdatedDate()).ToLocalTime():f}";
        }
        else
        {
            return string.Empty;
        }

        async Task<DateTime> GetIndicatorLastUpdatedDate()
        {
            var targetUpdated = DateTime.MinValue;
            if (Indicator?.Target != null)
            {
                targetUpdated = _context.Entry(Indicator.Target).Property<DateTime>("ValidFrom").CurrentValue;
            }
            else
            {
                targetUpdated = await _context.Targets
                    .TemporalAll()
                    .Where(t => t.IndicatorId == Indicator!.Id)
                    .OrderBy(t => EF.Property<DateTime>(t, "ValidTo"))
                    .Select(t => EF.Property<DateTime>(t, "ValidTo"))
                    .LastOrDefaultAsync();
            }
            var indicatorUpdated = _context.Entry(Indicator!).Property<DateTime>("ValidFrom").CurrentValue;
            //An indicator might not have a target, in which case we return the indicatorUpdatedDate
            return indicatorUpdated > targetUpdated ? indicatorUpdated : targetUpdated;
        }
    }

    private DateTime GetEntryLastUpdatedDate(Entry entry)
    {
        return _context.Entry(entry).Property<DateTime>("ValidFrom").CurrentValue;
    }

    private void Edit()
    {
        Navigation.NavigateTo("/indicators/edit/" + Indicator.Id);
    }

    private void ViewAction(Action action)
    {
        Navigation.NavigateTo("/actions/details/" + action.Id);
    }

    private void ViewArea(Area area)
    {
        Navigation.NavigateTo("/areas/" + area.Title.ToLower().Replace(' ', '-'));
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
