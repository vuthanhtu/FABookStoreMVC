namespace FA.Bookstore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreateDat = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.BookId);
            
            AlterColumn("dbo.Books", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BookId", "dbo.Books");
            DropIndex("dbo.Comments", new[] { "BookId" });
            AlterColumn("dbo.Books", "CreatedDate", c => c.DateTime());
            DropTable("dbo.Comments");
        }
    }
}
