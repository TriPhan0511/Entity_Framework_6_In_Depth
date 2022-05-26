namespace CodeFirstExistingDatabase3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoryTable : DbMigration
    {
        //public override void Up()
        //{
        //    DropTable("dbo.Categories");
        //}

        /*
            Preserve the "Categories" table (optional)
         */
        public override void Up()
        {
            CreateTable(
                "dbo._Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO _Categories (Name) SELECT Name FROM Categories");
            DropTable("dbo.Categories");
        }

        //public override void Down()
        //{
        //    CreateTable(
        //        "dbo.Categories",
        //        c => new
        //            {
        //                Id = c.Int(nullable: false, identity: true),
        //                Name = c.String(),
        //            })
        //        .PrimaryKey(t => t.Id);
        //}

        /*
            Populate data into "Categories" table.
         */
        public override void Down()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);
            Sql("INSERT INTO Categories (Name) SELECT Name FROM _Categories");
            DropTable("dbo._Categories");
        }
    }
}
