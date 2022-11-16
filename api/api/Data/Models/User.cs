using Microsoft.AspNetCore.Identity;
using System.Diagnostics;

namespace api.Data.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int TeamId { get; set; }

        public Team Team { get; set; }

    }
}
