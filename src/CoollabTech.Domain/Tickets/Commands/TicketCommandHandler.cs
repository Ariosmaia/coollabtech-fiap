using CoollabTech.Domain.Core.Notifications;
using CoollabTech.Domain.Handlers;
using CoollabTech.Domain.Interfaces;
using CoollabTech.Domain.Tickets.Events;
using CoollabTech.Domain.Tickets.Repository;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CoollabTech.Domain.Tickets.Commands
{
    public class TicketCommandHandler : CommandHandler, 
        IRequestHandler<RegisterTicketCommand, bool>,
        IRequestHandler<UpdateTicketCommand, bool>
    {
        private readonly IMediatorHandler _mediator;
        private readonly ITicketRepository _ticketRepository;

        public TicketCommandHandler(
            ITicketRepository ticketRepository,
            IUnitOfWork uow, 
            IMediatorHandler mediator, 
            INotificationHandler<DomainNotification> notifications) : base(uow, mediator, notifications)
        {
            _ticketRepository = ticketRepository;
            _mediator = mediator;
        }

        public Task<bool> Handle(RegisterTicketCommand message, CancellationToken cancellationToken)
        {
            var ticket = new Ticket(message.Id, message.Description, message.Localization, message.TicketStatusId, message.TicketTypeId, message.DateRegister);

            if(!TicketIsValid(ticket)) return Task.FromResult(false);

            var ticketRegistred = _ticketRepository.Find(c => c.Id == ticket.Id);

            if(ticketRegistred.Any())
            {
                _mediator.PublishEvent(new DomainNotification(message.MessageType, "Já existe um ticket com esse Id"));
            }

            _ticketRepository.Add(ticket);

            if (Commit())
            {
                _mediator.PublishEvent(new TicketRegisteredEvent(ticket.Id, ticket.Description, ticket.Localization, ticket.TicketStatusId, ticket.TicketTypeId, ticket.DateRegister));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateTicketCommand message, CancellationToken cancellationToken)
        {
            var ticketActual = _ticketRepository.GetById(message.Id);

            if (!TicketExistent(message.Id, message.MessageType)) return Task.FromResult(false);

            var ticket = new Ticket(message.Id, message.Description, message.Localization, message.TicketStatusId, message.TicketTypeId, ticketActual.DateRegister);

            if (!TicketIsValid(ticket)) return Task.FromResult(false);

            _ticketRepository.Update(ticket);

            if (Commit())
            {
                _mediator.PublishEvent(new TicketUpdatedEvent(ticket.Id, ticket.Description, ticket.Localization, ticket.TicketStatusId, ticket.TicketTypeId, ticket.DateRegister));
            }

            return Task.FromResult(true);
        }

        private bool TicketExistent(Guid id, string messageType)
        {
            var ticket = _ticketRepository.GetById(id);

            if (ticket != null) return true;

            _mediator.PublishEvent(new DomainNotification(messageType, "Ticket não encontrado."));
            return false;
        }

        private bool TicketIsValid(Ticket ticket)
        {
            if (ticket.IsValid()) return true;

            NotifyValidationsError(ticket.ValidationResult); 
            return false;
        }
    }
}
