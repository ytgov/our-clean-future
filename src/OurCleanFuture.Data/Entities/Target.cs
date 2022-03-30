using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class Target
{
    public int Id { get; set; }
    public double? Value { get; set; }
    public DateTime? CompletionDate { get; set; }

    [StringLength(500, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters.")]
    public string Description { get; set; } = "";

    public int IndicatorId { get; set; }
    public Indicator Indicator { get; set; } = null!;

    public string ValueToString()
    {
        if (Value is not null) {
            var value = (double)Value;
            var result = Indicator.UnitOfMeasurement.Name switch {
                "Count" => value.ToString(),
                "Dollars" => value.ToString("c"),
                // All other units
                _ => $"{value:n} {Indicator.UnitOfMeasurement.Symbol}",
            };
            return result;
        }
        else {
            return "";
        }
    }
}
