using System;

namespace CoollabTech.Domain.Tickets.Commands
{
    public class RegisterTicketCommand : BaseTicketCommand
    {
        public RegisterTicketCommand(Guid id, string description, string localization, Guid ticketStatusId, Guid ticketTypeId, DateTime dateRegister)
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
