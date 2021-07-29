using System.Collections.Generic;

namespace ClimateChangeIndicators.Data.Entities
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
            if (Branch is null) {
                return $"{Organization.Name}";
            }
            else {
                return $"{Organization.Name} | {Branch.Department.Name} | {Branch.Name}";
            }
        }
    }
}