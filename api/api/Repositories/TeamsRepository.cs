using api.Contracts;
using api.Data;
using api.Data.Models;
using api.Dto.Team;
using Microsoft.EntityFrameworkCore;
using Serilog.Context;

namespace api.Repositories
{
    public class TeamsRepository : Repository<Team>, ITeamsRepository
    {
        public TeamsRepository(VacationManagerDbContext context) : base(context)
        {
        }

        public async override Task<List<Team>> GetAllAsync()
        {
            return await _context.Teams
                       .Include(s => s.Users)
                       .Include(x => x.Projects)
                       .ToListAsync();
        }

        public async Task<Team> AssignUser(User user, Team team)
        {
            user.Team = team;
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<Team> RemoveUser(User user, Team team)
        {
            user.TeamId = null;
            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<Team> GetDetailTeam(int? id)
        {
            return await _context.Teams
                .Include(q => q.Users)
                .Include(a => a.Projects)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Team> CascadeDelete(int? id)
        {
            var blog = await _context.Teams.Include(t => t.Users).FirstOrDefaultAsync(t => t.Id == id);

            _context.Remove(blog);
            await _context.SaveChangesAsync();

            return blog;
        }
    }
}
