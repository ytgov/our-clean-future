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

            _modelBuilder.Entity<Goal>().HasData(new Goal { Id = 1, Title = "Reduce Yukon's greenhouse gas emissions." });
            _modelBuilder.Entity<Goal>().HasData(new Goal { Id = 2, Title = "Ensure Yukoners have access to reliable, affordable and renewable energy." });
            _modelBuilder.Entity<Goal>().HasData(new Goal { Id = 3, Title = "Adapt to the impacts of climate change." });
            _modelBuilder.Entity<Goal>().HasData(new Goal { Id = 4, Title = "Build a green economy." });

            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 1, Title = "Increase the number of zero emission vehicles on our roads.", AreaId = 1 });
            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 2, Title = "Reduce the lifecycle carbon intensity of transportation fuels.", AreaId = 1 });
            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 3, Title = "Increase the use of public and active transportation.", AreaId = 1 });
            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 4, Title = "Reduce the carbon footprint from medium and heavy-duty vehicles.", AreaId = 1 });
            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 5, Title = "Be more efficient in how and when we travel.", AreaId = 1 });
            _modelBuilder.Entity<Objective>().HasData(new Objective { Id = 6, Title = "Ensure roads, runways and other transportation infrastructure are resilient to the impacts of climate change.", AreaId = 1 });

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

            _modelBuilder.Entity<Action>().HasData(new Action { Id = 1, Code = "T1", Title = "Work with local vehicle dealerships and manufacturers to establish a system by 2024 to ensure zero emission vehicles are 10 per cent of light duty vehicle sales by 2025 and 30 per cent by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 2, Code = "T2", Title = "Ensure at least 50 per cent of all new light-duty cars purchased by the Government of Yukon are zero emission vehicles each year from 2020 to 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 3, Code = "T3", Title = "Provide a rebate to Yukon businesses and individuals who purchase eligible zero emission vehicles beginning in 2020." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 4, Code = "T4", Title = "Continue to install fast-charging stations across Yukon to make it possible to travel between all road-accessible Yukon communities by 2027 and work with neighbouring governments and organizations to explore options to connect Yukon with BC" });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 5, Code = "T5", Title = "Provide rebates to support the installation of smart electric vehicle charging stations at residential" });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 6, Code = "T6", Title = "Require new residential buildings to be built with the electrical infrastructure to support Level 2 electric vehicle charging beginning on April 1" });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 7, Code = "T7", Title = "Draft legislation by 2024 that will enable private businesses and Yukon’s public utilities to sell electricity for the purpose of electric vehicle charging." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 8, Code = "T8", Title = "Continue to run public education events and campaigns to raise awareness of the benefits of electric vehicles and how they function in cold climates." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 9, Code = "T9", Title = "Require all diesel fuel sold in Yukon for transportation to align with the percentage of biodiesel and renewable diesel by volume in leading Canadian jurisdictions beginning in 2025" });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 10, Code = "T10", Title = "Require all gasoline sold in Yukon for transportation to align with the percentage of ethanol by volume in leading Canadian jurisdictions beginning in 2025" });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 11, Code = "T11", Title = "Provide rebates to encourage the purchase of electric bicycles for personal and business commuting beginning in 2020." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 12, Code = "T12", Title = "Continue to support municipalities and First Nations to make investments in public and active transportation infrastructure." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 13, Code = "T13", Title = "Continue to incorporate active transportation in the design of highways and other Government of Yukon transportation infrastructure near communities." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 14, Code = "T14", Title = "Update the Government of Yukon’s heavy-duty vehicle fleet by 2030 to reduce greenhouse gas emissions and fuel costs." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 15, Code = "T15", Title = "Begin a pilot project in 2021 to test the use of short-haul medium and heavy-duty electric vehicles for commercial and institutional applications within Yukon." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 16, Code = "T16", Title = "Train the Government of Yukon’s heavy equipment operators on efficient driving techniques for all new equipment by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 17, Code = "T17", Title = "Expand the Government of Yukon’s video and teleconferencing systems and require employees to consider these options when requesting permission for work travel by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 18, Code = "T18", Title = "Implement new policies to enable Government of Yukon employees in suitable positions to work from home for the longer term by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 19, Code = "T19", Title = "Develop a planning and engagement strategy by 2022 to change how and where Government of Yukon employees work by providing choices and flexibility through a modern workplace." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 20, Code = "T20", Title = "Develop and implement a system by 2021 to coordinate carpooling for Government of Yukon staff travelling by vehicle for work within Yukon." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 21, Code = "T21", Title = "Develop guidelines for the Government of Yukon Fleet Vehicle Agency’s fleet by 2021 to ensure appropriate vehicles are used for the task at hand." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 22, Code = "T22", Title = "Incorporate fuel efficiency into purchasing decisions for Government of Yukon fleet vehicles beginning in 2020 to reduce greenhouse gas emissions and fuel costs." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 23, Code = "T23", Title = "Expand virtual health care services to Whitehorse medical clinics by 2022 in order to improve access to healthcare while reducing greenhouse gas emissions from travel to and from Whitehorse." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 24, Code = "T24", Title = "Continue to operate the Yukon Rideshare program to make carpooling and other shared travel easier." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 25, Code = "T25", Title = "Complete a climate change vulnerability study of the road transportation network by 2023 to inform the development of standards and specifications." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 26, Code = "T26", Title = "Establish a geohazard mapping program for major transportation corridors and prioritize sections for targeted permafrost study by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 27, Code = "T27", Title = "Analyze flood risk along critical transportation corridors at risk of flooding by 2023." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 28, Code = "T28", Title = "Continue to conduct climate risk assessments of all major transportation infrastructure projects above $10 million, such as through the federal Climate Lens assessment." });

            _modelBuilder.Entity<Action>().HasData(new Action { Id = 29, Code = "H1", Title = "Conduct retrofits to Government of Yukon buildings to reduce energy use and contribute to a 30 per cent reduction in greenhouse gas emissions by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 30, Code = "H2", Title = "Conduct energy assessments of Government of Yukon buildings to identify opportunities for energy efficiency and greenhouse gas reductions, with the first period of assessments completed by 2025 and the second period completed by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 31, Code = "H3", Title = "Provide low-interest financing to support energy efficiency retrofits to homes and buildings beginning in 2021." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 32, Code = "H4", Title = "Continue to provide financial support to assist First Nations and municipalities to complete major energy retrofits to institutional buildings across Yukon, aiming for 30 retrofits by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 33, Code = "H5", Title = "Continue to provide financial support for municipal and First Nations energy efficiency projects." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 34, Code = "H6", Title = "Continue to work with Yukon First Nations to retrofit First Nations housing to be more energy efficient." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 35, Code = "H7", Title = "Continue to retrofit Government of Yukon community housing to reduce greenhouse gas emissions in each building by 30 per cent." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 36, Code = "H8", Title = "Continue to provide rebates for thermal enclosure upgrades and energy efficient equipment to reduce energy use in homes and commercial buildings." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 37, Code = "H9", Title = "Assess ways to ensure Yukoners can access adequate insurance for fires, floods and permafrost thaw by 2023." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 38, Code = "H10", Title = "Develop and implement a plan by 2024 to conduct routine monitoring of the structural condition of Government of Yukon buildings located on permafrost." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 39, Code = "H11", Title = "Assess options to provide financial support for actions to improve the climate resiliency of homes and buildings by 2023." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 40, Code = "H12", Title = "Work with the Government of Canada to develop and implement building codes suitable to northern Canada that will aspire to see all new residential and commercial buildings be net zero energy ready by 2032." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 41, Code = "H13", Title = "Continue to require all new Government of Yukon buildings to be designed to use 35 per cent less energy than the targets in the National Energy Code for Buildings, in accordance with the Government of Yukon’s Design Requirements and Building Standards Manual." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 42, Code = "H14", Title = "Adopt and enforce relevant building standards by 2030 that will require new buildings to be constructed to be more resilient to climate change impacts like permafrost thaw, flooding and forest fires." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 43, Code = "H15", Title = "Continue to conduct climate risk assessments of all major building projects over $10 million that are built or funded by the Government of Yukon." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 44, Code = "H16", Title = "Continue to provide rebates for new homes that are net zero energy ready, aiming for 500 homes by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 45, Code = "H17", Title = "Install renewable heat sources such as biomass energy in Government of Yukon buildings by 2030 to create long-term demand for renewable heating and contribute to a 30 per cent reduction in greenhouse gas emissions." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 46, Code = "H18", Title = "Provide low-interest financing to install smart electric heating devices in residential, commercial and institutional buildings in collaboration with Yukon’s public utilities beginning in 2021." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 47, Code = "H19", Title = "Provide low-interest financing to install biomass heating systems in commercial and institutional buildings beginning in 2021." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 48, Code = "H20", Title = "Continue to assist First Nations to complete feasibility studies for the installation and operation of biomass heating systems." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 49, Code = "H21", Title = "Continue to provide rebates for residential, commercial and institutional biomass heating systems and smart electric heating devices and increase the current rebate for smart electric heating devices beginning in 2020." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 50, Code = "H22", Title = "Work with local industry to install and test 25 electric heat pumps with backup fossil fuel heating systems or utility-controlled electric thermal storage from 2020 to 2023." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 51, Code = "H23", Title = "Identify regulatory improvements that could support the growth of Yukon’s biomass energy industry during the review of the Forest Resources Act by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 52, Code = "H24", Title = "Amend the Air Emissions Regulations by 2025 in order to regulate air emissions from commercial and institutional biomass burning systems to minimize the release of harmful air pollutants." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 53, Code = "H25", Title = "Analyze and compare the climate benefits of different types of biomass harvesting and use in Yukon by 2021 in order to identify recommended forest management practices to guide sustainable and low-carbon biomass use." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 54, Code = "H26", Title = "Provide direction to the Yukon Utilities Board in 2020 to allow Yukon’s public utilities to partner with the Government of Yukon to pursue cost-effective demand-side management measures." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 55, Code = "H27", Title = "Establish a partnership between the Government of Yukon, Yukon Energy Corporation and ATCO Electric Yukon by 2021 that will collaborate on the delivery of energy and capacity demand-side management programs." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 56, Code = "H28", Title = "Complete the Peak Smart pilot project by 2022 to evaluate the use of smart devices to shift energy demand to off-peak hours." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 57, Code = "H29", Title = "Implement an education campaign for Government of Yukon building occupants and visitors by 2026 to encourage more energy efficient behaviours." });

            _modelBuilder.Entity<Action>().HasData(new Action { Id = 58, Code = "E1", Title = "While aiming for an aspirational target of 97 per cent by 2030, develop legislation by 2023 that will require at least 93 per cent of the electricity generated on the Yukon Integrated System to come from renewable sources, calculated as a long-term rolling average." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 59, Code = "E2", Title = "Require some of the diesel used to generate electricity on the Yukon Integrated System and in off-grid communities to be substituted with clean diesel alternatives like biodiesel and renewable diesel beginning in 2025, aiming for around 20 per cent." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 60, Code = "E3", Title = "Update the Public Utilities Act by 2025 to ensure an effective and efficient process for regulating electricity in Yukon." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 61, Code = "E4", Title = "Install renewable electricity generation systems in 5 Government of Yukon buildings in offgrid locations by 2025 to reduce reliance on diesel-generated electricity." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 62, Code = "E5", Title = "Evaluate the potential to generate renewable electricity at remote historic sites co-managed by the Government of Yukon and Yukon First Nations by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 63, Code = "E6", Title = "Continue to provide financial and technical support for Yukon First Nations, municipalities and community organizations to undertake community-led renewable energy projects." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 64, Code = "E7", Title = "Work with Yukon’s public utilities to continue to implement the Independent Power Production Policy that enables independent power producers, including Yukon First Nations and communities, to generate and sell electricity to the grid." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 65, Code = "E8", Title = "Increase the limit of the Standing Offer Program under the Independent Power Production Policy from 20 gigawatt hours (GWh) to 40 GWh by 2021 to support additional community-based renewable energy projects on Yukon’s main electrical grid." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 66, Code = "E9", Title = "Develop a framework by 2022 for First Nations to economically participate in renewable electricity projects developed by Yukon’s public utilities." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 67, Code = "E10", Title = "Continue to deliver the Micro-generation Program in collaboration with Yukon’s public utilities, targeting 7 megawatts (MW) of installed renewable electricity capacity by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 68, Code = "E11", Title = "Develop legislation by 2023 to regulate geothermal energy development in Yukon." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 69, Code = "E12", Title = "Research the potential to use geothermal energy for heating and electricity, with a focus along Yukon fault systems, by 2025." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 70, Code = "E13", Title = "Improve modelling of the impacts of climate change on hydroelectricity reservoirs by 2021 and incorporate this information into short, medium and long-term forecasts for renewable hydroelectricity generation." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 71, Code = "E14", Title = "Develop a climate change adaptation plan for the Yukon Energy Corporation by 2022 that will identify risks and appropriate responses to ensure Yukon’s main electrical grid is resilient to the impacts of climate change." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 72, Code = "E15", Title = "Implement a glacier monitoring program in 2020 to improve our ability to predict the impacts of glacier melt on hydrological systems and hydroelectricity generation." });

            _modelBuilder.Entity<Action>().HasData(new Action { Id = 73, Code = "P1", Title = "Establish a standardized method to determine the health status of wetland ecosystems and complete a pilot study to measure the baseline conditions of various reference wetlands by 2022 to better understand future changes." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 74, Code = "P2", Title = "Adapt existing surface and groundwater monitoring networks by 2026 to be able to track long-term trends in water quality and quantity in a changing climate." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 75, Code = "P3", Title = "Continue to lead and participate in projects that improve our understanding of how climate change is affecting ecosystems, wild species and their habitats." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 76, Code = "P4", Title = "Continue to monitor key species that will provide an indication of the impacts of climate change on Yukon ecosystems and expand monitoring to more taxonomic groups." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 77, Code = "P5", Title = "Continue to incorporate climate change into the design of protected and managed areas using landscape conservation science in order to allow native species to move, adapt and survive in the face of climate change." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 78, Code = "P6", Title = "Continue to track new and invasive species to Yukon that could impact ecosystems and biodiversity." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 79, Code = "P7", Title = "Work with Yukon First Nations to develop a tailored hunter education program by 2023 that can be adapted and delivered by Yukon First Nations for First Nations citizens." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 80, Code = "P8", Title = "Work collaboratively with First Nations and the Inuvialuit to document information from historic sites and culturally important places on the North Slope that are at risk due to climate change by 2024." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 81, Code = "P9", Title = "Provide training to healthcare providers beginning in 2023 to be better able to identify and treat the physical and mental health impacts of climate change." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 82, Code = "P10", Title = "Incorporate climate-related illnesses like heat stroke, respiratory illness, and vector-borne diseases into the new 1Health Yukon health information system by 2023 to enable tracking of climate-related illnesses in Yukon." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 83, Code = "P11", Title = "Expand monitoring of concentrations of particulate matter in the air from biomass burning and forest fires to all Yukon communities by 2023." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 84, Code = "P12", Title = "Purchase a moveable clean air shelter by 2021 that can be set up in communities to protect public health during wildfire smoke events." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 85, Code = "P13", Title = "Provide financial support to vulnerable Yukoners to install cleaner air spaces in their homes and buildings beginning in 2023 to provide protection from wildfire smoke." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 86, Code = "P14", Title = "Analyze existing information on food insecurity in Yukon by 2023 to inform the development of a system to gather food insecurity data into the future." });

            _modelBuilder.Entity<Action>().HasData(new Action { Id = 87, Code = "C1", Title = "Expand geohazard map coverage to all Yukon communities with a high risk of permafrost thaw by 2025." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 88, Code = "C2", Title = "Develop flood probability maps for all Yukon communities at risk of flooding by 2023 that incorporate climate change projections." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 89, Code = "C3", Title = "Develop detailed guidelines by 2025 that can be used by the Government of Yukon and partners to develop walkable, bike-friendly and transit-oriented communities." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 90, Code = "C4", Title = "Continue to develop, encourage and apply applicable climate resiliency standards to community design and infrastructure development projects built by or receiving capital funding from the Government of Yukon" });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 91, Code = "C5", Title = "Continue to conduct detailed climate change risk assessments of all major community infrastructure projects over $10 million that are built or funded by the Government of Yukon." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 92, Code = "C6", Title = "Continue to make recommendations to consider the impacts of climate change in regional land use and local area planning processes, which inform the Government of Yukon’s development permitting and zoning decisions." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 93, Code = "C7", Title = "Continue to provide technical and administrative support to Yukon First Nations and municipalities to prepare integrated asset management plans." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 94, Code = "C8", Title = "Expand monitoring networks and improve modelling tools to generate reliable daily flood forecasts and relevant warnings for all at-risk Yukon communities by 2024." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 95, Code = "C9", Title = "Work with First Nations and municipalities to develop Wildfire Protection Plans for all Yukon communities by 2026 and to complete the forest fuel management activities outlined in the plans by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 96, Code = "C10", Title = "Increase the capacity in Yukon Wildland Fire to prevent wildfires and respond to extended fire seasons by investing in staffing in 2020." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 97, Code = "C11", Title = "Complete hazard identification and risk assessments (HIRAs) for all Yukon communities by 2022 that include climate change risks." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 98, Code = "C12", Title = "Work with First Nations and municipalities to complete emergency management plans for all Yukon communities by 2022 informed by community hazard identification and risk assessments (HIRAs)." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 99, Code = "C13", Title = "Develop a territorial disaster financial assistance policy by 2022 to support recovery from natural disasters that result in extensive property damage or disruption to the delivery of essential goods and services." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 100, Code = "C14", Title = "Develop a territorial disaster financial assistance policy by 2022 to support recovery from natural disasters that result in extensive property damage or disruption to the delivery of essential goods and services." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 101, Code = "C15", Title = "Continue to provide funding for community gardens and greenhouses, especially in rural communities." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 102, Code = "C16", Title = "Continue to provide technical advice to assist First Nations and municipal governments with their agricultural and animal husbandry projects." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 103, Code = "C17", Title = "Continue to conduct and provide access to funding for research on how climate change could affect local agriculture." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 104, Code = "C18", Title = "Continue to support agricultural producers to adapt to the impacts of climate change, adopt low-carbon practices and use surface water and groundwater efficiently." });

            _modelBuilder.Entity<Action>().HasData(new Action { Id = 105, Code = "I1", Title = "Incorporate greenhouse gas emissions into the decision-making process for Department of Economic Development funding programs by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 106, Code = "I2", Title = "Update the Government of Yukon’s procurement policies and standards in 2020 to better support sustainable and local procurement." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 107, Code = "I3", Title = "Identify and develop options to address potential regulatory and policy barriers to the growth of green businesses in Yukon by 2023." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 108, Code = "I4", Title = "Expand the range of relevant professional development offerings by 2023 to enable more Yukoners to participate in the green economy." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 109, Code = "I5", Title = "Create an award program by 2022 to recognize the achievements of local green businesses and organizations." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 110, Code = "I6", Title = "Include new provisions in quartz mine licenses by 2022 that will ensure critical mine infrastructure is planned, designed and built to withstand current and projected impacts of climate change." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 111, Code = "I7", Title = "Require quartz mines to project their anticipated greenhouse gas emissions, identify measures to reduce emissions, and annually report greenhouse gas emissions through the quartz mine licensing process beginning in 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 112, Code = "I8", Title = "Increase the Government of Yukon’s participation in intergovernmental initiatives related to mine resiliency, low-carbon mining and innovation by 2021." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 113, Code = "I9", Title = "Establish an intensity-based greenhouse gas reduction target for Yukon’s mining industry and additional actions needed to reach the target by 2022." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 114, Code = "I10", Title = "Establish and implement a framework to measure the sustainability of tourism development in Yukon by 2021." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 115, Code = "I11", Title = "Develop and implement a system to track greenhouse gas emissions from Yukon’s tourism industry by 2021." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 116, Code = "I12", Title = "Assess options for establishing a comprehensive waste diversion system in Government of Yukon buildings, including reuse, recycling, compost and e-waste collection by 2030." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 117, Code = "I13", Title = "Develop legislation that will enable the Government of Yukon to restrict or prohibit the production, supply or distribution of appropriate single use bags by 2021." });
            _modelBuilder.Entity<Action>().HasData(new Action { Id = 118, Code = "I14", Title = "Design and implement a system for Extended Producer Responsibility by 2025 that will make producers responsible for managing materials through the lifecycle of a product." });

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
                    Description = "Yukon Agricultural Self-Sufficiency Indicator.",
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
                    Description = "Total GHGs from the Government of Yukon's operations.",
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