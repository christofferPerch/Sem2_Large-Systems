using System.Collections.Generic;

namespace Sem2_Large_Systems.ViewModels
{
    public class TicketViewModel
    {
        public int TicketId { get; set; }
        public string DriverName { get; set; }
        public string Status { get; set; }
        public List<TicketChemicalViewModel> Chemicals { get; set; }
    }
}
