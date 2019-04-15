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

    }
}
