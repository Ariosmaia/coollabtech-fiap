using CoollabTech.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace CoollabTech.Application.Interfaces
{
    public interface IServiceProviderAppService
    {
        ServiceProviderViewModel GetById(Guid id);
        IEnumerable<ServiceProviderViewModel> GetAll();
    }
}
