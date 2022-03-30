using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using MudBlazor;
using OurCleanFuture.Data;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Actions;

public partial class Index : IDisposable
{
    private bool isLoaded;
    private AppDbContext context = null!;

    private IOrderedEnumerable<Action> orderedActions = null!;
    private List<Action> filteredActions = new();
    private MudSwitch<bool> filterActionsSwitch = null!;

    private Action selectedItem = null!;
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
            var actions = await context.Actions
                .Include(i => i.Leads)
                .ThenInclude(l => l.Organization)
                .Include(i => i.Leads)
                .ThenInclude(l => l.Branch)
                .ThenInclude(b => b!.Department)
                .AsNoTracking()
                .AsSingleQuery()
                .ToListAsync();
            orderedActions = actions.OrderBy(a => a.Number[0])
                                            .ThenBy(a => a.Number.Length)
                                            .ThenBy(a => a.Number);
            filteredActions.AddRange(orderedActions);
        }
        catch (Exception ex) {
            Log.Error("{Exception}", ex);
            throw;
        }
        finally {
            isLoaded = true;
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
        if (p.MouseEventArgs.CtrlKey && p.MouseEventArgs.AltKey) {
            await JSRuntime.InvokeAsync<object>("open", CancellationToken.None, $"/actions/edit/{p.Item.Id}", "_blank");
        }
        else if (p.MouseEventArgs.CtrlKey) {
            await JSRuntime.InvokeAsync<object>("open", CancellationToken.None, $"/actions/details/{p.Item.Id}", "_blank");
        }
        else {
            Details(p.Item.Id);
        }
    }

    private bool FilterFunc(Action action)
    {
        if (string.IsNullOrWhiteSpace(searchString))
            return true;
        foreach (var lead in action.Leads) {
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
        if (action.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }

    private string FilterActionsText()
    {
        if (filterActionsSwitch.Checked) {
            return "My actions";
        }
        else {
            return "All actions";
        }
    }

    private void FilterActions()
    {
        filteredActions.Clear();
        if (filterActionsSwitch.Checked) {
            filteredActions = orderedActions.Where(i => IsUserAMemberOfLeads(i)).ToList();
        }
        else {
            filteredActions.AddRange(orderedActions);
        }
    }

    private bool IsUserAMemberOfLeads(Action action)
    {
        var claimsPrincipal = StateContainer.ClaimsPrincipal;
        foreach (var lead in action.Leads) {
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