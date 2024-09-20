namespace Sem2_Large_Systems.Models
{
    public class AuditTrail
    {
        public int LogID { get; set; }
        public int JobID { get; set; } 
        public DateTime Timestamp { get; set; }
        public string Action { get; set; } 
        public string ChemicalType { get; set; }
        public double Quantity { get; set; }
        public Job Job { get; set; }
    }
}
