using System.Collections.Generic;
using ToolsManagement.Entities;

namespace ToolsManagement.Models.Drill
{
    public class DrillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }
        public int Length { get; set; }
        public List<DrillParametersDto> DrillParameters { get; set; }
        public List<MaterialDto> Materials { get; set; }
    }
}
