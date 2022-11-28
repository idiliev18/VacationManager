using api.Data.Models;
using api.Dto.Team;

namespace api.Contracts
{
    public interface IUsersManager
    {
        Task<User> GetUserAsync(string id);
        Task<string> GetUserRoleAsync(string id);
    }
}
