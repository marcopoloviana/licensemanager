using Microsoft.EntityFrameworkCore;
using LicenceManager.Models;

namespace licensemanager.DataContext
{
    public class LicenseManagerDataContext : DbContext 
    {
        public LicenseManagerDataContext(DbContextOptions<LicenseManagerDataContext> options) : base(options)
         {             
             
         }

         public LicenseManagerDataContext()
         {
             DbInitializer.Initializer(this);
         }
         
        public DbSet<Resale> Resale {get; set;}
        public DbSet<Version> Version {get; set;}
        public DbSet<Product> Product {get; set;}
        public DbSet<Module> Module {get; set;}
        public DbSet<Customer> Customer {get; set;}
        public DbSet<CustomerModule> CustomerModule {get; set;}
        public DbSet<CustomerStation> CustomerStation {get; set;}
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Startup.connectionString);
        }
        

    }
    
}