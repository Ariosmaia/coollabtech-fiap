using CoollabTech.Domain.Citizen.Enums;
using CoollabTech.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Domain.Citizen.Commands
{
    public class RegisterCitizenCommand : BaseCitizenCommand
    {
        public RegisterCitizenCommand(Guid id, string name, string nickName, string document, string email, EGender gender, DateTime dateRegister)
        {
            Id = id;
            Name = name;
            NickName = nickName;
            Document = document;
            Email = email;
            this.Gender = gender;
            DateRegister = dateRegister;
        }
    }
}
