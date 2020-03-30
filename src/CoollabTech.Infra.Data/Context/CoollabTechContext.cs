using CoollabTech.Domain.Citizen;
using CoollabTech.Infra.Data.Extensions;
using CoollabTech.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoollabTech.Infra.Data.Context
{
    public class CoollabTechContext : DbContext
    {
        public CoollabTechContext(DbContextOptions<CoollabTechContext> options ) : base(options) { }
        public DbSet<Citizen> Citizen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CitizenMapping());

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

        //}
    }
}
