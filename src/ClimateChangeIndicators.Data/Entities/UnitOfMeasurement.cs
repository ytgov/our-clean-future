using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public class UnitOfMeasurement
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }
    }
}