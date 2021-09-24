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
    public partial class Details
    {
        private bool _isLoaded;
        private AppDbContext _context = null!;

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
                _context = ContextFactory.CreateDbContext();
#pragma warning disable CS8601 // Possible null reference assignment.
                Action = await _context.Actions.Include(a => a.Indicators).Include(a => a.DirectorsCommittees).Include(a => a.Objective).ThenInclude(a => a.Area).Include(a => a.Objective).ThenInclude(a => a.Goals).FirstOrDefaultAsync(a => a.Id == Id);
#pragma warning restore CS8601 // Possible null reference assignment.
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                _isLoaded = true;
            }

            await base.OnInitializedAsync();
        }
        private static string GetAreaIconPath(Area area)
        {
            return area.Id switch {
                1 => "/images/transportation.png",
                2 => "/images/homes-and-buildings.png",
                3 => "/images/energy-production.png",
                4 => "/images/people-and-the-environment.png",
                5 => "/images/communities.png",
                6 => "/images/innovation.png",
                7 => "/images/leadership.png",
                _ => ""
            };
        }
        private static string GetGoalIconPath(Goal goal)
        {
            return goal.Id switch {
                1 => "/images/reduce-greenhouse-gas-emissions.png",
                2 => "/images/ensure-yukoners-have-access-to-reliable-affordable-and-renewable-energy.png",
                3 => "/images/adapt-to-the-impacts-of-climate-change.png",
                4 => "/images/build-a-green-economy.png",
                _ => ""
            };
        }

        private void Edit()
        {
            Navigation.NavigateTo("/actions/edit/" + Action.Id);
        }

        private void ViewIndicator(Indicator indicator)
        {
            Navigation.NavigateTo("/indicators/details/" + indicator.Id);
        }
    }
}