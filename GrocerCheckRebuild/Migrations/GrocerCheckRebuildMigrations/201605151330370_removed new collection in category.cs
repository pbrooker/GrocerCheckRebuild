namespace GrocerCheckRebuild.Migrations.GrocerCheckRebuildMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removednewcollectionincategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Brand", "Category_CategoryID", "dbo.Category");
            DropIndex("dbo.Brand", new[] { "Category_CategoryID" });
            DropColumn("dbo.Brand", "Category_CategoryID");
            DropColumn("dbo.Category", "BrandName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "BrandName", c => c.String());
            AddColumn("dbo.Brand", "Category_CategoryID", c => c.Int());
            CreateIndex("dbo.Brand", "Category_CategoryID");
            AddForeignKey("dbo.Brand", "Category_CategoryID", "dbo.Category", "CategoryID");
        }
    }
}
