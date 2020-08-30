using CoollabTech.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoollabTech.Services.Api.DTOs
{
    public class ResultDataDTO
    {
        public ResultDataDTO(CitizenViewModel citizen, string token)
        {
            Citizen = citizen;
            Token = token;
        }

        public CitizenViewModel Citizen { get; set; }
        public string Token { get; set; }
    }
}
