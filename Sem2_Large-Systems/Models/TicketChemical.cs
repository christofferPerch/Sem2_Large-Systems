namespace Sem2_Large_Systems.Models
{
    public class TicketChemical
    {
        public int TicketId { get; set; }
        public int ChemicalId { get; set; }
        public int Quantity { get; set; }  
        public Ticket Ticket { get; set; }
        public Chemical Chemical { get; set; }
        public string ChemicalName { get; set; }

    }

}
