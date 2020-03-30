using AutoMapper;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Citizen;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Citizen, CitizenViewModel>();
        }
    }
}
