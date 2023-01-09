using Microsoft.EntityFrameworkCore;
using System.Linq;
using ToolsManagement.Data.Context;
using ToolsManagement.Data.Entities;
using ToolsManagement.Entities;
using ToolsManagement.Exceptions;
using ToolsManagement.Models.DrillParameters;
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
        public int CreateDrillParameters(int drillId, int materialId, CreateDrillParametersDto dto)
        {
            var drill = GetDrillById(drillId);
            var material = drill.Materials.FirstOrDefault(x => x.Id == materialId);

            var drillParameters = new DrillParameters() 
            { 
                Vc = dto.Vc,
                Fz = dto.Fz, 
                MaterialId = materialId
            };

            if (material is null)
            {
                throw new NotFoundException("This drill don't have that material.");
            }
            _dbContext.DrillParameters.Add(drillParameters);
            _dbContext.SaveChanges();
            return drillParameters.Id;
        }
        private Drill GetDrillById(int drillId)
        {
            var drill = _dbContext.Drills
                .Include(a => a.Materials)
                .FirstOrDefault(x => x.Id == drillId);
            if (drill is null)
            {
                throw new NotFoundException("Drill not found.");
            }
            return drill;
        }
    }
}
