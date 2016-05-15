namespace GrocerCheckRebuild.Migrations.GrocerCheckRebuildMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedimagenametobrand : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Brand", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Brand", "ImageName");
        }
    }
}
