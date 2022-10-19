using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class Action
{
    public int Id { get; set; }

    [StringLength(3, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string Number { get; set; } = "";

    [StringLength(300, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string Title { get; set; } = "";

    public DateTime? StartDate { get; set; }
    public DateTime? TargetCompletionDate { get; set; }
    public DateTime? ActualCompletionDate { get; set; }

    public InternalStatus InternalStatus { get; set; }

    [StringLength(100)] public string InternalStatusUpdatedBy { get; set; } = "";

    public DateTimeOffset? InternalStatusUpdatedDate { get; set; }

    public ExternalStatus ExternalStatus { get; set; }

    [StringLength(100)] public string ExternalStatusUpdatedBy { get; set; } = "";

    public DateTimeOffset? ExternalStatusUpdatedDate { get; set; }

    [StringLength(1000, ErrorMessage = "{0} has a maximum length of {1} characters.")]
    public string PublicExplanation { get; set; } = "";

    [StringLength(2000, ErrorMessage = "{0} has a maximum length of {1} characters.")]
    public string Note { get; set; } = "";

    public List<Lead> Leads { get; set; } = new();
    public List<ActionLead> ActionLeads { get; set; } = new();
    public List<Indicator> Indicators { get; set; } = new();
    public Objective Objective { get; set; } = null!;
    public int ObjectiveId { get; set; }
    public List<DirectorsCommittee> DirectorsCommittees { get; set; } = new();

    public override string ToString() => $"{Number}. {Title}";
}
