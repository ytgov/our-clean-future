using System;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTimeOffset Date { get; set; }
        public double MeasuredValue { get; set; }
        

        public Indicator Indicator { get; set; } = null!;
    }
}