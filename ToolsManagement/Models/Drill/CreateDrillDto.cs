using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToolsManagement.Models.Drill
{
    public class CreateDrillDto
    {
        public string Name { get; set; }
        public double Diameter { get; set; }
        public int Length { get; set; }
    }
}
