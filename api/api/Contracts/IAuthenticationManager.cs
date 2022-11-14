using api.Models.Dto.User;
using Microsoft.AspNetCore.Identity;

namespace api.Contracts
{
    public interface IAuthenticationManager
    {
        Task<IEnumerable<IdentityError>> RegisterUser(RegisterUserDto userDto);

        Task<AuthenticationResponseDto> Login(LoginUserDto loginDto);

        Task<string> CreateRefreshToken();

        Task<AuthenticationResponseDto> VerifyRefreshToken(AuthenticationResponseDto authResponseDto);
    }
}
