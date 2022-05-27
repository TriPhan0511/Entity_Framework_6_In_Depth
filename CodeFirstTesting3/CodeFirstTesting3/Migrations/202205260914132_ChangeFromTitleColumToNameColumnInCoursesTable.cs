namespace CodeFirstTesting3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFromTitleColumToNameColumnInCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false));
            // Transfer data from Title colum to Name column
            Sql("UPDATE dbo.Courses SET Name = Title");
            DropColumn("dbo.Courses", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Title", c => c.String(nullable: false));
            // Transfer data from Name colum to Title column
            Sql("UPDATE dbo.Courses SET Title = Name");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
