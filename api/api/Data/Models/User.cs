using AutoMapper.Configuration.Annotations;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace api.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(32, MinimumLength = 2,
        ErrorMessage = "Length must have min length of 2 and max Length of 32")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 2,
        ErrorMessage = "Length must have min length of 2 and max Length of 32")]
        public string LastName { get; set; }

        [AllowNull]
        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
}
