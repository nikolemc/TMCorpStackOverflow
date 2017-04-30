namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CommentId);
            
            CreateTable(
                "dbo.IndividualPostViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
            AddColumn("dbo.Comments", "IsAnswered", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "IndividualPostViewModel_Id", c => c.Int());
            CreateIndex("dbo.Comments", "IndividualPostViewModel_Id");
            AddForeignKey("dbo.Comments", "IndividualPostViewModel_Id", "dbo.IndividualPostViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndividualPostViewModels", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Comments", "IndividualPostViewModel_Id", "dbo.IndividualPostViewModels");
            DropForeignKey("dbo.CommentVotes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentVotes", "CommentId", "dbo.Comments");
            DropIndex("dbo.IndividualPostViewModels", new[] { "Post_Id" });
            DropIndex("dbo.CommentVotes", new[] { "CommentId" });
            DropIndex("dbo.CommentVotes", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "IndividualPostViewModel_Id" });
            DropColumn("dbo.Comments", "IndividualPostViewModel_Id");
            DropColumn("dbo.Comments", "IsAnswered");
            DropTable("dbo.IndividualPostViewModels");
            DropTable("dbo.CommentVotes");
        }
    }
}
