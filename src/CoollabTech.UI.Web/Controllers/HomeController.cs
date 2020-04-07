using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoollabTech.UI.Web.Models;
using CoollabTech.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using CoollabTech.Application.ViewModels;

namespace CoollabTech.UI.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICitizenAppService _citizenAppService;

        public HomeController(ILogger<HomeController> logger, ICitizenAppService citizenAppService)
        {
            _logger = logger;
            _citizenAppService = citizenAppService;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View(_citizenAppService.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [Route("edit-citizen/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizenViewModel = _citizenAppService.GetById(id.Value);

            if (citizenViewModel == null)
            {
                return NotFound();
            }

            return View(citizenViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit-citizen/{id:guid}")]
        public IActionResult Edit(CitizenViewModel citizenViewModel)
        {
            if (!ModelState.IsValid) return View(citizenViewModel);

            _citizenAppService.Update(citizenViewModel);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
