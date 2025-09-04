using greenEyeProject.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<SatelliteData> SatelliteData { get; set; }
    public DbSet<SoilData> SoilData { get; set; }
    public DbSet<ClimateData> ClimateData { get; set; }
    public DbSet<AIAnalysis> Analyses { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //  Precision for AIAnalysis
        modelBuilder.Entity<AIAnalysis>()
            .Property(a => a.RiskPrediction)
            .HasPrecision(5, 2);

        //  Precision for ClimateData
        modelBuilder.Entity<ClimateData>()
            .Property(c => c.Temperature)
            .HasPrecision(10, 2);

        modelBuilder.Entity<ClimateData>()
            .Property(c => c.Rainfall)
            .HasPrecision(10, 2);

        modelBuilder.Entity<ClimateData>()
            .Property(c => c.Humidity)
            .HasPrecision(10, 2);

        //  Precision for SoilData
        modelBuilder.Entity<SoilData>()
            .Property(s => s.pH)
            .HasPrecision(4, 2);

        modelBuilder.Entity<SoilData>()
            .Property(s => s.Salinity)
            .HasPrecision(8, 3);

        modelBuilder.Entity<SoilData>()
            .Property(s => s.Carbon)
            .HasPrecision(8, 3);

        //  Precision for SatelliteData
        modelBuilder.Entity<SatelliteData>()
            .Property(s => s.NDVI)
            .HasPrecision(5, 3);

        //  Fix multiple cascade paths for Reports
        modelBuilder.Entity<Report>()
            .HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Report>()
            .HasOne(r => r.Location)
            .WithMany()
            .HasForeignKey(r => r.LocationId)
            .OnDelete(DeleteBehavior.Restrict);


        //  Seed Roles
        modelBuilder.Entity<Location>().HasData(
            new Location { LocationId = 1, LocationName = "Head Office", UserId = 1 },
            new Location { LocationId = 2, LocationName = "Branch Office", UserId = 1 }
        );

        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1, RoleName = "Admin" },
            new Role { RoleId = 2, RoleName = "User" }
        );

        //  Seed Admin User
        modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                Name = "System Admin",
                Email = "admin@greeneye.com",
                PasswordHash = "Admin@123", 
                PhoneNumber = "01016943529",
                Location = "Head Office",
                RoleId = 1,
                CreatedAt = new DateTime(2025, 9, 4, 0, 0, 0, DateTimeKind.Utc)
            }
        );
    }
}
