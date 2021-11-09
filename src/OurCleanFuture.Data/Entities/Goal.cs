namespace OurCleanFuture.Data.Entities;

public class Goal
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public List<Objective> Objectives { get; set; } = new();
    public List<Indicator> Indicators { get; set; } = new();
}