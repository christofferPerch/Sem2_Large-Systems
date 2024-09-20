namespace Sem2_Large_Systems.ViewModels
{
    public class JobViewModel
    {
        public int JobId { get; set; }
        public string JobStatus { get; set; }

        // Ticket-related properties
        public int TicketId { get; set; }
        public string DriverName { get; set; }

        // Warehouse-related properties
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public List<TicketChemicalViewModel> Chemicals { get; set; }

    }
}
