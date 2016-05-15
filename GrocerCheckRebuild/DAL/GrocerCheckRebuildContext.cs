using GrocerCheckRebuild.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GrocerCheckRebuild.DAL
{
    public class GrocerCheckRebuildContext:DbContext
    {

        public GrocerCheckRebuildContext():base("DefaultConnection")
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Grocer> Grocers { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<SizeType> SizeTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                .HasMany(c => c.Sizes).WithMany(i => i.Users)
                .Map(t => t.MapLeftKey("UserID")
                .MapRightKey("SizeID")
                .ToTable("UserSize"));

            modelBuilder.Entity<User>()
                .HasMany(c => c.Brands).WithMany(i => i.Users)
                .Map(t => t.MapLeftKey("UserID")
                .MapRightKey("BrandID")
                .ToTable("UserBrand"));

            modelBuilder.Entity<User>()
              .HasMany(c => c.Grocers).WithMany(i => i.Users)
              .Map(t => t.MapLeftKey("UserID")
              .MapRightKey("GrocerID")
              .ToTable("UserGrocer"));
            
        }
    }
}