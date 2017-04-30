namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModeratorDashboardViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Comments", "ModeratorDashboardViewModel_Id", c => c.Int());
            AddColumn("dbo.Posts", "ModeratorDashboardViewModel_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "ModeratorDashboardViewModel_Id", c => c.Int());
            CreateIndex("dbo.Comments", "ModeratorDashboardViewModel_Id");
            CreateIndex("dbo.Posts", "ModeratorDashboardViewModel_Id");
            CreateIndex("dbo.AspNetUsers", "ModeratorDashboardViewModel_Id");
            AddForeignKey("dbo.Comments", "ModeratorDashboardViewModel_Id", "dbo.ModeratorDashboardViewModels", "Id");
            AddForeignKey("dbo.AspNetUsers", "ModeratorDashboardViewModel_Id", "dbo.ModeratorDashboardViewModels", "Id");
            AddForeignKey("dbo.Posts", "ModeratorDashboardViewModel_Id", "dbo.ModeratorDashboardViewModels", "Id");
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
            DropColumn("dbo.Comments", "ModeratorDashboardViewModel_Id");
            DropTable("dbo.ModeratorDashboardViewModels");
        }
    }
}
