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

            _modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Environment", ShortName = "ENV" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "Highways and Public Works", ShortName = "HPW" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 3, Name = "Tourism and Culture", ShortName = "TC" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 4, Name = "Finance", ShortName = "FIN" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 5, Name = "Energy, Mines and Resources", ShortName = "EMR" });

            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 1, OrganizationId = 1 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 2, OrganizationId = 1 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 3, OrganizationId = 1 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 4, OrganizationId = 1 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 5, OrganizationId = 1 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 6, OrganizationId = 1 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 7, OrganizationId = 1 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 8, OrganizationId = 1 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 9, OrganizationId = 1 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 10, OrganizationId = 1 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 11, OrganizationId = 1 });
            _modelBuilder.Entity<Owner>().HasData(new Owner { Id = 12, OrganizationId = 2 });

            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 1, DepartmentId = 1, Name = "Climate Change Secretariat", OwnerId = 1 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 2, DepartmentId = 1, Name = "Water Resources", OwnerId = 2 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 3, DepartmentId = 1, Name = "Parks", OwnerId = 3 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 4, DepartmentId = 1, Name = "Fish and Wildlife", OwnerId = 4 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 5, DepartmentId = 1, Name = "Conservation Officer Services", OwnerId = 5 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 6, DepartmentId = 5, Name = "Forest Resources", OwnerId = 6 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 7, DepartmentId = 5, Name = "Agriculture", OwnerId = 7 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 8, DepartmentId = 5, Name = "Energy", OwnerId = 8 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 9, DepartmentId = 2, Name = "Supply Services", OwnerId = 9 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 10, DepartmentId = 2, Name = "Strategic Initiatives", OwnerId = 10 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 11, DepartmentId = 3, Name = "Culture Services", OwnerId = 11 });

            _modelBuilder.Entity<OurCleanFutureReference>().HasData(new OurCleanFutureReference { Id = 1, ReferenceText = "Increase the number of zero emission vehicles on our roads." });
            _modelBuilder.Entity<OurCleanFutureReference>().HasData(new OurCleanFutureReference { Id = 2, ReferenceText = "Ensure Yukoners have access to reliable, affordable and renewable energy." });
            _modelBuilder.Entity<OurCleanFutureReference>().HasData(new OurCleanFutureReference { Id = 3, ReferenceText = "Conduct energy assessments of Government of Yukon buildings to identify opportunities for energy efficiency and greenhouse gas reductions, with the first period of assessments completed by 2025 and the second period completed by 2030." });
            _modelBuilder.Entity<OurCleanFutureReference>().HasData(new OurCleanFutureReference { Id = 4, ReferenceText = "Supply more of what we eat through sustainable local food production." });
            _modelBuilder.Entity<OurCleanFutureReference>().HasData(new OurCleanFutureReference { Id = 5, ReferenceText = "LEADERSHIP" });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 1,
                    CollectionInterval = CollectionInterval.Biannual,
                    DataType = DataType.Cumulative,
                    Description = "Total number of heavy-duty zero emission vehicles registered in Yukon.",
                    Title = "ZEVs - Total heavy duty",
                    IsActive = true,
                    OurCleanFutureReferenceId = 1,
                    OwnerId = 8
                });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 2,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Total electricity generated off-grid during the reporting year (thermal and renewable).",
                    Title = "Off-grid generation - total",
                    IsActive = true,
                    OurCleanFutureReferenceId = 2,
                    OwnerId = 12
                });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 3,
                    CollectionInterval = CollectionInterval.Biannual,
                    DataType = DataType.Cumulative,
                    Description = "Number of energy assessments of Government of Yukon buildings completed during the reporting year.",
                    Title = "YG buildings - energy assessments completed",
                    IsActive = true,
                    OurCleanFutureReferenceId = 3,
                    OwnerId = 10
                });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 4,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Yukon Agricultural Self-Sufficiency Indicator",
                    Title = "Food self-sufficiency",
                    IsActive = true,
                    OurCleanFutureReferenceId = 4,
                    OwnerId = 7
                });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 5,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Total GHGs from the Government of Yukon's operations",
                    Title = "YG GHGs - total",
                    IsActive = true,
                    OurCleanFutureReferenceId = 5,
                    OwnerId = 1
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