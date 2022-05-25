namespace CodeFirstExistingDatabase3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            // Use DbMigration.Sql() method to execute a SQL command or set of SQL commands
            Sql("INSERT INTO Categories VALUES (1, 'Web Development')");
            Sql("INSERT INTO Categories VALUES (2, 'Programming Languages')");
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
