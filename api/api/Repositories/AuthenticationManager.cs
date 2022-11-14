using api.Contracts;
using api.Data;
using api.Models.Dto.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Repositories
{
    public class AuthManager : IAuthManager
    {
       
        public Task<string> CreateRefreshToken()
        {
            throw new NotImplementedException();
        }
   
        public Task<AuthenticationResponseDto> Login(LoginUserDto loginDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IdentityError>> RegisterUser(RegisterUserDto userDto)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResponseDto> VerifyRefreshToken(AuthenticationResponseDto request)
        {
            throw new NotImplementedException();
        }

        private Task<string> GenerateToken()
        {
            throw new NotImplementedException();
        }
    }
}
