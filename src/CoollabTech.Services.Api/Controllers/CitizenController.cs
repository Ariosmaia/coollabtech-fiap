using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoollabTech.Application.Interfaces;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Core.Notifications;
using CoollabTech.Domain.Interfaces;
using CoollabTech.Infra.CrossCutting.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoollabTech.Services.Api.Controllers
{
    //[Authorize]
    public class CitizenController : ApiController
    {
        private readonly ICitizenAppService _citizenAppService;
        private readonly UserManager<ApplicationUser> _userManager;


        public CitizenController(
            UserManager<ApplicationUser> userManage,
            ICitizenAppService citizenAppService,
            INotificationHandler<DomainNotification> notifications, 
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _citizenAppService = citizenAppService;
            _userManager = userManage;
        }

        [HttpGet]
        [Route("citizens")]
        public IActionResult Get()
        {
            return Response(_citizenAppService.GetAll());
        }

        [HttpGet]
        [Route("citizens/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var citizenViewModel = _citizenAppService.GetById(id);

            return Response(citizenViewModel);
        }

        [HttpPut]
        [Route("citizens/{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]CitizenViewModel citizenViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Response();
            }

            var user = await _userManager.FindByIdAsync(id.ToString());
            var citizen = _citizenAppService.GetById(id);

            if (user == null || citizen == null)
            {
                NotifyError("Citizen", "Usuário não encontrado");
                return Response();
            }

            user.Email = citizenViewModel.Email;
            user.UserName = citizenViewModel.Email;
            user.Active = citizenViewModel.Active;

            citizenViewModel.Id = id;
            _citizenAppService.Update(citizenViewModel);

            if (!IsValidOperation())
            {
                NotifyError("Citizen", "Falha ao atualizar");
                return Response();
            }

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                NotifyError("Citizen", "Não foi possível atualizar");
                return Response();
            }


            return Response();

        }

        [HttpDelete]
        [Route("citizens/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.Active = false;

            var userUpdate = _userManager.UpdateAsync(user);

            if (!userUpdate.Result.Succeeded)
            {
                NotifyError("Delete", "Não foi possível excluir");
                return Response();
            }

            _citizenAppService.Remove(id);
            return Response();
        }
    }
}