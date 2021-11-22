﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OurCleanFuture.Data;

#nullable disable

namespace OurCleanFuture.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211122212610_AddLeadsToActions")]
    partial class AddLeadsToActions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ActionDirectorsCommittee", b =>
                {
                    b.Property<int>("ActionsId")
                        .HasColumnType("int");

                    b.Property<int>("DirectorsCommitteesId")
                        .HasColumnType("int");

                    b.HasKey("ActionsId", "DirectorsCommitteesId");

                    b.HasIndex("DirectorsCommitteesId");

                    b.ToTable("ActionDirectorsCommittee");
                });

            modelBuilder.Entity("GoalObjective", b =>
                {
                    b.Property<int>("GoalsId")
                        .HasColumnType("int");

                    b.Property<int>("ObjectivesId")
                        .HasColumnType("int");

                    b.HasKey("GoalsId", "ObjectivesId");

                    b.HasIndex("ObjectivesId");

                    b.ToTable("GoalObjective");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ActualCompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExternalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternalStatusUpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("InternalStatusUpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ObjectiveId")
                        .HasColumnType("int");

                    b.Property<string>("PublicExplanation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TargetCompletionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex("ObjectiveId");

                    b.ToTable("Actions", (string)null);

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb.UseHistoryTable("ActionsHistory");
                            ttb
                                .HasPeriodStart("ValidFrom")
                                .HasColumnName("ValidFrom");
                            ttb
                                .HasPeriodEnd("ValidTo")
                                .HasColumnName("ValidTo");
                        }
                    ));
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.ActionLead", b =>
                {
                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<int>("LeadId")
                        .HasColumnType("int");

                    b.HasKey("ActionId", "LeadId");

                    b.HasIndex("LeadId");

                    b.ToTable("ActionLead");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Branches", (string)null);
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.DirectorsCommittee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DirectorsCommittees");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Indicator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ActionId")
                        .HasColumnType("int");

                    b.Property<string>("CollectionInterval")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DataType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GoalId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ObjectiveId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitOfMeasurementId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.HasIndex("GoalId");

                    b.HasIndex("ObjectiveId");

                    b.HasIndex("UnitOfMeasurementId");

                    b.ToTable("Indicators");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb.UseHistoryTable("IndicatorsHistory");
                            ttb
                                .HasPeriodStart("ValidFrom")
                                .HasColumnName("ValidFrom");
                            ttb
                                .HasPeriodEnd("ValidTo")
                                .HasColumnName("ValidTo");
                        }
                    ));
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.IndicatorLead", b =>
                {
                    b.Property<int>("IndicatorId")
                        .HasColumnType("int");

                    b.Property<int>("LeadId")
                        .HasColumnType("int");

                    b.HasKey("IndicatorId", "LeadId");

                    b.HasIndex("LeadId");

                    b.ToTable("IndicatorLead");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Lead", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId")
                        .IsUnique()
                        .HasFilter("[BranchId] IS NOT NULL");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Leads");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Objective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Objectives");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations", (string)null);
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Target", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IndicatorId")
                        .HasColumnType("int");

                    b.Property<string>("OcfDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.Property<double?>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IndicatorId")
                        .IsUnique();

                    b.ToTable("Targets");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                        {
                            ttb.UseHistoryTable("TargetsHistory");
                            ttb
                                .HasPeriodStart("ValidFrom")
                                .HasColumnName("ValidFrom");
                            ttb
                                .HasPeriodEnd("ValidTo")
                                .HasColumnName("ValidTo");
                        }
                    ));
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.UnitOfMeasurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("UnitsOfMeasurement", (string)null);
                });

            modelBuilder.Entity("ActionDirectorsCommittee", b =>
                {
                    b.HasOne("OurCleanFuture.Data.Entities.Action", null)
                        .WithMany()
                        .HasForeignKey("ActionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OurCleanFuture.Data.Entities.DirectorsCommittee", null)
                        .WithMany()
                        .HasForeignKey("DirectorsCommitteesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GoalObjective", b =>
                {
                    b.HasOne("OurCleanFuture.Data.Entities.Goal", null)
                        .WithMany()
                        .HasForeignKey("GoalsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OurCleanFuture.Data.Entities.Objective", null)
                        .WithMany()
                        .HasForeignKey("ObjectivesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Action", b =>
                {
                    b.HasOne("OurCleanFuture.Data.Entities.Objective", "Objective")
                        .WithMany("Actions")
                        .HasForeignKey("ObjectiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Objective");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.ActionLead", b =>
                {
                    b.HasOne("OurCleanFuture.Data.Entities.Action", "Action")
                        .WithMany("ActionLeads")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OurCleanFuture.Data.Entities.Lead", "Lead")
                        .WithMany("ActionLeads")
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Lead");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Branch", b =>
                {
                    b.HasOne("OurCleanFuture.Data.Entities.Department", "Department")
                        .WithMany("Branches")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Indicator", b =>
                {
                    b.HasOne("OurCleanFuture.Data.Entities.Action", "Action")
                        .WithMany("Indicators")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OurCleanFuture.Data.Entities.Goal", "Goal")
                        .WithMany("Indicators")
                        .HasForeignKey("GoalId");

                    b.HasOne("OurCleanFuture.Data.Entities.Objective", "Objective")
                        .WithMany("Indicators")
                        .HasForeignKey("ObjectiveId");

                    b.HasOne("OurCleanFuture.Data.Entities.UnitOfMeasurement", "UnitOfMeasurement")
                        .WithMany()
                        .HasForeignKey("UnitOfMeasurementId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsMany("OurCleanFuture.Data.Entities.Entry", "Entries", b1 =>
                        {
                            b1.Property<int>("IndicatorId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<DateTime>("StartDate")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("EndDate")
                                .HasColumnType("datetime2");

                            b1.Property<string>("Note")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("ValidFrom")
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnType("datetime2")
                                .HasColumnName("ValidFrom");

                            b1.Property<DateTime>("ValidTo")
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnType("datetime2")
                                .HasColumnName("ValidTo");

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("IndicatorId", "Id", "StartDate");

                            b1.ToTable("Entries", (string)null);

                            b1.ToTable(tb => tb.IsTemporal(ttb =>
                                {
                                    ttb.UseHistoryTable("EntriesHistory");
                                    ttb
                                        .HasPeriodStart("ValidFrom")
                                        .HasColumnName("ValidFrom");
                                    ttb
                                        .HasPeriodEnd("ValidTo")
                                        .HasColumnName("ValidTo");
                                }
                            ));

                            b1.WithOwner("Indicator")
                                .HasForeignKey("IndicatorId");

                            b1.Navigation("Indicator");
                        });

                    b.Navigation("Action");

                    b.Navigation("Entries");

                    b.Navigation("Goal");

                    b.Navigation("Objective");

                    b.Navigation("UnitOfMeasurement");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.IndicatorLead", b =>
                {
                    b.HasOne("OurCleanFuture.Data.Entities.Indicator", "Indicator")
                        .WithMany("IndicatorLeads")
                        .HasForeignKey("IndicatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OurCleanFuture.Data.Entities.Lead", "Lead")
                        .WithMany("IndicatorLeads")
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Indicator");

                    b.Navigation("Lead");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Lead", b =>
                {
                    b.HasOne("OurCleanFuture.Data.Entities.Branch", "Branch")
                        .WithOne("Lead")
                        .HasForeignKey("OurCleanFuture.Data.Entities.Lead", "BranchId");

                    b.HasOne("OurCleanFuture.Data.Entities.Organization", "Organization")
                        .WithMany()
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Objective", b =>
                {
                    b.HasOne("OurCleanFuture.Data.Entities.Area", "Area")
                        .WithMany("Objectives")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Target", b =>
                {
                    b.HasOne("OurCleanFuture.Data.Entities.Indicator", "Indicator")
                        .WithOne("Target")
                        .HasForeignKey("OurCleanFuture.Data.Entities.Target", "IndicatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Indicator");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Action", b =>
                {
                    b.Navigation("ActionLeads");

                    b.Navigation("Indicators");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Area", b =>
                {
                    b.Navigation("Objectives");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Branch", b =>
                {
                    b.Navigation("Lead")
                        .IsRequired();
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Department", b =>
                {
                    b.Navigation("Branches");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Goal", b =>
                {
                    b.Navigation("Indicators");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Indicator", b =>
                {
                    b.Navigation("IndicatorLeads");

                    b.Navigation("Target");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Lead", b =>
                {
                    b.Navigation("ActionLeads");

                    b.Navigation("IndicatorLeads");
                });

            modelBuilder.Entity("OurCleanFuture.Data.Entities.Objective", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("Indicators");
                });
#pragma warning restore 612, 618
        }
    }
}
