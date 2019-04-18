using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models.Interfaces
{
    public interface IUserInfo
    {
        // Get all users
        Task<List<UserInfo>> GetAllUsers(string searchString);

        // Get specific user by ID
        Task<UserInfo> GetUser(int id);

        // Add user
        Task AddUser(UserInfo user);

        // Update user
        Task UpdateUser(UserInfo user);

        // Delete user
        void DeleteUser(UserInfo user);

        // Confirm user exists
        bool UserExists(int id);
    }
}
