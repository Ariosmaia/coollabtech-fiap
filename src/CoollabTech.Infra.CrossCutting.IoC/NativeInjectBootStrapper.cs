using CoollabTech.Application.Interfaces;
using CoollabTech.Application.Services;
using CoollabTech.Domain.Citizen.Commands;
using CoollabTech.Domain.Citizen.Events;
using CoollabTech.Domain.Citizen.Repository;
using CoollabTech.Domain.Core.Notifications;
using CoollabTech.Domain.Handlers;
using CoollabTech.Domain.Interfaces;
using CoollabTech.Domain.Tickets.Repository;
using CoollabTech.Infra.CrossCutting.Identity.Authorization;
using CoollabTech.Infra.Data.Repository;
using CoollabTech.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Infra.CrossCutting.IoC
{
    public class NativeInjectBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // ASP.NET Poticas de Autorização
            services.AddScoped<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<ICitizenAppService, CitizenAppService>();
            services.AddScoped<ITicketAppService, TicketAppService>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterCitizenCommand, bool>, CitizenCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCitizenCommand, bool>, CitizenCommandHandler>();

            // Domain - Eventos
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler> ();
            services.AddScoped<INotificationHandler<CitizenRegisteredEvent>, CitizenEventHandler>();
            services.AddScoped<INotificationHandler<CitizenUpdatedEvent>, CitizenEventHandler>();

            // Infra - Data
            services.AddScoped<ICitizenRepository, CitizenRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketStatusRepository, TicketStatusRepository>();
            services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
            services.AddScoped<IServiceProviderRepository, ServiceProviderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Identity

        }
    }
}
