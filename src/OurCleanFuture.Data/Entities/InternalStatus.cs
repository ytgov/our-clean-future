using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public enum InternalStatus
{
    [Display(Name = "Complete")]
    Complete = 1,

    [Display(Name = "Delayed")]
    Delayed = 2,

    [Display(Name = "Not started")]
    NotStarted = 3,

    [Display(Name = "In progress")]
    InProgress = 4
}
