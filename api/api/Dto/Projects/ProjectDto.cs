using api.Dto.Team;

namespace api.Dto.Projects
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<TeamDetailDto> Teams { get; set; }
    }
}
