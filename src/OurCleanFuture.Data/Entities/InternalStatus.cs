using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities
{
    public enum InternalStatus
    {
        [Display(Name = "Complete")]
        Complete = 0,
        [Display(Name = "Delayed")]
        Delayed = 1,
        [Display(Name = "Not Applicable")]
        NotApplicable = 2,
        [Display(Name = "Not Started")]
        NotStarted = 3,
        [Display(Name = "On Track")]
        OnTrack = 4
    }
}