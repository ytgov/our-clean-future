using System.Collections.Generic;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public Organization Organization { get; set; }
        public Branch Branch { get; set; }
        public List<Indicator> Indicators { get; set; }
    }
}