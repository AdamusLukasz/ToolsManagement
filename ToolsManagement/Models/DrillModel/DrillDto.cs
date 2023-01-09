using System.Collections.Generic;
using ToolsManagement.Entities;

namespace ToolsManagement.Models.DrillModel
{
    public class DrillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Diameter { get; set; }
        public int? Length { get; set; }
        public int Quantity { get; set; }
        public int QuantityInMagazine { get; set; }
    }
}
