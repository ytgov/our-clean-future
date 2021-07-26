using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public class UnitOfMeasurement
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Symbol { get; set; } = "";
    }
}