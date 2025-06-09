using Microsoft.EntityFrameworkCore;
using Projekt_zaliczenie.Models;

namespace Projekt_zaliczenie.Data;

public class MissionContext : DbContext
{
    public DbSet<Mission> Missions { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RocketStatus> RocketStatuses { get; set; }
    public DbSet<MissionStatus> MissionStatuses { get; set; }

    public MissionContext(DbContextOptions<MissionContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mission>().ToTable("Missions");
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<RocketStatus>().ToTable("RocketStatuses");
        modelBuilder.Entity<MissionStatus>().ToTable("MissionStatuses");

        modelBuilder.Entity<Mission>()
            .HasOne(m => m.RocketStatus)
            .WithMany(rs => rs.Missions)
            .HasForeignKey(m => m.RocketStatusId);

        modelBuilder.Entity<Mission>()
            .HasOne(m => m.MissionStatus)
            .WithMany(ms => ms.Missions)
            .HasForeignKey(m => m.MissionStatusId);
    }
}