using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using MudBlazor;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Pages.Indicators;

public partial class Index : IDisposable
{
    private bool isLoaded;
    private AppDbContext context = null!;

    private List<Indicator> indicators = new();
    private List<Indicator> filteredIndicators = new();
    private MudSwitch<bool> filterIndicatorsSwitch = null!;

    private Indicator selectedItem = null!;
    private string searchString = "";

    [Inject]
    private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject]
    private NavigationManager Navigation { get; set; } = null!;

    [Inject]
    private StateContainer StateContainer { get; init; } = null!;

    [Inject]
    private IJSRuntime JSRuntime { get; set; } = null!;

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
            filteredIndicators.AddRange(indicators);
        }
        catch (Exception ex) {
            Log.Error("{Exception}", ex);
            throw;
        }
        finally {
            isLoaded = true;
        }

        await base.OnInitializedAsync();
    }

    private static DateTime? GetDateLastEntry(Indicator indicator)
    {
        return indicator.Entries.OrderByDescending(e => e.EndDate).FirstOrDefault()?.EndDate;
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

    public async void RowClicked(TableRowClickEventArgs<Indicator> p)
    {
        if (p.MouseEventArgs.CtrlKey && p.MouseEventArgs.AltKey) {
            await JSRuntime.InvokeAsync<object>("open", CancellationToken.None, $"/indicators/edit/{p.Item.Id}", "_blank");
        }
        else if (p.MouseEventArgs.CtrlKey) {
            await JSRuntime.InvokeAsync<object>("open", CancellationToken.None, $"/indicators/details/{p.Item.Id}", "_blank");
        }
        else {
            Details(p.Item.Id);
        }
    }

    private bool FilterFunc(Indicator indicator)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        foreach (var lead in indicator.Leads) {
            if (lead.Organization.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (lead.Branch?.Department.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                return true;
            if (lead.Branch?.Department.ShortName.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                return true;
            if (lead.Branch?.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                return true;
            if (lead.ToString().Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        if (indicator.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (indicator.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }

    private string FilterIndicatorsText()
    {
        if (filterIndicatorsSwitch.Checked) {
            return "My indicators";
        } else {
            return "All indicators";
        }
    }

    private void FilterIndicators()
    {
        filteredIndicators.Clear();
        if(filterIndicatorsSwitch.Checked) {
            filteredIndicators = indicators.Where(i => IsUserAMemberOfLeads(i)).ToList();
        } else {
            filteredIndicators.AddRange(indicators);
        }
    }

    private static string GetTrend(Indicator indicator)
    {
        var entries = indicator.Entries.OrderByDescending(e => e.EndDate).ToList();
        var count = entries.Count;
        if (count >= 2) {
            if (entries[0].Value > entries[1].Value) {
                return "TrendingUp";
            }
            else if (entries[0].Value < entries[1].Value) {
                return "TrendingDown";
            }
            else {
                return "TrendingFlat";
            }
        }
        else {
            return "NoTrend";
        }
    }

    private bool IsUserAMemberOfLeads(Indicator indicator)
    {
        var claimsPrincipal = StateContainer.ClaimsPrincipal;
        foreach (var lead in indicator.Leads) {
            if (claimsPrincipal.IsInRole(lead.Id.ToString())) {
                return true;
            }
        }
        if (claimsPrincipal.IsInRole("Administrator")
            || claimsPrincipal.IsInRole("1")) {
            return true;
        }
        return false;
    }

    public void Dispose()
    {
        context.Dispose();
    }
}