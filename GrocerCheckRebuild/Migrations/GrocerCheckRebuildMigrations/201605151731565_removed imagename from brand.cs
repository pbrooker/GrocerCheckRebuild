namespace GrocerCheckRebuild.Migrations.GrocerCheckRebuildMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedimagenamefrombrand : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Brand", "ImageName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Brand", "ImageName", c => c.String());
        }
    }
}
