namespace GrocerCheckRebuild.Migrations.GrocerCheckRebuildMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cleanedupgrocerandbrand : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Brand", "Category_CategoryID", "dbo.Category");
            DropForeignKey("dbo.Category", "Grocer_GrocerID", "dbo.Grocer");
            DropIndex("dbo.Brand", new[] { "Category_CategoryID" });
            DropIndex("dbo.Category", new[] { "Grocer_GrocerID" });
            DropColumn("dbo.Brand", "Category_CategoryID");
            DropColumn("dbo.Category", "Grocer_GrocerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "Grocer_GrocerID", c => c.Int());
            AddColumn("dbo.Brand", "Category_CategoryID", c => c.Int());
            CreateIndex("dbo.Category", "Grocer_GrocerID");
            CreateIndex("dbo.Brand", "Category_CategoryID");
            AddForeignKey("dbo.Category", "Grocer_GrocerID", "dbo.Grocer", "GrocerID");
            AddForeignKey("dbo.Brand", "Category_CategoryID", "dbo.Category", "CategoryID");
        }
    }
}
