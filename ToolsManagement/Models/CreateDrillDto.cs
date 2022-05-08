using System.ComponentModel.DataAnnotations;

namespace ToolsManagement.Models
{
    public class CreateDrillDto
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public double Diameter { get; set; }
        [Required]
        public int Vc { get; set; }
        [Required]
        public double Fz { get; set; }
    }
}
