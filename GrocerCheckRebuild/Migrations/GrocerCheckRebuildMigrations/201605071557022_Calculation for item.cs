namespace GrocerCheckRebuild.Migrations.GrocerCheckRebuildMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calculationforitem : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE dbo.item SET CalculatedPrice=(Price/SizeMeasure)*100");
        }
        
        public override void Down()
        {
        }
    }
}
