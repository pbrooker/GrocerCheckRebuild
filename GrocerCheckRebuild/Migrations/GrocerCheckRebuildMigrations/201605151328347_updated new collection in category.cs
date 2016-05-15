namespace GrocerCheckRebuild.Migrations.GrocerCheckRebuildMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatednewcollectionincategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "BrandName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "BrandName");
        }
    }
}
