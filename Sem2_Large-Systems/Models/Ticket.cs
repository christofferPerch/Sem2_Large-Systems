using System.ComponentModel.DataAnnotations;

namespace Sem2_Large_Systems.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }

        [Required]
        public string DriverName { get; set; }

        [Required]
        public string ChemicalType { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public double Quantity { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }

        public string Status { get; set; } = "Pending";
    }

}
