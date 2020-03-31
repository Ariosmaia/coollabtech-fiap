using CoollabTech.Domain.Tickets;
using CoollabTech.Domain.Tickets.Repository;
using CoollabTech.Infra.Data.Context;

namespace CoollabTech.Infra.Data.Repository
{
    public class TicketStatusRepository : Repository<TicketStatus>, ITicketStatusRepository
    {
        public TicketStatusRepository(CoollabTechContext context) : base(context)
        {
        }
    }
}