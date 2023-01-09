using AutoMapper;
using ToolsManagement.Data.Entities;
using ToolsManagement.Models.DrillModel;

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
