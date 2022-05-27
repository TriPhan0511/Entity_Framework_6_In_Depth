namespace CodeFirstExistingDatabase3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using System.Collections.ObjectModel;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstExistingDatabase3.PlutoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        //protected override void Seed(CodeFirstExistingDatabase3.PlutoContext context)
        //{
        //    //  This method will be called after migrating to the latest version.

        //    //  You can use the DbSet<T>.AddOrUpdate() helper extension method
        //    //  to avoid creating duplicate seed data.
        //}

        // Testing
        protected override void Seed(CodeFirstExistingDatabase3.PlutoContext context)
        {
            context.Authors.AddOrUpdate(a => a.Name,
                new Author 
                { 
                    Name = "Author 1",
                    Courses = new Collection<Course>()
                    {
                        new Course()
                        {
                            Name = "Course for Author 1",
                            Description = "Description"
                        }
                    }
                });
        }
    }
}
