using CoollabTech.Domain.Core.Events;
using MediatR;
using System;

namespace CoollabTech.Domain.Core.Commands
{
    public class Command : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }

    }
}
