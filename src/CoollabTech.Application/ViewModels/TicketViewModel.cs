using CoollabTech.Domain.Tickets;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
		[DisplayName("Localização")]
		public string Localization { get; set; }

		[DisplayName("Status")]
		public Guid TicketStatusId { get; set; }
		public TicketStatus TicketStatus { get; set; } 

		[DisplayName("Tipo")]
		public Guid TicketTypeId { get; set; }
		public TicketType TicketType { get; set; }

		[DisplayName("Prestador de serviço")]
		public Guid ServiceProviderId { get; set; }
		
		[DisplayName("Data de cadastro")]
		public DateTime DateRegister { get; set; }
	}
}
