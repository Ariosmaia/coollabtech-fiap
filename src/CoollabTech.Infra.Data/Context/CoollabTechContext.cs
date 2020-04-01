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
        public CoollabTechContext(DbContextOptions<CoollabTechContext> options) : base(options) { }

        public DbSet<Citizen> Citizen { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TicketType> TicketType { get; set; }
        public DbSet<TicketStatus> TicketStatus { get; set; }
        public DbSet<ServiceProvider> ServiceProvider { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new CitizenMapping());
            modelBuilder.AddConfiguration(new TicketMapping());
            modelBuilder.AddConfiguration(new TicketTypeMapping());
            modelBuilder.AddConfiguration(new TicketStatusMapping());
            modelBuilder.AddConfiguration(new ServiceProviderMapping());

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.AddConfiguration(new Citizen());
        //    modelBuilder.AddConfiguration(new Ticket());
        //    modelBuilder.AddConfiguration(new TicketType());
        //    modelBuilder.AddConfiguration(new TicketStatus());
        //    modelBuilder.AddConfiguration(new ServiceProvider());

        //    base.OnModelCreating(modelBuilder);
        //}

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
