using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities
{
    public enum BiannualInterval
    {
        [Display(Name = "January 1st to June 30th")]
        JanuaryToJune = 0,

        [Display(Name = "July 1st to December 31st")]
        JulyToDecember = 1
    }
}