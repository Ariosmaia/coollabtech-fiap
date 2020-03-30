using CoollabTech.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Application.Interfaces
{
    public interface ICitizenAppService
    {
        CitizenViewModel GetById(Guid id);
        void Add(CitizenViewModel citizenViewModel);
        void Update(CitizenViewModel citizenViewModel);
        IEnumerable<CitizenViewModel> GetAll();
        //void Remove(Guid id);
        //IEnumerable<CitizenViewModel> Find(Expression<Func<CitizenViewModel, bool>> predicate);
    }
}
