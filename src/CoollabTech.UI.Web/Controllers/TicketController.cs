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
            return View(_ticketAppService.GetAll());
        }

        [HttpGet]
        [Route("create-ticket/")]
        public IActionResult Create()
        {
            return View(new TicketViewModel());
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit-ticket/{id:guid}")]
        public IActionResult Edit(TicketViewModel ticketViewModel)
        {
            if (!ModelState.IsValid) return View(ticketViewModel);

            _ticketAppService.Update(ticketViewModel);

            return RedirectToAction("Index");
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