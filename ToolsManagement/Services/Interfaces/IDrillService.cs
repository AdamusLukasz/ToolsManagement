using System.Collections.Generic;
using ToolsManagement.Entities;
using ToolsManagement.Models;
using ToolsManagement.Models.Drill;

namespace ToolsManagement.Services.Interfaces
{
    public interface IDrillService
    {
        PagedResult<DrillDto> GetAll(DrillQuery drillQuery);
        DrillDto GetById(int id);
        IEnumerable<DrillDto> GetDrillForDeclaredDiameters(int minDiameter, int maxDiameter);
        int CreateDrill(CreateDrillDto dto);
        void Delete(int id);
        void Update(int id, UpdateDrillDto dto);
    }
}
