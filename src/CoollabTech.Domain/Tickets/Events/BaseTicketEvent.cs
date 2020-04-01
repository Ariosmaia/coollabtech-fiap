using CoollabTech.Domain.Citizen.Enums;
using CoollabTech.Domain.Core.Events;
using System;

namespace CoollabTech.Domain.Tickets.Events
{
    public class BaseTicketEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Description { get; protected set; }
        public string Localization { get; protected set; }
        public Guid TicketStatusId { get; protected set; }
        public Guid TicketTypeId { get; protected set; }
        public DateTime DateRegister { get; protected set; }
    }
}
