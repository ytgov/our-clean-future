namespace OurCleanFuture.Data.Entities;

public class Area
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public List<Objective> Objectives { get; set; } = new();
}