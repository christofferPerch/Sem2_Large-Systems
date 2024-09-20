namespace Sem2_Large_Systems.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int WarehouseId { get; set; }
        public string Status { get; set; }
        public Ticket Ticket { get; set; }  
        public Warehouse Warehouse { get; set; }
        public ICollection<AuditTrail> AuditTrails { get; set; }
    }
}
