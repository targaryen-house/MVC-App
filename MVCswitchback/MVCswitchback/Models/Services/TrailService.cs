using Microsoft.EntityFrameworkCore;
using MVCswitchback.Data;
using MVCswitchback.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCswitchback.Models.Services
{
    public class TrailService : ITrailManager
    {
        private readonly SwitchbackDbContext _context;

        public TrailService(SwitchbackDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserComments>> GetUserReviews(int id)
        {
            var list = await _context.UserReviews
                               .Where(x => x.TrailID == id)
                               .Include(u => u.UserInfo)
                               .ThenInclude(u => u.UserName)
                               .ToListAsync();

            return  list;
        }

    }
}
