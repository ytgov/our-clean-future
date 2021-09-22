using System.Collections.Generic;

namespace OurCleanFuture.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; } = null!;
        public Branch? Branch { get; set; }
        public List<Indicator> Indicators { get; set; } = new();
        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Branch?.Name)) {
                return $"{Organization.Name}";
            }
            else {
                return $"{Branch.Department.ShortName} | {Branch.Name}";
            }
        }
    }
}