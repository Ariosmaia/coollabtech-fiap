using CoollabTech.Infra.CrossCutting.Identity.Models;
using CoollabTech.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoollabTech.UI.Web.Extensions
{
    public static class DatabseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<CoollabTechContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }

    }
}
