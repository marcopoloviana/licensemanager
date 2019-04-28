using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenceManager.Models
{
    public class CustomerModule
    {
        public int ID { get; set; }
        
        [Required]
        public int CustomerID { get; set; }
        
        [Required]
        public int ProductID { get; set; }
        
        [Required]
        public int ModuleID { get; set; }
        
        [Required]
        [MaxLength(255)]
        [DefaultValue("$1$h7OMHbRH$epeShEMiqXSAFOXHUQz4c.")]
        public string Status { get; set; }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public Module Module { get; set; }
    }
}