using api.Data.Models.Mapping;

namespace api.Data.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<User> Students { get; set; }
        public IList<ProjectTeam> ProjectTeams { get; set; }
    }
}
