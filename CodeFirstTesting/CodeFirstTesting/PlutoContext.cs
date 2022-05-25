using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace CodeFirstTesting
{
    internal class PlutoContext : DbContext
    {
        public PlutoContext()
            :base("name=PlutoConnectionString")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
