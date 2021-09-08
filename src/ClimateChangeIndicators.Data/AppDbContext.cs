﻿using ClimateChangeIndicators.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Action = ClimateChangeIndicators.Data.Entities.Action;

namespace ClimateChangeIndicators.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Indicator> Indicators { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<UnitOfMeasurement> UnitsOfMeasurement { get; set; } = null!;
        public DbSet<Action> Actions { get; set; } = null!;
        public DbSet<Target> Targets { get; set; } = null!;

        private readonly ConnectionStrings _connectionStrings;

        //Uncomment to allow EF Core Power Tools to generate a diagram
        //public AppDbContext()
        //{
        //}

        public AppDbContext(DbContextOptions options, ConnectionStrings connectionStrings) : base(options)
        {
            _connectionStrings = connectionStrings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Comment to allow EF Core Power Tools to generate a diagram
            optionsBuilder.UseSqlServer(_connectionStrings.AppContext);

            //Uncomment to allow EF Core Power Tools to generate a diagram
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=EnvClimateChangeIndicators; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>()
                        .ToTable("Organizations");
            modelBuilder.Entity<Branch>()
                        .ToTable("Branches")
                        .Ignore(b => b.Owner);
            modelBuilder.Entity<Department>()
                        .ToTable("Departments");
            //modelBuilder.Entity<Action>()
            //            .ToTable("Actions");
            modelBuilder.Entity<UnitOfMeasurement>()
                        .ToTable("UnitsOfMeasurement")
                        .HasIndex(u => u.Symbol)
                        .IsUnique();

            modelBuilder.Entity<Owner>()
                        .HasOne(o => o.Organization)
                        .WithMany()
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Owner>()
                        .HasOne(o => o.Branch)
                        .WithOne()
                        .HasForeignKey<Branch>(b => b.OwnerId)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Indicator>()
                        .Property(i => i.DataType)
                        .HasConversion<string>();
            modelBuilder.Entity<Indicator>()
                        .Property(i => i.CollectionInterval)
                        .HasConversion<string>();
            modelBuilder.Entity<Indicator>()
                        .HasOne(i => i.Owner)
                        .WithMany(o => o.Indicators)
                        .IsRequired()
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Indicator>()
                        .HasOne(i => i.UnitOfMeasurement)
                        .WithMany()
                        .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Indicator>()
                        .HasOne(i => i.Action)
                        .WithMany(o => o.Indicators)
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

            //Generate bogus data for testing
            new DataSeeder(modelBuilder).Init();
        }
    }
}