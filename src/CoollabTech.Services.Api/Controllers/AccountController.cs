using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoollabTech.Application.Interfaces;
using CoollabTech.Application.ViewModels;
using CoollabTech.Domain.Core.Notifications;
using CoollabTech.Domain.Interfaces;
using CoollabTech.Infra.CrossCutting.Identity.Models;
using CoollabTech.Services.Api.Configuration;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using CoollabTech.Domain.Citizen.Enums;
using Microsoft.AspNetCore.Authorization;
using CoollabTech.Domain.Citizen;
using CoollabTech.Services.Api.DTOs;

namespace CoollabTech.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ApiController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly ICitizenAppService _citizenAppService;
        private readonly IUser _user;

        public AccountController(
            IUser user,
            ICitizenAppService citizenAppService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IOptions<AppSettings> appSettings,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _user = user;
            _citizenAppService = citizenAppService;
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;

        }


        // POST api/Registro
        /// <summary>
        /// Registra um novo usário no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Register
        ///     {
        ///        "password":"Abc123@.",
        ///        "passwordConfirm":"Abc123@.",
        ///        "name":"Allan",
        ///        "nickName":"AllanR91",
        ///        "document":"35789510258",
        ///        "email":"exemplo@gmail.com",
        ///        "gender":"0 para Masculino ou 1 para feminino",
        ///     }
        ///
        /// </remarks>
        /// <param name="userRegistration"></param>
        /// <returns>Um novo usuário criado</returns>
        /// <response code="400">Se o usuário não for registrado</response>   
        /// <response code="500">Erro interno</response>   
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserRegistration userRegistration)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userRegistration);
            }

            var user = new ApplicationUser
            {
                UserName = userRegistration.Email,
                Email = userRegistration.Email,
                EmailConfirmed = true,
                Active = true
            };

            var result = await _userManager.CreateAsync(user, userRegistration.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    NotifyError(error.Code, error.Description);
                }

                return Response(userRegistration);
            }

            var citizen = new CitizenViewModel
            {
                Id = Guid.Parse(user.Id),
                Name = userRegistration.Name,
                NickName = userRegistration.NickName,
                Document = userRegistration.Document,
                Email = user.Email,
                Gender = userRegistration.Gender
            };

            _citizenAppService.Add(citizen);

            if (!IsValidOperation())
            {
                await _userManager.DeleteAsync(user);
                return Response(citizen);
            }

            await _signInManager.SignInAsync(user, false);
            var token = await GenerateJwt(userRegistration.Email);



            return Response(
                new { citizen, token }
            );
        }


        // POST api/Login
        /// <summary>
        /// Faz o login no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Login
        ///     {
        ///        "password":"Abc123@.",
        ///        "email":"exemplo@gmail.com",
        ///     }
        ///
        /// </remarks>
        /// <param name="userLogin"></param>
        /// <returns>Login</returns>
        /// <response code="400">Se o login não for sucesso</response>   
        /// <response code="500">Erro interno</response>   
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userLogin);
            }

            var result = await _signInManager.PasswordSignInAsync(userLogin.Email, userLogin.Password, false, false);

            var user = await _userManager.FindByEmailAsync(userLogin.Email);

            if (result.Succeeded)
            {
                if (!user.Active)
                {
                    NotifyError("Login", "Usuário não tem permissão de acesso!");
                    return Response(userLogin);
                }

                var token = await GenerateJwt(userLogin.Email);
                var citizen = _citizenAppService.GetById(Guid.Parse(user.Id));


                return Response(new ResultDataDTO(citizen, token));
            }



            NotifyError("Login", result.ToString());
            return Response(userLogin);
        }

        [HttpPut]
        [Authorize]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword(UserChangePassword userChangePassword)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(userChangePassword);
            }

            var userName = _user.Name;

            var user = await _userManager.FindByEmailAsync(userName);
            var userUpdate = await _userManager.ChangePasswordAsync(user, userChangePassword.CurrentPassword, userChangePassword.NewPassword);

            if (!userUpdate.Succeeded)
            {
                NotifyError("Account", "Não foi possível mudar sua senha!");
                return Response();
            }

            return Response();
        }

        private async Task<string> GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var claims = await _userManager.GetClaimsAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.ValidAt,
                Expires = DateTime.UtcNow.AddHours(_appSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }


    }
}