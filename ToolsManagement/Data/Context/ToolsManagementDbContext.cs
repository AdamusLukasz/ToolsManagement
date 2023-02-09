using Microsoft.EntityFrameworkCore;
using ToolsManagement.Data.Entities;
using ToolsManagement.Entities;
using ToolsManagement.Models.DrillModel;

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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drill>(mb =>
            {
                mb.HasMany(h => h.Materials)
                .WithOne(h => h.Drill)
                .HasForeignKey(h => h.DrillId);
                
                mb.Property(p => p.Diameter)
                .HasColumnType("decimal(4,1)");

                mb.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<EndMillCutter>(mb =>
            {
                mb.HasMany(h => h.EndMillCutterParameters)
                .WithOne(h => h.EndMillCutter)
                .HasForeignKey(h => h.EndMillCutterId);

                mb.Property(p => p.Name)
                .IsRequired();
            });

            modelBuilder.Entity<Material>(mb =>
            {
                mb.HasMany(h => h.DrillParameters)
                .WithOne(h => h.Material)
                .HasForeignKey(h => h.MaterialId);
            });

            modelBuilder.Entity<User>(mb =>
            {
                mb.Property(p => p.FirstName).IsRequired();
                mb.Property(p => p.LastName).IsRequired();
            });

            modelBuilder.Entity<Role>(mb =>
            {
                mb.Property(p => p.Name).IsRequired();
                mb.HasData(
                    new Role() { Id = 1, Name = "Admin" },
                    new Role() { Id = 2, Name = "Operator" },
                    new Role() { Id = 3, Name = "Programmer" },
                    new Role() { Id = 4, Name = "Viewer" }
                           );
            });

        }
    }
}
