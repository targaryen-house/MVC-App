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
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UserReviews> UserReviews { get; set; }
    }
}
