using CoollabTech.Domain.Tickets;
using CoollabTech.Domain.Tickets.Repository;
using CoollabTech.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoollabTech.Infra.Data.Repository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(CoollabTechContext context) : base(context)
        {
        }

        public IEnumerable<Ticket> GetAll()
        {
            return DbSet.AsNoTracking()
                .Include("TicketStatus")
                .Include("TicketType");
        }
    }
}