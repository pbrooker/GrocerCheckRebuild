namespace GrocerCheckRebuild.Migrations.GrocerCheckRebuildMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedNavigation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryBrand",
                c => new
                    {
                        Category_CategoryID = c.Int(nullable: false),
                        Brand_BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_CategoryID, t.Brand_BrandID })
                .ForeignKey("dbo.Category", t => t.Category_CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Brand", t => t.Brand_BrandID, cascadeDelete: true)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.Brand_BrandID);
            
            CreateTable(
                "dbo.GrocerBrand",
                c => new
                    {
                        Grocer_GrocerID = c.Int(nullable: false),
                        Brand_BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Grocer_GrocerID, t.Brand_BrandID })
                .ForeignKey("dbo.Grocer", t => t.Grocer_GrocerID, cascadeDelete: true)
                .ForeignKey("dbo.Brand", t => t.Brand_BrandID, cascadeDelete: true)
                .Index(t => t.Grocer_GrocerID)
                .Index(t => t.Brand_BrandID);
            
            CreateTable(
                "dbo.GrocerCategory",
                c => new
                    {
                        Grocer_GrocerID = c.Int(nullable: false),
                        Category_CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Grocer_GrocerID, t.Category_CategoryID })
                .ForeignKey("dbo.Grocer", t => t.Grocer_GrocerID, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_CategoryID, cascadeDelete: true)
                .Index(t => t.Grocer_GrocerID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.SizeBrand",
                c => new
                    {
                        Size_SizeID = c.Int(nullable: false),
                        Brand_BrandID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Size_SizeID, t.Brand_BrandID })
                .ForeignKey("dbo.Size", t => t.Size_SizeID, cascadeDelete: true)
                .ForeignKey("dbo.Brand", t => t.Brand_BrandID, cascadeDelete: true)
                .Index(t => t.Size_SizeID)
                .Index(t => t.Brand_BrandID);
            
            CreateTable(
                "dbo.SizeCategory",
                c => new
                    {
                        Size_SizeID = c.Int(nullable: false),
                        Category_CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Size_SizeID, t.Category_CategoryID })
                .ForeignKey("dbo.Size", t => t.Size_SizeID, cascadeDelete: true)
                .ForeignKey("dbo.Category", t => t.Category_CategoryID, cascadeDelete: true)
                .Index(t => t.Size_SizeID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.SizeGrocer",
                c => new
                    {
                        Size_SizeID = c.Int(nullable: false),
                        Grocer_GrocerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Size_SizeID, t.Grocer_GrocerID })
                .ForeignKey("dbo.Size", t => t.Size_SizeID, cascadeDelete: true)
                .ForeignKey("dbo.Grocer", t => t.Grocer_GrocerID, cascadeDelete: true)
                .Index(t => t.Size_SizeID)
                .Index(t => t.Grocer_GrocerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SizeGrocer", "Grocer_GrocerID", "dbo.Grocer");
            DropForeignKey("dbo.SizeGrocer", "Size_SizeID", "dbo.Size");
            DropForeignKey("dbo.SizeCategory", "Category_CategoryID", "dbo.Category");
            DropForeignKey("dbo.SizeCategory", "Size_SizeID", "dbo.Size");
            DropForeignKey("dbo.SizeBrand", "Brand_BrandID", "dbo.Brand");
            DropForeignKey("dbo.SizeBrand", "Size_SizeID", "dbo.Size");
            DropForeignKey("dbo.GrocerCategory", "Category_CategoryID", "dbo.Category");
            DropForeignKey("dbo.GrocerCategory", "Grocer_GrocerID", "dbo.Grocer");
            DropForeignKey("dbo.GrocerBrand", "Brand_BrandID", "dbo.Brand");
            DropForeignKey("dbo.GrocerBrand", "Grocer_GrocerID", "dbo.Grocer");
            DropForeignKey("dbo.CategoryBrand", "Brand_BrandID", "dbo.Brand");
            DropForeignKey("dbo.CategoryBrand", "Category_CategoryID", "dbo.Category");
            DropIndex("dbo.SizeGrocer", new[] { "Grocer_GrocerID" });
            DropIndex("dbo.SizeGrocer", new[] { "Size_SizeID" });
            DropIndex("dbo.SizeCategory", new[] { "Category_CategoryID" });
            DropIndex("dbo.SizeCategory", new[] { "Size_SizeID" });
            DropIndex("dbo.SizeBrand", new[] { "Brand_BrandID" });
            DropIndex("dbo.SizeBrand", new[] { "Size_SizeID" });
            DropIndex("dbo.GrocerCategory", new[] { "Category_CategoryID" });
            DropIndex("dbo.GrocerCategory", new[] { "Grocer_GrocerID" });
            DropIndex("dbo.GrocerBrand", new[] { "Brand_BrandID" });
            DropIndex("dbo.GrocerBrand", new[] { "Grocer_GrocerID" });
            DropIndex("dbo.CategoryBrand", new[] { "Brand_BrandID" });
            DropIndex("dbo.CategoryBrand", new[] { "Category_CategoryID" });
            DropTable("dbo.SizeGrocer");
            DropTable("dbo.SizeCategory");
            DropTable("dbo.SizeBrand");
            DropTable("dbo.GrocerCategory");
            DropTable("dbo.GrocerBrand");
            DropTable("dbo.CategoryBrand");
        }
    }
}
