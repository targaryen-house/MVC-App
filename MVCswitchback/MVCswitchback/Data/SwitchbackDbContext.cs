using System;
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

            modelBuilder.Entity<UserReviews>().HasData(
                new UserReviews
                {
                    ID = 1,
                    UserID = 1,
                    TrailID = 7013499,
                    UserComment = "My trailmates were all slow, but the trail was great."
                },
                new UserReviews
                {
                    ID = 2,
                    UserID = 2,
                    TrailID = 7013499,
                    UserComment = "I don't like physical activity..."
                },
                new UserReviews
                {
                    ID = 3,
                    UserID = 3,
                    TrailID = 7013499,
                    UserComment = "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle."
                },
                new UserReviews
                {
                    ID = 4,
                    UserID = 4,
                    TrailID = 7013499,
                    UserComment = "It was ok."
                },
                new UserReviews
                {
                    ID = 5,
                    UserID = 5,
                    TrailID = 7013499,
                    UserComment = "The trail was fantastic and the views were amazing."
                });

        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserReviews> UserReviews { get; set; }
    }
}
