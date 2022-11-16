namespace api.Data
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<ProjectTeam> ProjectTeams { get; set; }
    }
}
