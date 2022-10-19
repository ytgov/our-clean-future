using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using OurCleanFuture.App.Extensions;
using OurCleanFuture.App.Services;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Indicators;

public partial class Edit : IDisposable
{
    private AppDbContext _context = null!;
    private bool _isLoaded;
    private bool _targetIsDeleted;
    private ClaimsPrincipal _user = null!;

    private int[] Years { get; } = Enumerable.Range(2009, DateTime.Now.Year - 2008).Reverse().ToArray();

    [Parameter] public int Id { get; set; }

    private string AuthorizedRoles { get; set; } = "Administrator, 1";
    private string SelectedParentType { get; set; } = "";
    private IEnumerable<Lead> SelectedLeads { get; set; } = new List<Lead>();

    private List<Lead> Leads { get; set; } = new();
    private List<UnitOfMeasurement> UnitsOfMeasurement { get; set; } = new();
    private List<Goal> Goals { get; set; } = new();
    private List<Objective> Objectives { get; set; } = new();
    private List<Action> Actions { get; set; } = new();
    private Indicator? Indicator { get; set; }

    [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

    [Inject] private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject] private IDialogService DialogService { get; set; } = null!;

    [Inject] private NavigationManager Navigation { get; set; } = null!;

    [Inject] private ISnackbar Snackbar { get; set; } = null!;

    [Inject] private StateContainerService StateContainer { get; init; } = null!;

    public void Dispose() => _context.Dispose();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _context = ContextFactory.CreateDbContext();
            Leads = await _context.Leads.Include(l => l.Organization).Include(l => l.Branch)
                .ThenInclude(b => b!.Department).OrderBy(l => l.Branch!.Department.ShortName)
                .ThenBy(l => l.Branch!.Name).ToListAsync();
            UnitsOfMeasurement = await _context.UnitsOfMeasurement.ToListAsync();
            Goals = await _context.Goals.OrderBy(g => g.Title).ToListAsync();
            Objectives = await _context.Objectives.Include(o => o.Area).OrderBy(o => o.Area.Title).ThenBy(o => o.Title)
                .ToListAsync();
            Actions = await _context.Actions.ToListAsync();
            Indicator = await _context.Indicators.Include(i => i.Target).Include(i => i.Leads).AsSingleQuery()
                .FirstOrDefaultAsync(i => i.Id == Id);
            if (Indicator != null)
            {
                foreach (var lead in Indicator.Leads)
                {
                    SelectedLeads = SelectedLeads.Append(lead);
                }

                GetSelectedParentType();
                await GetUserPrincipal();
                AuthorizedRoles += GetAuthorizedRoles();
            }
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

    private string GetAuthorizedRoles()
    {
        var authorizedRoles = "";
        foreach (var lead in Indicator!.Leads)
        {
            authorizedRoles += $", {lead.Id}";
        }

        return authorizedRoles;
    }

    private async Task GetUserPrincipal()
    {
        var authState = await AuthenticationStateTask;
        _user = authState.User;
    }

    private void GetSelectedParentType()
    {
        if (Indicator?.Goal is not null)
        {
            SelectedParentType = "Goal";
        }
        else if (Indicator?.Objective is not null)
        {
            SelectedParentType = "Objective";
        }
        else if (Indicator?.Action is not null)
        {
            SelectedParentType = "Action";
        }
    }

    private async Task Update()
    {
        switch (SelectedParentType)
        {
            case "Goal":
                Indicator!.Objective = null;
                Indicator.Action = null;
                break;

            case "Objective":
                Indicator!.Goal = null;
                Indicator.Action = null;
                break;

            case "Action":
                Indicator!.Goal = null;
                Indicator.Objective = null;
                break;

            default:
                Indicator!.Goal = null;
                Indicator.Objective = null;
                Indicator.Action = null;
                break;
        }

        Indicator.Leads.Clear();
        Indicator.Leads.AddRange(SelectedLeads);

        // Don't update Indicator.UpdatedBy if only the Entries were modified.
        try
        {
            if (_context.Entry(Indicator).State == EntityState.Modified)
            {
                Indicator.UpdatedBy = _user.GetFormattedName();
            }
            else if (Indicator.Target is not null)
            {
                Console.WriteLine($"Indicator.Target state is: {_context.Entry(Indicator.Target).State}");
                if (_context.Entry(Indicator.Target).State is EntityState.Added or EntityState.Modified)
                {
                    Indicator.UpdatedBy = _user.GetFormattedName();
                }
            }
            else if (_targetIsDeleted)
            {
                Indicator.UpdatedBy = _user.GetFormattedName();
            }

            await _context.SaveChangesAsync();
            Snackbar.Add($"Successfully updated indicator: {Indicator.Title}", Severity.Success);
            Log.Information("{User} updated indicator {IndicatorId}: {IndicatorTitle}",
                StateContainer.ClaimsPrincipalEmail, Indicator.Id, Indicator.Title);
        }
        catch (Exception ex)
        {
            switch (ex)
            {
                case InvalidOperationException:
                    Snackbar.Add("The entry changes were not saved. Two entries cannot have the same period.",
                        Severity.Error);
                    break;

                case DbUpdateException:
                    Snackbar.Add(ex.Message, Severity.Error);
                    break;

                default:
                    throw;
            }
        }

        Navigation.NavigateTo($"/indicators/details/{Id}");
    }

    private void CreateTarget()
    {
        Indicator!.Target = new Target();
        _context.Attach(Indicator.Target);
    }

    private void DeleteTarget()
    {
        // This flag is used by the Update() method instead of checking EntityState, as we cannot check the EntityState of a null reference (Indicator.Target).
        _targetIsDeleted = true;
        Indicator!.Target = null;
        StateHasChanged();
    }

    private async Task CreateEntry()
    {
        var parameters = new DialogParameters { ["Indicator"] = Indicator, ["Years"] = Years };

        var dialog = DialogService.Show<CreateEntryDialog>("Add entry", parameters);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            var newEntry = (Entry)result.Data;
            newEntry.UpdatedBy = _user.GetFormattedName();
            Indicator!.Entries.Add(newEntry);
            Snackbar.Add($"Click submit to confirm adding entry dated {newEntry.StartDate.ToLongDateString()}",
                Severity.Info);
        }
    }

    private async Task EditEntry(Entry entry)
    {
        var parameters = new DialogParameters { ["Indicator"] = Indicator, ["Entry"] = entry, ["Years"] = Years };

        var dialog = DialogService.Show<EditEntryDialog>("Edit entry", parameters);
        var result = await dialog.Result;

        if (!result.Cancelled)
        {
            var editedEntry = (Entry)result.Data;
            editedEntry.UpdatedBy = _user.GetFormattedName();
            Snackbar.Add($"Click submit to confirm update of entry dated {editedEntry.StartDate.ToLongDateString()}",
                Severity.Info);
        }
    }

    private async Task DeleteEntry(Entry entry)
    {
        var result = await DialogService.ShowMessageBox(
            $"Delete entry dated {entry.StartDate.ToLongDateString()}?",
            "",
            "Delete", cancelText: "Cancel");
        if (result == true)
        {
            Indicator!.Entries.Remove(entry);
            Snackbar.Add($"Click submit to confirm deletion of entry dated {entry.StartDate.ToLongDateString()}",
                Severity.Info);
        }
    }
}
