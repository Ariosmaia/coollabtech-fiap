using CoollabTech.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CoollabTech.Application.Interfaces
{
    public interface ITicketTypeAppService
    {
        TicketTypeViewModel GetById(Guid id);
        IEnumerable<TicketTypeViewModel> GetAll();
    }
}
