using CoollabTech.Domain.Citizen.Events;
using CoollabTech.Domain.Citizen.Repository;
using CoollabTech.Domain.Core.Notifications;
using CoollabTech.Domain.Handlers;
using CoollabTech.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoollabTech.Domain.Citizen.Commands
{
    public class CitizenCommandHandler : CommandHandler, 
        IRequestHandler<RegisterCitizenCommand, bool>,
        IRequestHandler<UpdateCitizenCommand, bool>
    {
        private readonly IMediatorHandler _mediator;
        private readonly ICitizenRepository _citizenRepository;

        public CitizenCommandHandler(
            ICitizenRepository citizenRepository,
            IUnitOfWork uow, 
            IMediatorHandler mediator, 
            INotificationHandler<DomainNotification> notifications) : base(uow, mediator, notifications)
        {
            _citizenRepository = citizenRepository;
            _mediator = mediator;
        }

        public Task<bool> Handle(RegisterCitizenCommand message, CancellationToken cancellationToken)
        {
            var citizen = new Citizen(message.Id, message.Name, message.NickName, message.Document, message.Email, message.Gender, message.DateRegister);

            if(!CitizenIsValid(citizen)) return Task.FromResult(false);

            var citizenRegistred = _citizenRepository.Find(c => c.Document == citizen.Document || c.Email == citizen.Email);

            if(citizenRegistred.Any())
            {
                _mediator.PublishEvent(new DomainNotification(message.MessageType, "CPF ou e-mail já utilizados"));
            }

            _citizenRepository.Add(citizen);

            if (Commit())
            {
                _mediator.PublishEvent(new CitizenRegisteredEvent(citizen.Id, citizen.Name, citizen.NickName, citizen.Document, citizen.Email, citizen.Gender, citizen.DateRegister));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateCitizenCommand message, CancellationToken cancellationToken)
        {
            var citizenActual = _citizenRepository.GetById(message.Id);

            if (!CitizenExistent(message.Id, message.MessageType)) return Task.FromResult(false);

            var citizen = new Citizen(message.Id, message.Name, message.NickName, message.Document, message.Email, message.Gender, citizenActual.DateRegister);

            if (!CitizenIsValid(citizen)) return Task.FromResult(false);

            _citizenRepository.Update(citizen);

            if (Commit())
            {
                _mediator.PublishEvent(new CitizenUpdatedEvent(citizen.Id, citizen.Name, citizen.NickName, citizen.Document, citizen.Email, citizen.Gender, citizen.DateRegister));
            }

            return Task.FromResult(true);
        }

        private bool CitizenExistent(Guid id, string messageType)
        {
            var citizen = _citizenRepository.GetById(id);

            if (citizen != null) return true;

            _mediator.PublishEvent(new DomainNotification(messageType, "Cidadão não encontrado."));
            return false;
        }

        private bool CitizenIsValid(Citizen citizen)
        {
            if (citizen.IsValid()) return true;

            NotifyValidationsError(citizen.ValidationResult); 
            return false;
        }
    }
}
