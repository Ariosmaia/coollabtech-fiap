using AutoMapper;
using CoollabTech.Application.Interfaces;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Interfaces;
using CoollabTech.Domain.Tickets;
using CoollabTech.Domain.Tickets.Commands;
using CoollabTech.Domain.Tickets.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoollabTech.Application.Services
{
    public class TicketAppService : ITicketAppService
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;
        private readonly IMediatorHandler _bus;

        public TicketAppService(IMapper mapper, ITicketRepository ticketRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
            _bus = bus;
        }

        public TicketViewModel GetById(Guid id)
        {
            return _mapper.Map<TicketViewModel>(_ticketRepository.GetById(id));
        }

        public IEnumerable<TicketViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<TicketViewModel>>(_ticketRepository.GetAll());
        }

        public IEnumerable<TicketViewModel> Find(Expression<Func<Ticket, bool>> predicate)
        {
            return _mapper.Map<IEnumerable<TicketViewModel>>(_ticketRepository.Find(predicate));
        }

        public void Add(TicketViewModel ticketViewModel)
        {
            var registerTicketCommand = _mapper.Map<RegisterTicketCommand>(ticketViewModel);
            _bus.SendCommand(registerTicketCommand);
        }

        public void Update(TicketViewModel ticketViewModel)
        {
            var updateTicketCommand = _mapper.Map<UpdateTicketCommand>(ticketViewModel);
            _bus.SendCommand(updateTicketCommand);
        }

        public void Remove(Guid id)
        {
            var deleteTicketCommand = _mapper.Map<DeleteTicketCommand>(id);
            _bus.SendCommand(deleteTicketCommand);
        }
    }
}