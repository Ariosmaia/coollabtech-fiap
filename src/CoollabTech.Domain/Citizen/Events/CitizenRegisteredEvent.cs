﻿using CoollabTech.Domain.Citizen.Enums;
using CoollabTech.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Domain.Citizen.Events
{
    public class CitizenRegisteredEvent : BaseCitizenEvent
    {
        public CitizenRegisteredEvent(Guid id, string name, string nickName, string document, string email, EGender gender, DateTime dateRegister, bool exclued, bool active)
        {
            Id = id;
            Name = name;
            NickName = nickName;
            Document = document;
            Email = email;
            this.Gender = gender;
            DateRegister = dateRegister;
            Excluded = exclued;
            Active = active;
        }
    }
}
