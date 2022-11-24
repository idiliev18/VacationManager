using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace api.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
