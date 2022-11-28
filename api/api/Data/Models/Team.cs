
using System.ComponentModel.DataAnnotations;

namespace api.Data.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 2,
        ErrorMessage = "Length must have min length of 2 and max Length of 32")]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
