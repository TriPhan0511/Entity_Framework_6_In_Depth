namespace CodeFirstTesting1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCategoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "Categories_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Categories_Id");
            AddForeignKey("dbo.Courses", "Categories_Id", "dbo.Categories", "Id");

            Sql("INSERT INTO Categories (Name) VALUES ('C# Programming Language'), ('Web Development')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Categories_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Categories_Id" });
            DropColumn("dbo.Courses", "Categories_Id");
            DropTable("dbo.Categories");
        }
    }
}
