using Microsoft.EntityFrameworkCore;
using MVCswitchback.Data;
using MVCswitchback.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models.Services
{
    public class UserInfoService : IUserInfoManager
    {
        private readonly SwitchbackDbContext _context;

        public UserInfoService(SwitchbackDbContext context)
        {
            _context = context;
        }

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

        public async Task<UserInfo> GetUser(int id)
        {
            return await _context.UserInfo
                                 .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task AddUser(UserInfo user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(UserInfo user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }

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
