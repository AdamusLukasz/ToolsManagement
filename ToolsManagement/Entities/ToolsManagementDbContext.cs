using Microsoft.EntityFrameworkCore;
using ToolsManagement.Models;

namespace ToolsManagement.Entities
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drill>(mb =>
            {
                mb.HasMany(h => h.DrillParameters).WithOne(h => h.Drill).HasForeignKey(j => j.DrillId);
            });
            modelBuilder.Entity<EndMillCutter>(mb =>
            {
                mb.HasMany(h => h.EndMillCutterParameters).WithOne(h => h.EndMillCutter).HasForeignKey(h => h.EndMillCutterId);
            });
            modelBuilder.Entity<CreateDrillDto>(mb =>
            {
                mb.Property(x => x.Name).HasMaxLength(40).IsRequired();
                mb.Property(x => x.Diameter).HasMaxLength(40).IsRequired();
                //mb.Property(x => x.Vc).HasMaxLength(40).IsRequired();
                //mb.Property(x => x.Fz).HasMaxLength(40).IsRequired();
            });
        }


    }
}
