namespace api.Dto.User
{
    public class RegisterUserDto : LoginUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
