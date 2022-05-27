namespace CodeFirstTesting3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDatePublishedColumnFromCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "_DatePublished", c => c.DateTime());

            // Preserve data in the DatePublished column
            Sql("UPDATE dbo.Courses SET _DatePublished = DatePublished");

            DropColumn("dbo.Courses", "DatePublished");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "DatePublished", c => c.DateTime());

            // Transfer data from _DatePublished column to DatePublished column
            // and drop the _DatePublished column
            Sql("UPDATE dbo.Courses SET DatePublished = _DatePublished");
            DropColumn("dbo.Courses", "_DatePublished");
        }
    }
}
