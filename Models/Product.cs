using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenceManager.Models
{
    public class Product
    {

        public int ID { get; set; }

        [Required]        
        public int IdApplication { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }
        
        [Required]
        [DefaultValue("true")]
        public bool Status { get; set; }

        public virtual ICollection<Version> Versions { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}