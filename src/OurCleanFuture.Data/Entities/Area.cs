using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class Area
{
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string Title { get; set; } = "";

    public List<Objective> Objectives { get; set; } = new();
}
