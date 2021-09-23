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
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Actions
{
    public partial class Index
    {
        private bool _isLoaded;
        private Action _selectedItem = null!;

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public NavigationManager Navigation { get; set; } = null!;
        public AppDbContext Context { get; private set; } = null!;
        public List<Action> Actions { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            try {
                Context = ContextFactory.CreateDbContext();
                Actions = await Context.Actions
                    .AsNoTracking()
                    .AsSingleQuery()
                    .ToListAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                _isLoaded = true;
            }
        }

        private void Details(int actionId)
        {
            Navigation.NavigateTo("/actions/details/" + actionId);
        }

        private void Edit(int actionId)
        {
            Navigation.NavigateTo("/actions/edit/" + actionId);
        }
    }
}