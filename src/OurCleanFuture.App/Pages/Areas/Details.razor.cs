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
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Areas
{
    public partial class Details
    {
        private bool _isLoaded;
        private AppDbContext context = null!;

        public Area Area { get; set; } = null!;

        [Parameter]
        public string AreaTitle { get; set; } = null!;
        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        [Inject]
        public NavigationManager Navigation { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        //Required to force the app to re-render when navigating between Area pages
        protected override async Task OnParametersSetAsync()
        {
            await OnInitializedAsync();
        }

        protected override async Task OnInitializedAsync()
        {
            try {
                context = ContextFactory.CreateDbContext();
#pragma warning disable CS8601 // Possible null reference assignment.
                Area = await context.Areas.Include(a => a.Objectives).ThenInclude(o => o.Actions).FirstOrDefaultAsync(a => a.Title == AreaTitle.Replace('-', ' '));
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
        private void ViewAction(Action action)
        {
            Navigation.NavigateTo("/actions/details/" + action.Id);
        }
    }
}