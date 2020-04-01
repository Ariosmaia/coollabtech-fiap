using CoollabTech.Application.Interfaces;
using CoollabTech.Application.ViewModels;
using CoollabTech.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace CoollabTech.UI.Web.Controllers
{
    public class TicketController : Controller
    {
        private readonly ILogger<TicketController> _logger;
        private readonly ITicketAppService _ticketAppService;

        public TicketController(ILogger<TicketController> logger, ITicketAppService ticketAppService)
        {
            _logger = logger;
            _ticketAppService = ticketAppService;
            
        }
        public IActionResult Index()
        {

            var teste = _ticketAppService.GetAll();
            return View(teste);
        }
    }
}
