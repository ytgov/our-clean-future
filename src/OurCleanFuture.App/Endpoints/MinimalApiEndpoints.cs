using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using OurCleanFuture.App.Extensions;
using OurCleanFuture.Data;
using OurCleanFuture.Data.Entities;

namespace OurCleanFuture.App.Endpoints;
public static class MinimalApiEndpoints
{
    public static void IndicatorsEndpoints(this WebApplication app)
    {
        app.MapGet("/indicators", async (AppDbContext context) =>
        {
            var indicators = await context.Indicators.Select(i => new IndicatorDTO()
            {
                Id = i.Id,
                Title = i.Title,
                Description = i.Description,
                CollectionInterval = i.CollectionInterval.ToString(),
                UnitOfMeasurement = i.UnitOfMeasurement.Symbol,
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
                LastEntryDate = i.Entries.OrderBy(e => e.EndDate).LastOrDefault().EndDate.Date.ToString(),
                LastEntryBy = i.Entries.OrderBy(e => e.EndDate).LastOrDefault().UpdatedBy,
                LastEntryValue = i.Entries.OrderBy(e => e.EndDate).LastOrDefault().Value,
                TargetDescription = i.Target == null ? default : i.Target.Description,
                TargetValue = i.Target == null ? default : i.Target.Value,
                TargetCompletionDate = i.Target == null ? default : i.Target.CompletionDate.ToString()
            }).AsNoTracking().ToListAsync();

            return indicators;
        });
    }

    public static void ActionsEndpoints(this WebApplication app)
    {
        app.MapGet("/actions", async (AppDbContext context) =>
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
            }).AsNoTracking().ToListAsync();
            return actions;
        });
    }
    private record IndicatorDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? CollectionInterval { get; set; }
        public string UnitOfMeasurement { get; set; } = null!;
        public List<LeadDTO> Leads { get; set; }
        public List<GoalDTO> Goals { get; set; }
        public string? AreaTitle { get; set; }
        public string? ObjectiveTitle { get; set; }
        public int? ActionId { get; set; }
        public string? ActionNumber { get; set; }
        public string? ActionTitle { get; set; }
        public string? LastEntryDate { get; set; }
        public string? LastEntryBy { get; set; }
        public decimal? LastEntryValue { get; set; }
        public string? TargetDescription { get; set; }
        public double? TargetValue { get; set; }
        public string? TargetCompletionDate { get; set; }
    };

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

    }

    private record LeadDTO
    {
        public int Id { get; set; }
        public string Organization { get; set; }
        public string? Department { get; set; }
        public string? Branch { get; set; }
    }
}
