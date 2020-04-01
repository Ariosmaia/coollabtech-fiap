using System;

namespace CoollabTech.Domain.Tickets.Events
{
    public class TicketUpdatedEvent : BaseTicketEvent
    {
        public TicketUpdatedEvent(Guid id, string description, string localization, Guid ticketStatusId, Guid ticketTypeId, DateTime dateRegister)
        {
            Id = id;
            Description = description;
            Localization = localization;
            TicketStatusId = ticketStatusId;
            TicketTypeId = ticketTypeId;
            DateRegister = dateRegister;
        }
    }
}