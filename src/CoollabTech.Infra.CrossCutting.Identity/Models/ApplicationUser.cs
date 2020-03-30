using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoollabTech.Infra.CrossCutting.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool Active { get; set; }
    }
}
