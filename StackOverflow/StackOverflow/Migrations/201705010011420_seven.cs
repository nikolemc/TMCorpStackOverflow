namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seven : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SearchViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        searchKeyWord = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Posts", "SearchViewModel_Id", c => c.Int());
            CreateIndex("dbo.Posts", "SearchViewModel_Id");
            AddForeignKey("dbo.Posts", "SearchViewModel_Id", "dbo.SearchViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "SearchViewModel_Id", "dbo.SearchViewModels");
            DropIndex("dbo.Posts", new[] { "SearchViewModel_Id" });
            DropColumn("dbo.Posts", "SearchViewModel_Id");
            DropTable("dbo.SearchViewModels");
        }
    }
}
