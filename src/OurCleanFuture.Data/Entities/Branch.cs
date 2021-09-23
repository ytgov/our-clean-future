﻿using System.ComponentModel.DataAnnotations;

namespace OurCleanFuture.Data.Entities
{
    public class Branch
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int LeadId { get; set; }
        public Lead Lead { get; set; } = null!;

        public int DepartmentId { get; set; }
        public Department Department { get; set; } = null!;
    }
}