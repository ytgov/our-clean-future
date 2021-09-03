using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Target
    {
        public int Id { get; set; }
        public double? Value { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string OcfDescription { get; set; } = "";

        public int IndicatorId { get; set; }
        public Indicator Indicator { get; set; } = null!;
    }
}
