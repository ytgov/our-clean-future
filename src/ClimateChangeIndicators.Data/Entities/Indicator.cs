using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Indicator
    {
        public int Id { get; set; }

        [Required]
        public string DisplayName { get; set; }

        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        [Required]
        public string Description { get; set; }

        public string Target { get; set; }
        public DataType DataType { get; set; }
        public int OurCleanFutureReferenceId { get; set; }
        public OurCleanFutureReference OurCleanFutureReference { get; set; }
        public CollectionInterval CollectionInterval { get; set; }
        public List<Entry> Entries { get; set; } = new List<Entry>();
        public string Notes { get; set; }
        public bool IsActive { get; set; }
    }
}