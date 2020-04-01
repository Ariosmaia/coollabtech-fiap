﻿using AutoMapper;
using CoollabTech.Application.Interfaces;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Interfaces;
using CoollabTech.Domain.Tickets.Commands;
using CoollabTech.Domain.Tickets.Repository;
using System;
using System.Collections.Generic;

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

        public void Add(TicketViewModel ticketViewModel)
        {
            var registerCitizenCommand = _mapper.Map<RegisterTicketCommand>(ticketViewModel);
            _bus.SendCommand(registerCitizenCommand);
        }

        public void Update(TicketViewModel ticketViewModel)
        {
            var updateCitizenCommand = _mapper.Map<UpdateTicketCommand>(ticketViewModel);
            _bus.SendCommand(updateCitizenCommand);
        }

        public void Remove(Guid id)
        {
            //throw new NotImplementedException();
        }
    }
}