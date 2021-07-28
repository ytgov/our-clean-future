using ClimateChangeIndicators.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeIndicators.App.ViewModels
{
    public class IndicatorViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";

        public string OrganizationName { get; set; } = "";
        public string DepartmentName { get; set; } = "";
        public string BranchName { get; set; } = "";

        public string Description { get; set; } = "";
        public string Target { get; set; } = "";
        public Data.Entities.DataType DataType { get; set; }

        public int OurCleanFutureReferenceId { get; set; }

        public CollectionInterval CollectionInterval { get; set; }

        public string Notes { get; set; } = "";
        public bool IsActive { get; set; }

        public string OwnerToString()
        {
            if (string.IsNullOrWhiteSpace(BranchName)) {
                return $"{OrganizationName}";
            }
            else {
                return $"{OrganizationName} | {DepartmentName} | {BranchName}";
            }
        }
    }
}
