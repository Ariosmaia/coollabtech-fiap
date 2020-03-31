using AutoMapper;
using CoollabTech.Application.Interfaces;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Interfaces;
using CoollabTech.Domain.Tickets.Repository;
using System;
using System.Collections.Generic;

namespace CoollabTech.Application.Services
{
    public class TicketStatusAppService : ITicketStatusAppService
    {
        private readonly IMapper _mapper;
        private readonly ITicketStatusRepository _ticketStatusRepository;
        private readonly IMediatorHandler _bus;

        public TicketStatusAppService(IMapper mapper, ITicketStatusRepository ticketStatusRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _ticketStatusRepository = ticketStatusRepository;
            _bus = bus;
        }

        public TicketStatusViewModel GetById(Guid id)
        {
            return _mapper.Map<TicketStatusViewModel>(_ticketStatusRepository.GetById(id));
        }

        public IEnumerable<TicketStatusViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<TicketStatusViewModel>>(_ticketStatusRepository.GetAll());
        }
    }
}