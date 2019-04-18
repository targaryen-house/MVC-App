using Microsoft.EntityFrameworkCore;
using MVCswitchback.Data;
using MVCswitchback.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models.Services
{
    public class UserInfoService : IUserInfo
    {
        private readonly SwitchbackDbContext _context;

        public UserInfoService(SwitchbackDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a list of users
        /// </summary>
        /// <param name="searchString"> Identifier for the search parameters </param>
        /// <returns> Returns the list of users </returns>
        public async Task<List<UserInfo>> GetAllUsers(string searchString)
        {
            var users = from u in _context.UserInfo
                        select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.UserName.Contains(searchString));
            }

            return await users.ToListAsync();
        }
        
        /// <summary>
        /// Gets a single user
        /// </summary>
        /// <param name="id"> Identifier for the user </param>
        /// <returns> Returns a User </returns>
        public async Task<UserInfo> GetUser(int id)
        {
            return await _context.UserInfo
                                 .FirstOrDefaultAsync(x => x.ID == id);
        }

        /// <summary>
        /// Adds a user to the DB
        /// </summary>
        /// <param name="user"> Identifies the user in relation to UserInfo </param>
        /// <returns></returns>
        public async Task AddUser(UserInfo user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Updates Information about a selected user
        /// </summary>
        /// <param name="user"> Identifies the user in relation to UserInfo </param>
        /// <returns></returns>
        public async Task UpdateUser(UserInfo user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a selected user
        /// </summary>
        /// <param name="user"> Identifies the user in relation to UserInfo </param>
        public void DeleteUser(UserInfo user)
        {
            _context.UserInfo.Remove(user);
            _context.SaveChangesAsync();
        }

        public bool UserExists(int id)
        {
            return _context.UserInfo.Any(x => x.ID == id);
        }
    }
}
