namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eight : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommentVotes", "IsAllowedToVote", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommentVotes", "IsAllowedToVote");
        }
    }
}
