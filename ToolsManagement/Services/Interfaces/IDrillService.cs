using System.Collections.Generic;
using System.Threading.Tasks;
using ToolsManagement.Data.Entities;
using ToolsManagement.Entities;
using ToolsManagement.Models;
using ToolsManagement.Models.DrillModel;

namespace ToolsManagement.Services.Interfaces
{
    public interface IDrillService
    {
        PagedResult<DrillDto> GetPaginated(DrillQuery drillQuery);
        Task<IEnumerable<DrillDto>> GetAllAsync();
        Task<DrillDto> GetByIdAsync(int id);
        Task<IEnumerable<DrillDto>> GetDrillForDeclaredDiametersAsync(int minDiameter, int maxDiameter);
        Task<int> CreateDrillAsync(CreateDrillDto dto);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(int id, UpdateDrillDto dto);
    }
}
