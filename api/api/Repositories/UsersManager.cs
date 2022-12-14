using api.Contracts;
using api.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.ComponentModel;

namespace api.Repositories
{
    public class UsersManager : IUsersManager
    {
        private readonly UserManager<User> _userManager;

        public UsersManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetAsync(string id)
        {
            if (id is null)
            {
                return null;
            }

            return await _userManager.FindByIdAsync(id);
        }

        public async Task<string> GetUserRoleAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles =  await _userManager.GetRolesAsync(user);

            return roles[0];
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _userManager.FindByEmailAsync(username);
        }
    }
}
