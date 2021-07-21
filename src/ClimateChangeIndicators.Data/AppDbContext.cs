using ClimateChangeIndicators.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClimateChangeIndicators.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<Owner> Owners { get; set; }

        //public AppDbContext()
        //{
        //}

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
            modelBuilder.Entity<OurCleanFutureReference>().ToTable("OurCleanFutureReferences");
            modelBuilder.Entity<Department>().ToTable("Departments");

            modelBuilder.Entity<Indicator>().Property(i => i.DataType).HasConversion<string>();
            modelBuilder.Entity<Indicator>().Property(i => i.CollectionInterval).HasConversion<string>();

            modelBuilder.Entity<Owner>().HasOne(o => o.Organization).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Owner>().HasOne(o => o.Branch).WithMany().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Indicator>().HasOne(i => i.Owner).WithMany(o => o.Indicators).IsRequired().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Indicator>().OwnsMany(i => i.Entries, ie => {
                ie.ToTable("Entries").WithOwner(e => e.Indicator);
                ie.HasOne(e => e.UnitOfMeasurement).WithMany().OnDelete(DeleteBehavior.Restrict);
            }
            );

            //Generate bogus data for testing
            new BogusDataGenerator(modelBuilder).Init();
        }
    }
}