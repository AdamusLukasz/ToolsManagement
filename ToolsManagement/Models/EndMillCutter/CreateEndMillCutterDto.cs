namespace ToolsManagement.Models.EndMillCutter
{
    public class CreateEndMillCutterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }
        public int Vc { get; set; }
        public double Fz { get; set; }
        public int NumberOfTeeth { get; set; }
        public int WorkingLength { get; set; }
    }
}
