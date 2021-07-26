using System;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double MeasuredValue { get; set; }
        public int UnitOfMeasurementId { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; } = null!;

        public Indicator Indicator { get; set; } = null!;
    }
}