using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using OurCleanFuture.App.Extensions;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Actions;

public partial class Details : IDisposable
{
    private bool isLoaded;
    private AppDbContext context = null!;

    [Parameter]
    public int Id { get; set; }

    public List<Goal> Goals { get; set; } = new();
    public List<Objective> Objectives { get; set; } = new();
    public Action Action { get; set; } = null!;
    public List<Indicator> Indicators { get; set; } = new();
    public List<DirectorsCommittee> DirectorsCommittees { get; set; } = new();

    [Inject]
    public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject]
    public IDialogService DialogService { get; set; } = null!;

    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try {
            context = ContextFactory.CreateDbContext();
#pragma warning disable CS8601 // Possible null reference assignment.
            Action = await context.Actions.Include(a => a.Indicators)
                .Include(a => a.DirectorsCommittees)
                .Include(i => i.Leads)
                .ThenInclude(l => l.Branch)
                .ThenInclude(b => b!.Department)
                .Include(i => i.Leads)
                .ThenInclude(l => l.Organization)
                .Include(a => a.Objective)
                .ThenInclude(a => a.Area)
                .Include(a => a.Objective)
                .ThenInclude(a => a.Goals)
                .FirstOrDefaultAsync(a => a.Id == Id);
#pragma warning restore CS8601 // Possible null reference assignment.
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
        }
        finally {
            isLoaded = true;
        }

        await base.OnInitializedAsync();
    }

    private string InternalStatusToString()
    {
        var result = $"{Action.InternalStatus.GetDisplayName()}";
        // Only append updated by information if the InternalStatus has been updated after database creation
        if (!string.IsNullOrWhiteSpace(Action.InternalStatusUpdatedBy)) {
            result += $" (last updated by {Action.InternalStatusUpdatedBy} on {Action.InternalStatusUpdatedDate?.LocalDateTime.ToString("f")})";
        }
        return result;
    }

    private string ExternalStatusToString()
    {
        var result = $"{Action.ExternalStatus.GetDisplayName()}";
        // Only append updated by information if the ExternalStatus has been updated after database creation
        if (!string.IsNullOrWhiteSpace(Action.ExternalStatusUpdatedBy)) {
            result += $" (last updated by {Action.ExternalStatusUpdatedBy} on {Action.ExternalStatusUpdatedDate?.LocalDateTime.ToString("f")})";
        }
        return result;
    }

    private void Edit()
    {
        Navigation.NavigateTo("/actions/edit/" + Action.Id);
    }

    private void ViewIndicator(Indicator indicator)
    {
        Navigation.NavigateTo("/indicators/details/" + indicator.Id);
    }

    private void ViewArea(Area area)
    {
        Navigation.NavigateTo("/areas/" + area.Title.ToLower().Replace(' ', '-'));
    }

    public void Dispose()
    {
        context.DisposeAsync();
    }
}