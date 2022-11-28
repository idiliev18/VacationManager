using api.Data.Models.Mapping;
using System.ComponentModel.DataAnnotations;

namespace api.Data.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Team> Teams { get; set; }

    }
}
