using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class Branch
{
    public int Id { get; set; }

    [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string Name { get; set; } = "";

    public Lead Lead { get; set; } = null!;

    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
}