using Microsoft.EntityFrameworkCore;
using OurCleanFuture.Data.Entities;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.Data;

public class AppDbContext : DbContext
{
    ////Uncomment to allow EF Core Power Tools to generate a diagram
    //public AppDbContext() { }

    ////Uncomment to allow EF Core Power Tools to generate a diagram
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(
    //        "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=EnvOurCleanFuture; Integrated Security=True"
    //    );
    //}

    public AppDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Indicator> Indicators => Set<Indicator>();
    public DbSet<Lead> Leads => Set<Lead>();
    public DbSet<Branch> Branches => Set<Branch>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<UnitOfMeasurement> UnitsOfMeasurement => Set<UnitOfMeasurement>();
    public DbSet<DirectorsCommittee> DirectorsCommittees => Set<DirectorsCommittee>();
    public DbSet<Action> Actions => Set<Action>();
    public DbSet<Target> Targets => Set<Target>();
    public DbSet<Goal> Goals => Set<Goal>();
    public DbSet<Objective> Objectives => Set<Objective>();
    public DbSet<Area> Areas => Set<Area>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Organization>().ToTable("Organizations");

        modelBuilder.Entity<Branch>(b =>
        {
            b.ToTable("Branches");
            b.HasOne(b => b.Lead).WithOne(l => l.Branch).IsRequired(false);
        });

        modelBuilder.Entity<Department>().ToTable("Departments");

        modelBuilder
            .Entity<UnitOfMeasurement>()
            .ToTable("UnitsOfMeasurement")
            .HasIndex(u => u.Symbol)
            .IsUnique();

        modelBuilder
            .Entity<Lead>()
            .HasOne(l => l.Organization)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Action>(a =>
        {
            a.ToTable(
                tb =>
                    tb.IsTemporal(tb =>
                    {
                        tb.UseHistoryTable("ActionsHistory");
                        tb.HasPeriodStart("ValidFrom");
                        tb.HasPeriodEnd("ValidTo");
                    })
            );
            a.HasMany(a => a.Leads)
                .WithMany(l => l.Actions)
                .UsingEntity<ActionLead>(
                    j =>
                        j.HasOne(al => al.Lead)
                            .WithMany(l => l.ActionLeads)
                            .HasForeignKey("LeadId")
                            .OnDelete(DeleteBehavior.Restrict),
                    j =>
                        j.HasOne(al => al.Action)
                            .WithMany(i => i.ActionLeads)
                            .HasForeignKey("ActionId")
                            .OnDelete(DeleteBehavior.Restrict)
                );
            a.Property(a => a.StartDate).HasColumnType("date");
            a.Property(a => a.TargetCompletionDate).HasColumnType("date");
            a.Property(a => a.ActualCompletionDate).HasColumnType("date");
            a.Property(a => a.InternalStatus).HasConversion<string>().HasMaxLength(25);
            a.Property(a => a.ExternalStatus).HasConversion<string>().HasMaxLength(25);
            a.HasIndex(a => a.Number).IsUnique();
        });

        modelBuilder
            .Entity<Indicator>()
            .Property(i => i.DataType)
            .HasConversion<string>()
            .HasMaxLength(25);
        modelBuilder
            .Entity<Indicator>()
            .Property(i => i.CollectionInterval)
            .HasConversion<string>()
            .HasMaxLength(25);
        modelBuilder
            .Entity<Indicator>()
            .HasMany(i => i.Leads)
            .WithMany(l => l.Indicators)
            .UsingEntity<IndicatorLead>(
                j =>
                    j.HasOne(il => il.Lead)
                        .WithMany(l => l.IndicatorLeads)
                        .HasForeignKey("LeadId")
                        .OnDelete(DeleteBehavior.Restrict),
                j =>
                    j.HasOne(il => il.Indicator)
                        .WithMany(i => i.IndicatorLeads)
                        .HasForeignKey("IndicatorId")
                        .OnDelete(DeleteBehavior.Cascade)
            );
        modelBuilder
            .Entity<Indicator>()
            .HasOne(i => i.UnitOfMeasurement)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder
            .Entity<Indicator>()
            .HasOne(i => i.Action)
            .WithMany(a => a.Indicators)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder
            .Entity<Indicator>()
            .HasOne(i => i.Target)
            .WithOne(t => t!.Indicator)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder
            .Entity<Indicator>()
            .OwnsMany(
                i => i.Entries,
                ie =>
                {
                    ie.ToTable("Entries");
                    ie.Property(e => e.StartDate).HasColumnType("date");
                    ie.Property(e => e.EndDate).HasColumnType("date");
                    ie.Property<int>("IndicatorId").HasColumnType("int");
                    ie.HasKey("IndicatorId", "StartDate");
                    ie.ToTable(
                            tb =>
                                tb.IsTemporal(tb =>
                                {
                                    tb.UseHistoryTable("EntriesHistory");
                                    tb.HasPeriodStart("ValidFrom");
                                    tb.HasPeriodEnd("ValidTo");
                                })
                        )
                        .WithOwner(e => e.Indicator)
                        .HasForeignKey("IndicatorId");
                }
            );
        modelBuilder
            .Entity<Indicator>()
            .ToTable(
                tb =>
                    tb.IsTemporal(tb =>
                    {
                        tb.UseHistoryTable("IndicatorsHistory");
                        tb.HasPeriodStart("ValidFrom");
                        tb.HasPeriodEnd("ValidTo");
                    })
            );

        modelBuilder.Entity<Target>(t =>
        {
            t.ToTable(
                tb =>
                    tb.IsTemporal(tb =>
                    {
                        tb.UseHistoryTable("TargetsHistory");
                        tb.HasPeriodStart("ValidFrom");
                        tb.HasPeriodEnd("ValidTo");
                    })
            );
            t.Property(t => t.CompletionDate).HasColumnType("date");
        });
    }
}
