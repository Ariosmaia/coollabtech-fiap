using System;

namespace CoollabTech.Domain.Tickets.Commands
{
    public class DeleteTicketCommand : BaseTicketCommand
    {
        public DeleteTicketCommand(Guid id)
        {
            Id = id;
        }
    }
}
