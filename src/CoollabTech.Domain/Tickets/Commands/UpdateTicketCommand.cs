using System;

namespace CoollabTech.Domain.Tickets.Commands
{
    public class UpdateTicketCommand : BaseTicketCommand
    {
        public UpdateTicketCommand(Guid id, string description, string localization, Guid ticketStatusId, Guid ticketTypeId)
        {
            Id = id;
            Description = description;
            Localization = localization;
            TicketStatusId = ticketStatusId;
            TicketTypeId = ticketTypeId;
        }
    }
}
