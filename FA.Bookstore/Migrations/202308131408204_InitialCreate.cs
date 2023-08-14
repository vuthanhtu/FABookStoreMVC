namespace FA.Bookstore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        Summary = c.String(maxLength: 500),
                        ImgUrl = c.String(),
                        Price = c.Single(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        CateId = c.Int(nullable: false),
                        PubId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Categories", t => t.CateId, cascadeDelete: true)
                .ForeignKey("dbo.Publishers", t => t.PubId, cascadeDelete: true)
                .Index(t => t.CateId)
                .Index(t => t.PubId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CateId = c.Int(nullable: false, identity: true),
                        CateName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.CateId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        PubId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.PubId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PubId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "CateId", "dbo.Categories");
            DropIndex("dbo.Books", new[] { "PubId" });
            DropIndex("dbo.Books", new[] { "CateId" });
            DropTable("dbo.Publishers");
            DropTable("dbo.Categories");
            DropTable("dbo.Books");
        }
    }
}
