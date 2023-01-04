using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsManagement.Data.Context;
using ToolsManagement.Exceptions;
using ToolsManagement.Models.Drill;

namespace ToolsManagement.Services
{
    public class MagazineService : IMagazineService
    {
        private readonly ToolsManagementDbContext _dbContext;
        private readonly ILogger _logger;

        public MagazineService(ToolsManagementDbContext dbContext, ILogger<MagazineService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public IEnumerable<DrillDto> GetAll()
        {
            var drills = _dbContext
                .Drills
                .Select(n => new DrillDto()
                {
                    Id = n.Id,
                    Name = n.Name,
                    Quantity = n.Quantity, 
                    QuantityInMagazine = n.QuantityInMagazine
                })
                .ToList();
            return drills;
        }

        public void ReturnToMagazine(int drillId)
        {
            var drills = _dbContext
                .Drills
                .FirstOrDefault(a => a.Id == drillId);

            int quantityInMagazine = drills.QuantityInMagazine;

            int quantity = drills.Quantity;

            if (quantityInMagazine == quantity)
            {
                throw new NotFoundException("Magazine is full.");
            }

            drills.QuantityInMagazine += 1;

            _dbContext.SaveChanges();
        }
        public void TakeFromMagazine(int drillId)
        {
            var drills = _dbContext
                .Drills
                .Where(a => a.Id == drillId)
                .First();
            
            _logger.LogInformation($"{drills.Name} was taken.");

            var magazine = drills.QuantityInMagazine -= 1;

            if (magazine < 0)
            {
                throw new NotFoundException("Magazine is empty.");
            }

            _dbContext.SaveChanges();
        }

        public void UpdateQuantityInMagazine(int drillId, DrillMagazineQuantityUpdateDto dto)
        {
            var drill = _dbContext
                .Drills
                .First(a => a.Id == drillId);

            drill.Quantity = dto.Quantity;
            _dbContext.SaveChanges();
        }
    }
}
