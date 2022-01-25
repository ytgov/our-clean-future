using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
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

    private void RowClicked(TableRowClickEventArgs<Action> p)
    {
        Details(p.Item.Id);
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

    public void Dispose()
    {
        Context.Dispose();
    }
}