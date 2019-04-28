using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LicenceManager.Models;
using licensemanager.ViewModels.CustomerViewModels;
using licensemanager.ViewModels;
using licensemanager.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace licensemanager.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customer;

        public CustomerController(CustomerRepository customer)
        {
            _customer = customer;
            
        }

        [Route("api/customers/{resaleId}")]
        [HttpGet]
        public ICollection<ListCustomerViewModel> GetCustomers(int resaleId)
        {
            return _customer.GetCustomers(resaleId);
        }

        [Route("api/customers/{id}")]
        [HttpGet]
        public Customer Get(int id)
        {            
            return _customer.Find(id);
        }

        [Route("api/customers")]
        [HttpPost]
        public ResultViewModel Post([FromBody]EditorCustomerViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível incluir o cliente!",
                    Data = model.Notifications
                };

            var customer = new Customer();
            customer.ResaleID = model.ResaleID;
            customer.ProducID = model.ProducID;
            customer.Name = model.Name;
            customer.SocialName = model.SocialName;
            customer.Cnpj = model.Cnpj;
            customer.Ie = model.Ie;
            customer.StartDate = model.StartDate;
            customer.EndDate = model.EndDate;
            customer.Status = model.Status;
            
            _customer.Save(customer);
            _customer.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Cliente inserido com sucesso!",
                Data = customer
            };
            
        }

        [Route("api/customers")]
        [HttpPut]
        public ResultViewModel Put([FromBody]EditorCustomerViewModel model)
        {
            model.Validate();
            if (model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o cliente!",
                    Data = model.Notifications
                };

            var customer = _customer.Find(model.ID);
            customer.Name = model.Name;
            customer.SocialName = model.SocialName;
            customer.Ie = model.Ie;
            customer.EndDate = model.EndDate;
            customer.Status = model.Status;
            
            _customer.Update(customer);
            _customer.SaveChanges();

            return new ResultViewModel
            {
                Success = true,
                Message = "Cliente alterado com sucesso!",
                Data = customer
            };            
        }

        [Route("api/customers")]
        [HttpDelete]
        public Customer Delete([FromBody]Customer customer)
        {
            _customer.Delete(customer);
            _customer.SaveChanges();

            return customer;
        }

/* Customer Modules */ 

        [Route("api/customers/{id}/modules")]
        [HttpGet]
        public ICollection<CustomerModule> GetModules(int id)
        {            
            return _customer.GetModules(id);
        }
       

        [Route("api/customermodules/{id}")]
        [HttpGet]
        public CustomerModule GetModule(int idModule)
        {            
            return _customer.GetModule(idModule);
        }

        [Route("api/customermodules")]
        [HttpPost]
        public CustomerModule Post([FromBody]CustomerModule customerModule)
        {
            _customer.SaveModule(customerModule);
            _customer.SaveChanges();

            return customerModule;
        }

        [Route("api/customermodules")]
        [HttpPut]
        public CustomerModule Put([FromBody]CustomerModule customerModule)
        {
            _customer.UpdateModule(customerModule);
            _customer.SaveChanges();

            return customerModule;
        }

        [Route("api/customermodules")]
        [HttpDelete]
        public CustomerModule Delete([FromBody]CustomerModule customerModule)
        {
            _customer.RemoveModule(customerModule);
            _customer.SaveChanges();

            return customerModule;
        }

/* Customer Stations */

        [Route("api/customers/{id}/stations")]
        [HttpGet]
        public ICollection<CustomerStation> GetStations(int id)
        {            
            return _customer.GetStations(id);
        }

        [Route("api/customerstations/{id}")]
        [HttpGet]
        public CustomerStation GetStation(int idStation)
        {            
            return _customer.GetStation(idStation);
        }

        [Route("api/customerstations")]
        [HttpPost]
        public CustomerStation Post([FromBody]CustomerStation customerStation)
        {
            _customer.SaveStation(customerStation);
            _customer.SaveChanges();

            return customerStation;
        }

        [Route("api/customerstations")]
        [HttpPut]
        public CustomerStation Put([FromBody]CustomerStation customerStation)
        {
            _customer.UpdateStation(customerStation);
            _customer.SaveChanges();

            return customerStation;
        }

        [Route("api/customerstations")]
        [HttpDelete]
        public CustomerStation Delete([FromBody]CustomerStation customerStation)
        {
            _customer.RemoveStation(customerStation);
            _customer.SaveChanges();

            return customerStation;
        }

    }
}