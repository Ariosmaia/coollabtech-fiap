using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoollabTech.Domain.Citizen.Events
{
    public class CitizenEventHandler : INotificationHandler<CitizenRegisteredEvent>, INotificationHandler<CitizenUpdatedEvent>
    {
        public Task Handle(CitizenRegisteredEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Enviar email
            return Task.CompletedTask;
        }

        public Task Handle(CitizenUpdatedEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Enviar email
            return Task.CompletedTask;
        }
    }
}
