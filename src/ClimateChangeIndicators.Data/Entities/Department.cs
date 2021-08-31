using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string ShortName { get; set; } = "";

        public List<Branch> Branches { get; set; } = new();
    }
}