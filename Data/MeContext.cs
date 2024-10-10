using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Me.Models;

namespace Me.Data
{
    public class MeContext : DbContext
    {
        public MeContext (DbContextOptions<MeContext> options)
            : base(options)
        {
        }

        public DbSet<Me.Models.Project> Project { get; set; } = default!;

        public DbSet<Me.Models.Hobby>? Hobby { get; set; }

        public DbSet<Me.Models.Interest>? Interest { get; set; }
    }
}
