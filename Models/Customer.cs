using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenceManager.Models
{
    public class Customer
    {

        public int ID { get; set; }
        
        [Required]
        public int ResaleID { get; set; }

        [Required]
        public int ProducID { get; set; }

        [Required]
        [MaxLength(255)]
        public string SocialName { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Cnpj { get; set; }
        
        [MaxLength(20)]
        public string Ie { get; set; }

        [Required]
        [DefaultValue("true")]
        public string Status { get; set; }

        [Required]
        [Timestamp]
        public DateTime StartDate { get; set; }

        [Required]
        [Timestamp]
        public DateTime EndDate { get; set; }

        public string Message { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductSerial { get; set; }
        
        public int PaidAnnuity { get; set; }
        
        [Required]
        [DefaultValue("Ativo")]
        public string CustomerStatus { get; set; }

        public Resale Resale { get; set; }
        public Product Product { get; set; }
        public virtual ICollection<CustomerStation> Stations { get; set; }
        public virtual ICollection<Module> Modules { get; set; }
    }
}