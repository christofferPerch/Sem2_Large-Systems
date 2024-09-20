using System.ComponentModel.DataAnnotations;

namespace Sem2_Large_Systems.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string DriverName { get; set; }
        public string Status { get; set; }
        public int WarehouseId { get; set; } 
        public Warehouse Warehouse { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<TicketChemical> Chemicals { get; set; }

    }
}
