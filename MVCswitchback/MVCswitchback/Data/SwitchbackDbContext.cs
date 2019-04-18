﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCswitchback.Models;
using MVCswitchback.Controllers;

namespace MVCswitchback.Data
{
    public class SwitchbackDbContext : DbContext
    {
        public SwitchbackDbContext(DbContextOptions<SwitchbackDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// seeded data
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>().HasData(
                new UserInfo
                {
                    ID = 1,
                    UserName = "Secret Squirrel",
                    FirstName = "Christopher",
                    LastName = "Morton"
                },
                new UserInfo
                {
                    ID = 2,
                    UserName = "Roketsu",
                    FirstName = "Andy",
                    LastName = "Roska"
                },
                new UserInfo
                {
                    ID = 3,
                    UserName = "Hype Man",
                    FirstName = "Ian",
                    LastName = "Gifford"
                },
                new UserInfo
                {
                    ID = 4,
                    UserName = "TannMann",
                    FirstName = "Tanner",
                    LastName = "Percival"
                },
                new UserInfo
                {
                    ID = 5,
                    UserName = "The Wizard",
                    FirstName = "Mike",
                    LastName = "Kelly"
                });

            modelBuilder.Entity<UserComments>().HasData(
                new UserComments
                {
                    ID = 1,
                    UserID = 1,
                    TrailID = 7013499,
                    UserComment = "My trailmates were all slow, but the trail was great."
                },
                new UserComments
                {
                    ID = 2,
                    UserID = 2,
                    TrailID = 7013499,
                    UserComment = "I don't like physical activity..."
                },
                new UserComments
                {
                    ID = 3,
                    UserID = 3,
                    TrailID = 7013499,
                    UserComment = "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle."
                },
                new UserComments
                {
                    ID = 4,
                    UserID = 4,
                    TrailID = 7013499,
                    UserComment = "It was ok."
                },
                new UserComments
                {
                    ID = 5,
                    UserID = 5,
                    TrailID = 7013499,
                    UserComment = "The trail was fantastic and the views were amazing."
                },
                new UserComments
                {
                    ID = 6,
                    UserID = 1,
                    TrailID = 1,
                    UserComment = "My trailmates were all slow, but the trail was great."
                },
                new UserComments
                {
                    ID = 7,
                    UserID = 2,
                    TrailID = 1,
                    UserComment = "I don't like physical activity..."
                },
                new UserComments
                {
                    ID = 8,
                    UserID = 3,
                    TrailID = 1,
                    UserComment = "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle."
                },
                new UserComments
                {
                    ID = 9,
                    UserID = 4,
                    TrailID = 1,
                    UserComment = "It was ok."
                },
                new UserComments
                {
                    ID = 10,
                    UserID = 5,
                    TrailID = 1,
                    UserComment = "The trail was fantastic and the views were amazing."
                });

        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserComments> UserReviews { get; set; }
    }
}
