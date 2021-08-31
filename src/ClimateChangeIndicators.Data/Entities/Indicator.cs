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
        public string Target { get; set; } = "";
        public DataType DataType { get; set; }

        public int OurCleanFutureReferenceId { get; set; }
        public OurCleanFutureReference OurCleanFutureReference { get; set; } = null!;

        public CollectionInterval CollectionInterval { get; set; }
        public List<Entry> Entries { get; set; } = new();

        public string Notes { get; set; } = "";
        public bool IsActive { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Owner.Branch?.Name)) {
                return $"{Owner.Organization.Name}";
            }
            else {
                return $"{Owner.Branch.Department.Name} | {Owner.Branch.Name}";
            }
        }
    }
}