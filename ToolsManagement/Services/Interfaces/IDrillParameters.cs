using ToolsManagement.Models.DrillParameters;

namespace ToolsManagement.Services.Interfaces
{
    public interface IDrillParametersService
    {
        int CreateDrillParameters(int drillId, int materialId, CreateDrillParametersDto dto);
    }
}
