using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Offertguiden.Models
{
    public class OffertguidenContext : DbContext
    {
        public OffertguidenContext(DbContextOptions<OffertguidenContext> options) : base(options)
        {
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Reference> References { get; set; }
    }
}
