using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using OurCleanFuture.App;
using OurCleanFuture.App.Shared;
using MudBlazor;
using OurCleanFuture.Data.Entities;
using OurCleanFuture.Data;
using Microsoft.EntityFrameworkCore;

namespace OurCleanFuture.App.Pages.Branches
{
    [Authorize(Roles = "Admin")]
    public partial class Index : IDisposable
    {
        private bool isLoaded;
        private bool mayRender = true;
        private AppDbContext context = null!;

        public List<Branch> Branches { get; set; } = new();
        public List<Department> Departments { get; set; } = new();

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;



        protected override async Task OnInitializedAsync()
        {
            try {
                context = ContextFactory.CreateDbContext();
                Branches = await context.Branches.OrderBy(b => b.Name).Include(b => b.Department).Include(b => b.Lead).ToListAsync();
                Departments = await context.Departments.OrderBy(d => d.Name).ToListAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                isLoaded = true;
            }

            await base.OnInitializedAsync();
        }

        private async Task Create(List<Department> departments)
        {
            var parameters = new DialogParameters { ["Departments"] = departments };

            var dialog = DialogService.Show<CreateDialog>("Create", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled) {
                var newBranch = (Branch)result.Data;
                try {
                    context.Add(newBranch);
                    // Also create a Lead with Organization=YG for the new branch
                    context.Add(new Lead { Branch = newBranch, OrganizationId = 1 });
                    var entriesSaved = await context.SaveChangesAsync();
                    if (entriesSaved == 2) {
                        Branches.Add(newBranch);
                        Snackbar.Add($"Created branch {newBranch.Name}", Severity.Success);
                    }
                }
                catch (DbUpdateException) {

                    Snackbar.Add($"Unable to add new branch {newBranch.Name}", Severity.Error);
                }
            }
        }

        private async Task Edit(Branch branch, List<Department> departments)
        {
            var parameters = new DialogParameters { ["Branch"] = branch, ["Departments"] = departments };

            var dialog = DialogService.Show<EditDialog>("Edit", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled) {
                var updatedBranch = (Branch)result.Data;
                try {
                    var entriesSaved = await context.SaveChangesAsync();
                    if (entriesSaved == 1) {
                        Snackbar.Add($"Updated branch {updatedBranch.Name}", Severity.Success);
                    }
                }
                catch (DbUpdateException) {

                    Snackbar.Add($"Unable to edit branch {branch.Name}", Severity.Error);
                }
            }
        }

        private async Task Delete(Branch branch)
        {
            bool? result = await DialogService.ShowMessageBox(
                $"Delete {branch.Name}?",
                "This action cannot not be undone.",
                yesText: "Delete", cancelText: "Cancel");
            if (result == true) {
                //Prevents mid-method rerendering of the component, which avoids overlapping threads
                mayRender = false;
                try {
                    context.Remove(branch.Lead);
                    context.Remove(branch);
                    await context.SaveChangesAsync();
                    Branches.Remove(branch);
                    Snackbar.Add($"Deleted branch {branch.Name}", Severity.Success);
                }
                catch (DbUpdateException) {
                    Snackbar.Add($"Unable to delete branch {branch.Name}, as it is associated with an indicator or action", Severity.Error);
                }
                finally {
                    mayRender = true;
                }
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}