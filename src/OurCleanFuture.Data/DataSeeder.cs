﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bogus;
using OurCleanFuture.Data.Entities;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.Data
{
    internal class DataSeeder
    {
        private readonly ModelBuilder modelBuilder;

        public DataSeeder(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Init()
        {
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 1, Name = "Kilograms of carbon dioxide equivalent", Symbol = "kgCO₂e" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 2, Name = "Count", Symbol = "count" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 3, Name = "Megawatts", Symbol = "MW" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 4, Name = "Dollars", Symbol = "$" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 5, Name = "Percent", Symbol = "%" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 6, Name = "Proportion", Symbol = "proportion" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 7, Name = "Tons of carbon dioxide equivalent per litre", Symbol = "tCO₂e/L" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 8, Name = "Kilotons of carbon dioxide equivalent", Symbol = "ktCO₂e" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 9, Name = "Tons of carbon dioxide equivalent per person", Symbol = "tCO₂e/person" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 10, Name = "Litres", Symbol = "L" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 11, Name = "Gigawatt hours", Symbol = "GWh" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 12, Name = "Cubic metres", Symbol = "m³" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 13, Name = "Kilometres", Symbol = "km" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 14, Name = "Cubic kilometres", Symbol = "km³" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 15, Name = "Tons per person", Symbol = "t/person" });
            modelBuilder.Entity<UnitOfMeasurement>().HasData(new UnitOfMeasurement { Id = 16, Name = "Kilotonnes per million chained (2012) dollars", Symbol = "kt/$1MM chained (2012)" });

            modelBuilder.Entity<Goal>().HasData(new Goal { Id = 1, Title = "Reduce Yukon's greenhouse gas emissions." });
            modelBuilder.Entity<Goal>().HasData(new Goal { Id = 2, Title = "Ensure Yukoners have access to reliable, affordable and renewable energy." });
            modelBuilder.Entity<Goal>().HasData(new Goal { Id = 3, Title = "Adapt to the impacts of climate change." });
            modelBuilder.Entity<Goal>().HasData(new Goal { Id = 4, Title = "Build a green economy." });

            modelBuilder.Entity<Area>().HasData(new Area { Id = 1, Title = "Transportation" });
            modelBuilder.Entity<Area>().HasData(new Area { Id = 2, Title = "Homes and buildings" });
            modelBuilder.Entity<Area>().HasData(new Area { Id = 3, Title = "Energy production" });
            modelBuilder.Entity<Area>().HasData(new Area { Id = 4, Title = "People and the environment" });
            modelBuilder.Entity<Area>().HasData(new Area { Id = 5, Title = "Communities" });
            modelBuilder.Entity<Area>().HasData(new Area { Id = 6, Title = "Innovation" });
            modelBuilder.Entity<Area>().HasData(new Area { Id = 7, Title = "Leadership" });

            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 1, Title = "Increase the number of zero emission vehicles on our roads.", AreaId = 1 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 2, Title = "Reduce the lifecycle carbon intensity of transportation fuels.", AreaId = 1 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 3, Title = "Increase the use of public and active transportation.", AreaId = 1 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 4, Title = "Reduce the carbon footprint from medium and heavy-duty vehicles.", AreaId = 1 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 5, Title = "Be more efficient in how and when we travel.", AreaId = 1 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 6, Title = "Ensure roads, runways and other transportation infrastructure are resilient to the impacts of climate change.", AreaId = 1 });

            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 7, Title = "Improve the energy efficiency and climate resilience of existing homes and buildings.", AreaId = 2 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 8, Title = "Ensure new homes and buildings are built to be low-carbon and climate-resilient.", AreaId = 2 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 9, Title = "Increase the use of biomass and other renewable energy sources for heating.", AreaId = 2 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 10, Title = "Use energy more efficiently and better align energy supply and demand.", AreaId = 2 });

            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 11, Title = "Increase the supply of electricity generated from renewable sources.", AreaId = 3 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 12, Title = "Support local and community-based renewable energy projects for heating and electricity.", AreaId = 3 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 13, Title = "Ensure electricity generation, transmission and distribution infrastructure is resilient to the impacts of climate change.", AreaId = 3 });

            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 14, Title = "Respond to the impacts of climate change on wild species and their habitats.", AreaId = 4 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 15, Title = "Maintain our ability to practice traditional and cultural activities on the land.", AreaId = 4 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 16, Title = "Protect and enhance human health and wellbeing in a changing climate.", AreaId = 4 });

            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 17, Title = "Design our communities to be low-carbon and resilient to the impacts of climate change.", AreaId = 5 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 18, Title = "Ensure we are prepared for emergencies that are becoming more likely due to climate change.", AreaId = 5 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 19, Title = "Supply more of what we eat through sustainable local food production.", AreaId = 5 });

            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 20, Title = "Support innovation and green business practices.", AreaId = 6 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 21, Title = "Reduce the carbon intensity of mining and ensure mining projects are prepared for the impacts of climate change.", AreaId = 6 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 22, Title = "Enhance the sustainability of Yukon’s tourism industry.", AreaId = 6 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 23, Title = "Improve how we manage our waste to move toward a more circular economy.", AreaId = 6 });

            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 24, Title = "Ensure the goals of this strategy are incorporated into government planning and operations.", AreaId = 7 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 25, Title = "Educate and empower youth as the next generation of leaders.", AreaId = 7 });
            modelBuilder.Entity<Objective>().HasData(new Objective { Id = 26, Title = "Ensure Yukoners have the information needed to make evidence-based decisions.", AreaId = 7 });

            modelBuilder.Entity("GoalObjective").HasData(
                new { GoalsId = 1, ObjectivesId = 1 },
                new { GoalsId = 4, ObjectivesId = 1 },
                new { GoalsId = 1, ObjectivesId = 2 },
                new { GoalsId = 1, ObjectivesId = 3 },
                new { GoalsId = 2, ObjectivesId = 3 },
                new { GoalsId = 4, ObjectivesId = 3 },
                new { GoalsId = 1, ObjectivesId = 4 },
                new { GoalsId = 2, ObjectivesId = 4 },
                new { GoalsId = 1, ObjectivesId = 5 },
                new { GoalsId = 2, ObjectivesId = 5 },
                new { GoalsId = 4, ObjectivesId = 5 },
                new { GoalsId = 3, ObjectivesId = 6 },
                new { GoalsId = 4, ObjectivesId = 6 },
                new { GoalsId = 1, ObjectivesId = 7 },
                new { GoalsId = 2, ObjectivesId = 7 },
                new { GoalsId = 3, ObjectivesId = 7 },
                new { GoalsId = 4, ObjectivesId = 7 },
                new { GoalsId = 1, ObjectivesId = 8 },
                new { GoalsId = 2, ObjectivesId = 8 },
                new { GoalsId = 3, ObjectivesId = 8 },
                new { GoalsId = 4, ObjectivesId = 8 },
                new { GoalsId = 1, ObjectivesId = 9 },
                new { GoalsId = 2, ObjectivesId = 9 },
                new { GoalsId = 3, ObjectivesId = 9 },
                new { GoalsId = 4, ObjectivesId = 9 },
                new { GoalsId = 1, ObjectivesId = 10 },
                new { GoalsId = 2, ObjectivesId = 10 },
                new { GoalsId = 4, ObjectivesId = 10 },
                new { GoalsId = 1, ObjectivesId = 11 },
                new { GoalsId = 2, ObjectivesId = 11 },
                new { GoalsId = 4, ObjectivesId = 11 },
                new { GoalsId = 1, ObjectivesId = 12 },
                new { GoalsId = 2, ObjectivesId = 12 },
                new { GoalsId = 4, ObjectivesId = 12 },
                new { GoalsId = 3, ObjectivesId = 13 },
                new { GoalsId = 4, ObjectivesId = 13 },
                new { GoalsId = 3, ObjectivesId = 14 },
                new { GoalsId = 4, ObjectivesId = 14 },
                new { GoalsId = 3, ObjectivesId = 15 },
                new { GoalsId = 4, ObjectivesId = 15 },
                new { GoalsId = 3, ObjectivesId = 16 },
                new { GoalsId = 1, ObjectivesId = 17 },
                new { GoalsId = 2, ObjectivesId = 17 },
                new { GoalsId = 3, ObjectivesId = 17 },
                new { GoalsId = 4, ObjectivesId = 17 },
                new { GoalsId = 3, ObjectivesId = 18 },
                new { GoalsId = 4, ObjectivesId = 18 },
                new { GoalsId = 1, ObjectivesId = 19 },
                new { GoalsId = 3, ObjectivesId = 19 },
                new { GoalsId = 4, ObjectivesId = 19 },
                new { GoalsId = 1, ObjectivesId = 20 },
                new { GoalsId = 2, ObjectivesId = 20 },
                new { GoalsId = 3, ObjectivesId = 20 },
                new { GoalsId = 4, ObjectivesId = 20 },
                new { GoalsId = 1, ObjectivesId = 21 },
                new { GoalsId = 2, ObjectivesId = 21 },
                new { GoalsId = 3, ObjectivesId = 21 },
                new { GoalsId = 4, ObjectivesId = 21 },
                new { GoalsId = 1, ObjectivesId = 22 },
                new { GoalsId = 2, ObjectivesId = 22 },
                new { GoalsId = 3, ObjectivesId = 22 },
                new { GoalsId = 4, ObjectivesId = 22 },
                new { GoalsId = 1, ObjectivesId = 23 },
                new { GoalsId = 4, ObjectivesId = 23 },
                new { GoalsId = 1, ObjectivesId = 24 },
                new { GoalsId = 2, ObjectivesId = 24 },
                new { GoalsId = 3, ObjectivesId = 24 },
                new { GoalsId = 4, ObjectivesId = 24 },
                new { GoalsId = 1, ObjectivesId = 25 },
                new { GoalsId = 2, ObjectivesId = 25 },
                new { GoalsId = 3, ObjectivesId = 25 },
                new { GoalsId = 4, ObjectivesId = 25 },
                new { GoalsId = 1, ObjectivesId = 26 },
                new { GoalsId = 2, ObjectivesId = 26 },
                new { GoalsId = 3, ObjectivesId = 26 },
                new { GoalsId = 4, ObjectivesId = 26 }
            );

            modelBuilder.Entity<Action>().HasData(new Action { Id = 1, ObjectiveId = 1, Number = "T1", Title = "Work with local vehicle dealerships and manufacturers to establish a system by 2024 to ensure zero emission vehicles are 10 per cent of light duty vehicle sales by 2025 and 30 per cent by 2030." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 2, ObjectiveId = 1, Number = "T2", Title = "Ensure at least 50 per cent of all new light-duty cars purchased by the Government of Yukon are zero emission vehicles each year from 2020 to 2030." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 3, ObjectiveId = 1, Number = "T3", Title = "Provide a rebate to Yukon businesses and individuals who purchase eligible zero emission vehicles beginning in 2020." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 4, ObjectiveId = 1, Number = "T4", Title = "Continue to install fast-charging stations across Yukon to make it possible to travel between all road-accessible Yukon communities by 2027 and work with neighbouring governments and organizations to explore options to connect Yukon with BC." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 5, ObjectiveId = 1, Number = "T5", Title = "Provide rebates to support the installation of smart electric vehicle charging stations at residential, commercial and institutional buildings in collaboration with Yukon’s publicutilities beginning in 2020." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 6, ObjectiveId = 1, Number = "T6", Title = "Require new residential buildings to be built with the electrical infrastructure to support Level 2 electric vehicle charging beginning on April 1." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 7, ObjectiveId = 1, Number = "T7", Title = "Draft legislation by 2024 that will enable private businesses and Yukon’s public utilities to sell electricity for the purpose of electric vehicle charging." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 8, ObjectiveId = 1, Number = "T8", Title = "Continue to run public education events and campaigns to raise awareness of the benefits of electric vehicles and how they function in cold climates." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 9, ObjectiveId = 2, Number = "T9", Title = "Require all diesel fuel sold in Yukon for transportation to align with the percentage of biodiesel and renewable diesel by volume in leading Canadian jurisdictions beginning in 2025." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 10, ObjectiveId = 2, Number = "T10", Title = "Require all gasoline sold in Yukon for transportation to align with the percentage of ethanol by volume in leading Canadian jurisdictions beginning in 2025." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 11, ObjectiveId = 3, Number = "T11", Title = "Provide rebates to encourage the purchase of electric bicycles for personal and business commuting beginning in 2020." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 12, ObjectiveId = 3, Number = "T12", Title = "Continue to support municipalities and First Nations to make investments in public and active transportation infrastructure." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 13, ObjectiveId = 3, Number = "T13", Title = "Continue to incorporate active transportation in the design of highways and other Government of Yukon transportation infrastructure near communities." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 14, ObjectiveId = 4, Number = "T14", Title = "Update the Government of Yukon’s heavy-duty vehicle fleet by 2030 to reduce greenhouse gas emissions and fuel costs." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 15, ObjectiveId = 4, Number = "T15", Title = "Begin a pilot project in 2021 to test the use of short-haul medium and heavy-duty electric vehicles for commercial and institutional applications within Yukon." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 16, ObjectiveId = 4, Number = "T16", Title = "Train the Government of Yukon’s heavy equipment operators on efficient driving techniques for all new equipment by 2022." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 17, ObjectiveId = 5, Number = "T17", Title = "Expand the Government of Yukon’s video and teleconferencing systems and require employees to consider these options when requesting permission for work travel by 2022." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 18, ObjectiveId = 5, Number = "T18", Title = "Implement new policies to enable Government of Yukon employees in suitable positions to work from home for the longer term by 2022." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 19, ObjectiveId = 5, Number = "T19", Title = "Develop a planning and engagement strategy by 2022 to change how and where Government of Yukon employees work by providing choices and flexibility through a modern workplace." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 20, ObjectiveId = 5, Number = "T20", Title = "Develop and implement a system by 2021 to coordinate carpooling for Government of Yukon staff travelling by vehicle for work within Yukon." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 21, ObjectiveId = 5, Number = "T21", Title = "Develop guidelines for the Government of Yukon Fleet Vehicle Agency’s fleet by 2021 to ensure appropriate vehicles are used for the task at hand." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 22, ObjectiveId = 5, Number = "T22", Title = "Incorporate fuel efficiency into purchasing decisions for Government of Yukon fleet vehicles beginning in 2020 to reduce greenhouse gas emissions and fuel costs." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 23, ObjectiveId = 5, Number = "T23", Title = "Expand virtual health care services to Whitehorse medical clinics by 2022 in order to improve access to healthcare while reducing greenhouse gas emissions from travel to and from Whitehorse." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 24, ObjectiveId = 5, Number = "T24", Title = "Cont   inue to operate the Yukon Rideshare program to make carpooling and other shared travel easier." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 25, ObjectiveId = 6, Number = "T25", Title = "Complete a climate change vulnerability study of the road transportation network by 2023 to inform the development of standards and specifications." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 26, ObjectiveId = 6, Number = "T26", Title = "Establish a geohazard mapping program for major transportation corridors and prioritize sections for targeted permafrost study by 2022." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 27, ObjectiveId = 6, Number = "T27", Title = "Analyze flood risk along critical transportation corridors at risk of flooding by 2023." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 28, ObjectiveId = 6, Number = "T28", Title = "Continue to conduct climate risk assessments of all major transportation infrastructure projects above $10 million, such as through the federal Climate Lens assessment." });

            modelBuilder.Entity<Action>().HasData(new Action { Id = 29, ObjectiveId = 7, Number = "H1", Title = "Conduct retrofits to Government of Yukon buildings to reduce energy use and contribute to a 30 per cent reduction in greenhouse gas emissions by 2030." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 30, ObjectiveId = 7, Number = "H2", Title = "Conduct energy assessments of Government of Yukon buildings to identify opportunities for energy efficiency and greenhouse gas reductions, with the first period of assessments completed by 2025 and the second period completed by 2030." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 31, ObjectiveId = 7, Number = "H3", Title = "Provide low-interest financing to support energy efficiency retrofits to homes and buildings beginning in 2021." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 32, ObjectiveId = 7, Number = "H4", Title = "Continue to provide financial support to assist First Nations and municipalities to complete major energy retrofits to institutional buildings across Yukon, aiming for 30 retrofits by 2030." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 33, ObjectiveId = 7, Number = "H5", Title = "Continue to provide financial support for municipal and First Nations energy efficiency projects." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 34, ObjectiveId = 7, Number = "H6", Title = "Continue to work with Yukon First Nations to retrofit First Nations housing to be more energy efficient." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 35, ObjectiveId = 7, Number = "H7", Title = "Continue to retrofit Government of Yukon community housing to reduce greenhouse gas emissions in each building by 30 per cent." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 36, ObjectiveId = 7, Number = "H8", Title = "Continue to provide rebates for thermal enclosure upgrades and energy efficient equipment to reduce energy use in homes and commercial buildings." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 37, ObjectiveId = 7, Number = "H9", Title = "Assess ways to ensure Yukoners can access adequate insurance for fires, floods and permafrost thaw by 2023." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 38, ObjectiveId = 7, Number = "H10", Title = "Develop and implement a plan by 2024 to conduct routine monitoring of the structural condition of Government of Yukon buildings located on permafrost." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 39, ObjectiveId = 7, Number = "H11", Title = "Assess options to provide financial support for actions to improve the climate resiliency of homes and buildings by 2023." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 40, ObjectiveId = 8, Number = "H12", Title = "Work with the Government of Canada to develop and implement building codes suitable to northern Canada that will aspire to see all new residential and commercial buildings be net zero energy ready by 2032." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 41, ObjectiveId = 8, Number = "H13", Title = "Continue to require all new Government of Yukon buildings to be designed to use 35 per cent less energy than the targets in the National Energy Code for Buildings, in accordance with the Government of Yukon’s Design Requirements and Building Standards Manual." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 42, ObjectiveId = 8, Number = "H14", Title = "Adopt and enforce relevant building standards by 2030 that will require new buildings to be constructed to be more resilient to climate change impacts like permafrost thaw, flooding and forest fires." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 43, ObjectiveId = 8, Number = "H15", Title = "Continue to conduct climate risk assessments of all major building projects over $10 million that are built or funded by the Government of Yukon." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 44, ObjectiveId = 8, Number = "H16", Title = "Continue to provide rebates for new homes that are net zero energy ready, aiming for 500 homes by 2030." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 45, ObjectiveId = 9, Number = "H17", Title = "Install renewable heat sources such as biomass energy in Government of Yukon buildings by 2030 to create long-term demand for renewable heating and contribute to a 30 per cent reduction in greenhouse gas emissions." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 46, ObjectiveId = 9, Number = "H18", Title = "Provide low-interest financing to install smart electric heating devices in residential, commercial and institutional buildings in collaboration with Yukon’s public utilities beginning in 2021." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 47, ObjectiveId = 9, Number = "H19", Title = "Provide low-interest financing to install biomass heating systems in commercial and institutional buildings beginning in 2021." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 48, ObjectiveId = 9, Number = "H20", Title = "Continue to assist First Nations to complete feasibility studies for the installation and operation of biomass heating systems." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 49, ObjectiveId = 9, Number = "H21", Title = "Continue to provide rebates for residential, commercial and institutional biomass heating systems and smart electric heating devices and increase the current rebate for smart electric heating devices beginning in 2020." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 50, ObjectiveId = 9, Number = "H22", Title = "Work with local industry to install and test 25 electric heat pumps with backup fossil fuel heating systems or utility-controlled electric thermal storage from 2020 to 2023." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 51, ObjectiveId = 9, Number = "H23", Title = "Identify regulatory improvements that could support the growth of Yukon’s biomass energy industry during the review of the Forest Resources Act by 2022." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 52, ObjectiveId = 9, Number = "H24", Title = "Amend the Air Emissions Regulations by 2025 in order to regulate air emissions from commercial and institutional biomass burning systems to minimize the release of harmful air pollutants." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 53, ObjectiveId = 9, Number = "H25", Title = "Analyze and compare the climate benefits of different types of biomass harvesting and use in Yukon by 2021 in order to identify recommended forest management practices to guide sustainable and low-carbon biomass use." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 54, ObjectiveId = 10, Number = "H26", Title = "Provide direction to the Yukon Utilities Board in 2020 to allow Yukon’s public utilities to partner with the Government of Yukon to pursue cost-effective demand-side management measures." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 55, ObjectiveId = 10, Number = "H27", Title = "Establish a partnership between the Government of Yukon, Yukon Energy Corporation and ATCO Electric Yukon by 2021 that will collaborate on the delivery of energy and capacity demand-side management programs." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 56, ObjectiveId = 10, Number = "H28", Title = "Complete the Peak Smart pilot project by 2022 to evaluate the use of smart devices to shift energy demand to off-peak hours." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 57, ObjectiveId = 10, Number = "H29", Title = "Implement an education campaign for Government of Yukon building occupants and visitors by 2026 to encourage more energy efficient behaviours." });

            modelBuilder.Entity<Action>().HasData(new Action { Id = 58, ObjectiveId = 11, Number = "E1", Title = "While aiming for an aspirational target of 97 per cent by 2030, develop legislation by 2023 that will require at least 93 per cent of the electricity generated on the Yukon Integrated System to come from renewable sources, calculated as a long-term rolling average." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 59, ObjectiveId = 11, Number = "E2", Title = "Require some of the diesel used to generate electricity on the Yukon Integrated System and in off-grid communities to be substituted with clean diesel alternatives like biodiesel and renewable diesel beginning in 2025, aiming for around 20 per cent." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 60, ObjectiveId = 11, Number = "E3", Title = "Update the Public Utilities Act by 2025 to ensure an effective and efficient process for regulating electricity in Yukon." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 61, ObjectiveId = 11, Number = "E4", Title = "Install renewable electricity generation systems in 5 Government of Yukon buildings in off-grid locations by 2025 to reduce reliance on diesel-generated electricity." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 62, ObjectiveId = 11, Number = "E5", Title = "Evaluate the potential to generate renewable electricity at remote historic sites co-managed by the Government of Yukon and Yukon First Nations by 2022." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 63, ObjectiveId = 12, Number = "E6", Title = "Continue to provide financial and technical support for Yukon First Nations, municipalities and community organizations to undertake community-led renewable energy projects." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 64, ObjectiveId = 12, Number = "E7", Title = "Work with Yukon’s public utilities to continue to implement the Independent Power Production Policy that enables independent power producers, including Yukon First Nations and communities, to generate and sell electricity to the grid." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 65, ObjectiveId = 12, Number = "E8", Title = "Increase the limit of the Standing Offer Program under the Independent Power Production Policy from 20 gigawatt hours (GWh) to 40 GWh by 2021 to support additional community-based renewable energy projects on Yukon’s main electrical grid." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 66, ObjectiveId = 12, Number = "E9", Title = "Develop a framework by 2022 for First Nations to economically participate in renewable electricity projects developed by Yukon’s public utilities." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 67, ObjectiveId = 12, Number = "E10", Title = "Continue to deliver the Micro-generation Program in collaboration with Yukon’s public utilities, targeting 7 megawatts (MW) of installed renewable electricity capacity by 2030." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 68, ObjectiveId = 12, Number = "E11", Title = "Develop legislation by 2023 to regulate geothermal energy development in Yukon." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 69, ObjectiveId = 12, Number = "E12", Title = "Research the potential to use geothermal energy for heating and electricity, with a focus along Yukon fault systems, by 2025." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 70, ObjectiveId = 13, Number = "E13", Title = "Improve modelling of the impacts of climate change on hydroelectricity reservoirs by 2021 and incorporate this information into short, medium and long-term forecasts for renewable hydroelectricity generation." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 71, ObjectiveId = 13, Number = "E14", Title = "Develop a climate change adaptation plan for the Yukon Energy Corporation by 2022 that will identify risks and appropriate responses to ensure Yukon’s main electrical grid is resilient to the impacts of climate change." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 72, ObjectiveId = 13, Number = "E15", Title = "Implement a glacier monitoring program in 2020 to improve our ability to predict the impacts of glacier melt on hydrological systems and hydroelectricity generation." });

            modelBuilder.Entity<Action>().HasData(new Action { Id = 73, ObjectiveId = 14, Number = "P1", Title = "Establish a standardized method to determine the health status of wetland ecosystems and complete a pilot study to measure the baseline conditions of various reference wetlands by 2022 to better understand future changes." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 74, ObjectiveId = 14, Number = "P2", Title = "Adapt existing surface and groundwater monitoring networks by 2026 to be able to track long-term trends in water quality and quantity in a changing climate." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 75, ObjectiveId = 14, Number = "P3", Title = "Continue to lead and participate in projects that improve our understanding of how climate change is affecting ecosystems, wild species and their habitats." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 76, ObjectiveId = 14, Number = "P4", Title = "Continue to monitor key species that will provide an indication of the impacts of climate change on Yukon ecosystems and expand monitoring to more taxonomic groups." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 77, ObjectiveId = 14, Number = "P5", Title = "Continue to incorporate climate change into the design of protected and managed areas using landscape conservation science in order to allow native species to move, adapt and survive in the face of climate change." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 78, ObjectiveId = 14, Number = "P6", Title = "Continue to track new and invasive species to Yukon that could impact ecosystems and biodiversity." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 79, ObjectiveId = 15, Number = "P7", Title = "Work with Yukon First Nations to develop a tailored hunter education program by 2023 that can be adapted and delivered by Yukon First Nations for First Nations citizens." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 80, ObjectiveId = 15, Number = "P8", Title = "Work collaboratively with First Nations and the Inuvialuit to document information from historic sites and culturally important places on the North Slope that are at risk due to climate change by 2024." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 81, ObjectiveId = 16, Number = "P9", Title = "Provide training to healthcare providers beginning in 2023 to be better able to identify and treat the physical and mental health impacts of climate change." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 82, ObjectiveId = 16, Number = "P10", Title = "Incorporate climate-related illnesses like heat stroke, respiratory illness, and vector-borne diseases into the new 1Health Yukon health information system by 2023 to enable tracking of climate-related illnesses in Yukon." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 83, ObjectiveId = 16, Number = "P11", Title = "Expand monitoring of concentrations of particulate matter in the air from biomass burning and forest fires to all Yukon communities by 2023." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 84, ObjectiveId = 16, Number = "P12", Title = "Purchase a moveable clean air shelter by 2021 that can be set up in communities to protect public health during wildfire smoke events." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 85, ObjectiveId = 16, Number = "P13", Title = "Provide financial support to vulnerable Yukoners to install cleaner air spaces in their homes and buildings beginning in 2023 to provide protection from wildfire smoke." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 86, ObjectiveId = 16, Number = "P14", Title = "Analyze existing information on food insecurity in Yukon by 2023 to inform the development of a system to gather food insecurity data into the future." });

            modelBuilder.Entity<Action>().HasData(new Action { Id = 87, ObjectiveId = 17, Number = "C1", Title = "Expand geohazard map coverage to all Yukon communities with a high risk of permafrost thaw by 2025." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 88, ObjectiveId = 17, Number = "C2", Title = "Develop flood probability maps for all Yukon communities at risk of flooding by 2023 that incorporate climate change projections." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 89, ObjectiveId = 17, Number = "C3", Title = "Develop detailed guidelines by 2025 that can be used by the Government of Yukon and partners to develop walkable, bike-friendly and transit-oriented communities." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 90, ObjectiveId = 17, Number = "C4", Title = "Continue to develop, encourage and apply applicable climate resiliency standards to community design and infrastructure development projects built by or receiving capital funding from the Government of Yukon." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 91, ObjectiveId = 17, Number = "C5", Title = "Continue to conduct detailed climate change risk assessments of all major community infrastructure projects over $10 million that are built or funded by the Government of Yukon." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 92, ObjectiveId = 17, Number = "C6", Title = "Continue to make recommendations to consider the impacts of climate change in regional land use and local area planning processes, which inform the Government of Yukon’s development permitting and zoning decisions." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 93, ObjectiveId = 17, Number = "C7", Title = "Continue to provide technical and administrative support to Yukon First Nations and municipalities to prepare integrated asset management plans." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 94, ObjectiveId = 18, Number = "C8", Title = "Expand monitoring networks and improve modelling tools to generate reliable daily flood forecasts and relevant warnings for all at-risk Yukon communities by 2024." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 95, ObjectiveId = 18, Number = "C9", Title = "Work with First Nations and municipalities to develop Wildfire Protection Plans for all Yukon communities by 2026 and to complete the forest fuel management activities outlined in the plans by 2030." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 96, ObjectiveId = 18, Number = "C10", Title = "Increase the capacity in Yukon Wildland Fire to prevent wildfires and respond to extended fire seasons by investing in staffing in 2020." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 97, ObjectiveId = 18, Number = "C11", Title = "Complete hazard identification and risk assessments (HIRAs) for all Yukon communities by 2022 that include climate change risks." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 98, ObjectiveId = 18, Number = "C12", Title = "Work with First Nations and municipalities to complete emergency management plans for all Yukon communities by 2022 informed by community hazard identification and risk assessments (HIRAs)." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 99, ObjectiveId = 18, Number = "C13", Title = "Develop a territorial disaster financial assistance policy by 2022 to support recovery from natural disasters that result in extensive property damage or disruption to the delivery of essential goods and services." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 100, ObjectiveId = 19, Number = "C14", Title = "Develop a territorial disaster financial assistance policy by 2022 to support recovery from natural disasters that result in extensive property damage or disruption to the delivery of essential goods and services." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 101, ObjectiveId = 19, Number = "C15", Title = "Continue to provide funding for community gardens and greenhouses, especially in rural communities." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 102, ObjectiveId = 19, Number = "C16", Title = "Continue to provide technical advice to assist First Nations and municipal governments with their agricultural and animal husbandry projects." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 103, ObjectiveId = 19, Number = "C17", Title = "Continue to conduct and provide access to funding for research on how climate change could affect local agriculture." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 104, ObjectiveId = 19, Number = "C18", Title = "Continue to support agricultural producers to adapt to the impacts of climate change, adopt low-carbon practices and use surface water and groundwater efficiently." });

            modelBuilder.Entity<Action>().HasData(new Action { Id = 105, ObjectiveId = 20, Number = "I1", Title = "Incorporate greenhouse gas emissions into the decision-making process for Department of Economic Development funding programs by 2022." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 106, ObjectiveId = 20, Number = "I2", Title = "Update the Government of Yukon’s procurement policies and standards in 2020 to better support sustainable and local procurement." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 107, ObjectiveId = 20, Number = "I3", Title = "Identify and develop options to address potential regulatory and policy barriers to the growth of green businesses in Yukon by 2023." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 108, ObjectiveId = 20, Number = "I4", Title = "Expand the range of relevant professional development offerings by 2023 to enable more Yukoners to participate in the green economy." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 109, ObjectiveId = 20, Number = "I5", Title = "Create an award program by 2022 to recognize the achievements of local green businesses and organizations." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 110, ObjectiveId = 21, Number = "I6", Title = "Include new provisions in quartz mine licenses by 2022 that will ensure critical mine infrastructure is planned, designed and built to withstand current and projected impacts of climate change." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 111, ObjectiveId = 21, Number = "I7", Title = "Require quartz mines to project their anticipated greenhouse gas emissions, identify measures to reduce emissions, and annually report greenhouse gas emissions through the quartz mine licensing process beginning in 2022." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 112, ObjectiveId = 21, Number = "I8", Title = "Increase the Government of Yukon’s participation in intergovernmental initiatives related to mine resiliency, low-carbon mining and innovation by 2021." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 113, ObjectiveId = 21, Number = "I9", Title = "Establish an intensity-based greenhouse gas reduction target for Yukon’s mining industry and additional actions needed to reach the target by 2022." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 114, ObjectiveId = 22, Number = "I10", Title = "Establish and implement a framework to measure the sustainability of tourism development in Yukon by 2021." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 115, ObjectiveId = 22, Number = "I11", Title = "Develop and implement a system to track greenhouse gas emissions from Yukon’s tourism industry by 2021." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 116, ObjectiveId = 23, Number = "I12", Title = "Assess options for establishing a comprehensive waste diversion system in Government of Yukon buildings, including reuse, recycling, compost and e-waste collection by 2030." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 117, ObjectiveId = 23, Number = "I13", Title = "Develop legislation that will enable the Government of Yukon to restrict or prohibit the production, supply or distribution of appropriate single use bags by 2021." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 118, ObjectiveId = 23, Number = "I14", Title = "Design and implement a system for Extended Producer Responsibility by 2025 that will make producers responsible for managing materials through the lifecycle of a product." });

            modelBuilder.Entity<Action>().HasData(new Action { Id = 119, ObjectiveId = 24, Number = "L1", Title = "Create a Clean Energy Act by 2023 that legislates our greenhouse gas reduction targets and our commitments to energy efficiency and demand-side management to hold the Government of Yukon accountable." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 120, ObjectiveId = 24, Number = "L2", Title = "Incorporate a climate change lens into the decision-making process for major Government of Yukon policies, programs and projects by 2021." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 121, ObjectiveId = 24, Number = "L3", Title = "Incorporate climate change risks into Government of Yukon departmental planning processes by 2022." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 122, ObjectiveId = 24, Number = "L4", Title = "Incorporate greenhouse gas emissions and energy efficiency into the process for identifying and prioritizing Government of Yukon building retrofits and new construction projects by 2023." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 123, ObjectiveId = 24, Number = "L5", Title = "Develop and offer climate change training for Government of Yukon employees by 2022." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 124, ObjectiveId = 25, Number = "L6", Title = "Create a Youth Panel on Climate Change in 2020 that will provide advice and perspectives to the Government of Yukon on climate change, energy and green economy matters that reflects the diversity of Yukon youth." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 125, ObjectiveId = 25, Number = "L7", Title = "Provide mentorship opportunities for Yukon youth to participate in major international climate change and energy events with Government of Yukon staff beginning in 2023." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 126, ObjectiveId = 25, Number = "L8", Title = "Continue to support land-based programs in the Yukon school curriculum that teach First Nations ways of knowing and doing to youth." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 127, ObjectiveId = 26, Number = "L9", Title = "Assess climate hazards and vulnerabilities to those hazards across Yukon every three to four years between 2020 and 2030 to prioritize climate change adaptation actions." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 128, ObjectiveId = 26, Number = "L10", Title = "Support the Government of Canada’s work to develop a pan-territorial climate hub by 2030 that will support access to climate data and projections for the north." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 129, ObjectiveId = 26, Number = "L11", Title = "Begin participating in the National Forest Inventory monitoring program in 2022 to gather information about forest carbon stocks, potential biomass energy supply, pest and forest fire risks, and climate impacts on Yukon’s forests." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 130, ObjectiveId = 26, Number = "L12", Title = "Create easy access to technical information and lessons learned about climate change, energy and green economy for governments and stakeholders by 2021." });
            modelBuilder.Entity<Action>().HasData(new Action { Id = 131, ObjectiveId = 26, Number = "L13", Title = "Launch a Yukon-wide information or social marketing campaign in 2021 that will educate Yukoners on greenhouse gas emissions, renewable energy, climate change adaptation, and other topics and highlight what Yukoners can do to support climate change initiatives." });

            modelBuilder.Entity<DirectorsCommittee>().HasData(new DirectorsCommittee { Id = 1, Name = "Resilient Infrastructure" });
            modelBuilder.Entity<DirectorsCommittee>().HasData(new DirectorsCommittee { Id = 2, Name = "Social and Ecological Resilience" });
            modelBuilder.Entity<DirectorsCommittee>().HasData(new DirectorsCommittee { Id = 3, Name = "YG Leadership" });
            modelBuilder.Entity<DirectorsCommittee>().HasData(new DirectorsCommittee { Id = 4, Name = "Unknown" });

            modelBuilder.Entity<Organization>().HasData(new Organization { Id = 1, Name = "Yukon Government" });
            modelBuilder.Entity<Organization>().HasData(new Organization { Id = 2, Name = "ATCO Electric Yukon" });

            modelBuilder.Entity<Department>().HasData(new Department { Id = 1, Name = "Community Services", ShortName = "CS" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 2, Name = "Economic Development", ShortName = "EcDev" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 3, Name = "Education", ShortName = "EDU" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 4, Name = "Energy, Mines and Resources", ShortName = "EMR" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 5, Name = "Environment", ShortName = "ENV" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 6, Name = "Executive Council Office", ShortName = "ECO" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 7, Name = "Finance", ShortName = "FIN" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 8, Name = "Health and Social Services", ShortName = "HSS" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 9, Name = "Highways and Public Works", ShortName = "HPW" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 10, Name = "Justice", ShortName = "JUS" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 11, Name = "Public Service Commission", ShortName = "PSC" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 12, Name = "Tourism and Culture", ShortName = "TC" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 13, Name = "Yukon Development Corporation", ShortName = "YDC" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 14, Name = "Yukon Energy Corporation", ShortName = "YEC" });
            modelBuilder.Entity<Department>().HasData(new Department { Id = 15, Name = "Yukon Housing Corporation", ShortName = "YHC" });

            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 1, OrganizationId = 1 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 2, OrganizationId = 1 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 3, OrganizationId = 1 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 4, OrganizationId = 1 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 5, OrganizationId = 1 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 6, OrganizationId = 1 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 7, OrganizationId = 1 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 8, OrganizationId = 1 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 9, OrganizationId = 1 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 10, OrganizationId = 1 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 11, OrganizationId = 1 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 12, OrganizationId = 2 });
            modelBuilder.Entity<Lead>().HasData(new Lead { Id = 13, OrganizationId = 1 });

            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 1, DepartmentId = 5, Name = "Climate Change Secretariat", LeadId = 1 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 2, DepartmentId = 5, Name = "Water Resources", LeadId = 2 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 3, DepartmentId = 5, Name = "Parks", LeadId = 3 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 4, DepartmentId = 5, Name = "Fish and Wildlife", LeadId = 4 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 5, DepartmentId = 5, Name = "Conservation Officer Services", LeadId = 5 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 6, DepartmentId = 4, Name = "Forest Resources", LeadId = 6 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 7, DepartmentId = 4, Name = "Agriculture", LeadId = 7 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 8, DepartmentId = 4, Name = "Energy", LeadId = 8 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 9, DepartmentId = 9, Name = "Supply Services", LeadId = 9 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 10, DepartmentId = 9, Name = "Strategic Initiatives", LeadId = 10 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 11, DepartmentId = 12, Name = "Culture Services", LeadId = 11 });
            modelBuilder.Entity<Branch>().HasData(new Branch { Id = 12, DepartmentId = 4, Name = "Yukon Geological Survey", LeadId = 13 });

            modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 1,
                    CollectionInterval = CollectionInterval.Biannual,
                    DataType = DataType.Cumulative,
                    Description = "Total number of heavy-duty zero emission vehicles registered in Yukon.",
                    Title = "ZEVs - Total heavy duty",
                    UnitOfMeasurementId = 2
                });

            modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 2,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Total electricity generated off-grid during the reporting year (thermal and renewable).",
                    Title = "Off-grid generation - total",
                    UnitOfMeasurementId = 2
                });

            modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 3,
                    CollectionInterval = CollectionInterval.Biannual,
                    DataType = DataType.Cumulative,
                    Description = "Number of energy assessments of Government of Yukon buildings completed during the reporting year.",
                    Title = "YG buildings - energy assessments completed",
                    UnitOfMeasurementId = 2
                });

            modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 4,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Yukon Agricultural Self-Sufficiency Indicator.",
                    Title = "Food self-sufficiency",
                    UnitOfMeasurementId = 2
                });

            modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 5,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Total GHGs from the Government of Yukon's operations.",
                    Title = "YG GHGs - total",
                    UnitOfMeasurementId = 1
                });

            modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id = 6,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Volume of wood harvested by commercial entities for biomass energy during the reporting year.",
                    Title = "Commercial biomass harvest",
                    UnitOfMeasurementId = 12
                });

            modelBuilder.Entity<Indicator>()
                .HasData(new Indicator {
                    Id= 7,
                    CollectionInterval = CollectionInterval.Annual,
                    DataType = DataType.Incremental,
                    Description = "Change in volume of glaciers in the coast mountains during the reporting year.",
                    Title = "Glacier volume change",
                    UnitOfMeasurementId = 14
                });

            modelBuilder.Entity("IndicatorLead").HasData(
                new { IndicatorsId = 1, LeadsId = 8 },
                new { IndicatorsId = 2, LeadsId = 12 },
                new { IndicatorsId = 3, LeadsId = 10 },
                new { IndicatorsId = 4, LeadsId = 7 },
                new { IndicatorsId = 5, LeadsId = 1 },
                new { IndicatorsId = 6, LeadsId = 6 },
                new { IndicatorsId = 7, LeadsId = 13 }
                );

                    //var indicatorId = 1;
                    //var indicators = new Faker<Indicator>("en_CA")
                    //    .RuleFor(i => i.Id, _ => indicatorId++)
                    //    .RuleFor(i => i.CollectionInterval, _ => _.PickRandom<CollectionInterval>())
                    //    .RuleFor(i => i.DataType, _ => _.PickRandom<DataType>())
                    //    .RuleFor(i => i.Description, _ => "Total number of heavy-duty zero emission vehicles registered in Yukon.")
                    //    .RuleFor(i => i.DisplayName, _ => "ZEVs - Total heavy duty")
                    //    .RuleFor(i => i.IsActive, _ => true)
                    //    .RuleFor(i => i.OurCleanFutureReferenceId, _ => 1)
                    //    .RuleFor(i => i.LeadId, _ => 1);
                    //_modelBuilder.Entity<Indicator>().HasData(indicators.Generate(1));
        }
    }
}