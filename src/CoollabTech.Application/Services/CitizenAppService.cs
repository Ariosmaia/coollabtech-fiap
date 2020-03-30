using AutoMapper;
using CoollabTech.Application.Interfaces;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Citizen.Commands;
using CoollabTech.Domain.Citizen.Repository;
using CoollabTech.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Application.Services
{
    public class CitizenAppService : ICitizenAppService
    {
        private readonly IMapper _mapper;
        private readonly ICitizenRepository _citizenRepository;
        private readonly IMediatorHandler _bus;

        public CitizenAppService(IMapper mapper, ICitizenRepository citizenRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _citizenRepository = citizenRepository;
            _bus = bus;
        }

        public CitizenViewModel GetById(Guid id)
        {
            return _mapper.Map<CitizenViewModel>(_citizenRepository.GetById(id));
        }

        public IEnumerable<CitizenViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<CitizenViewModel>>(_citizenRepository.GetAll());
        }

        public void Add(CitizenViewModel citizenViewModel)
        {
            var registerCitizenCommand = _mapper.Map<RegisterCitizenCommand>(citizenViewModel);
            _bus.SendCommand(registerCitizenCommand);
        }

        public void Update(CitizenViewModel citizenViewModel)
        {
            var updateCitizenCommand = _mapper.Map<UpdateCitizenCommand>(citizenViewModel);
            _bus.SendCommand(updateCitizenCommand);
        }

    }
}
