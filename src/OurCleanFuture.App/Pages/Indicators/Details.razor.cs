using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using OurCleanFuture.App.Services;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Indicators;

public partial class Details : IDisposable
{
    private AppDbContext _context = null!;
    private bool _isLoaded;

    [Parameter]
    public int Id { get; set; }

    private Indicator? Indicator { get; set; }

    private string IndicatorLastUpdatedBy { get; set; } = "";

    [Inject]
    private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject]
    private NavigationManager Navigation { get; set; } = null!;

    [Inject]
    private StateContainerService StateContainer { get; init; } = null!;

    [Inject]
    private IDialogService DialogService { get; set; } = null!;

    [Inject]
    private ISnackbar Snackbar { get; set; } = null!;

    public void Dispose() => _context.Dispose();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _context = await ContextFactory.CreateDbContextAsync();
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
                .FirstOrDefaultAsync(i => i.Id == Id);
            if (Indicator is not null)
            {
                IndicatorLastUpdatedBy = await GetIndicatorLastUpdatedBy();
                Log.Information(
                    "{User} is viewing indicator {IndicatorId}: {IndicatorTitle}",
                    StateContainer.ClaimsPrincipalEmail,
                    Indicator.Id,
                    Indicator.Title
                );
            }
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

        await base.OnInitializedAsync();
    }

    private async Task<string> GetIndicatorLastUpdatedBy()
    {
        if (!string.IsNullOrWhiteSpace(Indicator!.UpdatedBy))
        {
            return $"{Indicator.UpdatedBy} on {(await GetIndicatorLastUpdatedDate()).ToLocalTime():f}";
        }

        return string.Empty;

        async Task<DateTime> GetIndicatorLastUpdatedDate()
        {
            DateTime targetUpdated;
            if (Indicator?.Target != null)
            {
                targetUpdated = _context
                    .Entry(Indicator.Target)
                    .Property<DateTime>("ValidFrom")
                    .CurrentValue;
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

            var indicatorUpdated = _context
                .Entry(Indicator!)
                .Property<DateTime>("ValidFrom")
                .CurrentValue;
            //An indicator might not have a target, in which case we return the indicatorUpdatedDate
            return indicatorUpdated > targetUpdated ? indicatorUpdated : targetUpdated;
        }
    }

    private DateTime GetEntryLastUpdatedDate(Entry entry) =>
        _context.Entry(entry).Property<DateTime>("ValidFrom").CurrentValue;

    private void Edit() => Navigation.NavigateTo("/indicators/edit/" + Indicator!.Id);

    private async Task Delete()
    {
        if (Indicator is null)
            return;
        var parameters = new DialogParameters
        {
            [nameof(DeleteIndicatorDialog.Title)] = Indicator.Title
        };

        var dialog = DialogService.Show<DeleteIndicatorDialog>("", parameters);
        var result = await dialog.Result;
        if (!result.Canceled)
        {
            try
            {
                _context.Indicators.Remove(Indicator);
                await _context.SaveChangesAsync();
                Snackbar.Add($"Deleted indicator {Indicator.Title}", Severity.Success);
                Log.Information(
                    "{User} deleted indicator {IndicatorId}: {IndicatorTitle}",
                    StateContainer.ClaimsPrincipalEmail,
                    Indicator.Id,
                    Indicator.Title
                );
                Indicator = null;
                Navigation.NavigateTo("/indicators");
            }
            catch (DbUpdateException)
            {
                Snackbar.Add("Unable to delete indicator.", Severity.Error);
            }
        }
    }

    private void ViewAction(Action action) =>
        Navigation.NavigateTo("/actions/details/" + action.Id);

    private void ViewArea(Area area) =>
        Navigation.NavigateTo("/areas/" + area.Title.ToLower().Replace(' ', '-'));
}
