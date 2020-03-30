using CoollabTech.Domain.Citizen.Enums;
using CoollabTech.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Domain.Citizen.Events
{
    public class BaseCitizenEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string NickName { get; protected set; }
        public string Document { get; protected set; }
        public string Email { get; protected set; }
        public EGender Gender { get; protected set; }
        public DateTime DateRegister { get; protected set; }
    }
}
