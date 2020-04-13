using CoollabTech.Domain.Citizen;
using CoollabTech.Domain.Citizen.Repository;
using CoollabTech.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoollabTech.Infra.Data.Repository
{
    public class CitizenRepository : Repository<Citizen>, ICitizenRepository
    {
        public CitizenRepository(CoollabTechContext context) : base(context)
        {
        }

        public override IEnumerable<Citizen> GetAll()
        {
            return DbSet.ToList().Where(c => c.Excluded == false);
        }

        public override void Remove(Guid id)
        {
            var citizen = GetById(id);
            citizen.DeleteCitizen();
            citizen.NotActive();
            Update(citizen);
        }
    }
}
