using System.Collections.Generic;
using ToolsManagement.Entities;
using ToolsManagement.Models.Drill;

namespace ToolsManagement.Services.Interfaces
{
    public interface IDrillService
    {
        IEnumerable<Drill> GetAll();
        int CreateDrill(CreateDrillDto dto);
        Drill GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateDrillDto dto);
    }
}
