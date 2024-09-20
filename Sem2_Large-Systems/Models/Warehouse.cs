namespace Sem2_Large_Systems.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public float Capacity { get; set; }
        public float CurrentLoad { get; set; }
        public ICollection<Chemical> Chemicals { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }

}
