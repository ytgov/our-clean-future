using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Action
    {
        public int Id { get; set; }
        public string Number { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime TargetCompletionDate { get; set; }

        public List<Indicator> Indicators { get; set; } = new();
    }
}