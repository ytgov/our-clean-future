namespace OurCleanFuture.Data.Entities;

public class IndigenousGroup
{
    public int Id { get; set; }
    public string AbbreviatedName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public List<Action> Actions { get; set; } = new();
}
