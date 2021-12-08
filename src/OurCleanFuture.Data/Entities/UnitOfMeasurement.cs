using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class UnitOfMeasurement
{
    public int Id { get; set; }

    [StringLength(100, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string Name { get; set; } = "";

    [StringLength(50, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string Symbol { get; set; } = "";

    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Symbol)) {
            return Name;
        }
        else {
            return Symbol;
        }
    }
}