using Microsoft.EntityFrameworkCore;
using OurCleanFuture.App.Extensions;
using OurCleanFuture.Data;

namespace OurCleanFuture.App.Endpoints;

public static class MinimalApiEndpoints
{
    public static void MapIndicatorEndpoints(this WebApplication app)
    {
        app.MapGet("api/v1/indicators", async (AppDbContext context, int? page, int? pageSize) =>
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
                    Department = l.Branch.Department.Name,
                    Branch = l.Branch.Name
                }).ToList(),
                Goals = i.Action != null ? i.Action.Objective.Goals.Select(g => new GoalDTO()
                {
                    Id = g.Id,
                    Title = g.Title
                }).ToList() : (i.Objective != null ? i.Objective.Goals.Select(g => new GoalDTO()
                {
                    Id = g.Id,
                    Title = g.Title
                }).ToList() : new List<GoalDTO>() { new GoalDTO() { Id = i.Id, Title = i.Title } }),
                AreaTitle = i.Action == null ? i.Objective!.Area.Title : i.Action.Objective.Area.Title,
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
                LastEntryDate = i.Entries.OrderBy(e => e.EndDate).LastOrDefault().EndDate,
                LastEntryBy = i.Entries.OrderBy(e => e.EndDate).LastOrDefault().UpdatedBy,
                LastEntryValue = i.Entries.OrderBy(e => e.EndDate).LastOrDefault().Value,
                TargetDescription = i.Target == null ? default : i.Target.Description,
                TargetValue = i.Target == null ? default : i.Target.Value,
                TargetCompletionDate = i.Target == null ? default : i.Target.CompletionDate
            }).Skip(pagerSkip).Take(pagerTake).AsNoTracking().ToListAsync();

            return indicators;
        }).WithTags("Indicators").WithName("GetIndicators");
    }

    public static void MapActionEndpoints(this WebApplication app)
    {
        app.MapGet("api/v1/actions", async (AppDbContext context) =>
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
                    Department = l.Branch.Department.Name,
                    Branch = l.Branch.Name
                }).ToList(),
                InternalStatus = a.InternalStatus.GetDisplayName(),
                ExternalStatus = a.ExternalStatus.GetDisplayName(),
                ActualOrAnticipatedCompletionDate = a.ActualCompletionDate,
                TargetCompletionDate = a.TargetCompletionDate,
                IndicatorCount = a.Indicators.Count,
            }).AsNoTracking().ToListAsync();

            return actions;
        }).WithTags("Actions").WithName("GetActions");
    }

    private record IndicatorDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? CollectionInterval { get; set; }
        public string UnitOfMeasurementName { get; set; } = null!;
        public string UnitOfMeasurementSymbol { get; set; } = null!;
        public List<LeadDTO> Leads { get; set; }
        public List<GoalDTO> Goals { get; set; }
        public string? AreaTitle { get; set; }
        public string? ObjectiveTitle { get; set; }
        public int? ActionId { get; set; }
        public string? ActionNumber { get; set; }
        public string? ActionTitle { get; set; }
        public List<EntryDTO> Entries { get; set; }
        public DateTime? LastEntryDate { get; set; }
        public string? LastEntryBy { get; set; }
        public decimal? LastEntryValue { get; set; }
        public string? TargetDescription { get; set; }
        public double? TargetValue { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
    };

    private record EntryDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Value { get; set; }
        public string Note { get; set; }
        public string LastUpdatedBy { get; set; }
    }

    private record GoalDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    private record ActionDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public List<LeadDTO> Leads { get; set; }
        public string InternalStatus { get; set; }
        public string ExternalStatus { get; set; }
        public DateTime? ActualOrAnticipatedCompletionDate { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public int IndicatorCount { get; set; }
    }

    private record LeadDTO
    {
        public int Id { get; set; }
        public string Organization { get; set; }
        public string? Department { get; set; }
        public string? Branch { get; set; }
    }
}
