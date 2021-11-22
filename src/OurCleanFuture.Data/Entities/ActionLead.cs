namespace OurCleanFuture.Data.Entities;

public class ActionLead
{
    public int ActionId { get; set; }
    public Action Action { get; set; } = null!;

    public int LeadId { get; set; }
    public Lead Lead { get; set; } = null!;
}