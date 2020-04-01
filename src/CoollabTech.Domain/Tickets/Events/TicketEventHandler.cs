using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoollabTech.Domain.Tickets.Events
{
    public class TicketEventHandler : INotificationHandler<TicketRegisteredEvent>, INotificationHandler<TicketUpdatedEvent>
    {
        public Task Handle(TicketRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Enviar email
            return Task.CompletedTask;
        }

        public Task Handle(TicketUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Enviar email
            return Task.CompletedTask;
        }
    }
}
