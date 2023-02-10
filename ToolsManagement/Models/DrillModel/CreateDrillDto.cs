using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToolsManagement.Models.DrillModel
{
    public class CreateDrillDto
    {
        [Required]
        [MaxLength(12)]
        public string Name { get; set; }
        [Required]
        public double Diameter { get; set; }
        [Required]
        public int Length { get; set; }
    }
}
