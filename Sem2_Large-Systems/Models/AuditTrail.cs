namespace Sem2_Large_Systems.Models
{
    public class AuditTrail
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }
        public Job Job { get; set; }
    }

}
