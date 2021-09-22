using OurCleanFuture.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Action = OurCleanFuture.Data.Entities.Action;

namespace OurCleanFuture.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Indicator> Indicators { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
        public DbSet<UnitOfMeasurement> UnitsOfMeasurement { get; set; } = null!;
        public DbSet<DirectorsCommittee> DirectorsCommittees { get; set; } = null!;
        public DbSet<Action> Actions { get; set; } = null!;
        public DbSet<Target> Targets { get; set; } = null!;
        public DbSet<Goal> Goals { get; set; } = null!;
        public DbSet<Objective> Objectives { get; set; } = null!;
        public DbSet<Area> Areas { get; set; } = null!;

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
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=EnvOurCleanFuture; Integrated Security=True");
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

            modelBuilder.Entity<Target>()
                        .Property(t => t.EndDate)
                        .IsRequired();

            //Generate bogus data for testing
            new DataSeeder(modelBuilder).Init();
        }
    }
}