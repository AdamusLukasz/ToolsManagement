using System.Collections.Generic;

namespace ToolsManagement.Entities
{
    public class Drill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }
        public int Length { get; set; }
        public List<DrillParameters> DrillParameters { get; set; } = new List<DrillParameters>();

    }
}
