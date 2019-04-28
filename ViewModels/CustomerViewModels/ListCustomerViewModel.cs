
using System;

namespace licensemanager.ViewModels.CustomerViewModels
{
    public class ListCustomerViewModel
    {
        public int ID { get; set; }

        public string SocialName { get; set; }

        public string Name { get; set; }
        
        public string Cnpj { get; set; }        

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public string CustomerStatus { get; set; }

    }
}
