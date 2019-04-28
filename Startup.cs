using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;

namespace licensemanager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration {get;}
        public static string connectionString {private set; get;}
        public void ConfigureServices(IServiceCollection services)
        {
            connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddAuthentication(options =>
                {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(
                    options =>  {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = "gerenciadoronline.com.br",
                            ValidAudience = "gerenciadoronline.com.br",
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(Configuration["SecurityKey"]))
                        };

                        options.Events = new JwtBearerEvents
                        {
                            OnAuthenticationFailed = context =>
                            {
                                //Console.WriteLine("Token inválido..:" + context.Exception.Message);
                                return Task.CompletedTask;
                            },
                            OnTokenValidated = context =>
                            {
                                //Console.WriteLine("Token válido..:" + context.SecurityToken);
                                return Task.CompletedTask;
                            }
                        };
                    }
                );


            services.AddMvc();
            services.AddScoped<DataContext.LicenseManagerDataContext, DataContext.LicenseManagerDataContext>();    

            services.AddSwaggerGen(x=>
            {
                x.SwaggerDoc("api", new Info {Title = "License Manager", Version = "1.0"});
            });        
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/api/swagger.json","License Manager API 1.0");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();                
            } 

            app.UseMvc();       
        }
    }
}
