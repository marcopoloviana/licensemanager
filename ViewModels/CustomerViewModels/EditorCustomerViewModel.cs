using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace licensemanager.ViewModels.CustomerViewModels
{
    public class EditorCustomerViewModel : Notifiable, IValidatable
    {
        public int ID { get; set; }        

        public string SocialName { get; set; }

        public string Name { get; set; }
        
        public string Cnpj { get; set; }
        
        public string Ie { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ProductSerial { get; set; }        
        
        public string CustomerStatus { get; set; }

        public int ResaleID { get; set; }

        public int ProducID { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMaxLen(SocialName, 100, "SocialName", "Razão Social máx. 100 caracteres")
                    .HasMinLen(SocialName, 1, "SocialName", "Razão Social mín. 1 caracter")
                    .HasMaxLen(Name, 50, "Name", "Nome Fantasia máx. 100 caracteres")
                    .HasMinLen(Name, 1, "Name", "Nome Fantasia mín. 1 caracter")
                    .HasExactLengthIfNotNullOrEmpty(Cnpj,14,"Cnpj","CNPJ não pode ser vazio")
                    .IsDigit(Cnpj,"Cnpj","CNPJ apenas dígitos numéricos")                    
            );
        }
    }
}