using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using MudBlazor;
using OurCleanFuture.App.Services;
using OurCleanFuture.Data;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Actions;

public partial class Index : IDisposable
{
    private bool _isLoaded;
    private AppDbContext _context = null!;

    private IOrderedEnumerable<Action> _orderedActions = null!;
    private List<Action> _filteredActions = new();
    private MudSwitch<bool> _filterActionsSwitch = null!;

    private Action _selectedItem = null!;
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
            var actions = await _context.Actions
                .Include(i => i.Leads)
                .ThenInclude(l => l.Organization)
                .Include(i => i.Leads)
                .ThenInclude(l => l.Branch)
                .ThenInclude(b => b!.Department)
                .AsNoTracking()
                .AsSingleQuery()
                .ToListAsync();
            _orderedActions = actions.OrderBy(a => a.Number[0])
                                            .ThenBy(a => a.Number.Length)
                                            .ThenBy(a => a.Number);
            _filteredActions.AddRange(_orderedActions);
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
    }

    private void Details(int actionId)
    {
        Navigation.NavigateTo("/actions/details/" + actionId);
    }

    private void Edit(int actionId)
    {
        Navigation.NavigateTo("/actions/edit/" + actionId);
    }

    public async void RowClicked(TableRowClickEventArgs<Action> p)
    {
        if (p.MouseEventArgs.CtrlKey && p.MouseEventArgs.AltKey)
        {
            await JSRuntime.InvokeAsync<object>("open", CancellationToken.None, $"/actions/edit/{p.Item.Id}", "_blank");
        }
        else if (p.MouseEventArgs.CtrlKey)
        {
            await JSRuntime.InvokeAsync<object>("open", CancellationToken.None, $"/actions/details/{p.Item.Id}", "_blank");
        }
        else
        {
            Details(p.Item.Id);
        }
    }

    private bool FilterFunc(Action action)
    {
        if (string.IsNullOrWhiteSpace(_searchString))
        {
            return true;
        }
        foreach (var lead in action.Leads)
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
        if (action.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
        return false;
    }

    private string FilterActionsText()
    {
        if (_filterActionsSwitch.Checked)
        {
            return "My actions";
        }
        else
        {
            return "All actions";
        }
    }

    private void FilterActions()
    {
        _filteredActions.Clear();
        if (_filterActionsSwitch.Checked)
        {
            _filteredActions = _orderedActions.Where(i => IsUserAMemberOfLeads(i)).ToList();
        }
        else
        {
            _filteredActions.AddRange(_orderedActions);
        }
    }

    private bool IsUserAMemberOfLeads(Action action)
    {
        var claimsPrincipal = StateContainer.ClaimsPrincipal;
        foreach (var lead in action.Leads)
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
