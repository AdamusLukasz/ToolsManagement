using System.Collections.Generic;
using ToolsManagement.Models.DrillModel;

namespace ToolsManagement.Services
{
    public interface IMagazineService
    {
        IEnumerable<DrillDto> GetAll();
        void ReturnToMagazine(int drillId);
        void TakeFromMagazine(int drillId);
        void UpdateQuantityInMagazine(int drillId, DrillMagazineQuantityUpdateDto dto);
    }
}