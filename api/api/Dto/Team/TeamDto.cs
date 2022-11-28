using api.Data.Models;
using api.Dto.Projects;
using api.Dto.User;
using System.Text.Json.Serialization;

namespace api.Dto.Team
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<UserDetailDto> Users { get; set; }
        public ICollection<ProjectDetailDto> Projects { get; set; }
    }
}
