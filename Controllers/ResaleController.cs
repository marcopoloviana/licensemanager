using Microsoft.AspNetCore.Mvc;
using LicenceManager.Models;
using licensemanager.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace licensemanager.Controllers
{
    [Authorize]
    public class ResaleController : Controller
    {        
        private readonly BaseRepository<Resale> _resale; 

        public ResaleController()
        {
            _resale = new ResaleRepository();             
        }

        [Route("api/resales/{id}")]
        [HttpGet]
        public Resale Get(int id)
        {
            return _resale.Find(id);            
        }
        
        [Route("api/resales")]
        [HttpPost]
        public Resale Post([FromBody]Resale resale)
        {
            _resale.Save(resale);
            _resale.SaveChanges();
            return resale;
        }

        [Route("api/resales")]
        [HttpPut]
        public Resale Put([FromBody]Resale resale)
        {
            _resale.Update(resale);
            _resale.SaveChanges();
            return resale;
        }

        [Route("api/resales")]
        [HttpDelete]
        public Resale Delete([FromBody]Resale resale)
        {
            _resale.Delete(resale);
            _resale.SaveChanges();
            return resale;
        }
    }
}