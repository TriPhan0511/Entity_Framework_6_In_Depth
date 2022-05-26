namespace CodeFirstExistingDatabase3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCoursesTable : DbMigration
    {
        //public override void Up()
        //{
        //    //AddColumn("dbo.Courses", "Name", c => c.String());
        //    AddColumn("dbo.Courses", "Name", c => c.String(nullable: false)); // Override the convention: It will create a not null column (named "Name") in the database
        //    DropColumn("dbo.Courses", "Title");
        //}

        /*
            Because if we drop the "Title" column, we will lose all data in the "Title" column.
            So the first technique is changing the "Title" column to "Name" column.
         */
        //public override void Up()
        //{
        //    RenameColumn("dbo.Courses", "Title", "Name");
        //}

        /*
            The second technique is using the Sql method to update the data in the "Name" column.
         */
        public override void Up()
        {
            //AddColumn("dbo.Courses", "Name", c => c.String());
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false)); // Override the convention: It will create a not null column (named "Name") in the database
            Sql("UPDATE Courses SET Name = Title");
            DropColumn("dbo.Courses", "Title");
        }

        //public override void Down()
        //{
        //    AddColumn("dbo.Courses", "Title", c => c.String());
        //    DropColumn("dbo.Courses", "Name");
        //}

        /*
            Make sure double check the Down() method because the Down() method is used downgrading th database.
         */
        public override void Down()
        {
            AddColumn("dbo.Courses", "Title", c => c.String(nullable: false)); // Override the convention
            Sql("UPDATE Courses SET Title = Name");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
