namespace Sem2_Large_Systems.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public int TicketID { get; set; } 
        public string StorageLocation { get; set; }
        public string JobType { get; set; }
        public string Status { get; set; } 
        public Ticket Ticket { get; set; } 
    }
}
