using CoollabTech.Domain.Tickets;
using CoollabTech.Domain.Tickets.Repository;
using CoollabTech.Infra.Data.Context;

namespace CoollabTech.Infra.Data.Repository
{
    public class ServiceProviderRepository : Repository<ServiceProvider>, IServiceProviderRepository
    {
        public ServiceProviderRepository(CoollabTechContext context) : base(context)
        {
        }
    }
}