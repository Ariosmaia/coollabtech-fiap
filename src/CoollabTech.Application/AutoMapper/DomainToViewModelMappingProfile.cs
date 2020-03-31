using AutoMapper;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Citizen;
using CoollabTech.Domain.Tickets;

namespace CoollabTech.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Citizen, CitizenViewModel>();
            CreateMap<Ticket, TicketViewModel>();
            CreateMap<TicketType, TicketTypeViewModel>();
            CreateMap<TicketStatus, TicketStatusViewModel>();
            CreateMap<ServiceProvider, ServiceProviderViewModel>();
        }
    }
}
