using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bogus;
using ClimateChangeIndicators.Data.Entities;

namespace ClimateChangeIndicators.Data
{
    internal class BogusDataGenerator
    {
        private readonly ModelBuilder _modelBuilder;

        public BogusDataGenerator(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Init()
        {
            _modelBuilder.Entity<Organization>().HasData(new Organization { Id = 1, Name = "Yukon Government" });
            _modelBuilder.Entity<Organization>().HasData(new Organization { Id = 2, Name = "ATCO Electric Yukon" });

            _modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Environment" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "Highways and Public Works" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 3, Name = "Tourism and Culture" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 4, Name = "Finance" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 5, Name = "Energy, Mines and Resources" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 6, Name = "Yukon Energy" });

            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 1, DepartmentId = 1, Name = "Climate Change Secretariat" });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 2, DepartmentId = 1, Name = "Conservation Officer Services" });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 3, DepartmentId = 1, Name = "Parks" });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 4, DepartmentId = 1, Name = "Fish and Wildlife" });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 5, DepartmentId = 1, Name = "Conservation Officer Services" });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 6, DepartmentId = 5, Name = "Forest Resources" });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 7, DepartmentId = 5, Name = "Agriculture" });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 8, DepartmentId = 5, Name = "Energy" });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 9, DepartmentId = 2, Name = "Supply Services" });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 10, DepartmentId = 2, Name = "Strategic Initiatives" });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 11, DepartmentId = 3, Name = "Culture Services" });

            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 1, OrganizationId = 1, BranchId = 8 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 2, OrganizationId = 2 });

            _modelBuilder.Entity<OurCleanFutureReference>().HasData(new OurCleanFutureReference { Id = 1, Description = "Increase the number of zero emission vehicles on our roads." });
            _modelBuilder.Entity<OurCleanFutureReference>().HasData(new OurCleanFutureReference { Id = 2, Description = "Ensure Yukoners have access to reliable, affordable and renewable energy." });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 1,
                    CollectionInterval = CollectionInterval.Biannual,
                    DataType = DataType.Cumulative,
                    Description = "Total number of heavy-duty zero emission vehicles registered in Yukon.",
                    DisplayName = "ZEVs - Total heavy duty",
                    IsActive = true,
                    OurCleanFutureReferenceId = 1,
                    OwnerId = 1
                });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 2,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Total electricity generated off-grid during the reporting year (thermal and renewable).",
                    DisplayName = "Off-grid generation - total",
                    IsActive = true,
                    OurCleanFutureReferenceId = 2,
                    OwnerId = 2
                });

            //var indicatorId = 1;
            //var indicators = new Faker<Indicator>("en_CA")
            //    .RuleFor(i => i.Id, _ => indicatorId++)
            //    .RuleFor(i => i.CollectionInterval, _ => _.PickRandom<CollectionInterval>())
            //    .RuleFor(i => i.DataType, _ => _.PickRandom<DataType>())
            //    .RuleFor(i => i.Description, _ => "Total number of heavy-duty zero emission vehicles registered in Yukon.")
            //    .RuleFor(i => i.DisplayName, _ => "ZEVs - Total heavy duty")
            //    .RuleFor(i => i.IsActive, _ => true)
            //    .RuleFor(i => i.OurCleanFutureReferenceId, _ => 1)
            //    .RuleFor(i => i.OwnerId, _ => 1);
            //_modelBuilder.Entity<Indicator>().HasData(indicators.Generate(1));
        }
    }
}