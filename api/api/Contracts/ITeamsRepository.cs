using api.Data.Models;
using api.Dto.Team;

namespace api.Contracts
{
    public interface ITeamsRepository : IRepository<Team>
    {
        Task<Team> AssignUser(User user, Team team);

        Task<Team> RemoveUser(User user, Team team);

        Task<Team> GetDetailTeam(int? id);

        Task<Team> CascadeDelete(int? id);
    }
}
