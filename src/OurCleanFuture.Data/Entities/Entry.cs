using System;

namespace OurCleanFuture.Data.Entities
{
    public class Entry
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public string Note { get; set; } = "";

        public Indicator Indicator { get; set; } = null!;
    }
}