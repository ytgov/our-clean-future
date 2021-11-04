using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities
{
    public enum ExternalStatus
    {
        [Display(Name = "N/A")]
        NotApplicable = 0,
        [Display(Name = "Complete")]
        Complete = 1,
        [Display(Name = "In progress")]
        InProgress = 2,
        [Display(Name = "Not started")]
        NotStarted = 3,
        [Display(Name = "Ongoing")]
        Ongoing = 4
    }
}