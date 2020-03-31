using CoollabTech.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CoollabTech.Application.Interfaces
{
    public interface ITicketStatusAppService
    {
        TicketStatusViewModel GetById(Guid id);
        IEnumerable<TicketStatusViewModel> GetAll();
    }
}
