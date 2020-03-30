using AutoMapper;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Citizen.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CitizenViewModel, RegisterCitizenCommand>()
                .ConvertUsing(c => new RegisterCitizenCommand(c.Id, c.Name, c.NickName, c.Document, c.Email, c.Gender, DateTime.Now));

            CreateMap<CitizenViewModel, UpdateCitizenCommand>()
                .ConvertUsing(c => new UpdateCitizenCommand(c.Id, c.Name, c.NickName, c.Document, c.Email, c.Gender));
        }
    }
}
