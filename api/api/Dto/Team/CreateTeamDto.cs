using System.ComponentModel.DataAnnotations;

namespace api.Dto.Team
{
    public class CreateTeamDto
    {
        [Required]
        public string Name { get; set; }
    }
}
