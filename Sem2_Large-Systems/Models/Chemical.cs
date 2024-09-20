namespace Sem2_Large_Systems.Models
{
    public class Chemical
    {
        public int Id { get; set; }
        public string ChemicalName { get; set; }
        public float Quantity { get; set; }
        public int WarehouseId { get; set; }
        public ChemicalClass Class { get; set; }  
        public Warehouse Warehouse { get; set; }
        public ICollection<TicketChemical> TicketChemicals { get; set; }
    }

}
