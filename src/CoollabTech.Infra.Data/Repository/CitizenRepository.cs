using CoollabTech.Domain.Citizen;
using CoollabTech.Domain.Citizen.Repository;
using CoollabTech.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Infra.Data.Repository
{
    public class CitizenRepository : Repository<Citizen>, ICitizenRepository
    {
        public CitizenRepository(CoollabTechContext context) : base(context)
        {
        }
    }
}
