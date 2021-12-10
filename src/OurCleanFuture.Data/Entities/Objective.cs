using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class Objective
{
    public int Id { get; set; }

    [StringLength(250, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string Title { get; set; } = "";

    public int AreaId { get; set; }
    public Area Area { get; set; } = null!;
    public List<Goal> Goals { get; set; } = new();
    public List<Action> Actions { get; set; } = new();
    public List<Indicator> Indicators { get; set; } = new();
}