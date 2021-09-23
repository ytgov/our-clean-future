using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities
{
    public class Indicator
    {
        public int Id { get; set; }

        [MinLength(1, ErrorMessage = "Title is required.")]
        public string Title { get; set; } = "";

        public List<Lead> Leads { get; set; } = new();

        [MinLength(1, ErrorMessage = "Description is required.")]
        public string Description { get; set; } = "";
        public int UnitOfMeasurementId { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; } = null!;
        public DataType DataType { get; set; }
        [ValidateComplexType]
        public Target? Target { get; set; } = null!;

        public int? ActionId { get; set; }
        public Action? Action { get; set; } = null!;

        public int? ObjectiveId { get; set; }
        public Objective? Objective { get; set; } = null!;

        public int? GoalId { get; set; }
        public Goal? Goal { get; set; } = null!;

        public CollectionInterval CollectionInterval { get; set; }
        public List<Entry> Entries { get; set; } = new();

        public string Notes { get; set; } = "";

        public string UpdatedBy { get; set; } = "";

        public string LeadsToString()
        {
            if (Leads.Count == 1) {
                return Leads[0].ToString();
            }
            else {
                var result = "";
                foreach (var lead in Leads) {
                    result += $"{lead}, ";
                }
                //Trim the trailing comma and space
                result = result.Remove(result.Length - 2, 2);
                return result;
            }
        }
    }
}