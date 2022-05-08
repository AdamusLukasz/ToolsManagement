using Microsoft.EntityFrameworkCore;

namespace ToolsManagement.Entities
{
    public class ToolsManagementDbContext : DbContext
    {
        private string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ToolsManagement;Trusted_Connection=True;";
                                            
        public DbSet<Drill> Drills { get; set; }
        public DbSet<EndMillCutter> EndMillCutters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
