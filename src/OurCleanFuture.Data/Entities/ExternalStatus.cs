using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities
{
    public enum ExternalStatus
    {
        [Display(Name = "Complete")]
        Complete = 0,
        [Display(Name = "In progress")]
        InProgress = 1,
        [Display(Name = "Not started")]
        NotStarted = 2,
        [Display(Name = "Ongoing")]
        Ongoing = 3
    }
}