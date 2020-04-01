using CoollabTech.Domain.Core.Commands;
using System;

namespace CoollabTech.Domain.Tickets.Commands
{
    public abstract class BaseTicketCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Description { get; protected set; }
        public string Localization { get; protected set; }
        public Guid TicketStatusId { get; protected set; }
        public Guid TicketTypeId { get; protected set; }
        public DateTime DateRegister { get; protected set; }
    }
}
