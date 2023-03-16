using System.Collections.Generic;

namespace ToolsManagement.Entities
{
    public class EndMillCutter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }
        public List<EndMillCutterParameters> EndMillCutterParameters { get; set; } = new List<EndMillCutterParameters>();

    }
}
