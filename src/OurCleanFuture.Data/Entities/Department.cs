using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class Department
{
    public int Id { get; set; }

    [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string Name { get; set; } = "";

    [StringLength(10, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string ShortName { get; set; } = "";

    public List<Branch> Branches { get; set; } = new();
}
