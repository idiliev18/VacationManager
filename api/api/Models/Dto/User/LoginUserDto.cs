using System.ComponentModel.DataAnnotations;

namespace api.Models.Dto.User
{
    public class LoginUserDto
    {

        [Required]
        public string Useraname { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
