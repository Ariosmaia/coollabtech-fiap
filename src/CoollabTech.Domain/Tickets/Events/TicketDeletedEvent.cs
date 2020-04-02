using System;

namespace CoollabTech.Domain.Tickets.Events
{
    public class TicketDeletedEvent : BaseTicketEvent
    {
        public TicketDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}