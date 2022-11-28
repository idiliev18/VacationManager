using System.ComponentModel.DataAnnotations;

namespace api.Data.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(32, MinimumLength = 2,
        ErrorMessage = "Length must have min length of 2 and max Length of 32")]
        public string Name { get; set; }

        [StringLength(256, MinimumLength = 2,
        ErrorMessage = "Length must have min length of 2 and max Length of 256")]
        public string Description { get; set; }

        public ICollection<Team> Teams { get; set; }

    }
}
