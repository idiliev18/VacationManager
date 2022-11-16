using System.ComponentModel.DataAnnotations;

namespace api.Dto.User
{
    public class LoginUserDto
    {

        [Required]
        public string Useraname { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
