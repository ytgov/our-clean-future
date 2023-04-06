using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using OurCleanFuture.App.Services;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Pages.Authorizations;

[Authorize(Roles = "Administrator, 1")]
public partial class Index
{
    private AppDbContext _context = null!;
    private bool _isLoaded;
    private List<User> Users { get; set; } = new();
    public List<Lead> Leads { get; set; } = new();

    [Inject]
    private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject]
    private IDialogService DialogService { get; set; } = null!;

    [Inject]
    private ISnackbar Snackbar { get; set; } = null!;

    [Inject]
    private StateContainerService StateContainer { get; init; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _context = await ContextFactory.CreateDbContextAsync();
            Users = await _context.Users.Include(u => u.Leads).ToListAsync();
            Leads = await _context.Leads
                .Include(l => l.Organization)
                .Include(l => l.Branch)
                .ThenInclude(b => b!.Department)
                .ToListAsync();
        }
        finally
        {
            _isLoaded = true;
        }
    }

    private async Task Add(Lead lead)
    {
        var parameters = new DialogParameters { ["Lead"] = lead };

        var dialog = DialogService.Show<AddUserDialog>("Add", parameters);
        var result = await dialog.Result;
        if (!result.Canceled)
        {
            var newUser = (User)result.Data;
            try
            {
                var existingUser = _context.Users.SingleOrDefault(u => u.Email == newUser.Email);
                if (existingUser is not null)
                {
                    existingUser.Leads.Add(lead);
                }
                else
                {
                    newUser.Leads.Add(lead);
                    _context.Users.Add(newUser);
                    // Required for the page to re-render
                    Users.Add(newUser);
                }

                var entriesSaved = await _context.SaveChangesAsync();
                if (entriesSaved == 2)
                {
                    Snackbar.Add(
                        $"Successfully added user {newUser.Email} to {lead}",
                        Severity.Success
                    );

                    Log.Information(
                        "{User} added user {AddedUser} to {Lead}",
                        StateContainer.ClaimsPrincipalEmail,
                        newUser.Email,
                        lead
                    );
                }
            }
            catch (DbUpdateException)
            {
                Snackbar.Add($"Unable to add user {newUser.Email} to {lead}", Severity.Error);
            }
        }
    }

    private async Task Remove(User user, Lead lead)
    {
        var result = await DialogService.ShowMessageBox(
            $"Remove {user.Email} from {lead}?",
            "This action cannot not be undone.",
            "Remove",
            cancelText: "Cancel"
        );
        if (result == true)
        {
            try
            {
                if (user.Leads.Count == 1)
                {
                    _context.Users.Remove(user);
                }

                lead.Users.Remove(user);
                await _context.SaveChangesAsync();
                Snackbar.Add($"Removed {user.Email} from {lead}", Severity.Success);
                Log.Information(
                    "{User} removed user {RemovedUser} from {Lead}",
                    StateContainer.ClaimsPrincipalEmail,
                    user.Email,
                    lead
                );
            }
            catch (DbUpdateException)
            {
                Snackbar.Add($"Unable to remove {user.Email} from {lead}", Severity.Error);
            }
        }
    }
}
