using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public class OurCleanFutureReference
    {
        public int Id { get; set; }

        //Alternative name: ReferenceText?
        [Required]
        public string Description { get; set; }

        public List<Indicator> Indicators { get; set; }
    }
}