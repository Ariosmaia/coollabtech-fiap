using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoollabTech.Infra.CrossCutting.Identity.Models
{
    public class UserChangePassword
    {
        [StringLength(100, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres", MinimumLength = 6)]
        public string CurrentPassword { get; set; }

        [StringLength(100, ErrorMessage = "O campo {0} deve ser entre {2} e {1} caracteres", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "As senhas não correspondem")]
        public string PasswordConfirm { get; set; }
    }
}
