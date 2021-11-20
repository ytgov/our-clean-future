using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.Data.Entities
{
    public enum QuarterInterval
    {
        [Display(Name = "January 1st to March 31st")]
        JanuaryToMarch = 0,
        [Display(Name = "April 1st to June 30th")]
        AprilToJune = 1,
        [Display(Name = "July 1st to September 30th")]
        JulyToSeptember = 2,
        [Display(Name = "October 1st to December 31st")]
        OctoberToDecember = 3
    }
}
