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

namespace OurCleanFuture.App.Pages.Actions;

public partial class Edit : IDisposable
{
    private readonly Func<DirectorsCommittee, string> _committeeConverter = d => d.Name;
    private AppDbContext _context = null!;
    private bool _isLoaded;
    private ClaimsPrincipal _user = null!;

    [Parameter] public int Id { get; set; }

    private string AuthorizedRoles { get; set; } = "Administrator, 1";

    private IEnumerable<Lead> SelectedLeads { get; set; } = new List<Lead>();

    private List<Objective> Objectives { get; set; } = new();
    private List<Lead> Leads { get; set; } = new();
    private Action Action { get; set; } = null!;

    private IEnumerable<DirectorsCommittee> SelectedDirectorsCommittees { get; set; } =
        new List<DirectorsCommittee>();

    private List<DirectorsCommittee> DirectorsCommittees { get; set; } = new();

    [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

    [Inject] private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject] private NavigationManager Navigation { get; set; } = null!;

    [Inject] private ISnackbar Snackbar { get; set; } = null!;

    [Inject] private StateContainerService StateContainer { get; init; } = null!;

    public void Dispose() => _context.Dispose();

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _context = ContextFactory.CreateDbContext();
            Leads = await _context.Leads
                .Include(l => l.Organization)
                .Include(l => l.Branch)
                .ThenInclude(b => b!.Department)
                .OrderBy(l => l.Branch!.Department.ShortName)
                .ThenBy(l => l.Branch!.Name)
                .ToListAsync();
            Objectives = await _context.Objectives
                .Include(o => o.Area)
                .OrderBy(o => o.Area.Title)
                .ThenBy(o => o.Title)
                .ToListAsync();
            DirectorsCommittees = await _context.DirectorsCommittees
                .OrderBy(dc => dc.Name)
                .ToListAsync();
#pragma warning disable CS8601 // Possible null reference assignment.
            Action = await _context.Actions
                .Include(a => a.Indicators)
                .Include(a => a.DirectorsCommittees)
                .Include(a => a.Leads)
                .AsSingleQuery()
                .FirstOrDefaultAsync(a => a.Id == Id);
#pragma warning restore CS8601 // Possible null reference assignment.
            if (Action != null)
            {
                foreach (var committee in Action!.DirectorsCommittees)
                {
                    SelectedDirectorsCommittees = SelectedDirectorsCommittees.Append(committee);
                }

                foreach (var lead in Action.Leads)
                {
                    SelectedLeads = SelectedLeads.Append(lead);
                }
            }

            await GetUserPrincipal();
            AuthorizedRoles += GetAuthorizedRoles();
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

    private async Task GetUserPrincipal()
    {
        var authState = await AuthenticationStateTask;
        _user = authState.User;
    }

    private string GetAuthorizedRoles()
    {
        var authorizedRoles = "";
        foreach (var lead in Action.Leads)
        {
            authorizedRoles += $", {lead.Id}";
        }

        return authorizedRoles;
    }

    private async Task Update()
    {
        if (
            Action.TargetCompletionDate < Action.ActualCompletionDate
            && Action.InternalStatus == InternalStatus.OnTrack
        )
        {
            Snackbar.Add(
                "The <b>Internal Status</b> cannot be set to <b>On track</b>, as the <b>Actual/Anticipated Completion Date</b> occurs after the <b>Target Completion Date</b>."
                + " Either revise the <b>Actual/Anticipated Completion Date</b>, or change the <b>Internal Status</b> to <b>Delayed</b>.",
                Severity.Error
            );
            return;
        }

        if (_context.Entry(Action).Property(a => a.InternalStatus).IsModified)
        {
            Action.InternalStatusUpdatedBy = _user.GetFormattedName();
            Action.InternalStatusUpdatedDate = DateTimeOffset.Now;
        }

        if (_context.Entry(Action).Property(a => a.ExternalStatus).IsModified)
        {
            Action.ExternalStatusUpdatedBy = _user.GetFormattedName();
            Action.ExternalStatusUpdatedDate = DateTimeOffset.Now;
        }

        Action.DirectorsCommittees.Clear();
        Action.DirectorsCommittees.AddRange(SelectedDirectorsCommittees);

        Action.Leads.Clear();
        Action.Leads.AddRange(SelectedLeads);

        await _context.SaveChangesAsync();
        Snackbar.Add($"Successfully updated action: {Action.Number}", Severity.Success);
        Log.Information(
            "{User} updated action {ActionId}: {ActionTitle}",
            StateContainer.ClaimsPrincipalEmail,
            Action.Id,
            Action.Title
        );
        Navigation.NavigateTo($"/actions/details/{Id}");
    }
}
