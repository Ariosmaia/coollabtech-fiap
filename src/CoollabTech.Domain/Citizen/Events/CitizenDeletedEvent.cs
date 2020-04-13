using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Domain.Citizen.Events
{
    public class CitizenDeletedEvent : BaseCitizenEvent
    {
        public CitizenDeletedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
