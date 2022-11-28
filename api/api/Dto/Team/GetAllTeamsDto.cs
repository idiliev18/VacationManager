namespace api.Dto.Team
{
    public class GetAllTeamsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MemberCount { get; set; }

        public int ProjectCount { get; set; }
    }
}
