namespace StackOverflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Comments", "IndividualPostViewModel_Id", c => c.Int());
            CreateIndex("dbo.Comments", "IndividualPostViewModel_Id");
            AddForeignKey("dbo.Comments", "IndividualPostViewModel_Id", "dbo.IndividualPostViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IndividualPostViewModels", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Comments", "IndividualPostViewModel_Id", "dbo.IndividualPostViewModels");
            DropIndex("dbo.IndividualPostViewModels", new[] { "Post_Id" });
            DropIndex("dbo.Comments", new[] { "IndividualPostViewModel_Id" });
            DropColumn("dbo.Comments", "IndividualPostViewModel_Id");
            DropTable("dbo.IndividualPostViewModels");
        }
    }
}
