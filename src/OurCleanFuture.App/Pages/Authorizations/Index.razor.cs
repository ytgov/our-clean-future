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
using Microsoft.EntityFrameworkCore;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Pages.Authorizations
{
    [Authorize(Roles = "Administrator, 1")]
    public partial class Index
    {
        private bool isLoaded;
        private AppDbContext _context = null!;
        private List<User> Users { get; set; } = new();
        public List<Lead> Leads { get; set; } = new();

        [Inject]
        private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        private IDialogService DialogService { get; set; } = null!;

        [Inject]
        private ISnackbar Snackbar { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try {
                _context = ContextFactory.CreateDbContext();
                Users = await _context.Users.Include(u => u.Leads).ToListAsync();
                Leads = await _context.Leads.Include(l => l.Organization)
                                            .Include(l => l.Branch)
                                            .ThenInclude(b => b!.Department)
                                            .ToListAsync();
            }
            finally {
                isLoaded = true;
            }
        }

        private async Task Add(Lead lead)
        {
            var parameters = new DialogParameters { ["Lead"] = lead };

            var dialog = DialogService.Show<AddUserDialog>("Add", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled) {
                var newUser = (User)result.Data;
                try {
                    var existingUser = _context.Users.SingleOrDefault(u => u.Email == newUser.Email);
                    if (existingUser is not null) {
                        existingUser.Leads.Add(lead);
                    }
                    else {
                        newUser.Leads.Add(lead);
                        _context.Users.Add(newUser);
                        // Required for the page to re-render
                        Users.Add(newUser);
                    }
                    var entriesSaved = await _context.SaveChangesAsync();
                    if (entriesSaved == 2) {
                        Snackbar.Add($"Successfully added user {newUser.Email} to {lead}", Severity.Success);
                    }
                }
                catch (DbUpdateException) {
                    Snackbar.Add($"Unable to add user {newUser.Email} to {lead}", Severity.Error);
                }
            }
        }

        private async Task Remove(User user, Lead lead)
        {
            bool? result = await DialogService.ShowMessageBox(
            $"Remove {user.Email} from {lead}?",
            "This action cannot not be undone.",
            yesText: "Remove", cancelText: "Cancel");
            if (result == true) {
                try {
                    if (user.Leads.Count == 1) {
                        _context.Users.Remove(user);
                    }
                    lead.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    Snackbar.Add($"Removed {user.Email} from {lead}", Severity.Success);
                }
                catch (DbUpdateException) {
                    Snackbar.Add($"Unable to remove {user.Email} from {lead}", Severity.Error);
                }
            }
        }
    }
}