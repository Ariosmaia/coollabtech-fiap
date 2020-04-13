using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using CoollabTech.Infra.CrossCutting.Identity.Models;
using CoollabTech.Application.ViewModels;
using CoollabTech.Application.Interfaces;
using CoollabTech.Domain.Core.Notifications;
using MediatR;

namespace CoollabTech.UI.Web.Areas.Identity.Pages.Account.Manage
{
    public partial class EmailModel : PageModel
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ICitizenAppService _citizenAppService;

        public EmailModel(
            INotificationHandler<DomainNotification> notifications,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ICitizenAppService citizenAppService,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _citizenAppService = citizenAppService;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel : CitizenViewModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Novo e-mail")]
            public string NewEmail { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var email = await _userManager.GetEmailAsync(user);
            var citizen = _citizenAppService.GetById(Guid.Parse(user.Id));
            Console.WriteLine(citizen);
            Email = email;

            Input = new InputModel
            {
                NewEmail = email,
                Name = citizen.Name,
                NickName = citizen.NickName,
                Document = citizen.Document,
                Gender = citizen.Gender,
                Email = citizen.Email
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o usuário com o ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o usuário com o ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var citizen = new CitizenViewModel
            {
                Id = Guid.Parse(user.Id),
                Name = Input.Name,
                NickName = Input.NickName,
                Document = Input.Document,
                Email = Input.NewEmail,
                Gender = Input.Gender,
                Excluded = false,
                Active = true
            };
            _citizenAppService.Update(citizen);

            if (!IsValidOperation())
            {
                return ErrorUpdate();
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.NewEmail != email)
            {
                //var userId = await _userManager.GetUserIdAsync(user);
                //var code = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);

                //var callbackUrl = Url.Page(
                //    "/Account/ConfirmEmailChange",
                //    pageHandler: null,
                //    values: new { userId = userId, email = Input.NewEmail, code = code },
                //    protocol: Request.Scheme);
                //await _emailSender.SendEmailAsync(
                //    Input.NewEmail,
                //    "Confirm your email",
                //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                user.Email = Input.NewEmail;
                user.UserName = Input.NewEmail;
                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    return ErrorUpdate();
                }

                // StatusMessage = "Confirmation link to change email sent. Please check your email.";
                StatusMessage = "Dados Atualizados com sucesso!";
                return RedirectToPage();
            }

            StatusMessage = "Dados Atualizados com sucesso!";
            return RedirectToPage();
        }

        private IActionResult ErrorUpdate()
        {
            StatusMessage = "Erro ao atualizar os dados";
            return Page();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Não foi possível carregar o usuário com o ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Confirme seu E-mail",
                $"Por favor, confirme sua conta <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clique aqui</a>.");

            StatusMessage = "E-mail de verificação enviado. Favor confirmar";
            return RedirectToPage();
        }

        public bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

    }
}
