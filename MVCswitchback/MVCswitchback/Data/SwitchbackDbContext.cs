using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCswitchback.Data
{
    public class SwitchbackDbContext : DbContext
    {
        public SwitchbackDbContext(DbContextOptions<SwitchbackDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<>().HasKey(ce => new { ce. , ce.});
            //modelBuilder.Entity<>().HasKey(ce => new { ce. , ce.});
            //modelBuilder.Entity<>().HasKey(ce => new { ce. , ce.});
            //modelBuilder.Entity<>().HasKey(ce => new { ce. , ce.});
            //modelBuilder.Entity<>().HasKey(ce => new { ce. , ce.});



        }

        //public DbSet<> { get; set; }
        //public DbSet<> { get; set; }
        //public DbSet<> { get; set; }
        //public DbSet<> { get; set; }
    }
}
