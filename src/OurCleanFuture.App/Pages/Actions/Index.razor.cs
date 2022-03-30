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

    private AppDbContext Context { get; set; } = null!;
    private List<Action> Actions { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        try {
            Context = ContextFactory.CreateDbContext();
            Actions = await Context.Actions
                .Include(i => i.Leads)
                .ThenInclude(l => l.Organization)
                .Include(i => i.Leads)
                .ThenInclude(l => l.Branch)
                .ThenInclude(b => b!.Department)
                .AsNoTracking()
                .AsSingleQuery()
                .ToListAsync();
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
        }
        finally {
            isLoaded = true;
        }
    }

    private void Details(int actionId)
    {
        Navigation.NavigateTo("/actions/details/" + actionId);
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

    private void Edit(int actionId)
    {
        Navigation.NavigateTo("/actions/edit/" + actionId);
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

    private bool IsAuthorizedToEdit(Action action)
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
        Context.Dispose();
    }
}