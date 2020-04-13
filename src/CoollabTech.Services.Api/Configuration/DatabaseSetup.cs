using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using CoollabTech.Infra.CrossCutting.Identity.Models;
using CoollabTech.Infra.Data.Context;

namespace CoollabTech.Services.Api.Configuration
{
    public static class DatabseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<CoollabTechContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        }

    }
}
