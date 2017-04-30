namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthenticatedUserQAViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Comments", "AuthenticatedUserQAViewModel_Id", c => c.Int());
            AddColumn("dbo.Posts", "AuthenticatedUserQAViewModel_Id", c => c.Int());
            CreateIndex("dbo.Comments", "AuthenticatedUserQAViewModel_Id");
            CreateIndex("dbo.Posts", "AuthenticatedUserQAViewModel_Id");
            AddForeignKey("dbo.Comments", "AuthenticatedUserQAViewModel_Id", "dbo.AuthenticatedUserQAViewModels", "Id");
            AddForeignKey("dbo.Posts", "AuthenticatedUserQAViewModel_Id", "dbo.AuthenticatedUserQAViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthenticatedUserQAViewModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "AuthenticatedUserQAViewModel_Id", "dbo.AuthenticatedUserQAViewModels");
            DropForeignKey("dbo.Comments", "AuthenticatedUserQAViewModel_Id", "dbo.AuthenticatedUserQAViewModels");
            DropIndex("dbo.Posts", new[] { "AuthenticatedUserQAViewModel_Id" });
            DropIndex("dbo.Comments", new[] { "AuthenticatedUserQAViewModel_Id" });
            DropIndex("dbo.AuthenticatedUserQAViewModels", new[] { "UserId" });
            DropColumn("dbo.Posts", "AuthenticatedUserQAViewModel_Id");
            DropColumn("dbo.Comments", "AuthenticatedUserQAViewModel_Id");
            DropTable("dbo.AuthenticatedUserQAViewModels");
        }
    }
}
