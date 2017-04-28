namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seven : DbMigration
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.CommentId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CommentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentVotes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CommentVotes", "CommentId", "dbo.Comments");
            DropIndex("dbo.CommentVotes", new[] { "CommentId" });
            DropIndex("dbo.CommentVotes", new[] { "UserId" });
            DropTable("dbo.CommentVotes");
        }
    }
}
