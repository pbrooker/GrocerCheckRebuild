namespace GrocerCheckRebuild.Migrations.GrocerCheckRebuildMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcollectiontocategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brand", "Category_CategoryID", c => c.Int());
            CreateIndex("dbo.Brand", "Category_CategoryID");
            AddForeignKey("dbo.Brand", "Category_CategoryID", "dbo.Category", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Brand", "Category_CategoryID", "dbo.Category");
            DropIndex("dbo.Brand", new[] { "Category_CategoryID" });
            DropColumn("dbo.Brand", "Category_CategoryID");
        }
    }
}
