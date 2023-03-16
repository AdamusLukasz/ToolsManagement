using System.Collections.Generic;
using ToolsManagement.Models.EndMillCutterModels;

namespace ToolsManagement.Services.Interfaces
{
    public interface IEndMillCutterService
    {
        IEnumerable<EndMillCutterDto> GetAll();
        EndMillCutterDto GetById(int id);

        int Create(CreateEndMillCutterDto dto);
        void Delete(int id);
        void Update(int id, UpdateEndMillCutterDto dto);
    }
}
