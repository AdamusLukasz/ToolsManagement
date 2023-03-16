using System.Collections.Generic;
using ToolsManagement.Models.DrillParametersModels;

namespace ToolsManagement.Models
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DrillParametersDto> DrillParametersDto { get; set; }
    }
}
