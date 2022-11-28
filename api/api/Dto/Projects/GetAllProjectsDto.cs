namespace api.Dto.Projects
{
    public class GetAllProjectsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TeamsCount { get; set; }
    }
}
