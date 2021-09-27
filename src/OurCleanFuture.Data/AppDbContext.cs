using OurCleanFuture.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Action = OurCleanFuture.Data.Entities.Action;
using System.Collections.Generic;

namespace OurCleanFuture.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Indicator> Indicators { get; set; } = null!;
        public DbSet<Lead> Leads { get; set; } = null!;
        public DbSet<Branch> Branches { get; set; } = null!;
        public DbSet<Department> Departments { get; set; } = null!;
        public DbSet<UnitOfMeasurement> UnitsOfMeasurement { get; set; } = null!;
        public DbSet<DirectorsCommittee> DirectorsCommittees { get; set; } = null!;
        public DbSet<Action> Actions { get; set; } = null!;
        public DbSet<Target> Targets { get; set; } = null!;
        public DbSet<Goal> Goals { get; set; } = null!;
        public DbSet<Objective> Objectives { get; set; } = null!;
        public DbSet<Area> Areas { get; set; } = null!;

        private readonly ConnectionStrings connectionStrings;

        //Uncomment to allow EF Core Power Tools to generate a diagram
        //public AppDbContext()
        //{
        //}

        //Uncomment to allow EF Core Power Tools to generate a diagram
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=EnvOurCleanFuture; Integrated Security=True");
        //}

        public AppDbContext(DbContextOptions options, ConnectionStrings connectionStrings) : base(options)
        {
            this.connectionStrings = connectionStrings;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                        .ToTable("Organizations");
            modelBuilder.Entity<Branch>()
                        .ToTable("Branches");
            modelBuilder.Entity<Branch>()
                        .HasOne(b => b.Lead)
                        .WithOne(l => l.Branch)
                        .IsRequired(false);
            modelBuilder.Entity<Department>()
                        .ToTable("Departments");
            //modelBuilder.Entity<Action>()
            //            .ToTable("Actions");
            modelBuilder.Entity<UnitOfMeasurement>()
                        .ToTable("UnitsOfMeasurement")
                        .HasIndex(u => u.Symbol)
                        .IsUnique();
            modelBuilder.Entity<Lead>()
                        .HasOne(l => l.Organization)
                        .WithMany()
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Action>()
                        .Property(a => a.InternalStatus)
                        .HasConversion<string>();
            modelBuilder.Entity<Action>()
                        .Property(a => a.ExternalStatus)
                        .HasConversion<string>();

            modelBuilder.Entity<Indicator>()
                        .Property(i => i.DataType)
                        .HasConversion<string>();
            modelBuilder.Entity<Indicator>()
                        .Property(i => i.CollectionInterval)
                        .HasConversion<string>();

            modelBuilder.Entity<Indicator>()
                        .HasMany(i => i.Leads)
                        .WithMany(l => l.Indicators)
                        .UsingEntity<IndicatorLead>(
                            j => j
                            .HasOne(il => il.Lead)
                            .WithMany(l => l.IndicatorLeads)
                            .HasForeignKey("LeadId")
                            .OnDelete(DeleteBehavior.Restrict),
                            j => j
                            .HasOne(il => il.Indicator)
                            .WithMany(i => i.IndicatorLeads)
                            .HasForeignKey("IndicatorId")
                            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Indicator>()
                        .HasOne(i => i.UnitOfMeasurement)
                        .WithMany()
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Indicator>()
                        .HasOne(i => i.Action)
                        .WithMany(a => a.Indicators)
                        .IsRequired(false)
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Indicator>()
                        .HasOne(i => i.Target)
                        .WithOne(t => t!.Indicator)
                        .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Indicator>()
                        .OwnsMany(i => i.Entries,
                            ie => {
                                ie.ToTable("Entries")
                                  .WithOwner(e => e.Indicator);
                            });
            modelBuilder.Entity<Indicator>().ToTable(tb => tb.IsTemporal());

            modelBuilder.Entity<Target>()
                        .Property(t => t.EndDate)
                        .IsRequired();
            modelBuilder.Entity<Target>().ToTable(tb => tb.IsTemporal());

            //Generate bogus data for testing
            new DataSeeder(modelBuilder).Init();
        }
    }
}