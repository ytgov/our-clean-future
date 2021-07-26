using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";
    }
}