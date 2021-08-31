using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Indicator
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";

        public int OwnerId { get; set; }
        public Owner Owner { get; set; } = null!;

        public string Description { get; set; } = "";
        public int UnitOfMeasurementId { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; } = null!;
        public string Target { get; set; } = "";
        public DataType DataType { get; set; }

        public int OurCleanFutureReferenceId { get; set; }
        public OurCleanFutureReference OurCleanFutureReference { get; set; } = null!;

        public CollectionInterval CollectionInterval { get; set; }
        public List<Entry> Entries { get; set; } = new();

        public string Notes { get; set; } = "";
        public bool IsActive { get; set; }
    }
}