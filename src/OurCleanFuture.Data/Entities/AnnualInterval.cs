using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities;

public enum AnnualInterval
{
    [Display(Name = "January 1st to December 31st")]
    JanuaryToDecember = 0
}
