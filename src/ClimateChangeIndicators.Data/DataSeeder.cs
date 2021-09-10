using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bogus;
using ClimateChangeIndicators.Data.Entities;
using Action = ClimateChangeIndicators.Data.Entities.Action;

namespace ClimateChangeIndicators.Data
{
    internal class DataSeeder
    {
        private readonly ModelBuilder _modelBuilder;

        public DataSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        public void Init()
        {
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 1, Name = "Kilograms of carbon dioxide equivalent", Symbol = "kgCO₂e" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 2, Name = "Count", Symbol = "count" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 3, Name = "Megawatts", Symbol = "MW" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 4, Name = "Dollars", Symbol = "$" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 5, Name = "Percent", Symbol = "%" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 6, Name = "Proportion", Symbol = "proportion" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 7, Name = "Tons of carbon dioxide equivalent per litre", Symbol = "tCO₂e/L" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 8, Name = "Kilotons of carbon dioxide equivalent", Symbol = "ktCO₂e" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 9, Name = "Tons of carbon dioxide equivalent per person", Symbol = "tCO₂e/person" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 10, Name = "Litres", Symbol = "L" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 11, Name = "Gigawatt hours", Symbol = "GWh" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 12, Name = "Cubic metres", Symbol = "m³" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 13, Name = "Kilometres", Symbol = "km" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 14, Name = "Cubic kilometres", Symbol = "km³" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 15, Name = "Tons per person", Symbol = "t/person" });
            _modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 16, Name = "Kilotonnes per million chained (2012) dollars", Symbol = "kt/$1MM chained (2012)" });

            _modelBuilder.Entity<Area>().HasData(new Area { Id = 1, Title = "Transportion" });
            _modelBuilder.Entity<Area>().HasData(new Area { Id = 2, Title = "Homes and buildings" });
            _modelBuilder.Entity<Area>().HasData(new Area { Id = 3, Title = "Energy production" });
            _modelBuilder.Entity<Area>().HasData(new Area { Id = 4, Title = "People and the environment" });
            _modelBuilder.Entity<Area>().HasData(new Area { Id = 5, Title = "Communities" });
            _modelBuilder.Entity<Area>().HasData(new Area { Id = 6, Title = "Innovation" });
            _modelBuilder.Entity<Area>().HasData(new Area { Id = 7, Title = "Leadership" });

            _modelBuilder.Entity<Goal>().HasData(new Goal { Id = 1, Title = "Reducing greenhouse gas emissions" });
            _modelBuilder.Entity<Goal>().HasData(new Goal { Id = 2, Title = "Ensuring Yukoners have access to reliable, affordable and renewable energy" });
            _modelBuilder.Entity<Goal>().HasData(new Goal { Id = 3, Title = "Adapting to the impacts of climate change" });
            _modelBuilder.Entity<Goal>().HasData(new Goal { Id = 4, Title = "Building a green economy" });

            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 1, Title = "Increase the number of zero emission vehicles on our roads", AreaId = 1 });
            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 2, Title = "Reduce the lifecycle carbon intensity of transportation fuels", AreaId = 1 });
            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 3, Title = "Increase the use of public and active transportation", AreaId = 1 });
            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 4, Title = "Reduce the carbon footprint from medium and heavy-duty vehicles", AreaId = 1 });
            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 5, Title = "Be more efficient in how and when we travel", AreaId = 1 });
            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 6, Title = "Ensure roads, runways and other transportation infrastructure are resilient to the impacts of climate change", AreaId = 1 });

            _modelBuilder.Entity<Organization>().HasData(new Organization { Id = 1, Name = "Yukon Government" });
            _modelBuilder.Entity<Organization>().HasData(new Organization { Id = 2, Name = "ATCO Electric Yukon" });

            _modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Community Services", ShortName = "CS" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "Economic Development", ShortName = "EcDev" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 3, Name = "Education", ShortName = "EDU" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 4, Name = "Energy, Mines and Resources", ShortName = "EMR" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 5, Name = "Environment", ShortName = "ENV" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 6, Name = "Executive Council Office", ShortName = "ECO" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 7, Name = "Finance", ShortName = "FIN" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 8, Name = "Health and Social Services", ShortName = "HSS" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 9, Name = "Highways and Public Works", ShortName = "HPW" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 10, Name = "Justice", ShortName = "JUS" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 11, Name = "Public Service Commission", ShortName = "PSC" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 12, Name = "Tourism and Culture", ShortName = "TC" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 13, Name = "Yukon Development Corporation", ShortName = "YDC" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 14, Name = "Yukon Energy Corporation", ShortName = "YEC" });
            _modelBuilder.Entity<Department>().HasData(new Department { Id = 15, Name = "Yukon Housing Corporation", ShortName = "YHC" });

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

            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 1, DepartmentId = 5, Name = "Climate Change Secretariat", OwnerId = 1 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 2, DepartmentId = 5, Name = "Water Resources", OwnerId = 2 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 3, DepartmentId = 5, Name = "Parks", OwnerId = 3 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 4, DepartmentId = 5, Name = "Fish and Wildlife", OwnerId = 4 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 5, DepartmentId = 5, Name = "Conservation Officer Services", OwnerId = 5 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 6, DepartmentId = 4, Name = "Forest Resources", OwnerId = 6 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 7, DepartmentId = 4, Name = "Agriculture", OwnerId = 7 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 8, DepartmentId = 4, Name = "Energy", OwnerId = 8 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 9, DepartmentId = 9, Name = "Supply Services", OwnerId = 9 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 10, DepartmentId = 9, Name = "Strategic Initiatives", OwnerId = 10 });
            _modelBuilder.Entity<Branch>().HasData(new Branch { Id = 11, DepartmentId = 12, Name = "Culture Services", OwnerId = 11 });

            _modelBuilder.Entity<Action>().HasData(new Action { Id = 1, Number = "T1", Title = "Work with local vehicle dealerships and manufacturers to establish a system by 2024 to ensure zero emission vehicles are 10 per cent of light duty vehicle sales by 2025 and 30 per cent by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 2, Number = "T2", Title = "Ensure at least 50 per cent of all new light-duty cars purchased by the Government of Yukon are zero emission vehicles each year from 2020 to 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 3, Number = "T3", Title = "Provide a rebate to Yukon businesses and individuals who purchase eligible zero emission vehicles beginning in 2020." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 4, Number = "T4", Title = "Continue to install fast-charging stations across Yukon to make it possible to travel between all road-accessible Yukon communities by 2027 and work with neighbouring governments and organizations to explore options to connect Yukon with BC" });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 5, Number = "T5", Title = "Provide rebates to support the installation of smart electric vehicle charging stations at residential" });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 6, Number = "T6", Title = "Require new residential buildings to be built with the electrical infrastructure to support Level 2 electric vehicle charging beginning on April 1" });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 7, Number = "T7", Title = "Draft legislation by 2024 that will enable private businesses and Yukon’s public utilities to sell electricity for the purpose of electric vehicle charging." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 8, Number = "T8", Title = "Continue to run public education events and campaigns to raise awareness of the benefits of electric vehicles and how they function in cold climates." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 9, Number = "T9", Title = "Require all diesel fuel sold in Yukon for transportation to align with the percentage of biodiesel and renewable diesel by volume in leading Canadian jurisdictions beginning in 2025" });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 10, Number = "T10", Title = "Require all gasoline sold in Yukon for transportation to align with the percentage of ethanol by volume in leading Canadian jurisdictions beginning in 2025" });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 11, Number = "T11", Title = "Provide rebates to encourage the purchase of electric bicycles for personal and business commuting beginning in 2020." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 12, Number = "T12", Title = "Continue to support municipalities and First Nations to make investments in public and active transportation infrastructure." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 13, Number = "T13", Title = "Continue to incorporate active transportation in the design of highways and other Government of Yukon transportation infrastructure near communities." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 14, Number = "T14", Title = "Update the Government of Yukon’s heavy-duty vehicle fleet by 2030 to reduce greenhouse gas emissions and fuel costs." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 15, Number = "T15", Title = "Begin a pilot project in 2021 to test the use of short-haul medium and heavy-duty electric vehicles for commercial and institutional applications within Yukon." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 16, Number = "T16", Title = "Train the Government of Yukon’s heavy equipment operators on efficient driving techniques for all new equipment by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 17, Number = "T17", Title = "Expand the Government of Yukon’s video and teleconferencing systems and require employees to consider these options when requesting permission for work travel by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 18, Number = "T18", Title = "Implement new policies to enable Government of Yukon employees in suitable positions to work from home for the longer term by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 19, Number = "T19", Title = "Develop a planning and engagement strategy by 2022 to change how and where Government of Yukon employees work by providing choices and flexibility through a modern workplace." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 20, Number = "T20", Title = "Develop and implement a system by 2021 to coordinate carpooling for Government of Yukon staff travelling by vehicle for work within Yukon." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 21, Number = "T21", Title = "Develop guidelines for the Government of Yukon Fleet Vehicle Agency’s fleet by 2021 to ensure appropriate vehicles are used for the task at hand." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 22, Number = "T22", Title = "Incorporate fuel efficiency into purchasing decisions for Government of Yukon fleet vehicles beginning in 2020 to reduce greenhouse gas emissions and fuel costs." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 23, Number = "T23", Title = "Expand virtual health care services to Whitehorse medical clinics by 2022 in order to improve access to healthcare while reducing greenhouse gas emissions from travel to and from Whitehorse." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 24, Number = "T24", Title = "Continue to operate the Yukon Rideshare program to make carpooling and other shared travel easier." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 25, Number = "T25", Title = "Complete a climate change vulnerability study of the road transportation network by 2023 to inform the development of standards and specifications." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 26, Number = "T26", Title = "Establish a geohazard mapping program for major transportation corridors and prioritize sections for targeted permafrost study by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 27, Number = "T27", Title = "Analyze flood risk along critical transportation corridors at risk of flooding by 2023." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 28, Number = "T28", Title = "Continue to conduct climate risk assessments of all major transportation infrastructure projects above $10 million, such as through the federal Climate Lens assessment." });

            _modelBuilder.Entity<Action>().HasData(new Action { Id = 29, Number = "H1", Title = "Conduct retrofits to Government of Yukon buildings to reduce energy use and contribute to a 30 per cent reduction in greenhouse gas emissions by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 30, Number = "H2", Title = "Conduct energy assessments of Government of Yukon buildings to identify opportunities for energy efficiency and greenhouse gas reductions, with the first period of assessments completed by 2025 and the second period completed by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 31, Number = "H3", Title = "Provide low-interest financing to support energy efficiency retrofits to homes and buildings beginning in 2021." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 32, Number = "H4", Title = "Continue to provide financial support to assist First Nations and municipalities to complete major energy retrofits to institutional buildings across Yukon, aiming for 30 retrofits by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 33, Number = "H5", Title = "Continue to provide financial support for municipal and First Nations energy efficiency projects." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 34, Number = "H6", Title = "Continue to work with Yukon First Nations to retrofit First Nations housing to be more energy efficient." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 35, Number = "H7", Title = "Continue to retrofit Government of Yukon community housing to reduce greenhouse gas emissions in each building by 30 per cent." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 36, Number = "H8", Title = "Continue to provide rebates for thermal enclosure upgrades and energy efficient equipment to reduce energy use in homes and commercial buildings." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 37, Number = "H9", Title = "Assess ways to ensure Yukoners can access adequate insurance for fires, floods and permafrost thaw by 2023." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 38, Number = "H10", Title = "Develop and implement a plan by 2024 to conduct routine monitoring of the structural condition of Government of Yukon buildings located on permafrost." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 39, Number = "H11", Title = "Assess options to provide financial support for actions to improve the climate resiliency of homes and buildings by 2023." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 40, Number = "H12", Title = "Work with the Government of Canada to develop and implement building codes suitable to northern Canada that will aspire to see all new residential and commercial buildings be net zero energy ready by 2032." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 41, Number = "H13", Title = "Continue to require all new Government of Yukon buildings to be designed to use 35 per cent less energy than the targets in the National Energy Code for Buildings, in accordance with the Government of Yukon’s Design Requirements and Building Standards Manual." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 42, Number = "H14", Title = "Adopt and enforce relevant building standards by 2030 that will require new buildings to be constructed to be more resilient to climate change impacts like permafrost thaw, flooding and forest fires." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 43, Number = "H15", Title = "Continue to conduct climate risk assessments of all major building projects over $10 million that are built or funded by the Government of Yukon." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 44, Number = "H16", Title = "Continue to provide rebates for new homes that are net zero energy ready, aiming for 500 homes by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 45, Number = "H17", Title = "Install renewable heat sources such as biomass energy in Government of Yukon buildings by 2030 to create long-term demand for renewable heating and contribute to a 30 per cent reduction in greenhouse gas emissions." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 46, Number = "H18", Title = "Provide low-interest financing to install smart electric heating devices in residential, commercial and institutional buildings in collaboration with Yukon’s public utilities beginning in 2021." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 47, Number = "H19", Title = "Provide low-interest financing to install biomass heating systems in commercial and institutional buildings beginning in 2021." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 48, Number = "H20", Title = "Continue to assist First Nations to complete feasibility studies for the installation and operation of biomass heating systems." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 49, Number = "H21", Title = "Continue to provide rebates for residential, commercial and institutional biomass heating systems and smart electric heating devices and increase the current rebate for smart electric heating devices beginning in 2020." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 50, Number = "H22", Title = "Work with local industry to install and test 25 electric heat pumps with backup fossil fuel heating systems or utility-controlled electric thermal storage from 2020 to 2023." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 51, Number = "H23", Title = "Identify regulatory improvements that could support the growth of Yukon’s biomass energy industry during the review of the Forest Resources Act by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 52, Number = "H24", Title = "Amend the Air Emissions Regulations by 2025 in order to regulate air emissions from commercial and institutional biomass burning systems to minimize the release of harmful air pollutants." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 53, Number = "H25", Title = "Analyze and compare the climate benefits of different types of biomass harvesting and use in Yukon by 2021 in order to identify recommended forest management practices to guide sustainable and low-carbon biomass use." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 54, Number = "H26", Title = "Provide direction to the Yukon Utilities Board in 2020 to allow Yukon’s public utilities to partner with the Government of Yukon to pursue cost-effective demand-side management measures." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 55, Number = "H27", Title = "Establish a partnership between the Government of Yukon, Yukon Energy Corporation and ATCO Electric Yukon by 2021 that will collaborate on the delivery of energy and capacity demand-side management programs." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 56, Number = "H28", Title = "Complete the Peak Smart pilot project by 2022 to evaluate the use of smart devices to shift energy demand to off-peak hours." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 57, Number = "H29", Title = "Implement an education campaign for Government of Yukon building occupants and visitors by 2026 to encourage more energy efficient behaviours." });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 1,
                    CollectionInterval = CollectionInterval.Biannual,
                    DataType = DataType.Cumulative,
                    Description = "Total number of heavy-duty zero emission vehicles registered in Yukon.",
                    Title = "ZEVs - Total heavy duty",
                    IsActive = true,
                    OwnerId = 8,
                    UnitOfMeasurementId = 2
                });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 2,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Total electricity generated off-grid during the reporting year (thermal and renewable).",
                    Title = "Off-grid generation - total",
                    IsActive = true,
                    OwnerId = 12,
                    UnitOfMeasurementId = 2
                });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 3,
                    CollectionInterval = CollectionInterval.Biannual,
                    DataType = DataType.Cumulative,
                    Description = "Number of energy assessments of Government of Yukon buildings completed during the reporting year.",
                    Title = "YG buildings - energy assessments completed",
                    IsActive = true,
                    OwnerId = 10,
                    UnitOfMeasurementId = 2
                });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 4,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Yukon Agricultural Self-Sufficiency Indicator",
                    Title = "Food self-sufficiency",
                    IsActive = true,
                    OwnerId = 7,
                    UnitOfMeasurementId = 2
                });

            _modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 5,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Total GHGs from the Government of Yukon's operations",
                    Title = "YG GHGs - total",
                    IsActive = true,
                    OwnerId = 1,
                    UnitOfMeasurementId = 1
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