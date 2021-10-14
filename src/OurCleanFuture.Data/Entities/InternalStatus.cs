using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities
{
    public enum InternalStatus
    {
        [Display(Name = "Complete")]
        Complete = 0,
        [Display(Name = "Delayed")]
        Delayed = 1,
        [Display(Name = "Not applicable")]
        NotApplicable = 2,
        [Display(Name = "Not started")]
        NotStarted = 3,
        [Display(Name = "On track")]
        OnTrack = 4
    }
}