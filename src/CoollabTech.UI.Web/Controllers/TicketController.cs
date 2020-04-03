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
        private readonly ITicketStatusAppService _ticketStatusAppService;
        private readonly ITicketTypeAppService _ticketTypeAppService;
        private readonly IServiceProviderAppService _serviceProviderAppService;

        public TicketController(ILogger<TicketController> logger, ITicketAppService ticketAppService, ITicketStatusAppService ticketStatusAppService, ITicketTypeAppService ticketTypeAppService, IServiceProviderAppService serviceProviderAppService)
        {
            _logger = logger;
            _ticketAppService = ticketAppService;
            _ticketStatusAppService = ticketStatusAppService;
            _ticketTypeAppService = ticketTypeAppService;
            _serviceProviderAppService = serviceProviderAppService;
        }

        public IActionResult Index()
        {
            return View(_ticketAppService.GetAll());
        }

        [HttpGet]
        [Route("details-ticket/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var ticketViewModel = _ticketAppService.GetById(id.Value);

            if (ticketViewModel == null)
            {
                return NotFound();
            }

            return View(ticketViewModel);
        }

        [HttpGet]
        [Route("create-ticket/")]
        public IActionResult Create()
        {
            var ticketViewModel = new TicketViewModel();
            ticketViewModel.TicketStatusViewModel = _ticketStatusAppService.GetAll();
            ticketViewModel.TicketTypesViewModel = _ticketTypeAppService.GetAll();
            ticketViewModel.ServiceProvidersViewModel = _serviceProviderAppService.GetAll();

            return View(ticketViewModel);
        }

        [HttpGet]
        [Route("edit-ticket/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var ticketViewModel = _ticketAppService.GetById(id.Value);

            if (ticketViewModel == null)
            {
                return NotFound();
            }

            return View(ticketViewModel);
        }

        [HttpGet]
        [Route("delete-ticket/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var ticketViewModel = _ticketAppService.GetById(id.Value);

            if (ticketViewModel == null)
            {
                return NotFound();
            }

            return View(ticketViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create-ticket/")]
        public IActionResult Create(TicketViewModel ticketViewModel)
        {
            if (!ModelState.IsValid) return View(ticketViewModel);

            _ticketAppService.Add(ticketViewModel);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit-ticket/{id:guid}")]
        public IActionResult Edit(TicketViewModel ticketViewModel)
        {
            if (!ModelState.IsValid) return View(ticketViewModel);

            _ticketAppService.Update(ticketViewModel);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("delete-ticket/{id:guid}")]
        public IActionResult Delete(TicketViewModel ticketViewModel)
        {
            _ticketAppService.Remove(ticketViewModel.Id);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}