using CoollabTech.Domain.Citizen.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoollabTech.Application.ViewModels
{
    public class TicketViewModel
    {
		[Key]
		[DisplayName("Id")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "A descrição é requirida")]
		[MinLength(2)]
		[MaxLength(100)]
		[DisplayName("Descrição")]
		public string Description { get; set; }

		[Required(ErrorMessage = "A localização é requirida")]
		[MinLength(2)]
		[MaxLength(100)]
		[DisplayName("Localicação")]
		public string Localization { get; set; }

		[DisplayName("Status Id")]
		public Guid TicketStatusId { get; private set; }

		[DisplayName("Tipo Id")]
		public Guid TicketTypeId { get; private set; }

		[DisplayName("Data de cadastro")]
		public DateTime DateRegister { get; private set; }
	}
}
