namespace OurCleanFuture.Data.Entities;

public class Lead
{
    public int Id { get; set; }
    public int OrganizationId { get; set; }
    public Organization Organization { get; set; } = null!;
    public int? BranchId { get; set; }
    public Branch? Branch { get; set; }
    public List<Indicator> Indicators { get; set; } = new();
    public List<IndicatorLead> IndicatorLeads { get; set; } = new();
    public List<Action> Actions { get; set; } = new();
    public List<ActionLead> ActionLeads { get; set; } = new();

    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Branch?.Name)) {
            return $"{Organization.Name}";
        }
        else {
            return $"{Branch.Department.ShortName} | {Branch.Name}";
        }
    }
}