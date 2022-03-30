using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Actions;

public partial class Details : IDisposable
{
    private bool _isLoaded;
    private AppDbContext _context = null!;

    [Parameter]
    public int Id { get; set; }

    private Action Action { get; set; } = null!;

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
#pragma warning disable CS8601 // Possible null reference assignment.
            Action = await _context.Actions.Include(a => a.Indicators)
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
                .AsSingleQuery()
                .FirstOrDefaultAsync(a => a.Id == Id);
#pragma warning restore CS8601 // Possible null reference assignment.
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
        Log.Information("{User} is viewing action {ActionId}: {ActionTitle}", StateContainer.ClaimsPrincipalEmail, Action?.Id, Action?.Title);

        await base.OnInitializedAsync();
    }

    private string InternalStatusToString()
    {
        // Only append updated by information if the InternalStatus has been updated after database creation
        if (!string.IsNullOrWhiteSpace(Action.InternalStatusUpdatedBy))
        {
            return $"Last updated by {Action.InternalStatusUpdatedBy} on {Action.InternalStatusUpdatedDate?.LocalDateTime.ToString("f")}";
        }
        else
        {
            return string.Empty;
        }
    }

    private string ExternalStatusToString()
    {
        // Only append updated by information if the ExternalStatus has been updated after database creation
        if (!string.IsNullOrWhiteSpace(Action.ExternalStatusUpdatedBy))
        {
            return $"Last updated by {Action.ExternalStatusUpdatedBy} on {Action.ExternalStatusUpdatedDate?.LocalDateTime.ToString("f")}";
        }
        else
        {
            return string.Empty;
        }
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
        _context.Dispose();
    }
}
