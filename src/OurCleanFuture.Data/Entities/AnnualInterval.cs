using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.Data.Entities
{
    public enum AnnualInterval
    {
        [Display(Name = "January 1st to December 31st")]
        JanuaryToDecember = 0
    }
}
