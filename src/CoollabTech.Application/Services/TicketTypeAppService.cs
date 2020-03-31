using AutoMapper;
using CoollabTech.Application.Interfaces;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Interfaces;
using CoollabTech.Domain.Tickets.Repository;
using System;
using System.Collections.Generic;

namespace CoollabTech.Application.Services
{
    public class TicketTypeAppService : ITicketTypeAppService
    {
        private readonly IMapper _mapper;
        private readonly ITicketTypeRepository _ticketTypeRepository;
        private readonly IMediatorHandler _bus;

        public TicketTypeAppService(IMapper mapper, ITicketTypeRepository ticketTypeRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _ticketTypeRepository = ticketTypeRepository;
            _bus = bus;
        }

        public TicketTypeViewModel GetById(Guid id)
        {
            return _mapper.Map<TicketTypeViewModel>(_ticketTypeRepository.GetById(id));
        }

        public IEnumerable<TicketTypeViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<TicketTypeViewModel>>(_ticketTypeRepository.GetAll());
        }
    }
}