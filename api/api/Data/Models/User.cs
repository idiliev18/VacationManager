using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace api.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [AllowNull]
        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
}
