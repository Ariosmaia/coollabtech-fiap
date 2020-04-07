using CoollabTech.Domain.Citizen.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoollabTech.Application.ViewModels
{
    public class CitizenViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é requirido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Name { get;  set; }

        [Required(ErrorMessage = "O apelido é requirido")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Apelido")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "O CPF é requirido")]
        [StringLength(11)]
        [DisplayName("CPF")]
        public string Document { get; set; }

        [Required(ErrorMessage = "O e-mail é requirido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get;  set; }

        [Required(ErrorMessage = "O sexo é requerido")]
        [DisplayName("Sexo")]
        public EGender Gender { get;  set; }

    }
}
