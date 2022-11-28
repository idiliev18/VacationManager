using api.Data.Models.Mapping;

namespace api.Data.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProjectTeam> ProjectTeams { get; set; }

    }
}
