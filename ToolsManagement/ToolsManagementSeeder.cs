using ToolsManagement.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ToolsManagement
{
    public class ToolsManagementSeeder
    {
        private readonly ToolsManagementDbContext _dbContext;
        public ToolsManagementSeeder(ToolsManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();
                if (pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

            }
        }
    }
}
