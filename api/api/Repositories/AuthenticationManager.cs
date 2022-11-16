using api.Contracts;
using api.Data.Models;
using api.Dto.User;
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

        public async Task<AuthenticationResponseDto> Login(LoginUserDto loginDto)
        {
            _user = await _userManager.FindByNameAsync(loginDto.Useraname);

            if(_user is null)
            {
                return null;
            }

            var isValidUser = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

            if(!isValidUser)
            {
                return null;
            }

            return new AuthenticationResponseDto
            {
                UserId = _user.Id,
                Token = await GenerateToken(),
                RefreshToken = "Coming Soon"
            };
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

        private async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.
                               UTF8.
                               GetBytes(_configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securityKey,
                                   SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.UserName),
                new Claim("uid", _user.Id),
            }
            .Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.
                         Now.
                         AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
