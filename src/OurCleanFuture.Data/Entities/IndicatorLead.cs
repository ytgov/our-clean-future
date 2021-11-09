using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.Data.Entities;

public class IndicatorLead
{
    public int IndicatorId { get; set; }
    public Indicator Indicator { get; set; } = null!;

    public int LeadId { get; set; }
    public Lead Lead { get; set; } = null!;
}
