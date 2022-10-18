using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class Organization
{
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string Name { get; set; } = "";
}
