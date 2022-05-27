using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using CodeFirstTesting2.Model;

namespace CodeFirstTesting2
{
    public class PlutoContext : DbContext
    {
        // Default constructor
        public PlutoContext()
            : base("name=PlutoContext")
        {

        }

        // Bunch of DbSet properties
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
