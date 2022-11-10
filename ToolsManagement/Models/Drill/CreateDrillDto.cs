using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToolsManagement.Models.Drill
{
    public class CreateDrillDto
    {
        [Required]
        [MaxLength(12)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0.1, 200.0)]
        public double? Diameter { get; set; } = null;
        [Required]
        [Range(10, 500)]
        public int? Length { get; set; } = null;
    }
}
