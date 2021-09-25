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
using Action = OurCleanFuture.Data.Entities.Action;
using OurCleanFuture.Data.Entities;
using OurCleanFuture.Data;
using Microsoft.EntityFrameworkCore;

namespace OurCleanFuture.App.Pages.Actions
{
    public partial class Edit
    {
        private bool isLoaded;
        private AppDbContext context = null!;
        private Func<DirectorsCommittee, string> committeeConverter = d => d.Name;

        [Parameter]
        public int Id { get; set; }

        public string SelectedParentType { get; set; } = "";

        public List<Goal> Goals { get; set; } = new();
        public List<Objective> Objectives { get; set; } = new();
        public Action Action { get; set; } = null!;
        public List<Indicator> Indicators { get; set; } = new();
        public HashSet<DirectorsCommittee> SelectedDirectorsCommittees { get; set; } = new();
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
                Goals = await context.Goals.OrderBy(g => g.Title).ToListAsync();
                Objectives = await context.Objectives.Include(o => o.Area).OrderBy(o => o.Area.Title).ThenBy(o => o.Title).ToListAsync();
                DirectorsCommittees = await context.DirectorsCommittees.OrderBy(dc => dc.Name).ToListAsync();
#pragma warning disable CS8601 // Possible null reference assignment.
                Action = await context.Actions.Include(a => a.Indicators).Include(a => a.DirectorsCommittees).FirstOrDefaultAsync(a => a.Id == Id);
#pragma warning restore CS8601 // Possible null reference assignment.
                foreach (var committee in Action!.DirectorsCommittees) {
                    SelectedDirectorsCommittees.Add(committee);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                isLoaded = true;
            }

            await base.OnInitializedAsync();
        }

        private async Task Update()
        {
            if (context.Entry(Action).Property(a => a.InternalStatus).IsModified) {
                Action.InternalStatusUpdatedDate = DateTimeOffset.Now;
            }
            Action.DirectorsCommittees.Clear();
            foreach (var committee in SelectedDirectorsCommittees) {
                Action.DirectorsCommittees.Add(committee);
            }
            await context.SaveChangesAsync();
            Snackbar.Add($"Successfully updated action: {Action.Number}", Severity.Success);
            Navigation.NavigateTo($"/actions/details/{Id}");
        }
    }
}