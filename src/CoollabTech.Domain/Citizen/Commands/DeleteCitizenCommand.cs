using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Domain.Citizen.Commands
{
    public class DeleteCitizenCommand : BaseCitizenCommand
    {
        public DeleteCitizenCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
