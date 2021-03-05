namespace Blog_App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.blogComments",
                c => new
                    {
                        commentId = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.commentId);
            
            CreateTable(
                "dbo.blogModels",
                c => new
                    {
                        blogId = c.Int(nullable: false, identity: true),
                        blogTitle = c.String(),
                        blogText = c.String(),
                        blogCreated = c.DateTime(nullable: false),
                        blogComment_commentId = c.Int(),
                    })
                .PrimaryKey(t => t.blogId)
                .ForeignKey("dbo.blogComments", t => t.blogComment_commentId)
                .Index(t => t.blogComment_commentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.blogModels", "blogComment_commentId", "dbo.blogComments");
            DropIndex("dbo.blogModels", new[] { "blogComment_commentId" });
            DropTable("dbo.blogModels");
            DropTable("dbo.blogComments");
        }
    }
}
