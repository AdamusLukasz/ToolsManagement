using AutoMapper;
using ToolsManagement.Entities;
using ToolsManagement.Models;

namespace ToolsManagement
{
    public class DrillMappingProfile : Profile
    {
        public DrillMappingProfile()
        {
            CreateMap<CreateDrillDto, Drill>();
        }
    }
}
