using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToolsManagement.Models
{
    public class CreateDrillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }
        public List<CreateDrillParametersDto> DrillParameters { get; set; }
        //public int Vc { get; set; }
        //public double Fz { get; set; }
    }
}
