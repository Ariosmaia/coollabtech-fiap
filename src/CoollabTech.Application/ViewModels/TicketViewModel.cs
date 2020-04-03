using System;
using System.Collections.Generic;
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
		[DisplayName("Localicação")]
		public string Localization { get; set; }

		[DisplayName("Status")]
		public Guid TicketStatusId { get; set; }

		[DisplayName("Tipo")]
		public Guid TicketTypeId { get; set; }

		[DisplayName("Data de cadastro")]
		public DateTime DateRegister { get; set; }

		public IEnumerable<TicketStatusViewModel> TicketStatusViewModel { get; set; }
		public IEnumerable<TicketTypeViewModel> TicketTypesViewModel { get; set; }
		public IEnumerable<ServiceProviderViewModel> ServiceProvidersViewModel { get; set; }
	}
}
