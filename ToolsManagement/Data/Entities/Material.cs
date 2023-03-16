using System.Collections.Generic;
using ToolsManagement.Entities;

namespace ToolsManagement.Data.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DrillParameters> DrillParameters { get; set; } = new();
        public Drill Drill { get; set; }
        public int DrillId { get; set; }
    }
}
