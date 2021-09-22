using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClimateChangeIndicators.Data.Entities
{
    public class Action
    {
        public int Id { get; set; }
        public string Number { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime? InternalStartDate { get; set; }
        public DateTime? InternalCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public InternalStatus InternalStatus { get; set; }
        public ExternalStatus ExternalStatus { get; set; }

        public string PublicExplanation { get; set; } = "";

        public string Notes { get; set; } = "";

        public List<Indicator> Indicators { get; set; } = new();
        public Objective Objective { get; set; } = null!;
        public int? ObjectiveId { get; set; }

        public override string ToString()
        {
            return $"{Number}. {Title}";
        }
    }
}