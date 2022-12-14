using api.Contracts;
using api.Dto.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly ILogger _logger;

        public AuthenticationController(IAuthenticationManager authenticationManager, ILogger<AuthenticationController> logger)
        {
            _authenticationManager = authenticationManager;
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] RegisterUserDto registerUserDto)
        {
            _logger.LogInformation($"Kondio {registerUserDto.Useraname}");
            var errors = await _authenticationManager.RegisterUser(registerUserDto);
            
            if(errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return BadRequest(errors);
            }

            return Ok();
        
        
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            var token = await _authenticationManager.Login(loginUserDto);

            if (token is null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }


    }
}
