namespace OurCleanFuture.Data.Entities;

public class DirectorsCommittee
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public List<Action> Actions { get; set; } = new();
}