using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class DirectorsCommittee
{
    public int Id { get; set; }

    [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string Name { get; set; } = "";

    public List<Action> Actions { get; set; } = new();
}
