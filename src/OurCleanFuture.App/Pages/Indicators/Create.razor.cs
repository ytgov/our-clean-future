﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using OurCleanFuture.App.Extensions;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using System.Security.Claims;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Indicators;

[Authorize(Roles = "Administrator, 1")]
public partial class Create : IDisposable
{
    private bool isLoaded;
    private AppDbContext context = null!;
    private ClaimsPrincipal user = null!;

    private string SelectedParentType { get; set; } = "";
    private IEnumerable<Lead> SelectedLeads { get; set; } = new List<Lead>();

    private List<Lead> Leads { get; set; } = new();
    private List<UnitOfMeasurement> UnitsOfMeasurement { get; set; } = new();
    private List<Goal> Goals { get; set; } = new();
    private List<Objective> Objectives { get; set; } = new();
    private List<Action> Actions { get; set; } = new();
    private Indicator Indicator { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

    [Inject]
    private IDbContextFactory<AppDbContext> ContextFactory { get; set; } = null!;

    [Inject]
    private NavigationManager Navigation { get; set; } = null!;

    [Inject]
    private ISnackbar Snackbar { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        try {
            context = ContextFactory.CreateDbContext();
            Leads = await context.Leads.Include(l => l.Organization).Include(l => l.Branch).ThenInclude(b => b!.Department).OrderBy(l => l.Branch!.Department.ShortName).ThenBy(l => l.Branch!.Name).ToListAsync();
            UnitsOfMeasurement = await context.UnitsOfMeasurement.ToListAsync();
            Goals = await context.Goals.OrderBy(g => g.Title).ToListAsync();
            Objectives = await context.Objectives.Include(o => o.Area).OrderBy(o => o.Area.Title).ThenBy(o => o.Title).ToListAsync();
            Actions = await context.Actions.ToListAsync();
            Indicator = new Indicator {
                UnitOfMeasurement = UnitsOfMeasurement.OrderBy(u => u.Symbol).First()
            };
            GetSelectedParentType();
            await GetUserPrincipal();
        }
        catch (Exception ex) {
            Log.Error("{Exception}", ex);
            throw;
        }
        finally {
            isLoaded = true;
        }

        await base.OnInitializedAsync();
    }

    private async Task GetUserPrincipal()
    {
        var authState = await AuthenticationStateTask;
        user = authState.User;
    }

    private void GetSelectedParentType()
    {
        if (Indicator.Goal is not null) {
            SelectedParentType = "Goal";
        }
        else if (Indicator.Objective is not null) {
            SelectedParentType = "Objective";
        }
        else if (Indicator.Action is not null) {
            SelectedParentType = "Action";
        }
    }

    private async Task Update()
    {
        switch (SelectedParentType) {
            case "Goal":
                Indicator.Objective = null;
                Indicator.Action = null;
                break;

            case "Objective":
                Indicator.Goal = null;
                Indicator.Action = null;
                break;

            case "Action":
                Indicator.Goal = null;
                Indicator.Objective = null;
                break;

            default:
                Indicator.Goal = null;
                Indicator.Objective = null;
                Indicator.Action = null;
                break;
        }

        Indicator.Leads.Clear();
        foreach (var lead in SelectedLeads) {
            Indicator.Leads.Add(lead);
        }

        Indicator.UpdatedBy = user.GetFormattedName();
        context.Indicators.Add(Indicator);
        await context.SaveChangesAsync();
        Snackbar.Add($"Successfully created indicator: {Indicator.Title}", Severity.Success);
        Navigation.NavigateTo($"/indicators/details/{Indicator.Id}");
    }

    private void CreateTarget()
    {
        Indicator.Target = new Target();
        context.Attach(Indicator.Target);
    }

    private void DeleteTarget()
    {
        Indicator.Target = null;
        StateHasChanged();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}