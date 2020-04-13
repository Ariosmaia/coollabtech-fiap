﻿using CoollabTech.Domain.Citizen.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Domain.Citizen.Commands
{
    public class UpdateCitizenCommand : BaseCitizenCommand
    {
        public UpdateCitizenCommand(Guid id, string name, string nickName, string document, string email, EGender gender, bool exclued, bool active)
        {
            Id = id;
            Name = name;
            NickName = nickName;
            Document = document;
            Email = email;
            this.Gender = gender;
            Excluded = exclued;
            Active = active;
        }

    }
}
