using ToolsManagement.Data.Entities;

namespace ToolsManagement.Entities
{
    public class DrillParameters
    {
        public int Id { get; set; }
        public int Vc { get; set; }
        public double Fz { get; set; }
        public Drill Drill { get; set; }
        public int DrillId { get; set; }
        //public Material Material { get; set; }
        //public int MaterialId { get; set; }
    }
}
