using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using OurCleanFuture.App.Services;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Areas;

public partial class Details : IDisposable
{
    private AppDbContext _context = null!;
    private bool _isLoaded;

    private Area? Area { get; set; }

    [Parameter] public string AreaTitle { get; set; } = null!;

    [Inject] private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject] private NavigationManager Navigation { get; set; } = null!;

    [Inject] private StateContainerService StateContainer { get; init; } = null!;

    public void Dispose() => _context.Dispose();

    // Required to force the app to re-render when navigating between Areas.
    // OnInitializedAsync is not called by default in this situation, as the user is merely changing the parameter, while staying on the same page.
    protected override async Task OnParametersSetAsync() => await OnInitializedAsync();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _context = ContextFactory.CreateDbContext();
            Area = await _context.Areas
                .Include(a => a.Objectives)
                .ThenInclude(o => o.Actions)
                .AsSingleQuery()
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Title == AreaTitle.Replace('-', ' '));
            if (Area is not null)
            {
                Log.Information(
                    "{User} is viewing area {AreaId}: {AreaTitle}",
                    StateContainer.ClaimsPrincipalEmail,
                    Area.Id,
                    Area.Title
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

    private void ViewAction(Action action) =>
        Navigation.NavigateTo("/actions/details/" + action.Id);
}
