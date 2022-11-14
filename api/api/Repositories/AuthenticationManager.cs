using api.Contracts;
using api.Data;
using api.Models.Dto.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api.Repositories
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        private User _user;
        private readonly string _defaultRole = "Unassigned";

        public AuthenticationManager(UserManager<User> userManager,
                                     IConfiguration configuration,
                                     IMapper mapper)
        {
            _userManager = userManager; 
            _configuration = configuration;
            _mapper = mapper;
        }


        public Task<string> CreateRefreshToken()
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResponseDto> Login(LoginUserDto loginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IdentityError>> RegisterUser(RegisterUserDto userDto)
        {
            _user = _mapper.Map<User>(userDto);
            _user.UserName = userDto.Useraname;

            var result = await _userManager.CreateAsync(_user, userDto.Password);

            // Add default role - Unassigned
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(_user, _defaultRole);
            }

            return result.Errors; 
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
