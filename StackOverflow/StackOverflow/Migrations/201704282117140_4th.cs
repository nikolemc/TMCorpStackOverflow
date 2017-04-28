namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4th : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommentVotes", "CommentId", "dbo.Comments");
            DropForeignKey("dbo.CommentVotes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "IndividualPostViewModel_Id", "dbo.IndividualPostViewModels");
            DropForeignKey("dbo.IndividualPostViewModels", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "IndividualPostViewModel_Id" });
            DropIndex("dbo.CommentVotes", new[] { "UserId" });
            DropIndex("dbo.CommentVotes", new[] { "CommentId" });
            DropIndex("dbo.IndividualPostViewModels", new[] { "Post_Id" });
            DropColumn("dbo.Comments", "IsAnswered");
            DropColumn("dbo.Comments", "IndividualPostViewModel_Id");
            DropTable("dbo.CommentVotes");
            DropTable("dbo.IndividualPostViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IndividualPostViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CommentVotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoteValue = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CommentId = c.Int(nullable: false),
                        IsAllowedToVote = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Comments", "IndividualPostViewModel_Id", c => c.Int());
            AddColumn("dbo.Comments", "IsAnswered", c => c.Boolean(nullable: false));
            CreateIndex("dbo.IndividualPostViewModels", "Post_Id");
            CreateIndex("dbo.CommentVotes", "CommentId");
            CreateIndex("dbo.CommentVotes", "UserId");
            CreateIndex("dbo.Comments", "IndividualPostViewModel_Id");
            AddForeignKey("dbo.IndividualPostViewModels", "Post_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.Comments", "IndividualPostViewModel_Id", "dbo.IndividualPostViewModels", "Id");
            AddForeignKey("dbo.CommentVotes", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CommentVotes", "CommentId", "dbo.Comments", "Id", cascadeDelete: true);
        }
    }
}
