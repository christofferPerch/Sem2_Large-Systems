using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sem2_Large_Systems.ViewModels
{
    public class TicketCreateViewModel
    {
        public string DriverName { get; set; }

        [Required]
        public int WarehouseId { get; set; }  

        public string Status { get; set; } = "Pending";  

        public List<TicketChemicalViewModel> Chemicals { get; set; } = new List<TicketChemicalViewModel>();
    }

    public class TicketChemicalViewModel
    {
        public int ChemicalId { get; set; }
        public int Quantity { get; set; }
        public string ChemicalName { get; set; }    
        public int TicketId { get; internal set; }
    }

}
