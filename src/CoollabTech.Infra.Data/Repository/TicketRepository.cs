using CoollabTech.Domain.Citizen;
using CoollabTech.Domain.Citizen.Repository;
using CoollabTech.Domain.Tickets;
using CoollabTech.Domain.Tickets.Repository;
using CoollabTech.Infra.Data.Context;
using System.Collections.Generic;

namespace CoollabTech.Infra.Data.Repository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(CoollabTechContext context) : base(context)
        {
        }
    }
}