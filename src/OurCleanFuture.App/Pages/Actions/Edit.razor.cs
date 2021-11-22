using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;
using System.Security.Claims;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.App.Pages.Actions;

public partial class Edit : IDisposable
{
    private bool isLoaded;
    private AppDbContext context = null!;
    private ClaimsPrincipal user = null!;
    private Func<DirectorsCommittee, string> committeeConverter = d => d.Name;

    [Parameter]
    public int Id { get; set; }

    public string AuthorizedRoles { get; set; } = "Administrator, ENV-CCS.Writer";
    public string SelectedParentType { get; set; } = "";
    public IEnumerable<Lead> SelectedLeads { get; set; } = new List<Lead>();

    public List<Goal> Goals { get; set; } = new();
    public List<Objective> Objectives { get; set; } = new();
    public List<Lead> Leads { get; set; } = new();
    public Action Action { get; set; } = null!;
    public List<Indicator> Indicators { get; set; } = new();
    public IEnumerable<DirectorsCommittee> SelectedDirectorsCommittees { get; set; } = new List<DirectorsCommittee>();
    public List<DirectorsCommittee> DirectorsCommittees { get; set; } = new();

    [CascadingParameter]
    private Task<AuthenticationState> AuthenticationStateTask { get; set; } = null!;

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
            Leads = await context.Leads.Include(l => l.Organization).Include(l => l.Branch).ThenInclude(b => b!.Department).OrderBy(l => l.Branch!.Department.ShortName).ThenBy(l => l.Branch!.Name).ToListAsync();
            Goals = await context.Goals.OrderBy(g => g.Title).ToListAsync();
            Objectives = await context.Objectives.Include(o => o.Area).OrderBy(o => o.Area.Title).ThenBy(o => o.Title).ToListAsync();
            DirectorsCommittees = await context.DirectorsCommittees.OrderBy(dc => dc.Name).ToListAsync();
#pragma warning disable CS8601 // Possible null reference assignment.
            Action = await context.Actions.Include(a => a.Indicators).Include(a => a.DirectorsCommittees).Include(a => a.Leads).FirstOrDefaultAsync(a => a.Id == Id);
#pragma warning restore CS8601 // Possible null reference assignment.
            if (Action != null) {
                foreach (var committee in Action!.DirectorsCommittees) {
                    SelectedDirectorsCommittees = SelectedDirectorsCommittees.Append(committee);
                }
                foreach (var lead in Action.Leads) {
                    SelectedLeads = SelectedLeads.Append(lead);
                }
            }
            await GetUserPrincipal();
            AuthorizedRoles += GetAuthorizedRoles();
        }
        catch (Exception ex) {
            Console.WriteLine(ex);
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

    private string GetAuthorizedRoles()
    {
        var authorizedRoles = "";
        foreach (var lead in Action.Leads) {
            switch (lead.Branch?.Department.ShortName) {
                case "CS":
                    authorizedRoles += ", CS.Writer";
                    break;

                case "EcDev":
                    authorizedRoles += ", EcDev.Writer";
                    break;

                case "EDU":
                    authorizedRoles += ", EDU.Writer";
                    break;

                case "EMR":
                    authorizedRoles += ", EMR.Writer";
                    break;

                case "ENV":
                    authorizedRoles += ", ENV.Writer";
                    break;

                case "ECO":
                    authorizedRoles += ", ECO.Writer";
                    break;

                case "FIN":
                    authorizedRoles += ", FIN.Writer";
                    break;

                case "HSS":
                    authorizedRoles += ", HSS.Writer";
                    break;

                case "HPW":
                    authorizedRoles += ", HPW.Writer";
                    break;

                case "JUS":
                    authorizedRoles += ", JUS.Writer";
                    break;

                case "PSC":
                    authorizedRoles += ", PSC.Writer";
                    break;

                case "TC":
                    authorizedRoles += ", TC.Writer";
                    break;

                case "YDC":
                    authorizedRoles += ", YDC.Writer";
                    break;

                case "YEC":
                    authorizedRoles += ", YEC.Writer";
                    break;

                case "YHC":
                    authorizedRoles += ", YHC.Writer";
                    break;

                default:
                    break;
            }
        }
        return authorizedRoles;
    }

    private async Task Update()
    {
        if (context.Entry(Action).Property(a => a.InternalStatus).IsModified) {
            Action.InternalStatusUpdatedBy = user.FindFirst("name")?.Value ?? "";
            Action.InternalStatusUpdatedDate = DateTimeOffset.Now;
        }

        Action.DirectorsCommittees.Clear();
        foreach (var committee in SelectedDirectorsCommittees) {
            Action.DirectorsCommittees.Add(committee);
        }

        Action.Leads.Clear();
        foreach (var lead in SelectedLeads) {
            Action.Leads.Add(lead);
        }

        await context.SaveChangesAsync();
        Snackbar.Add($"Successfully updated action: {Action.Number}", Severity.Success);
        Navigation.NavigateTo($"/actions/details/{Id}");
    }

    public void Dispose()
    {
        context.DisposeAsync();
    }
}