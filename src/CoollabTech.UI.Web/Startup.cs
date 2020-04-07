using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CoollabTech.UI.Web.Extensions;
using Microsoft.AspNetCore.Http;
using MediatR;

namespace CoollabTech.UI.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configura��o dos DBContext
            services.AddDatabaseSetup(Configuration);
            
            // Configura��o do ASP.NET Identity
            services.AddIdentitySetup();

            // Configura��es do AutoMapper
            services.AddAutoMapperSetup();

            // COnfigura��es do MVC
            services.AddControllersWithViews();
            services.AddRazorPages();

            // Autentica��o e Autoriza��o
            services.AddAuthSetup(Configuration);

            // Adiciona o mediator para os Eventos de Dominio e Notifica��es
            services.AddMediatR(typeof(Startup));

            // Dependencia do HttpContext do ASP.NET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Abstra��o da Inje��o de Depencia nativa do ASP.NET
            services.AddDependencyInjectionSetup();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {                
                endpoints.MapControllerRoute(                    
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}");                    
                endpoints.MapRazorPages();
            });
        }
    }
}
