using System;
using System.Collections.Generic;
using ToolsManagement.Data.Entities;

namespace ToolsManagement.Data.Entities
{
    public class Drill
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double? Diameter { get; set; }
        public int Length { get; set; } = 0;
        public int Quantity { get; set; }
        public int QuantityInMagazine { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<Material> Materials { get; set; } = new();
    }
}
