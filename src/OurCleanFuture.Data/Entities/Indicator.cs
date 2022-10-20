using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public class Indicator
{
    public int Id { get; set; }

    [StringLength(
        100,
        MinimumLength = 5,
        ErrorMessage = "{0} must be between {2} and {1} characters."
    )]
    public string Title { get; set; } = "";

    public List<Lead> Leads { get; set; } = new();
    public List<IndicatorLead> IndicatorLeads { get; set; } = new();

    [StringLength(
        500,
        MinimumLength = 1,
        ErrorMessage = "{0} must be between {2} and {1} characters."
    )]
    public string Description { get; set; } = "";

    public int UnitOfMeasurementId { get; set; }
    public UnitOfMeasurement UnitOfMeasurement { get; set; } = null!;
    public DataType DataType { get; set; }

    [ValidateComplexType] public Target? Target { get; set; }

    public int? ActionId { get; set; }
    public Action? Action { get; set; }

    public int? ObjectiveId { get; set; }
    public Objective? Objective { get; set; }

    public int? GoalId { get; set; }
    public Goal? Goal { get; set; }

    public CollectionInterval CollectionInterval { get; set; }
    public List<Entry> Entries { get; set; } = new();

    [StringLength(2000, ErrorMessage = "{0} has a maximum length of {1} characters.")]
    public string Note { get; set; } = "";

    [StringLength(100)] public string UpdatedBy { get; set; } = "";

    public string LeadsToString()
    {
        var result = "";
        if (Leads.Count != 0)
        {
            foreach (var lead in Leads)
            {
                result += $"{lead}, ";
            }

            //Trim the trailing comma and space
            result = result.Remove(result.Length - 2, 2);
        }
        else
        {
            result = "None";
        }

        return result;
    }
}
