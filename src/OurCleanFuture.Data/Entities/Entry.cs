namespace OurCleanFuture.Data.Entities;

public class Entry
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Value { get; set; }
    public string Note { get; set; } = "";
    public string UpdatedBy { get; set; } = "";

    public Indicator Indicator { get; set; } = null!;

    public string EntryValueToString()
    {
        var result = Value.ToString();
        // Switching on Id here, as end users have access to change the Name and Symbol.
        result = Indicator.UnitOfMeasurement.Id switch {
            // Count
            2 => Value.ToString(),
            // Dollars
            4 => Value.ToString("c"),
            // All other units
            _ => $"{Value} {Indicator.UnitOfMeasurement.Symbol}",
        };
        return result;
    }
}