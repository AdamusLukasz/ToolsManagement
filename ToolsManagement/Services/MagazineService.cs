using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsManagement.Data.Context;
using ToolsManagement.Models.Drill;

namespace ToolsManagement.Services
{
    public class MagazineService : IMagazineService
    {
        private readonly ToolsManagementDbContext _dbContext;
        public MagazineService(ToolsManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<DrillDto> GetAll()
        {
            var drills = _dbContext
                .Drills
                .Select(n => new DrillDto()
                {
                    Id = n.Id,
                    Name = n.Name,
                    //Length = n.Length,
                    //Diameter = n.Diameter,
                    Quantity = n.Quantity
                })
                .ToList();
            return drills;
        }

        public void ReturnToMagazine(int drillId)
        {
            var drills = _dbContext
                .Drills
                .FirstOrDefault(a => a.Id == drillId);

            int quantity = drills.Quantity;

            drills.Quantity = quantity + 1;

            _dbContext.SaveChanges();
        }
    }
}
