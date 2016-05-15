namespace GrocerCheckRebuild.Migrations.GrocerCheckRebuildMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brand",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        Category_CategoryID = c.Int(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.BrandID)
                .ForeignKey("dbo.Category", t => t.Category_CategoryID)
                .ForeignKey("dbo.User", t => t.User_UserID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 65),
                        StandardID = c.String(),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        SizeMeasure = c.Int(nullable: false),
                        CalculatedPrice = c.Decimal(storeType: "money"),
                        SizeID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        GrocerID = c.Int(nullable: false),
                        SizeTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Brand", t => t.BrandID, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Grocer", t => t.GrocerID, cascadeDelete: true)
                .ForeignKey("dbo.Size", t => t.SizeID, cascadeDelete: true)
                .ForeignKey("dbo.SizeType", t => t.SizeTypeID, cascadeDelete: true)
                .Index(t => t.SizeID)
                .Index(t => t.BrandID)
                .Index(t => t.CategoryID)
                .Index(t => t.GrocerID)
                .Index(t => t.SizeTypeID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        Grocer_GrocerID = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryID)
                .ForeignKey("dbo.Grocer", t => t.Grocer_GrocerID)
                .Index(t => t.Grocer_GrocerID);
            
            CreateTable(
                "dbo.Grocer",
                c => new
                    {
                        GrocerID = c.Int(nullable: false, identity: true),
                        GrocerName = c.String(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.GrocerID)
                .ForeignKey("dbo.User", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Size",
                c => new
                    {
                        SizeID = c.Int(nullable: false, identity: true),
                        SizeDescription = c.String(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.SizeID)
                .ForeignKey("dbo.User", t => t.User_UserID)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.SizeType",
                c => new
                    {
                        SizeTypeID = c.Int(nullable: false, identity: true),
                        SizeTypeName = c.String(),
                    })
                .PrimaryKey(t => t.SizeTypeID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserEmail = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Size", "User_UserID", "dbo.User");
            DropForeignKey("dbo.Grocer", "User_UserID", "dbo.User");
            DropForeignKey("dbo.Brand", "User_UserID", "dbo.User");
            DropForeignKey("dbo.Item", "SizeTypeID", "dbo.SizeType");
            DropForeignKey("dbo.Item", "SizeID", "dbo.Size");
            DropForeignKey("dbo.Item", "GrocerID", "dbo.Grocer");
            DropForeignKey("dbo.Category", "Grocer_GrocerID", "dbo.Grocer");
            DropForeignKey("dbo.Item", "CategoryID", "dbo.Category");
            DropForeignKey("dbo.Brand", "Category_CategoryID", "dbo.Category");
            DropForeignKey("dbo.Item", "BrandID", "dbo.Brand");
            DropIndex("dbo.Size", new[] { "User_UserID" });
            DropIndex("dbo.Grocer", new[] { "User_UserID" });
            DropIndex("dbo.Category", new[] { "Grocer_GrocerID" });
            DropIndex("dbo.Item", new[] { "SizeTypeID" });
            DropIndex("dbo.Item", new[] { "GrocerID" });
            DropIndex("dbo.Item", new[] { "CategoryID" });
            DropIndex("dbo.Item", new[] { "BrandID" });
            DropIndex("dbo.Item", new[] { "SizeID" });
            DropIndex("dbo.Brand", new[] { "User_UserID" });
            DropIndex("dbo.Brand", new[] { "Category_CategoryID" });
            DropTable("dbo.User");
            DropTable("dbo.SizeType");
            DropTable("dbo.Size");
            DropTable("dbo.Grocer");
            DropTable("dbo.Category");
            DropTable("dbo.Item");
            DropTable("dbo.Brand");
        }
    }
}
