using AutoMapper;
using CoollabTech.Application.Interfaces;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Interfaces;
using CoollabTech.Domain.Tickets.Repository;
using System;
using System.Collections.Generic;

namespace CoollabTech.Application.Services
{
    public class ServiceProviderAppService : IServiceProviderAppService
    {
        private readonly IMapper _mapper;
        private readonly IServiceProviderRepository _serviceProviderRepository;
        private readonly IMediatorHandler _bus;

        public ServiceProviderAppService(IMapper mapper, IServiceProviderRepository serviceProviderRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _serviceProviderRepository = serviceProviderRepository;
            _bus = bus;
        }

        public ServiceProviderViewModel GetById(Guid id)
        {
            return _mapper.Map<ServiceProviderViewModel>(_serviceProviderRepository.GetById(id));
        }

        public IEnumerable<ServiceProviderViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<ServiceProviderViewModel>>(_serviceProviderRepository.GetAll());
        }
    }
}