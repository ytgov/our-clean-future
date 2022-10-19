using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Pages.Branches;

[Authorize(Roles = "Administrator, 1")]
public partial class Index : IDisposable
{
    private AppDbContext _context = null!;
    private bool _isLoaded;

    private List<Branch> Branches { get; set; } = new();
    private List<Department> Departments { get; set; } = new();

    [Inject] private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject] private IDialogService DialogService { get; set; } = null!;

    [Inject] private ISnackbar Snackbar { get; set; } = null!;

    [Inject] private StateContainer StateContainer { get; init; } = null!;

    public void Dispose() => _context.Dispose();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _context = ContextFactory.CreateDbContext();
            Branches = await _context.Branches.OrderBy(b => b.Name).Include(b => b.Department).Include(b => b.Lead)
                .ToListAsync();
            Departments = await _context.Departments.OrderBy(d => d.Name).ToListAsync();
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

    private async Task Create(List<Department> departments)
    {
        var parameters = new DialogParameters { ["Departments"] = departments };

        var dialog = DialogService.Show<CreateDialog>("Create", parameters);
        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            var newBranch = (Branch)result.Data;
            try
            {
                _context.Add(newBranch);
                // Also create a Lead with Organization=YG for the new branch
                _context.Add(new Lead { Branch = newBranch, OrganizationId = 1 });
                var entriesSaved = await _context.SaveChangesAsync();
                if (entriesSaved == 2)
                {
                    Branches.Add(newBranch);
                    Snackbar.Add($"Created branch {newBranch.Name}", Severity.Success);
                    Log.Information("{User} created branch: {BranchId}, {BranchName}, {DepartmentName}",
                        StateContainer.ClaimsPrincipalEmail,
                        newBranch.Id,
                        newBranch.Name,
                        newBranch.Department.Name);
                }
            }
            catch (DbUpdateException)
            {
                Snackbar.Add($"Unable to add new branch {newBranch.Name}", Severity.Error);
            }
        }
    }

    private async Task Edit(Branch branch, List<Department> departments)
    {
        var parameters = new DialogParameters { ["Branch"] = branch, ["Departments"] = departments };

        var dialog = DialogService.Show<EditDialog>("Edit", parameters);
        var result = await dialog.Result;
        if (!result.Cancelled)
        {
            var updatedBranch = (Branch)result.Data;
            try
            {
                var entriesSaved = await _context.SaveChangesAsync();
                if (entriesSaved == 1)
                {
                    Snackbar.Add($"Updated branch {updatedBranch.Name}", Severity.Success);
                    Log.Information("{User} updated branch: {BranchId}, {BranchName}",
                        StateContainer.ClaimsPrincipalEmail,
                        branch.Id,
                        updatedBranch.Name);
                }
            }
            catch (DbUpdateException)
            {
                Snackbar.Add($"Unable to edit branch {branch.Name}", Severity.Error);
            }
        }
    }

    private async Task Delete(Branch branch)
    {
        var result = await DialogService.ShowMessageBox(
            $"Delete {branch.Name}?",
            "This action cannot not be undone.",
            "Delete", cancelText: "Cancel");
        if (result == true)
        {
            //Prevents mid-method rerendering of the component, which avoids overlapping threads
            try
            {
                _context.Remove(branch.Lead);
                _context.Remove(branch);
                await _context.SaveChangesAsync();
                Branches.Remove(branch);
                Snackbar.Add($"Deleted branch {branch.Name}", Severity.Success);
                Log.Information("{User} deleted branch: {BranchId}, {BranchName}, {DepartmentName}",
                    StateContainer.ClaimsPrincipalEmail,
                    branch.Id,
                    branch.Name,
                    branch.Department.Name);
            }
            catch (DbUpdateException)
            {
                Snackbar.Add($"Unable to delete branch {branch.Name}, as it is associated with an indicator or action",
                    Severity.Error);
            }
        }
    }
}
