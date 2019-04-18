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

        /// <summary>
        /// Retrieves the information from the users review for a selected trail and returns all related data
        /// </summary>
        /// <param name="id"> ID for the trail </param>
        /// <returns> List of user comments and a review related to the selected trail </returns>
        public async Task<List<UserComments>> GetUserReviews(int id)
        {
            var list = await _context.UserComments
                               .Where(x => x.TrailID == id)
                               .Include(u => u.UserInfo)
                               .ToListAsync();
            
            return  list;
        }

    }
}
