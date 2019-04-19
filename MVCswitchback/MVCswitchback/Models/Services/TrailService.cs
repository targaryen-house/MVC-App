﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
            var comments = await _context.UserComments
                               .Where(x => x.TrailID == id)
                               .Include(u => u.UserInfo)
                               .ToListAsync();

            return comments;
        }

        public SelectList GetAllUsers()
        {
            return new SelectList(_context.UserInfo, "ID", "User Name");

            //return await _context.UserInfo.ToListAsync();
        }

        public async Task AddComment(UserComments userComment)
        {
            await _context.UserComments.AddAsync(userComment);
            await _context.SaveChangesAsync();
        }

    }
}
