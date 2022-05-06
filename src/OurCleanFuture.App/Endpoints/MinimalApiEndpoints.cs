using Microsoft.EntityFrameworkCore;
using OurCleanFuture.App.Extensions;
using OurCleanFuture.Data;

namespace OurCleanFuture.App.Endpoints;

public static class MinimalApiEndpoints
{
    public static void MapIndicatorEndpoints(this WebApplication app)
    {
        app.MapGet("api/v1/indicators", GetIndicators)
            .WithTags("Indicators")
            .WithName("GetIndicators")
            .Produces<List<IndicatorDTO>>(200)
            .ProducesProblem(400);

        app.MapGet("api/v1/indicators/{id}", GetIndicatorById)
            .WithTags("Indicators")
            .WithName("GetIndicatorById")
            .Produces<IndicatorDTO>(200)
            .Produces(404)
            .ProducesProblem(400);
    }

    private static async Task<IResult> GetIndicators(AppDbContext context, int? page, int? pageSize)
    {
        var pagerTake = pageSize ?? 50;
        int pagerSkip;
        if (page is not null && page > 1)
        {
            pagerSkip = (int)((page - 1) * pagerTake);
        }
        else
        {
            pagerSkip = 0;
        }
        var indicators = await context.Indicators.Select(i => new IndicatorDTO()
        {
            Id = i.Id,
            Title = i.Title,
            Description = i.Description,
            CollectionInterval = i.CollectionInterval.ToString(),
            UnitOfMeasurementName = i.UnitOfMeasurement.Name,
            UnitOfMeasurementSymbol = i.UnitOfMeasurement.Symbol,
            Leads = i.Leads.Select(l => new LeadDTO()
            {
                Id = l.Id,
                Organization = l.Organization.Name,
                Department = l.Branch!.Department.Name,
                Branch = l.Branch.Name
            }).ToList(),
            ParentType = i.Action != null ? nameof(i.Action) : (i.Objective != null ? nameof(i.Objective) : nameof(i.Goal)),
            Goals = i.Action != null ? i.Action.Objective.Goals.Select(g => new GoalDTO()
            {
                Id = g.Id,
                Title = g.Title
            }).ToList() : (i.Objective != null ? i.Objective.Goals.Select(g => new GoalDTO()
            {
                Id = g.Id,
                Title = g.Title
            }).ToList() : new List<GoalDTO>() { new GoalDTO() { Id = i.Id, Title = i.Title } }),
            AreaId = i.Action == null ? i.Objective!.Area.Id : i.Action.Objective.Area.Id,
            AreaTitle = i.Action == null ? i.Objective!.Area.Title : i.Action.Objective.Area.Title,
            ObjectiveId = i.Objective == null ? i.Action!.Objective.Id : i.Objective.Id,
            ObjectiveTitle = i.Objective == null ? i.Action!.Objective.Title : i.Objective.Title,
            ActionId = i.Action == null ? null : i.Action.Id,
            ActionNumber = i.Action == null ? default : i.Action.Number,
            ActionTitle = i.Action == null ? default : i.Action.Title,
            Entries = i.Entries.Select(e => new EntryDTO()
            {
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Value = e.Value,
                Note = e.Note,
                LastUpdatedBy = e.UpdatedBy
            }).ToList(),
            TargetDescription = i.Target == null ? default : i.Target.Description,
            TargetValue = i.Target == null ? default : i.Target.Value,
            TargetCompletionDate = i.Target == null ? default : i.Target.CompletionDate
        }).Skip(pagerSkip).Take(pagerTake).AsNoTracking().ToListAsync();

        return Results.Ok(indicators);
    }

    private static async Task<IResult> GetIndicatorById(AppDbContext context, int id)
    {
        var indicator = await context.Indicators.Select(i => new IndicatorDTO()
        {
            Id = i.Id,
            Title = i.Title,
            Description = i.Description,
            CollectionInterval = i.CollectionInterval.ToString(),
            UnitOfMeasurementName = i.UnitOfMeasurement.Name,
            UnitOfMeasurementSymbol = i.UnitOfMeasurement.Symbol,
            Leads = i.Leads.Select(l => new LeadDTO()
            {
                Id = l.Id,
                Organization = l.Organization.Name,
                Department = l.Branch!.Department.Name,
                Branch = l.Branch.Name
            }).ToList(),
            ParentType = i.Action != null ? nameof(i.Action) : (i.Objective != null ? nameof(i.Objective) : nameof(i.Goal)),
            Goals = i.Action != null ? i.Action.Objective.Goals.Select(g => new GoalDTO()
            {
                Id = g.Id,
                Title = g.Title
            }).ToList() : (i.Objective != null ? i.Objective.Goals.Select(g => new GoalDTO()
            {
                Id = g.Id,
                Title = g.Title
            }).ToList() : new List<GoalDTO>() { new GoalDTO() { Id = i.Id, Title = i.Title } }),
            AreaId = i.Action == null ? i.Objective!.Area.Id : i.Action.Objective.Area.Id,
            AreaTitle = i.Action == null ? i.Objective!.Area.Title : i.Action.Objective.Area.Title,
            ObjectiveId = i.Objective == null ? i.Action!.Objective.Id : i.Objective.Id,
            ObjectiveTitle = i.Objective == null ? i.Action!.Objective.Title : i.Objective.Title,
            ActionId = i.Action == null ? null : i.Action.Id,
            ActionNumber = i.Action == null ? default : i.Action.Number,
            ActionTitle = i.Action == null ? default : i.Action.Title,
            Entries = i.Entries.Select(e => new EntryDTO()
            {
                StartDate = e.StartDate,
                EndDate = e.EndDate,
                Value = e.Value,
                Note = e.Note,
                LastUpdatedBy = e.UpdatedBy
            }).ToList(),
            TargetDescription = i.Target == null ? default : i.Target.Description,
            TargetValue = i.Target == null ? default : i.Target.Value,
            TargetCompletionDate = i.Target == null ? default : i.Target.CompletionDate
        }).Where(i => i.Id == id).FirstOrDefaultAsync();

        return indicator is not null ? Results.Ok(indicator) : Results.NotFound();
    }

    public static void MapActionEndpoints(this WebApplication app)
    {
        app.MapGet("api/v1/actions", GetActions)
            .WithTags("Actions")
            .WithName("GetActions")
            .Produces<List<ActionDTO>>(200)
            .ProducesProblem(400);

        app.MapGet("api/v1/actions/{id}", GetActionById)
            .WithTags("Actions")
            .WithName("GetActionById")
            .Produces<ActionDTO>(200)
            .Produces(404)
            .ProducesProblem(400);
    }

    private static async Task<IResult> GetActions(AppDbContext context)
    {
        var actions = await context.Actions.Select(a => new ActionDTO()
        {
            Id = a.Id,
            Number = a.Number,
            Title = a.Title,
            Leads = a.Leads.Select(l => new LeadDTO()
            {
                Id = l.Id,
                Organization = l.Organization.Name,
                Department = l.Branch!.Department.Name,
                Branch = l.Branch.Name
            }).ToList(),
            InternalStatus = a.InternalStatus.GetDisplayName(),
            ExternalStatus = a.ExternalStatus.GetDisplayName(),
            ActualOrAnticipatedCompletionDate = a.ActualCompletionDate,
            TargetCompletionDate = a.TargetCompletionDate,
            IndicatorCount = a.Indicators.Count,
            Indicators = a.Indicators.Select(i => new
            {
                i.Id,
                i.Title
            }).ToList()
        }).AsNoTracking().ToListAsync();

        return Results.Ok(actions);
    }

    private static async Task<IResult> GetActionById(AppDbContext context, int id)
    {
        var action = await context.Actions.Select(a => new ActionDTO()
        {
            Id = a.Id,
            Number = a.Number,
            Title = a.Title,
            Leads = a.Leads.Select(l => new LeadDTO()
            {
                Id = l.Id,
                Organization = l.Organization.Name,
                Department = l.Branch!.Department.Name,
                Branch = l.Branch.Name
            }).ToList(),
            InternalStatus = a.InternalStatus.GetDisplayName(),
            ExternalStatus = a.ExternalStatus.GetDisplayName(),
            ActualOrAnticipatedCompletionDate = a.ActualCompletionDate,
            TargetCompletionDate = a.TargetCompletionDate,
            IndicatorCount = a.Indicators.Count,
            Indicators = a.Indicators.Select(i => new
            {
                i.Id,
                i.Title
            }).ToList()
        }).Where(a => a.Id == id).FirstOrDefaultAsync();

        return action is not null ? Results.Ok(action) : Results.NotFound();
    }

    public static void MapAreaEndpoints(this WebApplication app)
    {
        app.MapGet("api/v1/areas", GetAreas)
            .WithTags("Areas")
            .WithName("GetAreas")
            .Produces<List<AreaDTO>>(200)
            .ProducesProblem(400);
        app.MapGet("api/v1/areas/{id}", GetAreaById)
            .WithTags("Areas")
            .WithName("GetAreaById")
            .Produces<AreaDTO>(200)
            .Produces(404)
            .ProducesProblem(400);
    }

    private static async Task<IResult> GetAreas(AppDbContext context)
    {
        var areas = await context.Areas.Select(a => new AreaDTO()
        {
            Id = a.Id,
            Title = a.Title,
            Objectives = a.Objectives.Select(o => new ObjectiveDTO()
            {
                Id = o.Id,
                Title = o.Title,
                Goals = o.Goals.Select(g => new GoalDTO()
                {
                    Id = g.Id,
                    Title = g.Title
                }).ToList()
            }).ToList()
        }).ToListAsync();

        return Results.Ok(areas);
    }

    private static async Task<IResult> GetAreaById(AppDbContext context, int id)
    {
        var area = await context.Areas.Select(a => new AreaDTO()
        {
            Id = a.Id,
            Title = a.Title,
            Objectives = a.Objectives.Select(o => new ObjectiveDTO()
            {
                Id = o.Id,
                Title = o.Title,
                Goals = o.Goals.Select(g => new GoalDTO()
                {
                    Id = g.Id,
                    Title = g.Title
                }).ToList()
            }).ToList()
        }).Where(a => a.Id == id).FirstOrDefaultAsync();

        return area is not null ? Results.Ok(area) : Results.NotFound();
    }

    private record AreaDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<ObjectiveDTO> Objectives { get; set; } = null!;
    }

    private record ObjectiveDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<GoalDTO> Goals { get; set; } = null!;
    }

    private record IndicatorDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? CollectionInterval { get; set; }
        public string UnitOfMeasurementName { get; set; } = null!;
        public string UnitOfMeasurementSymbol { get; set; } = null!;
        public List<LeadDTO> Leads { get; set; } = null!;
        public string ParentType { get; set; } = null!;
        public List<GoalDTO> Goals { get; set; } = null!;
        public int? AreaId { get; set; }
        public string? AreaTitle { get; set; }
        public int? ObjectiveId { get; set; }
        public string? ObjectiveTitle { get; set; }
        public int? ActionId { get; set; }
        public string? ActionNumber { get; set; }
        public string? ActionTitle { get; set; }
        public List<EntryDTO> Entries { get; set; } = null!;
        public string? TargetDescription { get; set; }
        public double? TargetValue { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
    };

    private record EntryDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Value { get; set; }
        public string Note { get; set; } = null!;
        public string LastUpdatedBy { get; set; } = null!;
    }

    private record GoalDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }

    private record ActionDTO
    {
        public int Id { get; set; }
        public string Number { get; set; } = null!;
        public string Title { get; set; } = null!;
        public List<LeadDTO> Leads { get; set; } = null!;
        public string InternalStatus { get; set; } = null!;
        public string ExternalStatus { get; set; } = null!;
        public DateTime? ActualOrAnticipatedCompletionDate { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public int IndicatorCount { get; set; }
        public object Indicators { get; set; } = null!;
    }

    private record LeadDTO
    {
        public int Id { get; set; }
        public string Organization { get; set; } = null!;
        public string? Department { get; set; }
        public string? Branch { get; set; }
    }
}
