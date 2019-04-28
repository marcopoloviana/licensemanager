using System.Collections.Generic;
using System.Linq;
using LicenceManager.Models;
using licensemanager.DataContext;
using licensemanager.ViewModels.CustomerViewModels;
using Microsoft.EntityFrameworkCore;

namespace licensemanager.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {

        public ICollection<ListCustomerViewModel> GetCustomers(int id)
        {
            return context.Customer
                .Where(x => x.Resale.ID == id)
                .Include(x => x.Resale)
                .Select(x => new ListCustomerViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    SocialName = x.SocialName,
                    Cnpj = x.Cnpj,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = x.Status
                })
                .AsNoTracking()
                .ToList();
        }        

        public ICollection<CustomerStation> GetStations(int idCustomer)
        {            
            return context.CustomerStation.AsNoTracking().Where(x => x.Customer.ID == idCustomer).ToList();
        }

        public ICollection<CustomerModule> GetModules(int idCustomer)
        {            
            return context.CustomerModule.AsNoTracking().Where(x => x.Customer.ID == idCustomer).ToList();
        }

        public CustomerStation GetStation(int idStation)
        {            
            return context.CustomerStation.AsNoTracking().Where(x=>x.ID == idStation).FirstOrDefault();
        }

        public void SaveStation(CustomerStation customerStation)
        {
            context.CustomerStation.Add(customerStation);
        }

        public void UpdateStation(CustomerStation customerStation)
        {
            context.CustomerStation.Update(customerStation);
        }

        public void RemoveStation(CustomerStation customerStation)
        {
            context.CustomerStation.Remove(customerStation);
        }

        public CustomerModule GetModule(int idModule)
        {            
            return context.CustomerModule.AsNoTracking().Where(x=>x.ID == idModule).FirstOrDefault();
        }

        public void SaveModule(CustomerModule customerModule)
        {
            context.CustomerModule.Add(customerModule);
        }

        public void UpdateModule(CustomerModule customerModule)
        {
            context.CustomerModule.Update(customerModule);
        }

        public void RemoveModule(CustomerModule customerModule)
        {
            context.CustomerModule.Remove(customerModule);
        }

        
    }
}