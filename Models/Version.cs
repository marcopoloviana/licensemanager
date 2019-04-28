using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LicenceManager.Models
{
    public class Version
    {
        public int ID { get; set; }
        
        [Required]    
        public int ProductID { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string VersionValue { get; set; }

        [Required]
        [Timestamp]
        public DateTime VersionDate { get; set; }
 
        [Required]
        [MaxLength(50)]
        public string VersionScript { get; set; }

        public string Script {get; set;}

        public Product Product { get; set; }
    }
}