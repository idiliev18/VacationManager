using api.Data.Models;
using api.Dto.Team;

namespace api.Contracts
{
    public interface IUsersManager
    {
        Task<User> GetAsync(string id);
        Task<User> GetByUsernameAsync(string username);
        Task<string> GetUserRoleAsync(string id);
        Task<List<User>> GetAllAsync();
    }
}
