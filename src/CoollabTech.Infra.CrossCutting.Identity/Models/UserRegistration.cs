using CoollabTech.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoollabTech.Infra.CrossCutting.Identity.Models
{
    public class UserRegistration : CitizenViewModel
    {

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "As senhas não correspondem")]
        public string PasswordConfirm { get; set; }
    }
}
