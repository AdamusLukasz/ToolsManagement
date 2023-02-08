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
        PagedResult<DrillMagazineDto> GetPaginated(DrillQuery drillQuery);
        Task<IEnumerable<DrillDto>> GetAll();
        DrillMagazineDto GetById(int id);
        IEnumerable<DrillMagazineDto> GetDrillForDeclaredDiameters(int minDiameter, int maxDiameter);
        int CreateDrill(CreateDrillDto dto);
        void Delete(int id);
        void Update(int id, UpdateDrillDto dto);
    }
}
