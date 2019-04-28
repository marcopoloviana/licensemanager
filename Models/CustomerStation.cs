using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenceManager.Models
{
    public class CustomerStation
    {
        public int ID { get; set; }
        
        [Required]
        public int CustomerID { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string StationSerial { get; set; }
        
        [Required]
        [MaxLength(255)]
        public string StationName { get; set; }

        public Customer Customer { get; set; }
    }
}