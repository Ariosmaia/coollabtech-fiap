using CoollabTech.Domain.Citizen;
using CoollabTech.Domain.Tickets;
using CoollabTech.Infra.Data.Extensions;
using CoollabTech.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CoollabTech.Infra.Data.Context
{
    public class CoollabTechContext : DbContext
    {
        public CoollabTechContext(DbContextOptions<CoollabTechContext> options ) : base(options) { }
        public DbSet<Citizen> Citizen { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketType> TicketType { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<ServiceProvider> ServiceProvider { get; set; }

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
