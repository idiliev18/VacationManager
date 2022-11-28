using Microsoft.Build.Framework;

namespace api.Dto.Projects
{
    public class CreateProjectDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
