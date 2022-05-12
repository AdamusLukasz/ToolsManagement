using Microsoft.EntityFrameworkCore;

namespace ToolsManagement.Entities
{
    public class ToolsManagementDbContext : DbContext
    {
        public ToolsManagementDbContext(DbContextOptions<ToolsManagementDbContext> options) : base(options)
        {

        }
                                            
        public DbSet<Drill> Drills { get; set; }
        public DbSet<EndMillCutter> EndMillCutters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
