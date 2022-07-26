using AutoMapper;
using ToolsManagement.Entities;
using ToolsManagement.Models.Drill;

namespace ToolsManagement.Profiles
{
    public class DrillMappingProfile : Profile
    {
        public DrillMappingProfile()
        {
            CreateMap<CreateDrillDto, Drill>();
        }
    }
}
