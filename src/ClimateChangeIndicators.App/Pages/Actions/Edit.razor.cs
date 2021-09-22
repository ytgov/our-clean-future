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
using ClimateChangeIndicators.App;
using ClimateChangeIndicators.App.Shared;
using MudBlazor;
using Action = ClimateChangeIndicators.Data.Entities.Action;
using ClimateChangeIndicators.Data.Entities;
using ClimateChangeIndicators.Data;
using Microsoft.EntityFrameworkCore;

namespace ClimateChangeIndicators.App.Pages.Actions
{
    public partial class Edit
    {
        private bool _isLoaded;
        private AppDbContext _context = null!;

        [Parameter]
        public int Id { get; set; }

        public string SelectedParentType { get; set; } = "";

        public List<Goal> Goals { get; set; } = new();
        public List<Objective> Objectives { get; set; } = new();
        public Action Action { get; set; } = null!;
        public List<Indicator> Indicators { get; set; } = new();

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
                Goals = await _context.Goals.OrderBy(g => g.Title).ToListAsync();
                Objectives = await _context.Objectives.Include(o => o.Area).OrderBy(o => o.Area.Title).ThenBy(o => o.Title).ToListAsync();
#pragma warning disable CS8601 // Possible null reference assignment.
                Action = await _context.Actions.Include(a => a.Indicators).FirstOrDefaultAsync(a => a.Id == Id);
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

        private async Task Update()
        {
            await _context.SaveChangesAsync();
            Snackbar.Add($"Successfully updated action: {Action.Title}", Severity.Success);
            Navigation.NavigateTo($"/actions/details/{Id}");
        }
    }
}