using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenceManager.Models
{
    public class Module
    {

        public int ID { get; set; }

        [Required]
        public int ProductID { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [MaxLength(255)]
        public string CryptDescription { get; set; }

        public Product Product { get; set; }
    }
}