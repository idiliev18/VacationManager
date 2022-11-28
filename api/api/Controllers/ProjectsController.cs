using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Data;
using api.Data.Models;
using api.Contracts;
using AutoMapper;
using api.Repositories;
using NuGet.Packaging.Signing;
using api.Dto.Projects;
using api.Dto.Team;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly VacationManagerDbContext _context;
        private readonly ILogger<ProjectsController> _logger;
        private readonly IProjectsRepository _projectsRepository;
        private readonly IMapper _mapper;
        private readonly IUsersManager _usersManager;
        private readonly ITeamsRepository _teamsRepository;

        public ProjectsController(VacationManagerDbContext context, 
                               ILogger<ProjectsController> logger,
                               IProjectsRepository projectsRepository,
                               ITeamsRepository teamsRepository,
                               IUsersManager usersManager,
                               IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _projectsRepository = projectsRepository;
            _mapper = mapper;
            _usersManager = usersManager;
            _teamsRepository = teamsRepository;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllProjectsDto>>> GetProject()
        {
            var projects = await _projectsRepository.GetAllAsync();

            var result = new List<GetAllProjectsDto>();
            foreach (var project in projects)
            {
                result.Add(new GetAllProjectsDto()
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    TeamsCount = project.Teams.Count
                });
            }

            return Ok(result);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProject(int id)
        {
            var project = await _projectsRepository.GetDetailProject(id);

            if (project == null)
            {
                return NotFound();
            }

            var teams = GetTeamFromProjects(project);
          
            var record = new ProjectDto()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Teams = teams
            };

            return Ok(record);
        }

        private List<TeamDetailDto> GetTeamFromProjects(Project project)
        {
            var result = new List<TeamDetailDto>();
            foreach (var team in project.Teams)
            {
                result.Add(new TeamDetailDto()
                {
                    Id = team.Id,
                    Name = team.Name
                });
            }

            return result;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject(int id, CreateProjectDto editProject)
        {
            var project = await _projectsRepository.GetAsync(id);

            if (project == null)
            {
                return NotFound($"Project with id: {id} does not exsist!");
            }

            _mapper.Map(editProject, project);

            try
            {
                await _projectsRepository.UpdateAsync(project);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProjectExists(id))
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

        // POST: api/Projects
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(CreateProjectDto newProject)
        {
            var team = _mapper.Map<Project>(newProject);

            await _projectsRepository.AddAsync(team);

            return CreatedAtAction("GetProject", new { id = team.Id }, team);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _projectsRepository.GetAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            _logger.LogInformation("Kondio Trie");
            await _projectsRepository.CascadeDelete(id);

            return NoContent();
        }

        [HttpPut("assign")]
        public async Task<IActionResult> AssignTeam(AssignTeamDto assignUserDto)
        {
            _logger.LogInformation($"{assignUserDto.TeamId} {assignUserDto.ProjectId}");

            var team = await _teamsRepository.GetAsync(assignUserDto.TeamId);
            var project = await _projectsRepository.GetAsync(assignUserDto.ProjectId);

            if (team is null || project is null)
            {
                return NotFound();
            }

            _logger.LogInformation($"Trying to assign team: {team.Name} to project: {project.Name}");

            return Ok(await _projectsRepository.AssignTeam(project, team));
        }

        [HttpDelete("removeTeam")]
        public async Task<IActionResult> RemoveUser(AssignTeamDto removeUserDto)
        {
            _logger.LogInformation($"{removeUserDto.TeamId} {removeUserDto.ProjectId}");

            var team = await _teamsRepository.GetDetailTeam(removeUserDto.TeamId);
            var project = await _projectsRepository.GetAsync(removeUserDto.ProjectId);

            if (team is null || project is null)
            {
                return NotFound();
            }

            _logger.LogInformation($"Trying to remove team: {team.Name} from project: {project.Name}");

            return Ok(await _projectsRepository.RemoveTeam(project, team));
        }

        private async Task<bool> ProjectExists(int id)
        {
            return await _projectsRepository.Exist(id);
        }
    }
}
