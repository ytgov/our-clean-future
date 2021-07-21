using ClimateChangeIndicators.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClimateChangeIndicators.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EnvClimateChangeIndicators");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitOfMeasurement>().ToTable("UnitsOfMeasurement");
            modelBuilder.Entity<Organization>().ToTable("Organizations");
            modelBuilder.Entity<Branch>().ToTable("Branches");
            modelBuilder.Entity<Entry>().ToTable("Entries");
            modelBuilder.Entity<OurCleanFutureReference>().ToTable("OurCleanFutureReferences");
            modelBuilder.Entity<DataType>().ToTable("DataTypes");
            modelBuilder.Entity<CollectionInterval>().ToTable("CollectionIntervals");
            modelBuilder.Entity<Department>().ToTable("Departments");

            modelBuilder.Entity<Indicator>().HasOne(i => i.DataType).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Indicator>().HasOne(i => i.CollectionInterval).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Indicator>().HasOne<Owner>().WithMany().IsRequired();
        }
    }
}
