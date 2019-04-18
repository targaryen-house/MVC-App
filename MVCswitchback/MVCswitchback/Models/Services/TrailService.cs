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

        public async Task<List<UserReviews>> GetUserReviews(int id)
        {
            //var list = _context.UserReviews.Where(x => x.TrailID == id);

            var list = from l in _context.UserReviews
                       where (id == l.TrailID)
                       select l;

            return await list.ToListAsync();
        }
    }
}
