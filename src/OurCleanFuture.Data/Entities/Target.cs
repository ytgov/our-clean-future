using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurCleanFuture.Data.Entities
{
    public class Target
    {
        public int Id { get; set; }
        public double? Value { get; set; }
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage ="Completion Date is required.")]
        public DateTime? EndDate { get; set; }
        [MinLength(1, ErrorMessage = "OCF Description is required.")]
        public string OcfDescription { get; set; } = "";

        public int IndicatorId { get; set; }
        public Indicator Indicator { get; set; } = null!;
    }
}
