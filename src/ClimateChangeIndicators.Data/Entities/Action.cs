using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Action
    {
        public int Id { get; set; }

        public string ReferenceNumber { get; set; } = "";

        public string ReferenceText { get; set; } = "";

        public List<Indicator> Indicators { get; set; } = new();
    }
}