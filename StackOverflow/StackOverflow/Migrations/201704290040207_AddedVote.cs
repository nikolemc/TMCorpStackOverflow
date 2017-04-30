namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVote : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostVotes", "IsAllowedToVote", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostVotes", "IsAllowedToVote");
        }
    }
}
