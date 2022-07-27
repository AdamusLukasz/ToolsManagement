namespace ToolsManagement.Entities
{
    public class EndMillCutterParameters
    {
        public int Id { get; set; }
        public int Vc { get; set; }
        public double Fz { get; set; }
        public int NumberOfTeeth { get; set; }
        public int WorkingLength { get; set; }
        public EndMillCutter EndMillCutter { get; set; }
        public int EndMillCutterId { get; set; }
    }
}
