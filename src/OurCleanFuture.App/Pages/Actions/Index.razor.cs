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
    private AppDbContext _context = null!;
    private MudSwitch<bool> _filterActionsSwitch = null!;
    private List<Action> _filteredActions = new();
    private bool _isLoaded;

    private IOrderedEnumerable<Action> _orderedActions = null!;
    private string _searchString = "";

    private Action _selectedItem = null!;

    [Inject]
    private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject]
    private NavigationManager Navigation { get; set; } = null!;

    [Inject]
    private StateContainerService StateContainer { get; init; } = null!;

    [Inject]
    private IJSRuntime JsRuntime { get; set; } = null!;

    public void Dispose() => _context.Dispose();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _context = await ContextFactory.CreateDbContextAsync();
            var actions = await _context.Actions
                .Include(i => i.Leads)
                .ThenInclude(l => l.Organization)
                .Include(i => i.Leads)
                .ThenInclude(l => l.Branch)
                .ThenInclude(b => b!.Department)
                .AsNoTracking()
                .AsSingleQuery()
                .ToListAsync();
            _orderedActions = actions
                .OrderBy(a => a.Number[0])
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

    private void Create() => Navigation.NavigateTo("/actions/create/");

    private void Details(int actionId) => Navigation.NavigateTo("/actions/details/" + actionId);

    private void Edit(int actionId) => Navigation.NavigateTo("/actions/edit/" + actionId);

    private async void RowClicked(TableRowClickEventArgs<Action> p)
    {
        switch (p.MouseEventArgs.CtrlKey)
        {
            case true when p.MouseEventArgs.AltKey:
                await JsRuntime.InvokeAsync<object>(
                    "open",
                    CancellationToken.None,
                    $"/actions/edit/{p.Item.Id}",
                    "_blank"
                );
                break;
            case true:
                await JsRuntime.InvokeAsync<object>(
                    "open",
                    CancellationToken.None,
                    $"/actions/details/{p.Item.Id}",
                    "_blank"
                );
                break;
            default:
                Details(p.Item.Id);
                break;
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

            if (
                lead.Branch?.Department.Name.Contains(
                    _searchString,
                    StringComparison.OrdinalIgnoreCase
                ) == true
            )
            {
                return true;
            }

            if (
                lead.Branch?.Department.ShortName.Contains(
                    _searchString,
                    StringComparison.OrdinalIgnoreCase
                ) == true
            )
            {
                return true;
            }

            if (
                lead.Branch?.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase)
                == true
            )
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

        return "All actions";
    }

    private void FilterActions()
    {
        _filteredActions.Clear();
        if (_filterActionsSwitch.Checked)
        {
            _filteredActions = _orderedActions.Where(IsUserAMemberOfLeads).ToList();
        }
        else
        {
            _filteredActions.AddRange(_orderedActions);
        }
    }

    private bool IsUserAMemberOfLeads(Action action)
    {
        var claimsPrincipal = StateContainer.ClaimsPrincipal;
        if (action.Leads.Any(lead => claimsPrincipal.IsInRole(lead.Id.ToString())))
        {
            return true;
        }

        return claimsPrincipal.IsInRole("Administrator") || claimsPrincipal.IsInRole("1");
    }
}
