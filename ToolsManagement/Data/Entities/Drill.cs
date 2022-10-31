using System.Collections.Generic;
using ToolsManagement.Data.Entities;

namespace ToolsManagement.Entities
{
    public class Drill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }
        public int Length { get; set; }
        public List<DrillParameters> DrillParameters { get; set; } = new();
        public List<Material> Materials { get; set; } = new();

    }
}
