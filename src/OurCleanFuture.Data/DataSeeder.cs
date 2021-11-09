using Microsoft.EntityFrameworkCore;
using OurCleanFuture.Data.Entities;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.Data;

internal class DataSeeder
{
    private readonly ModelBuilder modelBuilder;

    public DataSeeder(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Init()
    {
        modelBuilder.Entity<UnitOfMeasurement>().HasData(
            new UnitOfMeasurement { Id = 1, Name = "Kilograms of carbon dioxide equivalent", Symbol = "kgCO₂e" },
            new UnitOfMeasurement { Id = 2, Name = "Count", Symbol = "count" },
            new UnitOfMeasurement { Id = 3, Name = "Megawatts", Symbol = "MW" },
            new UnitOfMeasurement { Id = 4, Name = "Dollars", Symbol = "$" },
            new UnitOfMeasurement { Id = 5, Name = "Percent", Symbol = "%" },
            new UnitOfMeasurement { Id = 6, Name = "Proportion", Symbol = "proportion" },
            new UnitOfMeasurement { Id = 7, Name = "Tons of carbon dioxide equivalent per litre", Symbol = "tCO₂e/L" },
            new UnitOfMeasurement { Id = 8, Name = "Kilotons of carbon dioxide equivalent", Symbol = "ktCO₂e" },
            new UnitOfMeasurement { Id = 9, Name = "Tons of carbon dioxide equivalent per person", Symbol = "tCO₂e/person" },
            new UnitOfMeasurement { Id = 10, Name = "Litres", Symbol = "L" },
            new UnitOfMeasurement { Id = 11, Name = "Gigawatt hours", Symbol = "GWh" },
            new UnitOfMeasurement { Id = 12, Name = "Cubic metres", Symbol = "m³" },
            new UnitOfMeasurement { Id = 13, Name = "Kilometres", Symbol = "km" },
            new UnitOfMeasurement { Id = 14, Name = "Cubic kilometres", Symbol = "km³" },
            new UnitOfMeasurement { Id = 15, Name = "Tons per person", Symbol = "t/person" },
            new UnitOfMeasurement { Id = 16, Name = "Kilotonnes per million chained (2012) dollars", Symbol = "kt/$1MM chained (2012)" },
            new UnitOfMeasurement { Id = 17, Name = "Gigawatts", Symbol = "GW" },
            new UnitOfMeasurement { Id = 18, Name = "Megawatt hours", Symbol = "MWh" }
        );

        modelBuilder.Entity<Goal>().HasData(
            new Goal { Id = 1, Title = "Reduce Yukon's greenhouse gas emissions." },
            new Goal { Id = 2, Title = "Ensure Yukoners have access to reliable, affordable and renewable energy." },
            new Goal { Id = 3, Title = "Adapt to the impacts of climate change." },
            new Goal { Id = 4, Title = "Build a green economy." }
        );

        modelBuilder.Entity<Area>().HasData(
            new Area { Id = 1, Title = "Transportation" },
            new Area { Id = 2, Title = "Homes and buildings" },
            new Area { Id = 3, Title = "Energy production" },
            new Area { Id = 4, Title = "People and the environment" },
            new Area { Id = 5, Title = "Communities" },
            new Area { Id = 6, Title = "Innovation" },
            new Area { Id = 7, Title = "Leadership" }
        );

        modelBuilder.Entity<Objective>().HasData(
            new Objective { Id = 1, Title = "Increase the number of zero emission vehicles on our roads.", AreaId = 1 },
            new Objective { Id = 2, Title = "Reduce the lifecycle carbon intensity of transportation fuels.", AreaId = 1 },
            new Objective { Id = 3, Title = "Increase the use of public and active transportation.", AreaId = 1 },
            new Objective { Id = 4, Title = "Reduce the carbon footprint from medium and heavy-duty vehicles.", AreaId = 1 },
            new Objective { Id = 5, Title = "Be more efficient in how and when we travel.", AreaId = 1 },
            new Objective { Id = 6, Title = "Ensure roads, runways and other transportation infrastructure are resilient to the impacts of climate change.", AreaId = 1 },
            new Objective { Id = 7, Title = "Improve the energy efficiency and climate resilience of existing homes and buildings.", AreaId = 2 },
            new Objective { Id = 8, Title = "Ensure new homes and buildings are built to be low-carbon and climate-resilient.", AreaId = 2 },
            new Objective { Id = 9, Title = "Increase the use of biomass and other renewable energy sources for heating.", AreaId = 2 },
            new Objective { Id = 10, Title = "Use energy more efficiently and better align energy supply and demand.", AreaId = 2 },
            new Objective { Id = 11, Title = "Increase the supply of electricity generated from renewable sources.", AreaId = 3 },
            new Objective { Id = 12, Title = "Support local and community-based renewable energy projects for heating and electricity.", AreaId = 3 },
            new Objective { Id = 13, Title = "Ensure electricity generation, transmission and distribution infrastructure is resilient to the impacts of climate change.", AreaId = 3 },
            new Objective { Id = 14, Title = "Respond to the impacts of climate change on wild species and their habitats.", AreaId = 4 },
            new Objective { Id = 15, Title = "Maintain our ability to practice traditional and cultural activities on the land.", AreaId = 4 },
            new Objective { Id = 16, Title = "Protect and enhance human health and wellbeing in a changing climate.", AreaId = 4 },
            new Objective { Id = 17, Title = "Design our communities to be low-carbon and resilient to the impacts of climate change.", AreaId = 5 },
            new Objective { Id = 18, Title = "Ensure we are prepared for emergencies that are becoming more likely due to climate change.", AreaId = 5 },
            new Objective { Id = 19, Title = "Supply more of what we eat through sustainable local food production.", AreaId = 5 },
            new Objective { Id = 20, Title = "Support innovation and green business practices.", AreaId = 6 },
            new Objective { Id = 21, Title = "Reduce the carbon intensity of mining and ensure mining projects are prepared for the impacts of climate change.", AreaId = 6 },
            new Objective { Id = 22, Title = "Enhance the sustainability of Yukon’s tourism industry.", AreaId = 6 },
            new Objective { Id = 23, Title = "Improve how we manage our waste to move toward a more circular economy.", AreaId = 6 },
            new Objective { Id = 24, Title = "Ensure the goals of this strategy are incorporated into government planning and operations.", AreaId = 7 },
            new Objective { Id = 25, Title = "Educate and empower youth as the next generation of leaders.", AreaId = 7 },
            new Objective { Id = 26, Title = "Ensure Yukoners have the information needed to make evidence-based decisions.", AreaId = 7 }
        );

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

        modelBuilder.Entity<Action>().HasData(
            new Action { Id = 1, ObjectiveId = 1, Number = "T1", Title = "Work with local vehicle dealerships and manufacturers to establish a system by 2024 to ensure zero emission vehicles are 10 per cent of light duty vehicle sales by 2025 and 30 per cent by 2030." },
            new Action { Id = 2, ObjectiveId = 1, Number = "T2", Title = "Ensure at least 50 per cent of all new light-duty cars purchased by the Government of Yukon are zero emission vehicles each year from 2020 to 2030." },
            new Action { Id = 3, ObjectiveId = 1, Number = "T3", Title = "Provide a rebate to Yukon businesses and individuals who purchase eligible zero emission vehicles beginning in 2020." },
            new Action { Id = 4, ObjectiveId = 1, Number = "T4", Title = "Continue to install fast-charging stations across Yukon to make it possible to travel between all road-accessible Yukon communities by 2027 and work with neighbouring governments and organizations to explore options to connect Yukon with BC." },
            new Action { Id = 5, ObjectiveId = 1, Number = "T5", Title = "Provide rebates to support the installation of smart electric vehicle charging stations at residential, commercial and institutional buildings in collaboration with Yukon’s publicutilities beginning in 2020." },
            new Action { Id = 6, ObjectiveId = 1, Number = "T6", Title = "Require new residential buildings to be built with the electrical infrastructure to support Level 2 electric vehicle charging beginning on April 1." },
            new Action { Id = 7, ObjectiveId = 1, Number = "T7", Title = "Draft legislation by 2024 that will enable private businesses and Yukon’s public utilities to sell electricity for the purpose of electric vehicle charging." },
            new Action { Id = 8, ObjectiveId = 1, Number = "T8", Title = "Continue to run public education events and campaigns to raise awareness of the benefits of electric vehicles and how they function in cold climates." },
            new Action { Id = 9, ObjectiveId = 2, Number = "T9", Title = "Require all diesel fuel sold in Yukon for transportation to align with the percentage of biodiesel and renewable diesel by volume in leading Canadian jurisdictions beginning in 2025." },
            new Action { Id = 10, ObjectiveId = 2, Number = "T10", Title = "Require all gasoline sold in Yukon for transportation to align with the percentage of ethanol by volume in leading Canadian jurisdictions beginning in 2025." },
            new Action { Id = 11, ObjectiveId = 3, Number = "T11", Title = "Provide rebates to encourage the purchase of electric bicycles for personal and business commuting beginning in 2020." },
            new Action { Id = 12, ObjectiveId = 3, Number = "T12", Title = "Continue to support municipalities and First Nations to make investments in public and active transportation infrastructure." },
            new Action { Id = 13, ObjectiveId = 3, Number = "T13", Title = "Continue to incorporate active transportation in the design of highways and other Government of Yukon transportation infrastructure near communities." },
            new Action { Id = 14, ObjectiveId = 4, Number = "T14", Title = "Update the Government of Yukon’s heavy-duty vehicle fleet by 2030 to reduce greenhouse gas emissions and fuel costs." },
            new Action { Id = 15, ObjectiveId = 4, Number = "T15", Title = "Begin a pilot project in 2021 to test the use of short-haul medium and heavy-duty electric vehicles for commercial and institutional applications within Yukon." },
            new Action { Id = 16, ObjectiveId = 4, Number = "T16", Title = "Train the Government of Yukon’s heavy equipment operators on efficient driving techniques for all new equipment by 2022." },
            new Action { Id = 17, ObjectiveId = 5, Number = "T17", Title = "Expand the Government of Yukon’s video and teleconferencing systems and require employees to consider these options when requesting permission for work travel by 2022." },
            new Action { Id = 18, ObjectiveId = 5, Number = "T18", Title = "Implement new policies to enable Government of Yukon employees in suitable positions to work from home for the longer term by 2022." },
            new Action { Id = 19, ObjectiveId = 5, Number = "T19", Title = "Develop a planning and engagement strategy by 2022 to change how and where Government of Yukon employees work by providing choices and flexibility through a modern workplace." },
            new Action { Id = 20, ObjectiveId = 5, Number = "T20", Title = "Develop and implement a system by 2021 to coordinate carpooling for Government of Yukon staff travelling by vehicle for work within Yukon." },
            new Action { Id = 21, ObjectiveId = 5, Number = "T21", Title = "Develop guidelines for the Government of Yukon Fleet Vehicle Agency’s fleet by 2021 to ensure appropriate vehicles are used for the task at hand." },
            new Action { Id = 22, ObjectiveId = 5, Number = "T22", Title = "Incorporate fuel efficiency into purchasing decisions for Government of Yukon fleet vehicles beginning in 2020 to reduce greenhouse gas emissions and fuel costs." },
            new Action { Id = 23, ObjectiveId = 5, Number = "T23", Title = "Expand virtual health care services to Whitehorse medical clinics by 2022 in order to improve access to healthcare while reducing greenhouse gas emissions from travel to and from Whitehorse." },
            new Action { Id = 24, ObjectiveId = 5, Number = "T24", Title = "Continue to operate the Yukon Rideshare program to make carpooling and other shared travel easier." },
            new Action { Id = 25, ObjectiveId = 6, Number = "T25", Title = "Complete a climate change vulnerability study of the road transportation network by 2023 to inform the development of standards and specifications." },
            new Action { Id = 26, ObjectiveId = 6, Number = "T26", Title = "Establish a geohazard mapping program for major transportation corridors and prioritize sections for targeted permafrost study by 2022." },
            new Action { Id = 27, ObjectiveId = 6, Number = "T27", Title = "Analyze flood risk along critical transportation corridors at risk of flooding by 2023." },
            new Action { Id = 28, ObjectiveId = 6, Number = "T28", Title = "Continue to conduct climate risk assessments of all major transportation infrastructure projects above $10 million, such as through the federal Climate Lens assessment." },
            new Action { Id = 29, ObjectiveId = 7, Number = "H1", Title = "Conduct retrofits to Government of Yukon buildings to reduce energy use and contribute to a 30 per cent reduction in greenhouse gas emissions by 2030." },
            new Action { Id = 30, ObjectiveId = 7, Number = "H2", Title = "Conduct energy assessments of Government of Yukon buildings to identify opportunities for energy efficiency and greenhouse gas reductions, with the first period of assessments completed by 2025 and the second period completed by 2030." },
            new Action { Id = 31, ObjectiveId = 7, Number = "H3", Title = "Provide low-interest financing to support energy efficiency retrofits to homes and buildings beginning in 2021." },
            new Action { Id = 32, ObjectiveId = 7, Number = "H4", Title = "Continue to provide financial support to assist First Nations and municipalities to complete major energy retrofits to institutional buildings across Yukon, aiming for 30 retrofits by 2030." },
            new Action { Id = 33, ObjectiveId = 7, Number = "H5", Title = "Continue to provide financial support for municipal and First Nations energy efficiency projects." },
            new Action { Id = 34, ObjectiveId = 7, Number = "H6", Title = "Continue to work with Yukon First Nations to retrofit First Nations housing to be more energy efficient." },
            new Action { Id = 35, ObjectiveId = 7, Number = "H7", Title = "Continue to retrofit Government of Yukon community housing to reduce greenhouse gas emissions in each building by 30 per cent." },
            new Action { Id = 36, ObjectiveId = 7, Number = "H8", Title = "Continue to provide rebates for thermal enclosure upgrades and energy efficient equipment to reduce energy use in homes and commercial buildings." },
            new Action { Id = 37, ObjectiveId = 7, Number = "H9", Title = "Assess ways to ensure Yukoners can access adequate insurance for fires, floods and permafrost thaw by 2023." },
            new Action { Id = 38, ObjectiveId = 7, Number = "H10", Title = "Develop and implement a plan by 2024 to conduct routine monitoring of the structural condition of Government of Yukon buildings located on permafrost." },
            new Action { Id = 39, ObjectiveId = 7, Number = "H11", Title = "Assess options to provide financial support for actions to improve the climate resiliency of homes and buildings by 2023." },
            new Action { Id = 40, ObjectiveId = 8, Number = "H12", Title = "Work with the Government of Canada to develop and implement building codes suitable to northern Canada that will aspire to see all new residential and commercial buildings be net zero energy ready by 2032." },
            new Action { Id = 41, ObjectiveId = 8, Number = "H13", Title = "Continue to require all new Government of Yukon buildings to be designed to use 35 per cent less energy than the targets in the National Energy Code for Buildings, in accordance with the Government of Yukon’s Design Requirements and Building Standards Manual." },
            new Action { Id = 42, ObjectiveId = 8, Number = "H14", Title = "Adopt and enforce relevant building standards by 2030 that will require new buildings to be constructed to be more resilient to climate change impacts like permafrost thaw, flooding and forest fires." },
            new Action { Id = 43, ObjectiveId = 8, Number = "H15", Title = "Continue to conduct climate risk assessments of all major building projects over $10 million that are built or funded by the Government of Yukon." },
            new Action { Id = 44, ObjectiveId = 8, Number = "H16", Title = "Continue to provide rebates for new homes that are net zero energy ready, aiming for 500 homes by 2030." },
            new Action { Id = 45, ObjectiveId = 9, Number = "H17", Title = "Install renewable heat sources such as biomass energy in Government of Yukon buildings by 2030 to create long-term demand for renewable heating and contribute to a 30 per cent reduction in greenhouse gas emissions." },
            new Action { Id = 46, ObjectiveId = 9, Number = "H18", Title = "Provide low-interest financing to install smart electric heating devices in residential, commercial and institutional buildings in collaboration with Yukon’s public utilities beginning in 2021." },
            new Action { Id = 47, ObjectiveId = 9, Number = "H19", Title = "Provide low-interest financing to install biomass heating systems in commercial and institutional buildings beginning in 2021." },
            new Action { Id = 48, ObjectiveId = 9, Number = "H20", Title = "Continue to assist First Nations to complete feasibility studies for the installation and operation of biomass heating systems." },
            new Action { Id = 49, ObjectiveId = 9, Number = "H21", Title = "Continue to provide rebates for residential, commercial and institutional biomass heating systems and smart electric heating devices and increase the current rebate for smart electric heating devices beginning in 2020." },
            new Action { Id = 50, ObjectiveId = 9, Number = "H22", Title = "Work with local industry to install and test 25 electric heat pumps with backup fossil fuel heating systems or utility-controlled electric thermal storage from 2020 to 2023." },
            new Action { Id = 51, ObjectiveId = 9, Number = "H23", Title = "Identify regulatory improvements that could support the growth of Yukon’s biomass energy industry during the review of the Forest Resources Act by 2022." },
            new Action { Id = 52, ObjectiveId = 9, Number = "H24", Title = "Amend the Air Emissions Regulations by 2025 in order to regulate air emissions from commercial and institutional biomass burning systems to minimize the release of harmful air pollutants." },
            new Action { Id = 53, ObjectiveId = 9, Number = "H25", Title = "Analyze and compare the climate benefits of different types of biomass harvesting and use in Yukon by 2021 in order to identify recommended forest management practices to guide sustainable and low-carbon biomass use." },
            new Action { Id = 54, ObjectiveId = 10, Number = "H26", Title = "Provide direction to the Yukon Utilities Board in 2020 to allow Yukon’s public utilities to partner with the Government of Yukon to pursue cost-effective demand-side management measures." },
            new Action { Id = 55, ObjectiveId = 10, Number = "H27", Title = "Establish a partnership between the Government of Yukon, Yukon Energy Corporation and ATCO Electric Yukon by 2021 that will collaborate on the delivery of energy and capacity demand-side management programs." },
            new Action { Id = 56, ObjectiveId = 10, Number = "H28", Title = "Complete the Peak Smart pilot project by 2022 to evaluate the use of smart devices to shift energy demand to off-peak hours." },
            new Action { Id = 57, ObjectiveId = 10, Number = "H29", Title = "Implement an education campaign for Government of Yukon building occupants and visitors by 2026 to encourage more energy efficient behaviours." },
            new Action { Id = 58, ObjectiveId = 11, Number = "E1", Title = "While aiming for an aspirational target of 97 per cent by 2030, develop legislation by 2023 that will require at least 93 per cent of the electricity generated on the Yukon Integrated System to come from renewable sources, calculated as a long-term rolling average." },
            new Action { Id = 59, ObjectiveId = 11, Number = "E2", Title = "Require some of the diesel used to generate electricity on the Yukon Integrated System and in off-grid communities to be substituted with clean diesel alternatives like biodiesel and renewable diesel beginning in 2025, aiming for around 20 per cent." },
            new Action { Id = 60, ObjectiveId = 11, Number = "E3", Title = "Update the Public Utilities Act by 2025 to ensure an effective and efficient process for regulating electricity in Yukon." },
            new Action { Id = 61, ObjectiveId = 11, Number = "E4", Title = "Install renewable electricity generation systems in 5 Government of Yukon buildings in off-grid locations by 2025 to reduce reliance on diesel-generated electricity." },
            new Action { Id = 62, ObjectiveId = 11, Number = "E5", Title = "Evaluate the potential to generate renewable electricity at remote historic sites co-managed by the Government of Yukon and Yukon First Nations by 2022." },
            new Action { Id = 63, ObjectiveId = 12, Number = "E6", Title = "Continue to provide financial and technical support for Yukon First Nations, municipalities and community organizations to undertake community-led renewable energy projects." },
            new Action { Id = 64, ObjectiveId = 12, Number = "E7", Title = "Work with Yukon’s public utilities to continue to implement the Independent Power Production Policy that enables independent power producers, including Yukon First Nations and communities, to generate and sell electricity to the grid." },
            new Action { Id = 65, ObjectiveId = 12, Number = "E8", Title = "Increase the limit of the Standing Offer Program under the Independent Power Production Policy from 20 gigawatt hours (GWh) to 40 GWh by 2021 to support additional community-based renewable energy projects on Yukon’s main electrical grid." },
            new Action { Id = 66, ObjectiveId = 12, Number = "E9", Title = "Develop a framework by 2022 for First Nations to economically participate in renewable electricity projects developed by Yukon’s public utilities." },
            new Action { Id = 67, ObjectiveId = 12, Number = "E10", Title = "Continue to deliver the Micro-generation Program in collaboration with Yukon’s public utilities, targeting 7 megawatts (MW) of installed renewable electricity capacity by 2030." },
            new Action { Id = 68, ObjectiveId = 12, Number = "E11", Title = "Develop legislation by 2023 to regulate geothermal energy development in Yukon." },
            new Action { Id = 69, ObjectiveId = 12, Number = "E12", Title = "Research the potential to use geothermal energy for heating and electricity, with a focus along Yukon fault systems, by 2025." },
            new Action { Id = 70, ObjectiveId = 13, Number = "E13", Title = "Improve modelling of the impacts of climate change on hydroelectricity reservoirs by 2021 and incorporate this information into short, medium and long-term forecasts for renewable hydroelectricity generation." },
            new Action { Id = 71, ObjectiveId = 13, Number = "E14", Title = "Develop a climate change adaptation plan for the Yukon Energy Corporation by 2022 that will identify risks and appropriate responses to ensure Yukon’s main electrical grid is resilient to the impacts of climate change." },
            new Action { Id = 72, ObjectiveId = 13, Number = "E15", Title = "Implement a glacier monitoring program in 2020 to improve our ability to predict the impacts of glacier melt on hydrological systems and hydroelectricity generation." },
            new Action { Id = 73, ObjectiveId = 14, Number = "P1", Title = "Establish a standardized method to determine the health status of wetland ecosystems and complete a pilot study to measure the baseline conditions of various reference wetlands by 2022 to better understand future changes." },
            new Action { Id = 74, ObjectiveId = 14, Number = "P2", Title = "Adapt existing surface and groundwater monitoring networks by 2026 to be able to track long-term trends in water quality and quantity in a changing climate." },
            new Action { Id = 75, ObjectiveId = 14, Number = "P3", Title = "Continue to lead and participate in projects that improve our understanding of how climate change is affecting ecosystems, wild species and their habitats." },
            new Action { Id = 76, ObjectiveId = 14, Number = "P4", Title = "Continue to monitor key species that will provide an indication of the impacts of climate change on Yukon ecosystems and expand monitoring to more taxonomic groups." },
            new Action { Id = 77, ObjectiveId = 14, Number = "P5", Title = "Continue to incorporate climate change into the design of protected and managed areas using landscape conservation science in order to allow native species to move, adapt and survive in the face of climate change." },
            new Action { Id = 78, ObjectiveId = 14, Number = "P6", Title = "Continue to track new and invasive species to Yukon that could impact ecosystems and biodiversity." },
            new Action { Id = 79, ObjectiveId = 15, Number = "P7", Title = "Work with Yukon First Nations to develop a tailored hunter education program by 2023 that can be adapted and delivered by Yukon First Nations for First Nations citizens." },
            new Action { Id = 80, ObjectiveId = 15, Number = "P8", Title = "Work collaboratively with First Nations and the Inuvialuit to document information from historic sites and culturally important places on the North Slope that are at risk due to climate change by 2024." },
            new Action { Id = 81, ObjectiveId = 16, Number = "P9", Title = "Provide training to healthcare providers beginning in 2023 to be better able to identify and treat the physical and mental health impacts of climate change." },
            new Action { Id = 82, ObjectiveId = 16, Number = "P10", Title = "Incorporate climate-related illnesses like heat stroke, respiratory illness, and vector-borne diseases into the new 1Health Yukon health information system by 2023 to enable tracking of climate-related illnesses in Yukon." },
            new Action { Id = 83, ObjectiveId = 16, Number = "P11", Title = "Expand monitoring of concentrations of particulate matter in the air from biomass burning and forest fires to all Yukon communities by 2023." },
            new Action { Id = 84, ObjectiveId = 16, Number = "P12", Title = "Purchase a moveable clean air shelter by 2021 that can be set up in communities to protect public health during wildfire smoke events." },
            new Action { Id = 85, ObjectiveId = 16, Number = "P13", Title = "Provide financial support to vulnerable Yukoners to install cleaner air spaces in their homes and buildings beginning in 2023 to provide protection from wildfire smoke." },
            new Action { Id = 86, ObjectiveId = 16, Number = "P14", Title = "Analyze existing information on food insecurity in Yukon by 2023 to inform the development of a system to gather food insecurity data into the future." },
            new Action { Id = 87, ObjectiveId = 17, Number = "C1", Title = "Expand geohazard map coverage to all Yukon communities with a high risk of permafrost thaw by 2025." },
            new Action { Id = 88, ObjectiveId = 17, Number = "C2", Title = "Develop flood probability maps for all Yukon communities at risk of flooding by 2023 that incorporate climate change projections." },
            new Action { Id = 89, ObjectiveId = 17, Number = "C3", Title = "Develop detailed guidelines by 2025 that can be used by the Government of Yukon and partners to develop walkable, bike-friendly and transit-oriented communities." },
            new Action { Id = 90, ObjectiveId = 17, Number = "C4", Title = "Continue to develop, encourage and apply applicable climate resiliency standards to community design and infrastructure development projects built by or receiving capital funding from the Government of Yukon." },
            new Action { Id = 91, ObjectiveId = 17, Number = "C5", Title = "Continue to conduct detailed climate change risk assessments of all major community infrastructure projects over $10 million that are built or funded by the Government of Yukon." },
            new Action { Id = 92, ObjectiveId = 17, Number = "C6", Title = "Continue to make recommendations to consider the impacts of climate change in regional land use and local area planning processes, which inform the Government of Yukon’s development permitting and zoning decisions." },
            new Action { Id = 93, ObjectiveId = 17, Number = "C7", Title = "Continue to provide technical and administrative support to Yukon First Nations and municipalities to prepare integrated asset management plans." },
            new Action { Id = 94, ObjectiveId = 18, Number = "C8", Title = "Expand monitoring networks and improve modelling tools to generate reliable daily flood forecasts and relevant warnings for all at-risk Yukon communities by 2024." },
            new Action { Id = 95, ObjectiveId = 18, Number = "C9", Title = "Work with First Nations and municipalities to develop Wildfire Protection Plans for all Yukon communities by 2026 and to complete the forest fuel management activities outlined in the plans by 2030." },
            new Action { Id = 96, ObjectiveId = 18, Number = "C10", Title = "Increase the capacity in Yukon Wildland Fire to prevent wildfires and respond to extended fire seasons by investing in staffing in 2020." },
            new Action { Id = 97, ObjectiveId = 18, Number = "C11", Title = "Complete hazard identification and risk assessments (HIRAs) for all Yukon communities by 2022 that include climate change risks." },
            new Action { Id = 98, ObjectiveId = 18, Number = "C12", Title = "Work with First Nations and municipalities to complete emergency management plans for all Yukon communities by 2022 informed by community hazard identification and risk assessments (HIRAs)." },
            new Action { Id = 99, ObjectiveId = 18, Number = "C13", Title = "Develop a territorial disaster financial assistance policy by 2022 to support recovery from natural disasters that result in extensive property damage or disruption to the delivery of essential goods and services." },
            new Action { Id = 100, ObjectiveId = 19, Number = "C14", Title = "Develop a territorial disaster financial assistance policy by 2022 to support recovery from natural disasters that result in extensive property damage or disruption to the delivery of essential goods and services." },
            new Action { Id = 101, ObjectiveId = 19, Number = "C15", Title = "Continue to provide funding for community gardens and greenhouses, especially in rural communities." },
            new Action { Id = 102, ObjectiveId = 19, Number = "C16", Title = "Continue to provide technical advice to assist First Nations and municipal governments with their agricultural and animal husbandry projects." },
            new Action { Id = 103, ObjectiveId = 19, Number = "C17", Title = "Continue to conduct and provide access to funding for research on how climate change could affect local agriculture." },
            new Action { Id = 104, ObjectiveId = 19, Number = "C18", Title = "Continue to support agricultural producers to adapt to the impacts of climate change, adopt low-carbon practices and use surface water and groundwater efficiently." },
            new Action { Id = 105, ObjectiveId = 20, Number = "I1", Title = "Incorporate greenhouse gas emissions into the decision-making process for Department of Economic Development funding programs by 2022." },
            new Action { Id = 106, ObjectiveId = 20, Number = "I2", Title = "Update the Government of Yukon’s procurement policies and standards in 2020 to better support sustainable and local procurement." },
            new Action { Id = 107, ObjectiveId = 20, Number = "I3", Title = "Identify and develop options to address potential regulatory and policy barriers to the growth of green businesses in Yukon by 2023." },
            new Action { Id = 108, ObjectiveId = 20, Number = "I4", Title = "Expand the range of relevant professional development offerings by 2023 to enable more Yukoners to participate in the green economy." },
            new Action { Id = 109, ObjectiveId = 20, Number = "I5", Title = "Create an award program by 2022 to recognize the achievements of local green businesses and organizations." },
            new Action { Id = 110, ObjectiveId = 21, Number = "I6", Title = "Include new provisions in quartz mine licenses by 2022 that will ensure critical mine infrastructure is planned, designed and built to withstand current and projected impacts of climate change." },
            new Action { Id = 111, ObjectiveId = 21, Number = "I7", Title = "Require quartz mines to project their anticipated greenhouse gas emissions, identify measures to reduce emissions, and annually report greenhouse gas emissions through the quartz mine licensing process beginning in 2022." },
            new Action { Id = 112, ObjectiveId = 21, Number = "I8", Title = "Increase the Government of Yukon’s participation in intergovernmental initiatives related to mine resiliency, low-carbon mining and innovation by 2021." },
            new Action { Id = 113, ObjectiveId = 21, Number = "I9", Title = "Establish an intensity-based greenhouse gas reduction target for Yukon’s mining industry and additional actions needed to reach the target by 2022." },
            new Action { Id = 114, ObjectiveId = 22, Number = "I10", Title = "Establish and implement a framework to measure the sustainability of tourism development in Yukon by 2021." },
            new Action { Id = 115, ObjectiveId = 22, Number = "I11", Title = "Develop and implement a system to track greenhouse gas emissions from Yukon’s tourism industry by 2021." },
            new Action { Id = 116, ObjectiveId = 23, Number = "I12", Title = "Assess options for establishing a comprehensive waste diversion system in Government of Yukon buildings, including reuse, recycling, compost and e-waste collection by 2030." },
            new Action { Id = 117, ObjectiveId = 23, Number = "I13", Title = "Develop legislation that will enable the Government of Yukon to restrict or prohibit the production, supply or distribution of appropriate single use bags by 2021." },
            new Action { Id = 118, ObjectiveId = 23, Number = "I14", Title = "Design and implement a system for Extended Producer Responsibility by 2025 that will make producers responsible for managing materials through the lifecycle of a product." },
            new Action { Id = 119, ObjectiveId = 24, Number = "L1", Title = "Create a Clean Energy Act by 2023 that legislates our greenhouse gas reduction targets and our commitments to energy efficiency and demand-side management to hold the Government of Yukon accountable." },
            new Action { Id = 120, ObjectiveId = 24, Number = "L2", Title = "Incorporate a climate change lens into the decision-making process for major Government of Yukon policies, programs and projects by 2021." },
            new Action { Id = 121, ObjectiveId = 24, Number = "L3", Title = "Incorporate climate change risks into Government of Yukon departmental planning processes by 2022." },
            new Action { Id = 122, ObjectiveId = 24, Number = "L4", Title = "Incorporate greenhouse gas emissions and energy efficiency into the process for identifying and prioritizing Government of Yukon building retrofits and new construction projects by 2023." },
            new Action { Id = 123, ObjectiveId = 24, Number = "L5", Title = "Develop and offer climate change training for Government of Yukon employees by 2022." },
            new Action { Id = 124, ObjectiveId = 25, Number = "L6", Title = "Create a Youth Panel on Climate Change in 2020 that will provide advice and perspectives to the Government of Yukon on climate change, energy and green economy matters that reflects the diversity of Yukon youth." },
            new Action { Id = 125, ObjectiveId = 25, Number = "L7", Title = "Provide mentorship opportunities for Yukon youth to participate in major international climate change and energy events with Government of Yukon staff beginning in 2023." },
            new Action { Id = 126, ObjectiveId = 25, Number = "L8", Title = "Continue to support land-based programs in the Yukon school curriculum that teach First Nations ways of knowing and doing to youth." },
            new Action { Id = 127, ObjectiveId = 26, Number = "L9", Title = "Assess climate hazards and vulnerabilities to those hazards across Yukon every three to four years between 2020 and 2030 to prioritize climate change adaptation actions." },
            new Action { Id = 128, ObjectiveId = 26, Number = "L10", Title = "Support the Government of Canada’s work to develop a pan-territorial climate hub by 2030 that will support access to climate data and projections for the north." },
            new Action { Id = 129, ObjectiveId = 26, Number = "L11", Title = "Begin participating in the National Forest Inventory monitoring program in 2022 to gather information about forest carbon stocks, potential biomass energy supply, pest and forest fire risks, and climate impacts on Yukon’s forests." },
            new Action { Id = 130, ObjectiveId = 26, Number = "L12", Title = "Create easy access to technical information and lessons learned about climate change, energy and green economy for governments and stakeholders by 2021." },
            new Action { Id = 131, ObjectiveId = 26, Number = "L13", Title = "Launch a Yukon-wide information or social marketing campaign in 2021 that will educate Yukoners on greenhouse gas emissions, renewable energy, climate change adaptation, and other topics and highlight what Yukoners can do to support climate change initiatives." }
        );

        modelBuilder.Entity<DirectorsCommittee>().HasData(
            new DirectorsCommittee { Id = 1, Name = "AGEDS" },
            new DirectorsCommittee { Id = 2, Name = "Resilient Infrastructure" },
            new DirectorsCommittee { Id = 3, Name = "Social and Ecological Resilience" },
            new DirectorsCommittee { Id = 4, Name = "YG Leadership" }
        );

        modelBuilder.Entity<Organization>().HasData(
            new Organization { Id = 1, Name = "Yukon Government" },
            new Organization { Id = 2, Name = "ATCO Electric Yukon" }
        );

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Community Services", ShortName = "CS" },
            new Department { Id = 2, Name = "Economic Development", ShortName = "EcDev" },
            new Department { Id = 3, Name = "Education", ShortName = "EDU" },
            new Department { Id = 4, Name = "Energy, Mines and Resources", ShortName = "EMR" },
            new Department { Id = 5, Name = "Environment", ShortName = "ENV" },
            new Department { Id = 6, Name = "Executive Council Office", ShortName = "ECO" },
            new Department { Id = 7, Name = "Finance", ShortName = "FIN" },
            new Department { Id = 8, Name = "Health and Social Services", ShortName = "HSS" },
            new Department { Id = 9, Name = "Highways and Public Works", ShortName = "HPW" },
            new Department { Id = 10, Name = "Justice", ShortName = "JUS" },
            new Department { Id = 11, Name = "Public Service Commission", ShortName = "PSC" },
            new Department { Id = 12, Name = "Tourism and Culture", ShortName = "TC" },
            new Department { Id = 13, Name = "Yukon Development Corporation", ShortName = "YDC" },
            new Department { Id = 14, Name = "Yukon Energy Corporation", ShortName = "YEC" },
            new Department { Id = 15, Name = "Yukon Housing Corporation", ShortName = "YHC" }
        );

        modelBuilder.Entity<Lead>().HasData(
            new Lead { Id = 1, OrganizationId = 1, BranchId = 1 },
            new Lead { Id = 2, OrganizationId = 1, BranchId = 2 },
            new Lead { Id = 3, OrganizationId = 1, BranchId = 3 },
            new Lead { Id = 4, OrganizationId = 1, BranchId = 4 },
            new Lead { Id = 5, OrganizationId = 1, BranchId = 5 },
            new Lead { Id = 6, OrganizationId = 1, BranchId = 6 },
            new Lead { Id = 7, OrganizationId = 1, BranchId = 7 },
            new Lead { Id = 8, OrganizationId = 1, BranchId = 8 },
            new Lead { Id = 9, OrganizationId = 1, BranchId = 9 },
            new Lead { Id = 10, OrganizationId = 1, BranchId = 10 },
            new Lead { Id = 11, OrganizationId = 1, BranchId = 11 },
            new Lead { Id = 12, OrganizationId = 1, BranchId = 12 },
            new Lead { Id = 13, OrganizationId = 1, BranchId = 13 },
            new Lead { Id = 14, OrganizationId = 1, BranchId = 14 },
            new Lead { Id = 15, OrganizationId = 1, BranchId = 15 },
            new Lead { Id = 16, OrganizationId = 1, BranchId = 16 },
            new Lead { Id = 17, OrganizationId = 1, BranchId = 17 },
            new Lead { Id = 18, OrganizationId = 1, BranchId = 18 },
            new Lead { Id = 19, OrganizationId = 1, BranchId = 19 },
            new Lead { Id = 20, OrganizationId = 1, BranchId = 20 },
            new Lead { Id = 21, OrganizationId = 1, BranchId = 21 },
            new Lead { Id = 22, OrganizationId = 1, BranchId = 22 },
            new Lead { Id = 23, OrganizationId = 1, BranchId = 23 },
            new Lead { Id = 24, OrganizationId = 1, BranchId = 24 },
            new Lead { Id = 25, OrganizationId = 1, BranchId = 25 },
            new Lead { Id = 26, OrganizationId = 1, BranchId = 26 },
            new Lead { Id = 27, OrganizationId = 1, BranchId = 27 },
            new Lead { Id = 28, OrganizationId = 1, BranchId = 28 },
            new Lead { Id = 29, OrganizationId = 1, BranchId = 29 },
            new Lead { Id = 30, OrganizationId = 1, BranchId = 30 },
            new Lead { Id = 31, OrganizationId = 2 }
        );

        modelBuilder.Entity<Branch>().HasData(
            new Branch { Id = 1, DepartmentId = 5, Name = "Climate Change Secretariat" },
            new Branch { Id = 2, DepartmentId = 5, Name = "Water Resources" },
            new Branch { Id = 3, DepartmentId = 5, Name = "Parks" },
            new Branch { Id = 4, DepartmentId = 5, Name = "Fish and Wildlife" },
            new Branch { Id = 5, DepartmentId = 5, Name = "Conservation Officer Services" },
            new Branch { Id = 6, DepartmentId = 4, Name = "Forest Management" },
            new Branch { Id = 7, DepartmentId = 4, Name = "Agriculture" },
            new Branch { Id = 8, DepartmentId = 4, Name = "Energy" },
            new Branch { Id = 9, DepartmentId = 9, Name = "Supply Services" },
            new Branch { Id = 10, DepartmentId = 9, Name = "Strategic Initiatives" },
            new Branch { Id = 11, DepartmentId = 12, Name = "Culture Services" },
            new Branch { Id = 12, DepartmentId = 4, Name = "Yukon Geological Survey" },
            new Branch { Id = 13, DepartmentId = 4, Name = "Mineral Resources" },
            new Branch { Id = 14, DepartmentId = 5, Name = "Environmental Protection and Assessment" },
            new Branch { Id = 15, DepartmentId = 4, Name = "Land Planning" },
            new Branch { Id = 16, DepartmentId = 1, Name = "Infrastructure Development" },
            new Branch { Id = 17, DepartmentId = 9, Name = "Corporate Services" },
            new Branch { Id = 18, DepartmentId = 8, Name = "Community Nursing" },
            new Branch { Id = 19, DepartmentId = 13, Name = "Yukon Development Corporation" },
            new Branch { Id = 20, DepartmentId = 14, Name = "Yukon Energy Corporation" },
            new Branch { Id = 21, DepartmentId = 15, Name = "Capital Development" },
            new Branch { Id = 22, DepartmentId = 8, Name = "Population and Public Health Evidence and Evaluation" },
            new Branch { Id = 23, DepartmentId = 9, Name = "Transportation Engineering" },
            new Branch { Id = 24, DepartmentId = 4, Name = "Policy and Planning" },
            new Branch { Id = 25, DepartmentId = 8, Name = "Emergency Management Unit" },
            new Branch { Id = 26, DepartmentId = 9, Name = "Realty and Capital Asset Planning" },
            new Branch { Id = 27, DepartmentId = 9, Name = "Chief Information Office" },
            new Branch { Id = 28, DepartmentId = 1, Name = "Emergency Measures Organization" },
            new Branch { Id = 29, DepartmentId = 4, Name = "Finance" },
            new Branch { Id = 30, DepartmentId = 1, Name = "Fix me: Branch/Department is unknown" }
        );

        modelBuilder.Entity<Indicator>().HasData(
            new Indicator {
                Id = 1,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of high-risk communities with geohazard maps.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 2,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of community garden and greenhouse projects supported through the Canadian Agricultural Partnership that were completed during the reporting year.",
                UnitOfMeasurementId = 2,
            },
            new Indicator {
                Id = 3,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of First Nations and municipal agricultural and animal husbandry projects supported that were completed during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 4,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of research projects on climate impacts on agriculture that were supported during the reporting year:",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 5,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of projects supported during the reporting year to help agricultural producers adapt to the impacts of climate change, adopt low-carbon practices and use surface and groundwater efficiently:",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 6,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of at-risk communities with completed flood maps",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 7,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Proportion of community infrastructure projects over $10 million built or funded by YG during the reporting year that underwent a climate risk assessment.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 8,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Proportion of regional land use plans and local area plans completed during the reporting year that considered climate change.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 9,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of First Nations and municipalities with completed asset management plans.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 10,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of geothermal wells drilled during the reporting year:",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 11,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Change in volume of glaciers in the coast mountains during the reporting year.",
                UnitOfMeasurementId = 14
            },
            new Indicator {
                Id = 12,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of biodiesel and/or renewable diesel by volume in diesel fuel used for electricity generation on-grid during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 13,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of renewable electricity systems installed in YG buildings in off-grid locations during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 14,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of remote historic sites that have been evaluated for renewable electricity potential.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 15,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 16,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of signed Energy Purchase Agreements with Independent Power Producers that have First Nations ownership.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 17,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Percentage of independent power producers with signed Energy Purchase Agreements that have First Nations ownership.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 18,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of new electricity demand met by independent power producers during the reporting year",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 19,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Predicted energy generation from Independent Power Producers in future reporting years.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 20,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Percentage of YG buildings on permafrost that are being routinely monitored.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 21,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Proportion of identified deficiencies from YG building structural condition permafrost monitoring that are addressed by completed or planned actions.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 22,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Proportion of new construction projects for YG buildings during the reporting year that substantially met the energy performance target of 35 per cent less than the National Energy Code for Buildings.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 23,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Proportion of major building projects over $10 million built or funded by YG that during the reporting year that underwent a climate risk assessment.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 24,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Proportion of major transportation infrastructure projects over $10 million during the reporting year that underwent a climate risk assessment.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 25,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of biomass feasibility studies completed with First Nations governments or development corporations during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 26,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Volume of wood harvested by commercial entities for biomass energy during the reporting year:",
                UnitOfMeasurementId = 12
            },
            new Indicator {
                Id = 27,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of Peak Smart demand response events completed during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 28,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Average greenhouse gas reduction percentage from Government of Yukon community housing buildings retrofitted during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 29,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Results of the sustainable tourism measurement framework for the reporting year.",
                UnitOfMeasurementId = 1
            },
            new Indicator {
                Id = 30,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Greenhouse gas emissions from tourism during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 31,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Diversion rate of product streams managed by Extended Producer Responsibility during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 32,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Proportion of products from CCME�s 2009 Action Plan on EPR that are included in Yukon�s EPR system.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 33,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of Yukoners that participated in green economy professional development opportunities during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 34,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Proportion of quartz mines covered by new climate resilience license requirements.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 35,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Proportion of quartz mines covered by new greenhouse gas reporting license requirements.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 36,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Projected greenhouse gas emissions from quartz mines during future reporting years without identified mitigation measures.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 37,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Projected greenhouse gas emissions from quartz mines during future reporting years with identified mitigation measures.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 38,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of National Forest Inventory test plots established during the reporting year:",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 39,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Proportion of new construction or retrofit projects for YG buildings during the reporting year that used the new prioritization process.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 40,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of Youth Panel on Climate Change meetings during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 41,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of youth brought to international climate change/energy conferences/events during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 42,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Yukon�s climate resilience during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 43,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Fuel consumption of the Government of Yukon light duty fleet during the reporting year.",
                UnitOfMeasurementId = 10
            },
            new Indicator {
                Id = 44,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Distance travelled by YG staff by air for work purposes during the reporting year.",
                UnitOfMeasurementId = 13
            },
            new Indicator {
                Id = 45,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Distance travelled by YG staff by road for work purposes during the reporting year.",
                UnitOfMeasurementId = 13
            },
            new Indicator {
                Id = 46,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs per unit of GDP during the reporting year.",
                UnitOfMeasurementId = 16
            },
            new Indicator {
                Id = 47,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs per capita during the reporting year.",
                UnitOfMeasurementId = 9
            },
            new Indicator {
                Id = 48,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from Government of Yukon departmental and YukonU buildings",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 49,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from electricity generation during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 50,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Total amount of diesel used for electricity generation in off-grid communities during the reporting year.",
                UnitOfMeasurementId = 10
            },
            new Indicator {
                Id = 51,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Amount of diesel used for electricity generation in Destruction Bay/Burwash Landing during the reporting year.",
                UnitOfMeasurementId = 10
            },
            new Indicator {
                Id = 52,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Amount of diesel used for electricity generation in Beaver Creek during the reporting year.",
                UnitOfMeasurementId = 10
            },
            new Indicator {
                Id = 53,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Amount of diesel used for electricity generation in Watson Lake during the reporting year.",
                UnitOfMeasurementId = 10
            },
            new Indicator {
                Id = 54,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Amount of diesel used for electricity generation in Old Crow during the reporting year.",
                UnitOfMeasurementId = 10
            },
            new Indicator {
                Id = 55,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Amount of diesel used for electricity generation in Swift River during the reporting year.",
                UnitOfMeasurementId = 10
            },
            new Indicator {
                Id = 56,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Total electricity generated off-grid during the reporting year (thermal and renewable).",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 57,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Total electricity generated from fossil fuels off-grid during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 58,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity generated from fossil fuels in Destruction Bay/Burwash Landing during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 59,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity generated from fossil fuels in Beaver Creek during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 60,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity generated from fossil fuels in Watson Lake during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 61,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity generated from fossil fuels in Old Crow during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 62,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity generated from fossil fuels in Swift River during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 63,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "25-year rolling average percentage of renewable electricity supply on the Yukon Integrated System during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 64,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of renewable electricity supply on the Yukon Integrated System during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 65,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from heating fuel during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 66,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from waste during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 67,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Per capita waste generation in Yukon during the reporting year",
                UnitOfMeasurementId = 15
            },
            new Indicator {
                Id = 68,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Waste diversion percentage in Yukon during the reporting year",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 69,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Total installed renewable electricity capacity off-grid",
                UnitOfMeasurementId = 17
            },
            new Indicator {
                Id = 70,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Installed renewable capacity in Destruction Bay/Burwash Landing.",
                UnitOfMeasurementId = 17
            },
            new Indicator {
                Id = 71,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Installed renewable capacity in Beaver Creek.",
                UnitOfMeasurementId = 17
            },
            new Indicator {
                Id = 72,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Installed renewable capacity in Watson Lake.",
                UnitOfMeasurementId = 17
            },
            new Indicator {
                Id = 73,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Installed renewable capacity in Old Crow.",
                UnitOfMeasurementId = 17
            },
            new Indicator {
                Id = 74,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Installed renewable capacity in Swift River.",
                UnitOfMeasurementId = 17
            },
            new Indicator {
                Id = 75,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Total electricity generated from renewable sources off-grid during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 76,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity generated from renewable sources in Destruction Bay/Burwash Landing during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 77,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity generated from renewable sources in Beaver Creek during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 78,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity generated from renewable sources in Watson Lake during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 79,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity generated from renewable sources in Old Crow during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 80,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity generated from renewable sources in Swift River during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 81,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Installed renewable electricity capacity on-grid",
                UnitOfMeasurementId = 3
            },
            new Indicator {
                Id = 82,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity generated from renewable resources on-grid during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 83,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Total GHGs from the Government of Yukon's operations",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 84,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from Government of Yukon departmental and YukonU transportation",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 85,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from Government of Yukon departmental and YukonU other sources (refrigerants and waste)",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 86,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from Yukon Housing Corporation, Hospital Corporation and Liquor Corporation",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 87,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from Yukon Energy Corporation",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 88,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Total number of licensed hunters, trappers and fishers in Yukon during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 89,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Total number of resident licensed hunters during the reporting year (Indigenous and non-Indigenous).",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 90,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of resident non-Indigenous licensed hunters during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 91,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of resident First Nations and Inuit licensed hunters during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 92,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of resident and non-resident licensed fishers during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 93,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of resident licensed trappers and assistant trappers during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 94,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of zero emission cars relative to total YG car purchases during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 95,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from on-road diesel during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 96,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Fuel consumption of Government of Yukon off-road vehicles during the reporting year.",
                UnitOfMeasurementId = 10
            },
            new Indicator {
                Id = 97,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Fuel consumption of Government of Yukon heavy duty vehicles (both fleet and non-fleet vehicles) during the reporting year.",
                UnitOfMeasurementId = 10
            },
            new Indicator {
                Id = 98,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Carbon intensity of gasoline for transportation used in GHG calculations during the reporting year.",
                UnitOfMeasurementId = 7
            },
            new Indicator {
                Id = 99,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Carbon intensity of diesel for transportation used in GHG calculations during the reporting year.",
                UnitOfMeasurementId = 7
            },
            new Indicator {
                Id = 100,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from mining during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 101,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Emission intensity of mining during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 102,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Total non-mining GHGs during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 103,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from non-mining off-road diesel during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 104,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from other sources (industrial processes and fugitive emissions) during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 105,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Yukon's total GHGs during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 106,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Yukon Agricultural Self-Sufficiency Indicator",
                UnitOfMeasurementId = 4
            },
            new Indicator {
                Id = 107,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of large-scale renewable heating projects in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 108,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of off-grid communities with operational renewable electricity projects.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 109,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from aviation during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 110,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Total GHGs from road transportation during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 111,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "GHGs from on-road gasoline during the reporting year.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 112,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Electricity demand avoided through demand-side management during the reporting year.",
                UnitOfMeasurementId = 11
            },
            new Indicator {
                Id = 113,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Peak electricity demand avoided through demand-side management during the reporting year.",
                UnitOfMeasurementId = 3
            },
            new Indicator {
                Id = 114,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of commuting trips in Whitehorse made by walking",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 115,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of energy used for heating from renewable sources during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 116,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of cases of climate-related illnesses in Yukon during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 117,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of times the clean air shelter was deployed during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 118,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of Yukoners that were food insecure during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 119,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Proportion of recommendations from surface and groundwater monitoring network evaluation that have been implemented:",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 120,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Proportion of surface and groundwater monitoring stations that have climate change indicators identified and analyzed:",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 121,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of climate indicator species being monitored.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 122,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of taxonomic groups represented by climate indicator species.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 123,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Percent of Yukon's landscape covered by terrestrial and freshwater protected areas.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 124,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Percentage of Yukon's eco-regions with zero per cent of their area protected.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 125,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Percentage of Yukon's eco-regions with 1-10 per cent of their area protected.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 126,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Percentage of Yukon's eco-regions with 11-20 per cent of their area protected.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 127,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Total number of invasive species in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 128,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of invasive species in Yukon believed to be present.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 129,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of invasive species in Yukon believed to be absent.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 130,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of invasive species in Yukon whose presence is unknown.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 131,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of participants in First Nations-tailored hunter education courses during the reporting year:",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 132,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of healthcare providers that were provided climate change training during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 133,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of light-duty zero emission vehicle sales relative to total light-duty vehicle sales during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 134,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of ethanol by volume in transportation gasoline during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 135,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Proportion of designs for highway reconstruction projects on Class 1 and 2 highways during the reporting year that included an evaluation of active transportation options.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 136,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of video or audio conference calls by YG staff during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 137,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of YG flexible workplace pilot projects completed during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 138,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of zero emission vehicles in YG fleet.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 139,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of YG staff that carpooled rather than drove separately when signing out a fleet vehicle during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 140,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Proportion of fleet vehicles that were purchased using value-driven procurement during the reporting year.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 141,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of telehealth appointments facilitated from Whitehorse medical clinics during the reporting year:",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 142,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of active Rideshare users during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 143,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Proportion of recommendations from the road transportation network vulnerability assessment that have been implemented.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 144,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Length of highway for which targeted permafrost studies were completed during the reporting year.",
                UnitOfMeasurementId = 13
            },
            new Indicator {
                Id = 145,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of critical transportation corridors that flood risk has been analyzed for:",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 146,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Cumulative,
                Description = "Number of road-accessible communities in Yukon that can be reached in an electric vehicle from Whitehorse.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 147,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of electric vehicle fast-charging stations installed during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 148,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Number of electric vehicle discovery days, events or campaigns delivered during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 149,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of biodiesel and/or renewable diesel by volume in transportation diesel during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 150,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Average percentage improvement over code for new homes built in Whitehorse during the reporting year",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 151,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Average distance travelled by light-duty vehicles in Yukon during the reporting year.",
                UnitOfMeasurementId = 13
            },
            new Indicator {
                Id = 152,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of commuting trips in Whitehorse made as a driver",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 153,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of commuting trips in Whitehorse made as a passenger",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 154,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of commuting trips in Whitehorse made by bicycle",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 155,
                CollectionInterval = CollectionInterval.Annual,
                DataType = DataType.Incremental,
                Description = "Percentage of commuting trips in Whitehorse made by public transportation",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 156,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Electricity produced on residential, commercial and institutional buildings through the Micro-generation Program during the reporting period.",
                UnitOfMeasurementId = 18
            },
            new Indicator {
                Id = 157,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Cumulative,
                Description = "Installed renewable electricity capacity on residential, commercial and institutional buildings through the Micro-generation Program.",
                UnitOfMeasurementId = 3
            },
            new Indicator {
                Id = 158,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of energy efficiency retrofits (envelope improvements and/or heating system upgrades) to residential, commercial and non-YG institutional buildings during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 159,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of First Nations housing units retrofitted during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 160,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of major energy retrofits to First Nations and municipal buildings completed during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 161,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of private sector high performance thermal enclosure upgrades supported through Energy Branch prgrams during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 162,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of residential high performance thermal enclosure upgrades supported through Energy Branch programs during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 163,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of commercial high performance thermal enclosure upgrades supported through Energy Branch programs during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 164,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of Government of Yukon community housing buildings retrofitted during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 165,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of Government of Yukon community housing units retrofitted during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 166,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of energy efficient insulation and equipment rebates issued during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 167,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of residential energy efficient insulation and equipment rebates issued during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 168,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of commercial energy efficient insulation and equipment rebates issued during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 169,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of new home rebates issued during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 170,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of electric bicycle rebates issued during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 171,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Dollars of electric bicycle rebates issued during the reporting period",
                UnitOfMeasurementId = 4
            },
            new Indicator {
                Id = 172,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of heat pump installations during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 173,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of heat pumps supported through the Energy Branch's rebate program during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 174,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of heat pumps installed through the industry partnership during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 175,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of electric thermal storage systems installed through the Yukon Conservation Society's electric thermal storage demonstration project.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 176,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of heat pumps installed through the Better Buildings Loan during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 177,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of commercial and non-YG institutional biomass energy systems in Yukon installed during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 178,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number rebates provided for commercial and institutional biomass systems during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 179,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Dollars of rebates provided for residential, commercial and institutional biomass heating systems and smart electric heating devices during the reporting period.",
                UnitOfMeasurementId = 4
            },
            new Indicator {
                Id = 180,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of rebates issued for battery electric vehicles, plug-in hybrid electric vehicles and hydrogen fuel cell vehicles during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 181,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of rebates issued for battery electric vehicles during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 182,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of rebates issued for plugin hybrid electric vehicles during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 183,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Cumulative,
                Description = "Number of rebates isssued for",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 184,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of rebates issued for shipping of used electric vehicles during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 185,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of rebates issued for e-motorcycles during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 186,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of rebates issued for e-snowmobiles during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 187,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Dollars of zero emission vehicle rebates issued during the reporting period.",
                UnitOfMeasurementId = 4
            },
            new Indicator {
                Id = 188,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Number of smart electric vehicle charging station rebates issued during the reporting period.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 189,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Incremental,
                Description = "Dollars of smart electric charging station rebates issued during the reporting period.",
                UnitOfMeasurementId = 4
            },
            new Indicator {
                Id = 190,
                CollectionInterval = CollectionInterval.Quarter,
                DataType = DataType.Cumulative,
                Description = "Number of Yukon communities with air quality monitoring.",
                UnitOfMeasurementId = 6
            },
            new Indicator {
                Id = 191,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of Yukon communities with completed hazard identification and risk assessments.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 192,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of Yukon communities with completed emergency management plans.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 193,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of municipal and First Nations energy efficiency projects that were supported during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 194,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of municipal and First Nations energy efficiency projects that were supported and completed during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 195,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of municipal and First Nations public and active transportation infrastructure projects that were supported during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 196,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Incremental,
                Description = "Number of high-emitting Government of Yukon buildings that were substantially connected to renewable energy heating systems during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 197,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of high-emitting Government of Yukon buildings in the process of being substantially connected to renewable energy heating systems.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 198,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of high-emitting Government of Yukon buildings with feasibility studies underway to be substantially connected to renewable energy heating systems.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 199,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Anticipated greenhouse gas reductions from completed renewable energy heating system projects in Government of Yukon buildings to date.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 200,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Incremental,
                Description = "Number of high efficiency energy retrofits to Government of Yukon buildings completed during the reporting year.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 201,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of Government of Yukon buildings for which high efficiency energy retrofits are in progress.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 202,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Anticipated greenhouse gas reductions from completed high efficiency energy retrofit projects in Government of Yukon buildings.",
                UnitOfMeasurementId = 8
            },
            new Indicator {
                Id = 203,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Percentage of high-emitting Government of Yukon buildings for which energy assessments were completed during the reporting year.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 204,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Percentage of high-emitting Government of Yukon buildings that energy assessments are in progress for.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 205,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of Yukon communities with wildfire protection plans.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 206,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Incremental,
                Description = "Number of renewable energy projects supported during the reporting year through the Innovative Renewable Energy Initiative and/or the Arctic Energy Fund.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 207,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of zero emission vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 208,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of light-duty zero emission vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 209,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of light-duty plug-in hybrid electric vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 210,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of light-duty battery electric vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 211,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of light-duty hydrogen cell vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 212,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of light-duty conventional fossil fuel vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 213,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of light-duty hybrid fossil fuel vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 214,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of light-duty fossil fuel vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 215,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of light-duty vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 216,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Percentage of light-duty zero emission vehicles relative to total registered light-duty vehicles.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 217,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of battery electric snowmobiles registered in Yukon.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 218,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of conventional snowmobiles registered in Yukon.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 219,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of battery electric motorcycles registered in Yukon.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 220,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of conventional motorcycles registered in Yukon.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 221,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Total number of heavy-duty zero emission vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 222,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of heavy-duty plug-in hybrid electric vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 223,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of heavy-duty battery electric vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 224,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of heavy-duty hydrogen fuel cell vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 225,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of heavy-duty conventional fossil fuel vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 226,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of heavy-duty hybrid fossil fuel vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 227,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of heavy-duty fossil fuel vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 228,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Number of heavy-duty vehicles registered in Yukon.",
                UnitOfMeasurementId = 2
            },
            new Indicator {
                Id = 229,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Percentage of heavy-duty zero emission vehicles relative to total registered heavy-duty vehicles.",
                UnitOfMeasurementId = 5
            },
            new Indicator {
                Id = 230,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Cumulative,
                Description = "Installed Independent Power Production Capacity.",
                UnitOfMeasurementId = 3
            },
            new Indicator {
                Id = 231,
                CollectionInterval = CollectionInterval.Biannual,
                DataType = DataType.Incremental,
                Description = "Electricity generated by Independent Power Producers during the reporting period.",
                UnitOfMeasurementId = 11
            }
        );

        modelBuilder.Entity<IndicatorLead>().HasData(
            new IndicatorLead { IndicatorId = 1, LeadId = 16 },
            new IndicatorLead { IndicatorId = 2, LeadId = 7 },
            new IndicatorLead { IndicatorId = 3, LeadId = 7 },
            new IndicatorLead { IndicatorId = 4, LeadId = 7 },
            new IndicatorLead { IndicatorId = 5, LeadId = 7 },
            new IndicatorLead { IndicatorId = 6, LeadId = 2 },
            new IndicatorLead { IndicatorId = 7, LeadId = 16 },
            new IndicatorLead { IndicatorId = 8, LeadId = 15 },
            new IndicatorLead { IndicatorId = 9, LeadId = 8 },
            new IndicatorLead { IndicatorId = 10, LeadId = 12 },
            new IndicatorLead { IndicatorId = 11, LeadId = 12 },
            new IndicatorLead { IndicatorId = 12, LeadId = 8 },
            new IndicatorLead { IndicatorId = 13, LeadId = 10 },
            new IndicatorLead { IndicatorId = 14, LeadId = 11 },
            new IndicatorLead { IndicatorId = 15, LeadId = 8 },
            new IndicatorLead { IndicatorId = 16, LeadId = 8 },
            new IndicatorLead { IndicatorId = 17, LeadId = 8 },
            new IndicatorLead { IndicatorId = 18, LeadId = 8 },
            new IndicatorLead { IndicatorId = 19, LeadId = 19 },
            new IndicatorLead { IndicatorId = 20, LeadId = 21 },
            new IndicatorLead { IndicatorId = 21, LeadId = 21 },
            new IndicatorLead { IndicatorId = 22, LeadId = 10 },
            new IndicatorLead { IndicatorId = 23, LeadId = 16 },
            new IndicatorLead { IndicatorId = 24, LeadId = 23 },
            new IndicatorLead { IndicatorId = 25, LeadId = 8 },
            new IndicatorLead { IndicatorId = 26, LeadId = 6 },
            new IndicatorLead { IndicatorId = 27, LeadId = 20 },
            new IndicatorLead { IndicatorId = 28, LeadId = 8 },
            new IndicatorLead { IndicatorId = 29, LeadId = 11 },
            new IndicatorLead { IndicatorId = 30, LeadId = 11 },
            new IndicatorLead { IndicatorId = 31, LeadId = 14 },
            new IndicatorLead { IndicatorId = 32, LeadId = 14 },
            new IndicatorLead { IndicatorId = 33, LeadId = 8 },
            new IndicatorLead { IndicatorId = 34, LeadId = 13 },
            new IndicatorLead { IndicatorId = 35, LeadId = 13 },
            new IndicatorLead { IndicatorId = 36, LeadId = 13 },
            new IndicatorLead { IndicatorId = 37, LeadId = 13 },
            new IndicatorLead { IndicatorId = 38, LeadId = 6 },
            new IndicatorLead { IndicatorId = 39, LeadId = 10 },
            new IndicatorLead { IndicatorId = 40, LeadId = 24 },
            new IndicatorLead { IndicatorId = 41, LeadId = 1 },
            new IndicatorLead { IndicatorId = 42, LeadId = 1 },
            new IndicatorLead { IndicatorId = 43, LeadId = 30 },
            new IndicatorLead { IndicatorId = 44, LeadId = 30 },
            new IndicatorLead { IndicatorId = 45, LeadId = 30 },
            new IndicatorLead { IndicatorId = 46, LeadId = 1 },
            new IndicatorLead { IndicatorId = 47, LeadId = 1 },
            new IndicatorLead { IndicatorId = 48, LeadId = 1 },
            new IndicatorLead { IndicatorId = 49, LeadId = 1 },
            new IndicatorLead { IndicatorId = 50, LeadId = 31 },
            new IndicatorLead { IndicatorId = 51, LeadId = 31 },
            new IndicatorLead { IndicatorId = 52, LeadId = 31 },
            new IndicatorLead { IndicatorId = 53, LeadId = 31 },
            new IndicatorLead { IndicatorId = 54, LeadId = 31 },
            new IndicatorLead { IndicatorId = 55, LeadId = 31 },
            new IndicatorLead { IndicatorId = 56, LeadId = 31 },
            new IndicatorLead { IndicatorId = 57, LeadId = 31 },
            new IndicatorLead { IndicatorId = 58, LeadId = 31 },
            new IndicatorLead { IndicatorId = 59, LeadId = 31 },
            new IndicatorLead { IndicatorId = 60, LeadId = 31 },
            new IndicatorLead { IndicatorId = 61, LeadId = 31 },
            new IndicatorLead { IndicatorId = 62, LeadId = 31 },
            new IndicatorLead { IndicatorId = 63, LeadId = 20 },
            new IndicatorLead { IndicatorId = 64, LeadId = 20 },
            new IndicatorLead { IndicatorId = 65, LeadId = 1 },
            new IndicatorLead { IndicatorId = 66, LeadId = 1 },
            new IndicatorLead { IndicatorId = 67, LeadId = 14 },
            new IndicatorLead { IndicatorId = 68, LeadId = 14 },
            new IndicatorLead { IndicatorId = 69, LeadId = 31 },
            new IndicatorLead { IndicatorId = 70, LeadId = 31 },
            new IndicatorLead { IndicatorId = 71, LeadId = 31 },
            new IndicatorLead { IndicatorId = 72, LeadId = 31 },
            new IndicatorLead { IndicatorId = 73, LeadId = 31 },
            new IndicatorLead { IndicatorId = 74, LeadId = 31 },
            new IndicatorLead { IndicatorId = 75, LeadId = 31 },
            new IndicatorLead { IndicatorId = 76, LeadId = 31 },
            new IndicatorLead { IndicatorId = 77, LeadId = 31 },
            new IndicatorLead { IndicatorId = 78, LeadId = 31 },
            new IndicatorLead { IndicatorId = 79, LeadId = 31 },
            new IndicatorLead { IndicatorId = 80, LeadId = 31 },
            new IndicatorLead { IndicatorId = 81, LeadId = 20 },
            new IndicatorLead { IndicatorId = 82, LeadId = 20 },
            new IndicatorLead { IndicatorId = 83, LeadId = 1 },
            new IndicatorLead { IndicatorId = 84, LeadId = 1 },
            new IndicatorLead { IndicatorId = 85, LeadId = 1 },
            new IndicatorLead { IndicatorId = 86, LeadId = 1 },
            new IndicatorLead { IndicatorId = 87, LeadId = 1 },
            new IndicatorLead { IndicatorId = 88, LeadId = 5 },
            new IndicatorLead { IndicatorId = 89, LeadId = 5 },
            new IndicatorLead { IndicatorId = 90, LeadId = 5 },
            new IndicatorLead { IndicatorId = 91, LeadId = 5 },
            new IndicatorLead { IndicatorId = 92, LeadId = 5 },
            new IndicatorLead { IndicatorId = 93, LeadId = 5 },
            new IndicatorLead { IndicatorId = 94, LeadId = 9 },
            new IndicatorLead { IndicatorId = 95, LeadId = 1 },
            new IndicatorLead { IndicatorId = 96, LeadId = 1 },
            new IndicatorLead { IndicatorId = 97, LeadId = 1 },
            new IndicatorLead { IndicatorId = 98, LeadId = 1 },
            new IndicatorLead { IndicatorId = 99, LeadId = 1 },
            new IndicatorLead { IndicatorId = 100, LeadId = 1 },
            new IndicatorLead { IndicatorId = 101, LeadId = 1 },
            new IndicatorLead { IndicatorId = 102, LeadId = 1 },
            new IndicatorLead { IndicatorId = 103, LeadId = 1 },
            new IndicatorLead { IndicatorId = 104, LeadId = 1 },
            new IndicatorLead { IndicatorId = 105, LeadId = 1 },
            new IndicatorLead { IndicatorId = 106, LeadId = 7 },
            new IndicatorLead { IndicatorId = 107, LeadId = 8 },
            new IndicatorLead { IndicatorId = 108, LeadId = 8 },
            new IndicatorLead { IndicatorId = 109, LeadId = 1 },
            new IndicatorLead { IndicatorId = 110, LeadId = 1 },
            new IndicatorLead { IndicatorId = 111, LeadId = 1 },
            new IndicatorLead { IndicatorId = 112, LeadId = 8 },
            new IndicatorLead { IndicatorId = 113, LeadId = 20 },
            new IndicatorLead { IndicatorId = 114, LeadId = 30 },
            new IndicatorLead { IndicatorId = 115, LeadId = 8 },
            new IndicatorLead { IndicatorId = 116, LeadId = 22 },
            new IndicatorLead { IndicatorId = 117, LeadId = 25 },
            new IndicatorLead { IndicatorId = 118, LeadId = 22 },
            new IndicatorLead { IndicatorId = 119, LeadId = 2 },
            new IndicatorLead { IndicatorId = 120, LeadId = 2 },
            new IndicatorLead { IndicatorId = 121, LeadId = 4 },
            new IndicatorLead { IndicatorId = 122, LeadId = 4 },
            new IndicatorLead { IndicatorId = 123, LeadId = 3 },
            new IndicatorLead { IndicatorId = 124, LeadId = 3 },
            new IndicatorLead { IndicatorId = 125, LeadId = 3 },
            new IndicatorLead { IndicatorId = 126, LeadId = 3 },
            new IndicatorLead { IndicatorId = 127, LeadId = 4 },
            new IndicatorLead { IndicatorId = 128, LeadId = 4 },
            new IndicatorLead { IndicatorId = 129, LeadId = 4 },
            new IndicatorLead { IndicatorId = 130, LeadId = 4 },
            new IndicatorLead { IndicatorId = 131, LeadId = 5 },
            new IndicatorLead { IndicatorId = 132, LeadId = 17 },
            new IndicatorLead { IndicatorId = 133, LeadId = 8 },
            new IndicatorLead { IndicatorId = 134, LeadId = 1 },
            new IndicatorLead { IndicatorId = 135, LeadId = 23 },
            new IndicatorLead { IndicatorId = 136, LeadId = 27 },
            new IndicatorLead { IndicatorId = 137, LeadId = 26 },
            new IndicatorLead { IndicatorId = 138, LeadId = 9 },
            new IndicatorLead { IndicatorId = 139, LeadId = 9 },
            new IndicatorLead { IndicatorId = 140, LeadId = 9 },
            new IndicatorLead { IndicatorId = 141, LeadId = 18 },
            new IndicatorLead { IndicatorId = 142, LeadId = 1 },
            new IndicatorLead { IndicatorId = 143, LeadId = 23 },
            new IndicatorLead { IndicatorId = 144, LeadId = 12 },
            new IndicatorLead { IndicatorId = 145, LeadId = 2 },
            new IndicatorLead { IndicatorId = 146, LeadId = 8 },
            new IndicatorLead { IndicatorId = 147, LeadId = 8 },
            new IndicatorLead { IndicatorId = 148, LeadId = 8 },
            new IndicatorLead { IndicatorId = 149, LeadId = 1 },
            new IndicatorLead { IndicatorId = 150, LeadId = 30 },
            new IndicatorLead { IndicatorId = 151, LeadId = 30 },
            new IndicatorLead { IndicatorId = 152, LeadId = 30 },
            new IndicatorLead { IndicatorId = 153, LeadId = 30 },
            new IndicatorLead { IndicatorId = 154, LeadId = 30 },
            new IndicatorLead { IndicatorId = 155, LeadId = 30 },
            new IndicatorLead { IndicatorId = 156, LeadId = 8 },
            new IndicatorLead { IndicatorId = 157, LeadId = 8 },
            new IndicatorLead { IndicatorId = 158, LeadId = 8 },
            new IndicatorLead { IndicatorId = 159, LeadId = 29 },
            new IndicatorLead { IndicatorId = 160, LeadId = 8 },
            new IndicatorLead { IndicatorId = 161, LeadId = 8 },
            new IndicatorLead { IndicatorId = 162, LeadId = 8 },
            new IndicatorLead { IndicatorId = 163, LeadId = 8 },
            new IndicatorLead { IndicatorId = 164, LeadId = 8 },
            new IndicatorLead { IndicatorId = 165, LeadId = 8 },
            new IndicatorLead { IndicatorId = 166, LeadId = 8 },
            new IndicatorLead { IndicatorId = 167, LeadId = 8 },
            new IndicatorLead { IndicatorId = 168, LeadId = 8 },
            new IndicatorLead { IndicatorId = 169, LeadId = 8 },
            new IndicatorLead { IndicatorId = 170, LeadId = 8 },
            new IndicatorLead { IndicatorId = 171, LeadId = 8 },
            new IndicatorLead { IndicatorId = 172, LeadId = 8 },
            new IndicatorLead { IndicatorId = 173, LeadId = 8 },
            new IndicatorLead { IndicatorId = 174, LeadId = 8 },
            new IndicatorLead { IndicatorId = 175, LeadId = 8 },
            new IndicatorLead { IndicatorId = 176, LeadId = 8 },
            new IndicatorLead { IndicatorId = 177, LeadId = 8 },
            new IndicatorLead { IndicatorId = 178, LeadId = 8 },
            new IndicatorLead { IndicatorId = 179, LeadId = 8 },
            new IndicatorLead { IndicatorId = 180, LeadId = 8 },
            new IndicatorLead { IndicatorId = 181, LeadId = 8 },
            new IndicatorLead { IndicatorId = 182, LeadId = 8 },
            new IndicatorLead { IndicatorId = 183, LeadId = 8 },
            new IndicatorLead { IndicatorId = 184, LeadId = 8 },
            new IndicatorLead { IndicatorId = 185, LeadId = 8 },
            new IndicatorLead { IndicatorId = 186, LeadId = 8 },
            new IndicatorLead { IndicatorId = 187, LeadId = 8 },
            new IndicatorLead { IndicatorId = 188, LeadId = 8 },
            new IndicatorLead { IndicatorId = 189, LeadId = 8 },
            new IndicatorLead { IndicatorId = 190, LeadId = 14 },
            new IndicatorLead { IndicatorId = 191, LeadId = 28 },
            new IndicatorLead { IndicatorId = 192, LeadId = 28 },
            new IndicatorLead { IndicatorId = 193, LeadId = 8 },
            new IndicatorLead { IndicatorId = 194, LeadId = 8 },
            new IndicatorLead { IndicatorId = 195, LeadId = 16 },
            new IndicatorLead { IndicatorId = 196, LeadId = 10 },
            new IndicatorLead { IndicatorId = 197, LeadId = 10 },
            new IndicatorLead { IndicatorId = 198, LeadId = 10 },
            new IndicatorLead { IndicatorId = 199, LeadId = 10 },
            new IndicatorLead { IndicatorId = 200, LeadId = 10 },
            new IndicatorLead { IndicatorId = 201, LeadId = 10 },
            new IndicatorLead { IndicatorId = 202, LeadId = 10 },
            new IndicatorLead { IndicatorId = 203, LeadId = 10 },
            new IndicatorLead { IndicatorId = 204, LeadId = 10 },
            new IndicatorLead { IndicatorId = 205, LeadId = 28 },
            new IndicatorLead { IndicatorId = 206, LeadId = 19 },
            new IndicatorLead { IndicatorId = 207, LeadId = 8 },
            new IndicatorLead { IndicatorId = 208, LeadId = 8 },
            new IndicatorLead { IndicatorId = 209, LeadId = 8 },
            new IndicatorLead { IndicatorId = 210, LeadId = 8 },
            new IndicatorLead { IndicatorId = 211, LeadId = 8 },
            new IndicatorLead { IndicatorId = 212, LeadId = 8 },
            new IndicatorLead { IndicatorId = 213, LeadId = 8 },
            new IndicatorLead { IndicatorId = 214, LeadId = 8 },
            new IndicatorLead { IndicatorId = 215, LeadId = 8 },
            new IndicatorLead { IndicatorId = 216, LeadId = 8 },
            new IndicatorLead { IndicatorId = 217, LeadId = 8 },
            new IndicatorLead { IndicatorId = 218, LeadId = 8 },
            new IndicatorLead { IndicatorId = 219, LeadId = 8 },
            new IndicatorLead { IndicatorId = 220, LeadId = 8 },
            new IndicatorLead { IndicatorId = 221, LeadId = 8 },
            new IndicatorLead { IndicatorId = 222, LeadId = 8 },
            new IndicatorLead { IndicatorId = 223, LeadId = 8 },
            new IndicatorLead { IndicatorId = 224, LeadId = 8 },
            new IndicatorLead { IndicatorId = 225, LeadId = 8 },
            new IndicatorLead { IndicatorId = 226, LeadId = 8 },
            new IndicatorLead { IndicatorId = 227, LeadId = 8 },
            new IndicatorLead { IndicatorId = 228, LeadId = 8 },
            new IndicatorLead { IndicatorId = 229, LeadId = 8 },
            new IndicatorLead { IndicatorId = 230, LeadId = 8 },
            new IndicatorLead { IndicatorId = 231, LeadId = 8 }
        );
    }
}