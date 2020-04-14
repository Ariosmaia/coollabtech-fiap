using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoollabTech.Application.Interfaces;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Core.Notifications;
using CoollabTech.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoollabTech.Services.Api.Controllers
{
    [Authorize]
    public class TicketController : ApiController
    {
        private readonly ITicketAppService _ticketAppService;

        public TicketController(
            ITicketAppService ticketAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _ticketAppService = ticketAppService;
        }

        [HttpGet]
        [Route("tickets")]
        public IActionResult Get()
        {
            return Response(_ticketAppService.GetAll());
        }

        [HttpGet]
        [Route("tickets/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var ticketViewModel = _ticketAppService.GetById(id);

            return Response(ticketViewModel);
        }

        // POST tickets
        /// <summary>
        /// Registra um novo ticket no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///    POST /Tickets
        ///    {
        ///            "description": "teste",
        ///            "localization": "teste",
        ///            "ticketStatusId": "obter guid no get de tickets",
        ///            "ticketTypeId": "obter guid no get de tickets",
        ///            "dateRegister": "2020-04-14T07:57:41.1070568"
        ///    }
        /// </remarks>
        /// <param name="ticket"></param>
        /// <returns>Um novo ticket criado</returns>
        /// <response code="400">Se o ticket não for registrado</response>   
        /// <response code="500">Erro interno</response>   
        [HttpPost]
        [Route("tickets")]
        public async Task<IActionResult> Create([FromBody]TicketViewModel ticketViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            _ticketAppService.Add(ticketViewModel);

            if (!IsValidOperation())
            {
                NotifyError("Ticket", "Falha ao criar");
                return Response();
            }

            return Response();
        }

        // PUT tickets
        /// <summary>
        /// Altera o ticket no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///    PUT /Tickets
        ///    {
        ///            "id": "obter guid no get de tickets",
        ///            "description": "teste123",
        ///            "localization": "teste123",
        ///            "ticketStatusId": "obter guid no get de tickets",
        ///            "ticketTypeId": "obter guid no get de tickets",
        ///            "dateRegister": "2020-04-14T07:57:41.1070557"
        ///    }
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="ticket"></param>
        /// <returns>Um ticket alterado</returns>
        /// <response code="400">Se o ticket não for alterado</response>   
        /// <response code="500">Erro interno</response>   
        [HttpPut]
        [Route("tickets/{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]TicketViewModel ticketViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            var ticket = _ticketAppService.GetById(id);

            if (ticket == null)
            {
                NotifyError("Ticket", "Ticket não encontrado");
                return Response();
            }

            _ticketAppService.Update(ticketViewModel);

            if (!IsValidOperation())
            {
                NotifyError("Ticket", "Falha ao atualizar");
                return Response();
            }

            return Response();
        }

        [HttpDelete]
        [Route("tickets/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ticket = _ticketAppService.GetById(id);

            if (ticket == null)
            {
                NotifyError("Ticket", "Ticket não encontrado");
                return Response();
            }

            _ticketAppService.Remove(id);

            return Response();
        }
    }
}