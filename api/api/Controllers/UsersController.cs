using api.Contracts;
using api.Data;
using api.Dto.Team;
using api.Dto.User;
using api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly IUsersManager _usersManager;
        private readonly VacationManagerDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(ILogger<TeamsController> logger,
                               IUsersManager usersManager,
                               IMapper mapper,
                               VacationManagerDbContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _usersManager = usersManager;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<GetAllUsersDto>>> GetUsers()
        {

            var users = await _usersManager.GetAllAsync();
            var res = new List<GetAllUsersDto>();

            foreach (var user in users)
            {
                res.Add(new GetAllUsersDto()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.UserName,
                    Role = await _usersManager.GetUserRoleAsync(user.Id)
                });
            }

            return res;
        }

    }
}
