using ToolsManagement.Models.Drill;

namespace ToolsManagement.Services.Interfaces
{
    public interface IDrillParametersService
    {
        int CreateDrillParameters(int drillId, int materialId, CreateDrillParametersDto dto);
    }
}
