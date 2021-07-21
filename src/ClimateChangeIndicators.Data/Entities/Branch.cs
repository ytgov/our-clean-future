using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}