using ClimateChangeIndicators.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeIndicators.App.ViewModels
{
    public class IndicatorIndexViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Organization { get; set; } = "";
        public string Department { get; set; } = "";
        public string Branch { get; set; } = "";
        public string Description { get; set; } = "";
        public string Target { get; set; } = "";

        public CollectionInterval CollectionInterval { get; set; }
        public bool IsActive { get; set; }

        public string OwnerToString()
        {
            if (string.IsNullOrWhiteSpace(Branch)) {
                return $"{Organization}";
            }
            else {
                return $"{Department} | {Branch}";
            }
        }
    }
}
