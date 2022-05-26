using System;
using System.Data.Entity;
using System.Linq;

namespace CodeFirstTesting1
{
    public class PlutoContext : DbContext
    {
        // Your context has been configured to use a 'PlutoContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CodeFirstTesting1.PlutoContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'PlutoContext' 
        // connection string in the application configuration file.
        public PlutoContext()
            : base("name=PlutoContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}