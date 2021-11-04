using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities
{
    public enum InternalStatus
    {
        [Display(Name = "N/A")]
        NotApplicable = 0,
        [Display(Name = "Complete")]
        Complete = 1,
        [Display(Name = "Delayed")]
        Delayed = 2,
        [Display(Name = "Not started")]
        NotStarted = 3,
        [Display(Name = "On track")]
        OnTrack = 4
    }
}