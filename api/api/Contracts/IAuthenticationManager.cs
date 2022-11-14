using api.Models.Dto.User;
using Microsoft.AspNetCore.Identity;

namespace api.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> RegisterUser(UserDto userDto);

        Task<AuthenticationResponseDto> Login(LoginUserDto loginDto);

        Task<string> CreateRefreshToken();

        Task<AuthenticationResponseDto> VerifyRefreshToken(AuthenticationResponseDto authResponseDto);
    }
}
