namespace api.Data.Models.Mapping
{
    public class ProjectTeam
    {
        public string TeamId { get; set; }
        public Team Team { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
