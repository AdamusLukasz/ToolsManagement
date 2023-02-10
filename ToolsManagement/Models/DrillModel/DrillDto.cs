using ToolsManagement.Data.Entities;
using ToolsManagement.Models.DrillParametersModels;
using ToolsManagement.Entities;
using System.Collections.Generic;

namespace ToolsManagement.Models.DrillModel
{
    public class DrillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Diameter { get; set; }
        public int Length { get; set; }
        public IEnumerable<MaterialDto> MaterialsDto { get; set; }


        public static DrillDto ToDrillDTOMap(Drill drill)
        {
            return new DrillDto()
            {
                Id = drill.Id,
                Name = drill.Name,
                Diameter = drill.Diameter,
                Length = drill.Length,
                MaterialsDto = ToMaterialDTOMap(drill.Materials),
            };
        }

        public static IEnumerable<MaterialDto> ToMaterialDTOMap(IEnumerable<Material> materials)
        {
            var materialDtos = new List<MaterialDto>();
            foreach (var material in materials)
            {
                materialDtos.Add(new MaterialDto()
                {
                    Id = material.Id,
                    Name = material.Name, 
                    DrillParametersDto = ToDrillParametersDTOMap(material.DrillParameters)
                });
            }

            return materialDtos;
        }

        public static IEnumerable<DrillParametersDto> ToDrillParametersDTOMap(IEnumerable<DrillParameters> drillParameters)
        {
            var drillParametersDtos = new List<DrillParametersDto>();
            foreach (var drillParameter in drillParameters)
            {
                drillParametersDtos.Add(new DrillParametersDto()
                {
                    Id = drillParameter.Id,
                    Fz = drillParameter.Fz,
                    Vc = drillParameter.Vc,
                });
            }
            return drillParametersDtos;
        }
    }
}
