using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Data.Models;
using Microsoft.Extensions.Logging;
using api.Dto.Team;
using api.Repositories;
using api.Contracts;
using AutoMapper;
using System.Diagnostics.Metrics;
using api.Dto.User;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly ITeamsRepository _teamsRepository;
        private readonly IUsersManager _usersManager;
        private readonly IMapper _mapper;

        public TeamsController(ILogger<TeamsController> logger,
                               ITeamsRepository teamsRepository,
                               IUsersManager usersManager,
                               IMapper mapper)
        {
            _logger = logger;
            _teamsRepository = teamsRepository;
            _mapper = mapper;
            _usersManager = usersManager;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<ICollection<GetAllTeamsDto>>> GetTeams()
        {
            var teams = await _teamsRepository.GetAllAsync();
            var result = new List<GetAllTeamsDto>();

            foreach (var team in teams)
            {
                result.Add(new GetAllTeamsDto
                {
                    Id = team.Id,
                    Name = team.Name,
                    MemberCount = team.Users.Count,
                    ProjectCount = team.TeamProjects.Count
                });
            }

            return Ok(result);
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamDto>> GetTeam(int id)
        {
            var team = await _teamsRepository.GetDetailTeam(id);

            if (team == null)
            {
                return NotFound();
            }

            var users = new List<UserDetailDto>();
            foreach (var user in team.Users)
            {
                users.Add(new UserDetailDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.UserName,
                    Role = await _usersManager.GetUserRoleAsync(user.Id)
                });
            }

            var record = new TeamDto
            {
                Id = team.Id,
                Name = team.Name,
                Users = users
            };

            return Ok(record);
        }

        // PUT: api/Teams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeam(int id, CreateTeamDto newTeamName)
        {
            var team = await _teamsRepository.GetAsync(id);

            if (team == null)
            {
                return NotFound($"Team with id: {id} does not exsist!");
            }

            _mapper.Map(newTeamName, team);

            try
            {
                await _teamsRepository.UpdateAsync(team);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Teams
        [HttpPost]
        public async Task<ActionResult<Team>> PostTeam(CreateTeamDto newTeam)
        {
            var team = _mapper.Map<Team>(newTeam);

            await _teamsRepository.AddAsync(team);

            return CreatedAtAction("GetTeam", new { id = team.Id }, team);
        }

        // DELETE: api/Teams/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var team = await _teamsRepository.GetAsync(id);
            if (team == null)
            {
                return NotFound();
            }
            _logger.LogInformation("Kondio Trie");
            await _teamsRepository.CascadeDelete(id);

            return NoContent();
        }

        [HttpPut("assign")]
        public async Task<IActionResult> AssignUser(AssignUserDto assignUserDto)
        {
            _logger.LogInformation($"{assignUserDto.TeamId} {assignUserDto.UserId}");

            var team = await _teamsRepository.GetAsync(assignUserDto.TeamId);
            var user = await _usersManager.GetUserAsync(assignUserDto.UserId);

            if (team is null || user is null)
            {
                return NotFound();
            }

            _logger.LogInformation($"Trying to assign user: {user.UserName} to team: {team.Name}");

            return Ok(await _teamsRepository.AssignUser(user, team));
        }

        [HttpDelete("removeUser")]
        public async Task<IActionResult> RemoveUser(AssignUserDto assignUserDto)
        {
            _logger.LogInformation($"{assignUserDto.TeamId} {assignUserDto.UserId}");

            var team = await _teamsRepository.GetAsync(assignUserDto.TeamId);
            var user = await _usersManager.GetUserAsync(assignUserDto.UserId);

            if (team is null || user is null)
            {
                return NotFound();
            }

            _logger.LogInformation($"Trying to assign user: {user.UserName} to team: {team.Name}");

            return Ok(await _teamsRepository.RemoveUser(user, team));
        }

        private async Task<bool> TeamExists(int id)
        {
            return await _teamsRepository.Exist(id);
        }
    }
}
