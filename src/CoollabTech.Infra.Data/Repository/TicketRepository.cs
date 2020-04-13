using CoollabTech.Domain.Tickets;
using CoollabTech.Domain.Tickets.Repository;
using CoollabTech.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CoollabTech.Infra.Data.Repository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(CoollabTechContext context) : base(context)
        {
        }

        public override IEnumerable<Ticket> Find(Expression<Func<Ticket, bool>> predicate)
        {
            return DbSet
                .AsNoTracking()
                .Include(tst => tst.TicketStatus)
                .Include(tty => tty.TicketType)
                .Include(spr => spr.TicketType.ServiceProvider)
                .Where(predicate);
        }

        public override IEnumerable<Ticket> GetAll()
        {
            return DbSet
                .AsNoTracking()
                .Include(tst => tst.TicketStatus)
                .Include(tty => tty.TicketType)
                .Include(spr => spr.TicketType.ServiceProvider);
        }

        public override Ticket GetById(Guid id)
        {
            return DbSet
                .AsNoTracking()
                .Include(tst => tst.TicketStatus)
                .Include(tty => tty.TicketType)
                .Include(spr => spr.TicketType.ServiceProvider)
                .FirstOrDefault(t => t.Id == id);
        }
    }
}