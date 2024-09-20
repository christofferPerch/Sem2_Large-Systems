namespace Sem2_Large_Systems.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string DriverName { get; set; }
        public string ChemicalType { get; set; } 
        public double Quantity { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string Status { get; set; } 
    }
}
