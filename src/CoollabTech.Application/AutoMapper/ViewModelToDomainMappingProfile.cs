using AutoMapper;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Citizen.Commands;
using CoollabTech.Domain.Tickets.Commands;
using System;

namespace CoollabTech.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Citizen
            CreateMap<CitizenViewModel, RegisterCitizenCommand>()
                .ConvertUsing(c => new RegisterCitizenCommand(c.Id, c.Name, c.NickName, c.Document, c.Email, c.Gender, DateTime.Now, c.Excluded, c.Active));

            CreateMap<CitizenViewModel, UpdateCitizenCommand>()
                .ConvertUsing(c => new UpdateCitizenCommand(c.Id, c.Name, c.NickName, c.Document, c.Email, c.Gender, c.Excluded, c.Active));

            CreateMap<CitizenViewModel, DeleteCitizenCommand>()
                .ConvertUsing(c => new DeleteCitizenCommand(c.Id));
            #endregion

            #region Ticket
            CreateMap<TicketViewModel, RegisterTicketCommand>()
                .ConvertUsing(c => new RegisterTicketCommand(Guid.NewGuid(), c.Description, c.Localization, c.TicketStatusId, c.TicketTypeId, DateTime.Now));

            CreateMap<TicketViewModel, UpdateTicketCommand>()
                .ConvertUsing(c => new UpdateTicketCommand(c.Id, c.Description, c.Localization, c.TicketStatusId, c.TicketTypeId));

            CreateMap<Guid, DeleteTicketCommand>()
                .ConvertUsing(c => new DeleteTicketCommand(c));
            #endregion
        }

    }
}
