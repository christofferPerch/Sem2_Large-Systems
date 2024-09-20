namespace Sem2_Large_Systems.Models
{
    public class Warehouse
    {
        public int WarehouseID { get; set; }
        public double Capacity { get; set; } 
        public double CurrentLoad { get; set; } 
        public List<string> ChemicalClassRestrictions { get; set; } 
        public Warehouse()
        {
            ChemicalClassRestrictions = new List<string>();
        }
    }
}
