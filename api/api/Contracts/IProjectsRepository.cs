using api.Data.Models;

namespace api.Contracts
{
    public interface IProjectsRepository : IRepository<Project>
    {
        Task<Project> AssignTeam(Project project, Team team);

        Task<Project> RemoveTeam(Project project, Team team);

        Task<Project> GetDetailProject(int? id);

        Task<Project> CascadeDelete(int? id);
    }
}
