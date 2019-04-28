
using System.Linq;
using LicenceManager.Models;
using Microsoft.EntityFrameworkCore;

namespace licensemanager.Repositories
{
    public class ResaleRepository : BaseRepository<Resale>
    {

        public Resale Autenticate(string email, string password)
        {
            var q = (from resale in context.Resale
                where resale.Email.Equals(email)&&
                resale.Password.Equals(password)
                select resale                
            ).Take(1);

            return q.FirstOrDefault();
        }        
    }
    
}