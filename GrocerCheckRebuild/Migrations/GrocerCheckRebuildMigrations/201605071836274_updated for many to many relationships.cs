namespace GrocerCheckRebuild.Migrations.GrocerCheckRebuildMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedformanytomanyrelationships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Brand", "User_UserID", "dbo.User");
            DropForeignKey("dbo.Grocer", "User_UserID", "dbo.User");
            DropForeignKey("dbo.Size", "User_UserID", "dbo.User");
            DropIndex("dbo.Brand", new[] { "User_UserID" });
            DropIndex("dbo.Grocer", new[] { "User_UserID" });
            DropIndex("dbo.Size", new[] { "User_UserID" });
            CreateTable(
                "dbo.UserBrand",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.BrandID })
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Brand", t => t.BrandID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.UserGrocer",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        GrocerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.GrocerID })
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Grocer", t => t.GrocerID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.GrocerID);
            
            CreateTable(
                "dbo.UserSize",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        SizeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.SizeID })
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Size", t => t.SizeID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.SizeID);
            
            DropColumn("dbo.Brand", "User_UserID");
            DropColumn("dbo.Grocer", "User_UserID");
            DropColumn("dbo.Size", "User_UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Size", "User_UserID", c => c.Int());
            AddColumn("dbo.Grocer", "User_UserID", c => c.Int());
            AddColumn("dbo.Brand", "User_UserID", c => c.Int());
            DropForeignKey("dbo.UserSize", "SizeID", "dbo.Size");
            DropForeignKey("dbo.UserSize", "UserID", "dbo.User");
            DropForeignKey("dbo.UserGrocer", "GrocerID", "dbo.Grocer");
            DropForeignKey("dbo.UserGrocer", "UserID", "dbo.User");
            DropForeignKey("dbo.UserBrand", "BrandID", "dbo.Brand");
            DropForeignKey("dbo.UserBrand", "UserID", "dbo.User");
            DropIndex("dbo.UserSize", new[] { "SizeID" });
            DropIndex("dbo.UserSize", new[] { "UserID" });
            DropIndex("dbo.UserGrocer", new[] { "GrocerID" });
            DropIndex("dbo.UserGrocer", new[] { "UserID" });
            DropIndex("dbo.UserBrand", new[] { "BrandID" });
            DropIndex("dbo.UserBrand", new[] { "UserID" });
            DropTable("dbo.UserSize");
            DropTable("dbo.UserGrocer");
            DropTable("dbo.UserBrand");
            CreateIndex("dbo.Size", "User_UserID");
            CreateIndex("dbo.Grocer", "User_UserID");
            CreateIndex("dbo.Brand", "User_UserID");
            AddForeignKey("dbo.Size", "User_UserID", "dbo.User", "UserID");
            AddForeignKey("dbo.Grocer", "User_UserID", "dbo.User", "UserID");
            AddForeignKey("dbo.Brand", "User_UserID", "dbo.User", "UserID");
        }
    }
}
