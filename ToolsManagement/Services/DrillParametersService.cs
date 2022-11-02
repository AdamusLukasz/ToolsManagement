using Microsoft.EntityFrameworkCore;
using System.Linq;
using ToolsManagement.Data.Context;
using ToolsManagement.Entities;
using ToolsManagement.Exceptions;
using ToolsManagement.Models.Drill;
using ToolsManagement.Services.Interfaces;

namespace ToolsManagement.Services
{
    public class DrillParametersService : IDrillParametersService
    {
        private readonly ToolsManagementDbContext _dbContext;

        public DrillParametersService(ToolsManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int CreateDrillParameters(int drillId, CreateDrillParametersDto dto)
        {
            var drill = GetDrillById(drillId);
            var drillParameters = new DrillParameters() 
            { 
                Vc = dto.Vc,
                Fz = dto.Fz 
            };
            _dbContext.DrillParameters.Add(drillParameters);
            _dbContext.SaveChanges();
            return drillParameters.Id;
        }
        private Drill GetDrillById(int drillId)
        {
            var drill = _dbContext.Drills
                .Include(x => x.Materials)
                .ThenInclude(x => x.DrillParameters)
                .FirstOrDefault(x => x.Id == drillId);
            if (drill is null)
            {
                throw new NotFoundException("Drill not found.");
            }
            return drill;
        }
    }
}
