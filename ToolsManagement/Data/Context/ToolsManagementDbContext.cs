using Microsoft.EntityFrameworkCore;
using ToolsManagement.Data.Entities;
using ToolsManagement.Entities;
using ToolsManagement.Models.Drill;

namespace ToolsManagement.Data.Context
{
    public class ToolsManagementDbContext : DbContext
    {
        public ToolsManagementDbContext(DbContextOptions<ToolsManagementDbContext> options) : base(options)
        {

        }

        public DbSet<Drill> Drills { get; set; }
        public DbSet<EndMillCutter> EndMillCutters { get; set; }
        public DbSet<DrillParameters> DrillParameters { get; set; }
        public DbSet<EndMillCutterParameters> EndMillCutterParameters { get; set; }
        public DbSet<Material> Materials { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drill>(mb =>
            {
                mb.HasMany(h => h.Materials).WithOne(h => h.Drill).HasForeignKey(h => h.DrillId);
                mb.Property(p => p.Diameter).HasColumnType("decimal(4,1)");
            });

            modelBuilder.Entity<EndMillCutter>(mb =>
            {
                mb.HasMany(h => h.EndMillCutterParameters).WithOne(h => h.EndMillCutter).HasForeignKey(h => h.EndMillCutterId);
            });

            modelBuilder.Entity<Material>(mb =>
            {
                mb.HasMany(h => h.DrillParameters).WithOne(h => h.Material).HasForeignKey(h => h.MaterialId);
            });
        }
    }
}
