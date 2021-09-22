using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities
{
    public enum ExternalStatus
    {
        [Display(Name = "Complete")]
        Complete = 0,
        [Display(Name = "In Progress")]
        InProgress = 1,
        [Display(Name = "Not Started")]
        NotStarted = 2,
        [Display(Name = "Ongoing")]
        Ongoing = 3
    }
}