using api.Contracts;
using api.Data;
using api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ProjectsRepository : Repository<Project>, IProjectsRepository
    {
        public ProjectsRepository(VacationManagerDbContext context) : base(context)
        {
        }
        public async override Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.Include(a => a.Teams).ToListAsync();

        }

        public async Task<Project> AssignTeam(Project project, Team team)
        {
            //add instances to context
            _context.Project.Add(new Project()
            {
                Name = project.Name,
                Description = project.Description,
                Teams = new List<Team>() { team }
            });

            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> CascadeDelete(int? id)
        {
            var project = await _context.Projects.Include(t => t.Teams).FirstOrDefaultAsync(t => t.Id == id);

            _context.Remove(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<Project> GetDetailProject(int? id)
        {
            return await _context.Projects
             .Include(a => a.Teams)
             .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Project> RemoveTeam(Project project, Team team)
        {
            if(project.Teams.Remove(team))
            {
                await _context.SaveChangesAsync();
            }

            return project;
        }
    }
}
