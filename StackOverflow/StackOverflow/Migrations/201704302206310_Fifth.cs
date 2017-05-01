namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fifth : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "ModeratorDashboardViewModel_Id", "dbo.ModeratorDashboardViewModels");
            DropForeignKey("dbo.AspNetUsers", "ModeratorDashboardViewModel_Id", "dbo.ModeratorDashboardViewModels");
            DropForeignKey("dbo.Comments", "ModeratorDashboardViewModel_Id", "dbo.ModeratorDashboardViewModels");
            DropIndex("dbo.AspNetUsers", new[] { "ModeratorDashboardViewModel_Id" });
            DropIndex("dbo.Posts", new[] { "ModeratorDashboardViewModel_Id" });
            DropIndex("dbo.Comments", new[] { "ModeratorDashboardViewModel_Id" });
            DropColumn("dbo.AspNetUsers", "ModeratorDashboardViewModel_Id");
            DropColumn("dbo.Posts", "ModeratorDashboardViewModel_Id");
            DropColumn("dbo.Posts", "IsAnswered");
            DropColumn("dbo.Comments", "ModeratorDashboardViewModel_Id");
            DropTable("dbo.ModeratorDashboardViewModels");
        }
    }
}
