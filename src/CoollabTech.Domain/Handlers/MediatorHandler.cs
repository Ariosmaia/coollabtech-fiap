﻿using CoollabTech.Domain.Core.Commands;
using CoollabTech.Domain.Core.Events;
using CoollabTech.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoollabTech.Domain.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        //private readonly IEventStore _eventStore;

        public MediatorHandler(IMediator mediator /*, IEventStore eventStore*/)
        {
            _mediator = mediator;
           // _eventStore = eventStore;
        }

        public async Task SendCommand<T>(T mediatorCommand) where T : Command
        {
            await _mediator.Send(mediatorCommand);
        }

        public Task PublishEvent<T>(T @event) where T : Event
        {
            //if (!@event.MessageType.Equals("DomainNotification"))
                //_eventStore?.SalvarEvento(mediatorEvent);

            return _mediator.Publish(@event);
        }
    }
}
