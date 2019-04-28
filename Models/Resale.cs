using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenceManager.Models
{
    public class Resale
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string SocialName { get; set; }

        [Required]
        [MaxLength(20)]
        public string CpfCnpj { get; set; }

        [Required]
        [MaxLength(50)]
        public string Manager { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(20)]
        public string CelPhone { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        
        [Required]
        [DefaultValue("true")]
        public bool Status { get; set; }        
        public virtual ICollection<Customer> Customers { get; set; }

    }
}