using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities
{
    public class Action
    {
        public int Id { get; set; }
        public string Number { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime? StartDate { get; set; }
        public DateTime? TargetCompletionDate { get; set; }
        public DateTime? ActualCompletionDate { get; set; }
        public InternalStatus InternalStatus { get; set; }
        public DateTimeOffset? InternalStatusUpdatedDate { get; set; }
        public ExternalStatus ExternalStatus { get; set; }

        public string PublicExplanation { get; set; } = "";
        public string Note { get; set; } = "";

        public List<Indicator> Indicators { get; set; } = new();
        public Objective Objective { get; set; } = null!;
        public int? ObjectiveId { get; set; }
        public List<DirectorsCommittee> DirectorsCommittees { get; set; } = new();

        public override string ToString()
        {
            return $"{Number}. {Title}";
        }
    }
}