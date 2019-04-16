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
                    UserName = "Cmorto",
                    FirstName = "Christopher",
                    LastName = "Robin"
                });

            modelBuilder.Entity<UserReviews>().HasData(
                new UserReviews
                {
                    ID = 1,
                    UserID = 1,
                    TrailID = 0,
                    UserComment = "Was much fun, has difficult. much peril. 12/10 would recommend for bamboozle"
                });
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserReviews> UserReviews { get; set; }
    }
}
