using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OurCleanFuture.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Goals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfMeasurement",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_UnitsOfMeasurement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Objectives_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Owners_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InternalStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InternalCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualCompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InternalStatus = table.Column<int>(type: "int", nullable: false),
                    ExternalStatus = table.Column<int>(type: "int", nullable: false),
                    PublicExplanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectiveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actions_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoalObjective",
                columns: table => new {
                    GoalsId = table.Column<int>(type: "int", nullable: false),
                    ObjectivesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_GoalObjective", x => new { x.GoalsId, x.ObjectivesId });
                    table.ForeignKey(
                        name: "FK_GoalObjective_Goals_GoalsId",
                        column: x => x.GoalsId,
                        principalTable: "Goals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoalObjective_Objectives_ObjectivesId",
                        column: x => x.ObjectivesId,
                        principalTable: "Objectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Branches_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitOfMeasurementId = table.Column<int>(type: "int", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionId = table.Column<int>(type: "int", nullable: true),
                    ObjectiveId = table.Column<int>(type: "int", nullable: true),
                    GoalId = table.Column<int>(type: "int", nullable: true),
                    CollectionInterval = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indicators_Actions_ActionId",
                        column: x => x.ActionId,
                        principalTable: "Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Indicators_Goals_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Indicators_Objectives_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objectives",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Indicators_Owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Indicators_UnitsOfMeasurement_UnitOfMeasurementId",
                        column: x => x.UnitOfMeasurementId,
                        principalTable: "UnitsOfMeasurement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndicatorId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Entries", x => new { x.IndicatorId, x.Id });
                    table.ForeignKey(
                        name: "FK_Entries_Indicators_IndicatorId",
                        column: x => x.IndicatorId,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Targets",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OcfDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndicatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Targets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Targets_Indicators_IndicatorId",
                        column: x => x.IndicatorId,
                        principalTable: "Indicators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Transportion" },
                    { 2, "Homes and buildings" },
                    { 3, "Energy production" },
                    { 4, "People and the environment" },
                    { 5, "Communities" },
                    { 6, "Innovation" },
                    { 7, "Leadership" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 14, "Yukon Energy Corporation", "YEC" },
                    { 13, "Yukon Development Corporation", "YDC" },
                    { 12, "Tourism and Culture", "TC" },
                    { 11, "Public Service Commission", "PSC" },
                    { 10, "Justice", "JUS" },
                    { 9, "Highways and Public Works", "HPW" },
                    { 8, "Health and Social Services", "HSS" },
                    { 15, "Yukon Housing Corporation", "YHC" },
                    { 6, "Executive Council Office", "ECO" },
                    { 5, "Environment", "ENV" },
                    { 4, "Energy, Mines and Resources", "EMR" },
                    { 3, "Education", "EDU" },
                    { 2, "Economic Development", "EcDev" },
                    { 1, "Community Services", "CS" },
                    { 7, "Finance", "FIN" }
                });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 4, "Build a green economy." },
                    { 3, "Adapt to the impacts of climate change." },
                    { 1, "Reduce Yukon's greenhouse gas emissions." },
                    { 2, "Ensure Yukoners have access to reliable, affordable and renewable energy." }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Yukon Government" },
                    { 2, "ATCO Electric Yukon" }
                });

            migrationBuilder.InsertData(
                table: "UnitsOfMeasurement",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[,]
                {
                    { 9, "Tons of carbon dioxide equivalent per person", "tCO₂e/person" },
                    { 13, "Kilometres", "km" },
                    { 14, "Cubic kilometres", "km³" },
                    { 12, "Cubic metres", "m³" },
                    { 11, "Gigawatt hours", "GWh" },
                    { 10, "Litres", "L" },
                    { 8, "Kilotons of carbon dioxide equivalent", "ktCO₂e" },
                    { 2, "Count", "count" },
                    { 6, "Proportion", "proportion" },
                    { 5, "Percent", "%" },
                    { 4, "Dollars", "$" },
                    { 3, "Megawatts", "MW" },
                    { 1, "Kilograms of carbon dioxide equivalent", "kgCO₂e" },
                    { 15, "Tons per person", "t/person" }
                });

            migrationBuilder.InsertData(
                table: "UnitsOfMeasurement",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[] { 7, "Tons of carbon dioxide equivalent per litre", "tCO₂e/L" });

            migrationBuilder.InsertData(
                table: "UnitsOfMeasurement",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[] { 16, "Kilotonnes per million chained (2012) dollars", "kt/$1MM chained (2012)" });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "AreaId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Increase the number of zero emission vehicles on our roads." },
                    { 26, 7, "Ensure Yukoners have the information needed to make evidence-based decisions." },
                    { 25, 7, "Educate and empower youth as the next generation of leaders." },
                    { 24, 7, "Ensure the goals of this strategy are incorporated into government planning and operations." },
                    { 23, 6, "Improve how we manage our waste to move toward a more circular economy." },
                    { 22, 6, "Enhance the sustainability of Yukon’s tourism industry." },
                    { 21, 6, "Reduce the carbon intensity of mining and ensure mining projects are prepared for the impacts of climate change." },
                    { 19, 5, "Supply more of what we eat through sustainable local food production." },
                    { 18, 5, "Ensure we are prepared for emergencies that are becoming more likely due to climate change." },
                    { 17, 5, "Design our communities to be low-carbon and resilient to the impacts of climate change." },
                    { 16, 4, "Protect and enhance human health and wellbeing in a changing climate." },
                    { 15, 4, "Maintain our ability to practice traditional and cultural activities on the land." },
                    { 14, 4, "Respond to the impacts of climate change on wild species and their habitats." },
                    { 20, 6, "Support innovation and green business practices." },
                    { 12, 3, "Support local and community-based renewable energy projects for heating and electricity." },
                    { 13, 3, "Ensure electricity generation, transmission and distribution infrastructure is resilient to the impacts of climate change." },
                    { 2, 1, "Reduce the lifecycle carbon intensity of transportation fuels." },
                    { 3, 1, "Increase the use of public and active transportation." },
                    { 4, 1, "Reduce the carbon footprint from medium and heavy-duty vehicles." },
                    { 6, 1, "Ensure roads, runways and other transportation infrastructure are resilient to the impacts of climate change." },
                    { 5, 1, "Be more efficient in how and when we travel." },
                    { 8, 2, "Ensure new homes and buildings are built to be low-carbon and climate-resilient." },
                    { 9, 2, "Increase the use of biomass and other renewable energy sources for heating." },
                    { 10, 2, "Use energy more efficiently and better align energy supply and demand." },
                    { 11, 3, "Increase the supply of electricity generated from renewable sources." },
                    { 7, 2, "Improve the energy efficiency and climate resilience of existing homes and buildings." }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "Id", "OrganizationId" },
                values: new object[,]
                {
                    { 11, 1 },
                    { 8, 1 },
                    { 10, 1 },
                    { 9, 1 },
                    { 7, 1 },
                    { 1, 1 },
                    { 5, 1 },
                    { 4, 1 },
                    { 3, 1 },
                    { 2, 1 },
                    { 13, 1 },
                    { 6, 1 },
                    { 12, 2 }
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "ActualCompletionDate", "ExternalStatus", "InternalCompletionDate", "InternalStartDate", "InternalStatus", "Notes", "Number", "ObjectiveId", "PublicExplanation", "Title" },
                values: new object[,]
                {
                    { 1, null, 0, null, null, 0, "", "T1", 1, "", "Work with local vehicle dealerships and manufacturers to establish a system by 2024 to ensure zero emission vehicles are 10 per cent of light duty vehicle sales by 2025 and 30 per cent by 2030." },
                    { 76, null, 0, null, null, 0, "", "P4", 14, "", "Continue to monitor key species that will provide an indication of the impacts of climate change on Yukon ecosystems and expand monitoring to more taxonomic groups." },
                    { 78, null, 0, null, null, 0, "", "P6", 14, "", "Continue to track new and invasive species to Yukon that could impact ecosystems and biodiversity." },
                    { 79, null, 0, null, null, 0, "", "P7", 15, "", "Work with Yukon First Nations to develop a tailored hunter education program by 2023 that can be adapted and delivered by Yukon First Nations for First Nations citizens." },
                    { 80, null, 0, null, null, 0, "", "P8", 15, "", "Work collaboratively with First Nations and the Inuvialuit to document information from historic sites and culturally important places on the North Slope that are at risk due to climate change by 2024." },
                    { 81, null, 0, null, null, 0, "", "P9", 16, "", "Provide training to healthcare providers beginning in 2023 to be better able to identify and treat the physical and mental health impacts of climate change." },
                    { 82, null, 0, null, null, 0, "", "P10", 16, "", "Incorporate climate-related illnesses like heat stroke, respiratory illness, and vector-borne diseases into the new 1Health Yukon health information system by 2023 to enable tracking of climate-related illnesses in Yukon." },
                    { 83, null, 0, null, null, 0, "", "P11", 16, "", "Expand monitoring of concentrations of particulate matter in the air from biomass burning and forest fires to all Yukon communities by 2023." },
                    { 84, null, 0, null, null, 0, "", "P12", 16, "", "Purchase a moveable clean air shelter by 2021 that can be set up in communities to protect public health during wildfire smoke events." },
                    { 85, null, 0, null, null, 0, "", "P13", 16, "", "Provide financial support to vulnerable Yukoners to install cleaner air spaces in their homes and buildings beginning in 2023 to provide protection from wildfire smoke." },
                    { 86, null, 0, null, null, 0, "", "P14", 16, "", "Analyze existing information on food insecurity in Yukon by 2023 to inform the development of a system to gather food insecurity data into the future." },
                    { 87, null, 0, null, null, 0, "", "C1", 17, "", "Expand geohazard map coverage to all Yukon communities with a high risk of permafrost thaw by 2025." },
                    { 88, null, 0, null, null, 0, "", "C2", 17, "", "Develop flood probability maps for all Yukon communities at risk of flooding by 2023 that incorporate climate change projections." },
                    { 89, null, 0, null, null, 0, "", "C3", 17, "", "Develop detailed guidelines by 2025 that can be used by the Government of Yukon and partners to develop walkable, bike-friendly and transit-oriented communities." },
                    { 90, null, 0, null, null, 0, "", "C4", 17, "", "Continue to develop, encourage and apply applicable climate resiliency standards to community design and infrastructure development projects built by or receiving capital funding from the Government of Yukon." },
                    { 91, null, 0, null, null, 0, "", "C5", 17, "", "Continue to conduct detailed climate change risk assessments of all major community infrastructure projects over $10 million that are built or funded by the Government of Yukon." },
                    { 75, null, 0, null, null, 0, "", "P3", 14, "", "Continue to lead and participate in projects that improve our understanding of how climate change is affecting ecosystems, wild species and their habitats." },
                    { 74, null, 0, null, null, 0, "", "P2", 14, "", "Adapt existing surface and groundwater monitoring networks by 2026 to be able to track long-term trends in water quality and quantity in a changing climate." },
                    { 73, null, 0, null, null, 0, "", "P1", 14, "", "Establish a standardized method to determine the health status of wetland ecosystems and complete a pilot study to measure the baseline conditions of various reference wetlands by 2022 to better understand future changes." },
                    { 72, null, 0, null, null, 0, "", "E15", 13, "", "Implement a glacier monitoring program in 2020 to improve our ability to predict the impacts of glacier melt on hydrological systems and hydroelectricity generation." },
                    { 56, null, 0, null, null, 0, "", "H28", 10, "", "Complete the Peak Smart pilot project by 2022 to evaluate the use of smart devices to shift energy demand to off-peak hours." },
                    { 57, null, 0, null, null, 0, "", "H29", 10, "", "Implement an education campaign for Government of Yukon building occupants and visitors by 2026 to encourage more energy efficient behaviours." },
                    { 58, null, 0, null, null, 0, "", "E1", 11, "", "While aiming for an aspirational target of 97 per cent by 2030, develop legislation by 2023 that will require at least 93 per cent of the electricity generated on the Yukon Integrated System to come from renewable sources, calculated as a long-term rolling average." },
                    { 59, null, 0, null, null, 0, "", "E2", 11, "", "Require some of the diesel used to generate electricity on the Yukon Integrated System and in off-grid communities to be substituted with clean diesel alternatives like biodiesel and renewable diesel beginning in 2025, aiming for around 20 per cent." },
                    { 60, null, 0, null, null, 0, "", "E3", 11, "", "Update the Public Utilities Act by 2025 to ensure an effective and efficient process for regulating electricity in Yukon." },
                    { 61, null, 0, null, null, 0, "", "E4", 11, "", "Install renewable electricity generation systems in 5 Government of Yukon buildings in off-grid locations by 2025 to reduce reliance on diesel-generated electricity." },
                    { 62, null, 0, null, null, 0, "", "E5", 11, "", "Evaluate the potential to generate renewable electricity at remote historic sites co-managed by the Government of Yukon and Yukon First Nations by 2022." },
                    { 92, null, 0, null, null, 0, "", "C6", 17, "", "Continue to make recommendations to consider the impacts of climate change in regional land use and local area planning processes, which inform the Government of Yukon’s development permitting and zoning decisions." },
                    { 63, null, 0, null, null, 0, "", "E6", 12, "", "Continue to provide financial and technical support for Yukon First Nations, municipalities and community organizations to undertake community-led renewable energy projects." },
                    { 65, null, 0, null, null, 0, "", "E8", 12, "", "Increase the limit of the Standing Offer Program under the Independent Power Production Policy from 20 gigawatt hours (GWh) to 40 GWh by 2021 to support additional community-based renewable energy projects on Yukon’s main electrical grid." },
                    { 66, null, 0, null, null, 0, "", "E9", 12, "", "Develop a framework by 2022 for First Nations to economically participate in renewable electricity projects developed by Yukon’s public utilities." },
                    { 67, null, 0, null, null, 0, "", "E10", 12, "", "Continue to deliver the Micro-generation Program in collaboration with Yukon’s public utilities, targeting 7 megawatts (MW) of installed renewable electricity capacity by 2030." },
                    { 68, null, 0, null, null, 0, "", "E11", 12, "", "Develop legislation by 2023 to regulate geothermal energy development in Yukon." },
                    { 69, null, 0, null, null, 0, "", "E12", 12, "", "Research the potential to use geothermal energy for heating and electricity, with a focus along Yukon fault systems, by 2025." },
                    { 70, null, 0, null, null, 0, "", "E13", 13, "", "Improve modelling of the impacts of climate change on hydroelectricity reservoirs by 2021 and incorporate this information into short, medium and long-term forecasts for renewable hydroelectricity generation." },
                    { 71, null, 0, null, null, 0, "", "E14", 13, "", "Develop a climate change adaptation plan for the Yukon Energy Corporation by 2022 that will identify risks and appropriate responses to ensure Yukon’s main electrical grid is resilient to the impacts of climate change." },
                    { 64, null, 0, null, null, 0, "", "E7", 12, "", "Work with Yukon’s public utilities to continue to implement the Independent Power Production Policy that enables independent power producers, including Yukon First Nations and communities, to generate and sell electricity to the grid." },
                    { 93, null, 0, null, null, 0, "", "C7", 17, "", "Continue to provide technical and administrative support to Yukon First Nations and municipalities to prepare integrated asset management plans." },
                    { 94, null, 0, null, null, 0, "", "C8", 18, "", "Expand monitoring networks and improve modelling tools to generate reliable daily flood forecasts and relevant warnings for all at-risk Yukon communities by 2024." },
                    { 95, null, 0, null, null, 0, "", "C9", 18, "", "Work with First Nations and municipalities to develop Wildfire Protection Plans for all Yukon communities by 2026 and to complete the forest fuel management activities outlined in the plans by 2030." },
                    { 116, null, 0, null, null, 0, "", "I12", 23, "", "Assess options for establishing a comprehensive waste diversion system in Government of Yukon buildings, including reuse, recycling, compost and e-waste collection by 2030." },
                    { 117, null, 0, null, null, 0, "", "I13", 23, "", "Develop legislation that will enable the Government of Yukon to restrict or prohibit the production, supply or distribution of appropriate single use bags by 2021." }
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "ActualCompletionDate", "ExternalStatus", "InternalCompletionDate", "InternalStartDate", "InternalStatus", "Notes", "Number", "ObjectiveId", "PublicExplanation", "Title" },
                values: new object[,]
                {
                    { 118, null, 0, null, null, 0, "", "I14", 23, "", "Design and implement a system for Extended Producer Responsibility by 2025 that will make producers responsible for managing materials through the lifecycle of a product." },
                    { 119, null, 0, null, null, 0, "", "L1", 24, "", "Create a Clean Energy Act by 2023 that legislates our greenhouse gas reduction targets and our commitments to energy efficiency and demand-side management to hold the Government of Yukon accountable." },
                    { 120, null, 0, null, null, 0, "", "L2", 24, "", "Incorporate a climate change lens into the decision-making process for major Government of Yukon policies, programs and projects by 2021." },
                    { 121, null, 0, null, null, 0, "", "L3", 24, "", "Incorporate climate change risks into Government of Yukon departmental planning processes by 2022." },
                    { 122, null, 0, null, null, 0, "", "L4", 24, "", "Incorporate greenhouse gas emissions and energy efficiency into the process for identifying and prioritizing Government of Yukon building retrofits and new construction projects by 2023." },
                    { 115, null, 0, null, null, 0, "", "I11", 22, "", "Develop and implement a system to track greenhouse gas emissions from Yukon’s tourism industry by 2021." },
                    { 123, null, 0, null, null, 0, "", "L5", 24, "", "Develop and offer climate change training for Government of Yukon employees by 2022." },
                    { 125, null, 0, null, null, 0, "", "L7", 25, "", "Provide mentorship opportunities for Yukon youth to participate in major international climate change and energy events with Government of Yukon staff beginning in 2023." },
                    { 126, null, 0, null, null, 0, "", "L8", 25, "", "Continue to support land-based programs in the Yukon school curriculum that teach First Nations ways of knowing and doing to youth." },
                    { 127, null, 0, null, null, 0, "", "L9", 26, "", "Assess climate hazards and vulnerabilities to those hazards across Yukon every three to four years between 2020 and 2030 to prioritize climate change adaptation actions." },
                    { 128, null, 0, null, null, 0, "", "L10", 26, "", "Support the Government of Canada’s work to develop a pan-territorial climate hub by 2030 that will support access to climate data and projections for the north." },
                    { 129, null, 0, null, null, 0, "", "L11", 26, "", "Begin participating in the National Forest Inventory monitoring program in 2022 to gather information about forest carbon stocks, potential biomass energy supply, pest and forest fire risks, and climate impacts on Yukon’s forests." },
                    { 130, null, 0, null, null, 0, "", "L12", 26, "", "Create easy access to technical information and lessons learned about climate change, energy and green economy for governments and stakeholders by 2021." },
                    { 131, null, 0, null, null, 0, "", "L13", 26, "", "Launch a Yukon-wide information or social marketing campaign in 2021 that will educate Yukoners on greenhouse gas emissions, renewable energy, climate change adaptation, and other topics and highlight what Yukoners can do to support climate change initiatives." },
                    { 124, null, 0, null, null, 0, "", "L6", 25, "", "Create a Youth Panel on Climate Change in 2020 that will provide advice and perspectives to the Government of Yukon on climate change, energy and green economy matters that reflects the diversity of Yukon youth." },
                    { 55, null, 0, null, null, 0, "", "H27", 10, "", "Establish a partnership between the Government of Yukon, Yukon Energy Corporation and ATCO Electric Yukon by 2021 that will collaborate on the delivery of energy and capacity demand-side management programs." },
                    { 114, null, 0, null, null, 0, "", "I10", 22, "", "Establish and implement a framework to measure the sustainability of tourism development in Yukon by 2021." },
                    { 112, null, 0, null, null, 0, "", "I8", 21, "", "Increase the Government of Yukon’s participation in intergovernmental initiatives related to mine resiliency, low-carbon mining and innovation by 2021." },
                    { 96, null, 0, null, null, 0, "", "C10", 18, "", "Increase the capacity in Yukon Wildland Fire to prevent wildfires and respond to extended fire seasons by investing in staffing in 2020." },
                    { 97, null, 0, null, null, 0, "", "C11", 18, "", "Complete hazard identification and risk assessments (HIRAs) for all Yukon communities by 2022 that include climate change risks." },
                    { 98, null, 0, null, null, 0, "", "C12", 18, "", "Work with First Nations and municipalities to complete emergency management plans for all Yukon communities by 2022 informed by community hazard identification and risk assessments (HIRAs)." },
                    { 99, null, 0, null, null, 0, "", "C13", 18, "", "Develop a territorial disaster financial assistance policy by 2022 to support recovery from natural disasters that result in extensive property damage or disruption to the delivery of essential goods and services." },
                    { 100, null, 0, null, null, 0, "", "C14", 19, "", "Develop a territorial disaster financial assistance policy by 2022 to support recovery from natural disasters that result in extensive property damage or disruption to the delivery of essential goods and services." },
                    { 101, null, 0, null, null, 0, "", "C15", 19, "", "Continue to provide funding for community gardens and greenhouses, especially in rural communities." },
                    { 102, null, 0, null, null, 0, "", "C16", 19, "", "Continue to provide technical advice to assist First Nations and municipal governments with their agricultural and animal husbandry projects." },
                    { 113, null, 0, null, null, 0, "", "I9", 21, "", "Establish an intensity-based greenhouse gas reduction target for Yukon’s mining industry and additional actions needed to reach the target by 2022." },
                    { 103, null, 0, null, null, 0, "", "C17", 19, "", "Continue to conduct and provide access to funding for research on how climate change could affect local agriculture." },
                    { 105, null, 0, null, null, 0, "", "I1", 20, "", "Incorporate greenhouse gas emissions into the decision-making process for Department of Economic Development funding programs by 2022." },
                    { 106, null, 0, null, null, 0, "", "I2", 20, "", "Update the Government of Yukon’s procurement policies and standards in 2020 to better support sustainable and local procurement." },
                    { 107, null, 0, null, null, 0, "", "I3", 20, "", "Identify and develop options to address potential regulatory and policy barriers to the growth of green businesses in Yukon by 2023." },
                    { 108, null, 0, null, null, 0, "", "I4", 20, "", "Expand the range of relevant professional development offerings by 2023 to enable more Yukoners to participate in the green economy." },
                    { 109, null, 0, null, null, 0, "", "I5", 20, "", "Create an award program by 2022 to recognize the achievements of local green businesses and organizations." },
                    { 110, null, 0, null, null, 0, "", "I6", 21, "", "Include new provisions in quartz mine licenses by 2022 that will ensure critical mine infrastructure is planned, designed and built to withstand current and projected impacts of climate change." },
                    { 111, null, 0, null, null, 0, "", "I7", 21, "", "Require quartz mines to project their anticipated greenhouse gas emissions, identify measures to reduce emissions, and annually report greenhouse gas emissions through the quartz mine licensing process beginning in 2022." },
                    { 104, null, 0, null, null, 0, "", "C18", 19, "", "Continue to support agricultural producers to adapt to the impacts of climate change, adopt low-carbon practices and use surface water and groundwater efficiently." },
                    { 54, null, 0, null, null, 0, "", "H26", 10, "", "Provide direction to the Yukon Utilities Board in 2020 to allow Yukon’s public utilities to partner with the Government of Yukon to pursue cost-effective demand-side management measures." },
                    { 77, null, 0, null, null, 0, "", "P5", 14, "", "Continue to incorporate climate change into the design of protected and managed areas using landscape conservation science in order to allow native species to move, adapt and survive in the face of climate change." },
                    { 36, null, 0, null, null, 0, "", "H8", 7, "", "Continue to provide rebates for thermal enclosure upgrades and energy efficient equipment to reduce energy use in homes and commercial buildings." },
                    { 5, null, 0, null, null, 0, "", "T5", 1, "", "Provide rebates to support the installation of smart electric vehicle charging stations at residential" },
                    { 23, null, 0, null, null, 0, "", "T23", 5, "", "Expand virtual health care services to Whitehorse medical clinics by 2022 in order to improve access to healthcare while reducing greenhouse gas emissions from travel to and from Whitehorse." },
                    { 7, null, 0, null, null, 0, "", "T7", 1, "", "Draft legislation by 2024 that will enable private businesses and Yukon’s public utilities to sell electricity for the purpose of electric vehicle charging." },
                    { 39, null, 0, null, null, 0, "", "H11", 7, "", "Assess options to provide financial support for actions to improve the climate resiliency of homes and buildings by 2023." }
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "ActualCompletionDate", "ExternalStatus", "InternalCompletionDate", "InternalStartDate", "InternalStatus", "Notes", "Number", "ObjectiveId", "PublicExplanation", "Title" },
                values: new object[,]
                {
                    { 38, null, 0, null, null, 0, "", "H10", 7, "", "Develop and implement a plan by 2024 to conduct routine monitoring of the structural condition of Government of Yukon buildings located on permafrost." },
                    { 37, null, 0, null, null, 0, "", "H9", 7, "", "Assess ways to ensure Yukoners can access adequate insurance for fires, floods and permafrost thaw by 2023." },
                    { 35, null, 0, null, null, 0, "", "H7", 7, "", "Continue to retrofit Government of Yukon community housing to reduce greenhouse gas emissions in each building by 30 per cent." },
                    { 34, null, 0, null, null, 0, "", "H6", 7, "", "Continue to work with Yukon First Nations to retrofit First Nations housing to be more energy efficient." },
                    { 8, null, 0, null, null, 0, "", "T8", 1, "", "Continue to run public education events and campaigns to raise awareness of the benefits of electric vehicles and how they function in cold climates." },
                    { 33, null, 0, null, null, 0, "", "H5", 7, "", "Continue to provide financial support for municipal and First Nations energy efficiency projects." },
                    { 32, null, 0, null, null, 0, "", "H4", 7, "", "Continue to provide financial support to assist First Nations and municipalities to complete major energy retrofits to institutional buildings across Yukon, aiming for 30 retrofits by 2030." },
                    { 31, null, 0, null, null, 0, "", "H3", 7, "", "Provide low-interest financing to support energy efficiency retrofits to homes and buildings beginning in 2021." },
                    { 30, null, 0, null, null, 0, "", "H2", 7, "", "Conduct energy assessments of Government of Yukon buildings to identify opportunities for energy efficiency and greenhouse gas reductions, with the first period of assessments completed by 2025 and the second period completed by 2030." },
                    { 29, null, 0, null, null, 0, "", "H1", 7, "", "Conduct retrofits to Government of Yukon buildings to reduce energy use and contribute to a 30 per cent reduction in greenhouse gas emissions by 2030." },
                    { 17, null, 0, null, null, 0, "", "T17", 5, "", "Expand the Government of Yukon’s video and teleconferencing systems and require employees to consider these options when requesting permission for work travel by 2022." },
                    { 18, null, 0, null, null, 0, "", "T18", 5, "", "Implement new policies to enable Government of Yukon employees in suitable positions to work from home for the longer term by 2022." },
                    { 19, null, 0, null, null, 0, "", "T19", 5, "", "Develop a planning and engagement strategy by 2022 to change how and where Government of Yukon employees work by providing choices and flexibility through a modern workplace." },
                    { 20, null, 0, null, null, 0, "", "T20", 5, "", "Develop and implement a system by 2021 to coordinate carpooling for Government of Yukon staff travelling by vehicle for work within Yukon." },
                    { 13, null, 0, null, null, 0, "", "T13", 3, "", "Continue to incorporate active transportation in the design of highways and other Government of Yukon transportation infrastructure near communities." },
                    { 12, null, 0, null, null, 0, "", "T12", 3, "", "Continue to support municipalities and First Nations to make investments in public and active transportation infrastructure." },
                    { 28, null, 0, null, null, 0, "", "T28", 6, "", "Continue to conduct climate risk assessments of all major transportation infrastructure projects above $10 million, such as through the federal Climate Lens assessment." },
                    { 27, null, 0, null, null, 0, "", "T27", 6, "", "Analyze flood risk along critical transportation corridors at risk of flooding by 2023." },
                    { 26, null, 0, null, null, 0, "", "T26", 6, "", "Establish a geohazard mapping program for major transportation corridors and prioritize sections for targeted permafrost study by 2022." },
                    { 25, null, 0, null, null, 0, "", "T25", 6, "", "Complete a climate change vulnerability study of the road transportation network by 2023 to inform the development of standards and specifications." },
                    { 9, null, 0, null, null, 0, "", "T9", 2, "", "Require all diesel fuel sold in Yukon for transportation to align with the percentage of biodiesel and renewable diesel by volume in leading Canadian jurisdictions beginning in 2025." },
                    { 10, null, 0, null, null, 0, "", "T10", 2, "", "Require all gasoline sold in Yukon for transportation to align with the percentage of ethanol by volume in leading Canadian jurisdictions beginning in 2025." },
                    { 11, null, 0, null, null, 0, "", "T11", 3, "", "Provide rebates to encourage the purchase of electric bicycles for personal and business commuting beginning in 2020." },
                    { 21, null, 0, null, null, 0, "", "T21", 5, "", "Develop guidelines for the Government of Yukon Fleet Vehicle Agency’s fleet by 2021 to ensure appropriate vehicles are used for the task at hand." },
                    { 24, null, 0, null, null, 0, "", "T24", 5, "", "Cont   inue to operate the Yukon Rideshare program to make carpooling and other shared travel easier." },
                    { 4, null, 0, null, null, 0, "", "T4", 1, "", "Continue to install fast-charging stations across Yukon to make it possible to travel between all road-accessible Yukon communities by 2027 and work with neighbouring governments and organizations to explore options to connect Yukon with BC." },
                    { 3, null, 0, null, null, 0, "", "T3", 1, "", "Provide a rebate to Yukon businesses and individuals who purchase eligible zero emission vehicles beginning in 2020." },
                    { 6, null, 0, null, null, 0, "", "T6", 1, "", "Require new residential buildings to be built with the electrical infrastructure to support Level 2 electric vehicle charging beginning on April 1" },
                    { 41, null, 0, null, null, 0, "", "H13", 8, "", "Continue to require all new Government of Yukon buildings to be designed to use 35 per cent less energy than the targets in the National Energy Code for Buildings, in accordance with the Government of Yukon’s Design Requirements and Building Standards Manual." },
                    { 53, null, 0, null, null, 0, "", "H25", 9, "", "Analyze and compare the climate benefits of different types of biomass harvesting and use in Yukon by 2021 in order to identify recommended forest management practices to guide sustainable and low-carbon biomass use." },
                    { 52, null, 0, null, null, 0, "", "H24", 9, "", "Amend the Air Emissions Regulations by 2025 in order to regulate air emissions from commercial and institutional biomass burning systems to minimize the release of harmful air pollutants." },
                    { 51, null, 0, null, null, 0, "", "H23", 9, "", "Identify regulatory improvements that could support the growth of Yukon’s biomass energy industry during the review of the Forest Resources Act by 2022." },
                    { 50, null, 0, null, null, 0, "", "H22", 9, "", "Work with local industry to install and test 25 electric heat pumps with backup fossil fuel heating systems or utility-controlled electric thermal storage from 2020 to 2023." },
                    { 49, null, 0, null, null, 0, "", "H21", 9, "", "Continue to provide rebates for residential, commercial and institutional biomass heating systems and smart electric heating devices and increase the current rebate for smart electric heating devices beginning in 2020." },
                    { 48, null, 0, null, null, 0, "", "H20", 9, "", "Continue to assist First Nations to complete feasibility studies for the installation and operation of biomass heating systems." },
                    { 47, null, 0, null, null, 0, "", "H19", 9, "", "Provide low-interest financing to install biomass heating systems in commercial and institutional buildings beginning in 2021." },
                    { 46, null, 0, null, null, 0, "", "H18", 9, "", "Provide low-interest financing to install smart electric heating devices in residential, commercial and institutional buildings in collaboration with Yukon’s public utilities beginning in 2021." },
                    { 40, null, 0, null, null, 0, "", "H12", 8, "", "Work with the Government of Canada to develop and implement building codes suitable to northern Canada that will aspire to see all new residential and commercial buildings be net zero energy ready by 2032." },
                    { 14, null, 0, null, null, 0, "", "T14", 4, "", "Update the Government of Yukon’s heavy-duty vehicle fleet by 2030 to reduce greenhouse gas emissions and fuel costs." },
                    { 15, null, 0, null, null, 0, "", "T15", 4, "", "Begin a pilot project in 2021 to test the use of short-haul medium and heavy-duty electric vehicles for commercial and institutional applications within Yukon." },
                    { 45, null, 0, null, null, 0, "", "H17", 9, "", "Install renewable heat sources such as biomass energy in Government of Yukon buildings by 2030 to create long-term demand for renewable heating and contribute to a 30 per cent reduction in greenhouse gas emissions." },
                    { 16, null, 0, null, null, 0, "", "T16", 4, "", "Train the Government of Yukon’s heavy equipment operators on efficient driving techniques for all new equipment by 2022." }
                });

            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "ActualCompletionDate", "ExternalStatus", "InternalCompletionDate", "InternalStartDate", "InternalStatus", "Notes", "Number", "ObjectiveId", "PublicExplanation", "Title" },
                values: new object[,]
                {
                    { 42, null, 0, null, null, 0, "", "H14", 8, "", "Adopt and enforce relevant building standards by 2030 that will require new buildings to be constructed to be more resilient to climate change impacts like permafrost thaw, flooding and forest fires." },
                    { 2, null, 0, null, null, 0, "", "T2", 1, "", "Ensure at least 50 per cent of all new light-duty cars purchased by the Government of Yukon are zero emission vehicles each year from 2020 to 2030." },
                    { 43, null, 0, null, null, 0, "", "H15", 8, "", "Continue to conduct climate risk assessments of all major building projects over $10 million that are built or funded by the Government of Yukon." },
                    { 44, null, 0, null, null, 0, "", "H16", 8, "", "Continue to provide rebates for new homes that are net zero energy ready, aiming for 500 homes by 2030." },
                    { 22, null, 0, null, null, 0, "", "T22", 5, "", "Incorporate fuel efficiency into purchasing decisions for Government of Yukon fleet vehicles beginning in 2020 to reduce greenhouse gas emissions and fuel costs." }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "DepartmentId", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 3, 5, "Parks", 3 },
                    { 12, 4, "Yukon Geological Survey", 13 },
                    { 11, 12, "Culture Services", 11 },
                    { 10, 9, "Strategic Initiatives", 10 },
                    { 9, 9, "Supply Services", 9 },
                    { 8, 4, "Energy", 8 },
                    { 1, 5, "Climate Change Secretariat", 1 },
                    { 4, 5, "Fish and Wildlife", 4 },
                    { 2, 5, "Water Resources", 2 },
                    { 7, 4, "Agriculture", 7 },
                    { 6, 4, "Forest Resources", 6 },
                    { 5, 5, "Conservation Officer Services", 5 }
                });

            migrationBuilder.InsertData(
                table: "GoalObjective",
                columns: new[] { "GoalsId", "ObjectivesId" },
                values: new object[,]
                {
                    { 2, 22 },
                    { 1, 3 },
                    { 1, 23 },
                    { 4, 22 },
                    { 2, 3 },
                    { 1, 22 },
                    { 3, 22 },
                    { 3, 9 },
                    { 1, 2 },
                    { 4, 26 },
                    { 3, 26 },
                    { 2, 26 },
                    { 1, 26 },
                    { 4, 25 },
                    { 3, 25 },
                    { 2, 25 },
                    { 1, 25 },
                    { 4, 3 },
                    { 1, 1 },
                    { 4, 24 },
                    { 3, 24 },
                    { 2, 24 },
                    { 1, 24 },
                    { 4, 1 },
                    { 4, 23 }
                });

            migrationBuilder.InsertData(
                table: "GoalObjective",
                columns: new[] { "GoalsId", "ObjectivesId" },
                values: new object[,]
                {
                    { 4, 21 },
                    { 3, 19 },
                    { 2, 21 },
                    { 3, 21 },
                    { 3, 14 },
                    { 3, 7 },
                    { 4, 7 },
                    { 4, 13 },
                    { 3, 13 },
                    { 1, 8 },
                    { 4, 12 },
                    { 2, 12 },
                    { 1, 12 },
                    { 2, 8 },
                    { 3, 8 },
                    { 4, 8 },
                    { 4, 11 },
                    { 2, 11 },
                    { 1, 11 },
                    { 4, 10 },
                    { 2, 10 },
                    { 1, 10 },
                    { 1, 9 },
                    { 2, 9 },
                    { 2, 7 },
                    { 1, 7 },
                    { 4, 14 },
                    { 4, 15 },
                    { 1, 21 },
                    { 1, 4 },
                    { 4, 20 },
                    { 3, 20 },
                    { 2, 20 },
                    { 1, 20 },
                    { 2, 4 },
                    { 4, 19 },
                    { 4, 9 },
                    { 3, 15 },
                    { 1, 5 },
                    { 1, 19 },
                    { 3, 18 },
                    { 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "GoalObjective",
                columns: new[] { "GoalsId", "ObjectivesId" },
                values: new object[,]
                {
                    { 4, 5 },
                    { 4, 17 },
                    { 3, 17 },
                    { 3, 16 },
                    { 2, 17 },
                    { 4, 18 },
                    { 4, 6 },
                    { 1, 17 },
                    { 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "Indicators",
                columns: new[] { "Id", "ActionId", "CollectionInterval", "DataType", "Description", "GoalId", "Notes", "ObjectiveId", "OwnerId", "Title", "UnitOfMeasurementId" },
                values: new object[,]
                {
                    { 5, null, "Annual", "Incremental", "Total GHGs from the Government of Yukon's operations.", null, "", null, 1, "YG GHGs - total", 1 },
                    { 3, null, "Biannual", "Cumulative", "Number of energy assessments of Government of Yukon buildings completed during the reporting year.", null, "", null, 10, "YG buildings - energy assessments completed", 2 },
                    { 4, null, "Annual", "Incremental", "Yukon Agricultural Self-Sufficiency Indicator.", null, "", null, 7, "Food self-sufficiency", 2 },
                    { 7, null, "Annual", "Incremental", "Change in volume of glaciers in the coast mountains during the reporting year.", null, "", null, 13, "Glacier volume change", 14 },
                    { 6, null, "Annual", "Incremental", "Volume of wood harvested by commercial entities for biomass energy during the reporting year.", null, "", null, 6, "Commercial biomass harvest", 12 },
                    { 1, null, "Biannual", "Cumulative", "Total number of heavy-duty zero emission vehicles registered in Yukon.", null, "", null, 8, "ZEVs - Total heavy duty", 2 },
                    { 2, null, "Annual", "Incremental", "Total electricity generated off-grid during the reporting year (thermal and renewable).", null, "", null, 12, "Off-grid generation - total", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_ObjectiveId",
                table: "Actions",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DepartmentId",
                table: "Branches",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_OwnerId",
                table: "Branches",
                column: "OwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoalObjective_ObjectivesId",
                table: "GoalObjective",
                column: "ObjectivesId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_ActionId",
                table: "Indicators",
                column: "ActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_GoalId",
                table: "Indicators",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_ObjectiveId",
                table: "Indicators",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_OwnerId",
                table: "Indicators",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_UnitOfMeasurementId",
                table: "Indicators",
                column: "UnitOfMeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Objectives_AreaId",
                table: "Objectives",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_OrganizationId",
                table: "Owners",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Targets_IndicatorId",
                table: "Targets",
                column: "IndicatorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnitsOfMeasurement_Symbol",
                table: "UnitsOfMeasurement",
                column: "Symbol",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Entries");

            migrationBuilder.DropTable(
                name: "GoalObjective");

            migrationBuilder.DropTable(
                name: "Targets");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "UnitsOfMeasurement");

            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}