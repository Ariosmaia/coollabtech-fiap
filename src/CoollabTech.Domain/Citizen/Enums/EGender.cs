using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace CoollabTech.Domain.Citizen.Enums
{
    public enum EGender
    {
        [EnumMember(Value = "MASCULINO")]
        Masculino,
        [EnumMember(Value = "FEMININO")]
        Feminino,
    }
}
