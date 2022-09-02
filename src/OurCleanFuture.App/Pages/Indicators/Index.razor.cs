using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using MudBlazor;
using OurCleanFuture.App.Services;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Pages.Indicators;

public partial class Index : IDisposable
{
    private bool _isLoaded;
    private AppDbContext _context = null!;

    private List<Indicator> _indicators = new();
    private List<Indicator> _filteredIndicators = new();
    private MudSwitch<bool> _filterIndicatorsSwitch = null!;

    private Indicator _selectedItem = null!;
    private string _searchString = "";

    [Inject]
    private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject]
    private NavigationManager Navigation { get; set; } = null!;

    [Inject]
    private StateContainerService StateContainer { get; init; } = null!;

    [Inject]
    private IJSRuntime JSRuntime { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _context = ContextFactory.CreateDbContext();
            _indicators = await _context.Indicators
            .Include(i => i.Action)
            .Include(i => i.Leads)
            .ThenInclude(l => l.Organization)
            .Include(i => i.Leads)
            .ThenInclude(l => l.Branch)
            .ThenInclude(b => b!.Department)
            .AsNoTracking()
            .AsSingleQuery()
            .ToListAsync();
            _filteredIndicators.AddRange(_indicators);
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
        if (p.MouseEventArgs.CtrlKey && p.MouseEventArgs.AltKey)
        {
            await JSRuntime.InvokeAsync<object>("open", CancellationToken.None, $"/indicators/edit/{p.Item.Id}", "_blank");
        }
        else if (p.MouseEventArgs.CtrlKey)
        {
            await JSRuntime.InvokeAsync<object>("open", CancellationToken.None, $"/indicators/details/{p.Item.Id}", "_blank");
        }
        else
        {
            Details(p.Item.Id);
        }
    }

    private bool FilterFunc(Indicator indicator)
    {
        if (string.IsNullOrWhiteSpace(_searchString))
        {
            return true;
        }
        foreach (var lead in indicator.Leads)
        {
            if (lead.Organization.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (lead.Branch?.Department.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            if (lead.Branch?.Department.ShortName.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            if (lead.Branch?.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            if (lead.ToString().Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        if (indicator.Description.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        if (indicator.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        return false;
    }

    private string FilterIndicatorsText()
    {
        if (_filterIndicatorsSwitch.Checked)
        {
            return "My indicators";
        }
        else
        {
            return "All indicators";
        }
    }

    private void FilterIndicators()
    {
        _filteredIndicators.Clear();
        if (_filterIndicatorsSwitch.Checked)
        {
            _filteredIndicators = _indicators.Where(i => IsUserAMemberOfLeads(i)).ToList();
        }
        else
        {
            _filteredIndicators.AddRange(_indicators);
        }
    }

    private static string GetTrend(Indicator indicator)
    {
        var entries = indicator.Entries.OrderByDescending(e => e.EndDate).ToList();
        var count = entries.Count;
        if (count >= 2)
        {
            if (entries[0].Value > entries[1].Value)
            {
                return "TrendingUp";
            }
            else if (entries[0].Value < entries[1].Value)
            {
                return "TrendingDown";
            }
            else
            {
                return "TrendingFlat";
            }
        }
        else
        {
            return "NoTrend";
        }
    }

    private bool IsUserAMemberOfLeads(Indicator indicator)
    {
        var claimsPrincipal = StateContainer.ClaimsPrincipal;
        foreach (var lead in indicator.Leads)
        {
            if (claimsPrincipal.IsInRole(lead.Id.ToString()))
            {
                return true;
            }
        }
        if (claimsPrincipal.IsInRole("Administrator")
            || claimsPrincipal.IsInRole("1"))
        {
            return true;
        }
        return false;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
