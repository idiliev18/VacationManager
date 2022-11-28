using api.Data.Models.Mapping;

namespace api.Data.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
