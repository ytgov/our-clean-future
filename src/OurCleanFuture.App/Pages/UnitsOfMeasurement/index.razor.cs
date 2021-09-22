using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.App.Pages.UnitsOfMeasurement
{
    public partial class Index
    {
        private bool _isLoaded;
        private bool _mayRender = true;
        private AppDbContext _context = null!;

        public List<UnitOfMeasurement> _unitsOfMeasurement { get; set; } = new();

        [Inject]
        public IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

        [Inject]
        public IDialogService DialogService { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            try {
                _context = ContextFactory.CreateDbContext();
                _unitsOfMeasurement = await _context.UnitsOfMeasurement.OrderBy(u => u.Symbol).ToListAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally {
                _isLoaded = true;
            }

            await base.OnInitializedAsync();
        }

        private async Task Edit(UnitOfMeasurement unit)
        {
            var parameters = new DialogParameters
            {
                { "ButtonText", "Update" },
                { "Color", Color.Success },
                { "Entity", unit }
            };
        }

        private async Task Delete(UnitOfMeasurement unit)
        {
            bool? result = await DialogService.ShowMessageBox(
                $"Delete {unit.Symbol}?",
                "This action cannot not be undone.",
                yesText: "Delete", cancelText: "Cancel");
            if (result == true) {
                //Prevents mid-method rerendering of the component, which avoids overlapping threads
                _mayRender = false;
                try {
                    _context.Remove(unit);
                    await _context.SaveChangesAsync();
                    _unitsOfMeasurement.Remove(unit);
                    Snackbar.Add($"Deleted unit {unit.Symbol}", Severity.Success);
                }
                catch (DbUpdateException) {
                    Snackbar.Add($"Unable to delete unit {unit.Symbol}, as it is associated with an indicator", Severity.Error);
                }
                finally {
                    _mayRender = true;
                }
            }
        }
    }
}
