using CoollabTech.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CoollabTech.Application.Interfaces
{
    public interface ITicketAppService
    {
        TicketViewModel GetById(Guid id);
        void Add(TicketViewModel ticketViewModel);
        void Update(TicketViewModel ticketViewModel);
        IEnumerable<TicketViewModel> GetAll();
        void Remove(Guid id);
    }
}
