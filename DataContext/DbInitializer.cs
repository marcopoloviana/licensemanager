
using System.Linq;
using LicenceManager.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace licensemanager.DataContext
{
    public class DbInitializer
    {
        public static void Initializer(LicenseManagerDataContext context)
        {            

            context.Database.EnsureCreated();

            if  (context.Resale.Count(x=>x.ID>0) > 0)
                return;
            
            var resale = new Resale();
            resale.SocialName = "Administrador";
            resale.Name = "Administrador";
            resale.CpfCnpj = "99999999999";
            resale.Manager = "Administrador do sistema";
            resale.CelPhone = "88888888888";
            resale.Email = "admin@admin.com";
            resale.Password = "123456";
            resale.Status = true;

            context.Resale.Add(resale);
            context.SaveChanges();            
        }
    }
}