namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "HeadingId", c => c.Int());
            CreateIndex("dbo.Contents", "HeadingId");
            AddForeignKey("dbo.Contents", "HeadingId", "dbo.Headings", "HeadingId");
         
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Contents", "HeadingId", "dbo.Headings");
            DropIndex("dbo.Contents", new[] { "HeadingId" });
            DropIndex("dbo.Headings", new[] { "CategoryId" });
            AlterColumn("dbo.Headings", "CategoryId", c => c.Int());
            AlterColumn("dbo.Headings", "HeadingName", c => c.String());
            DropColumn("dbo.Contents", "HeadingId");
            RenameColumn(table: "dbo.Headings", name: "CategoryId", newName: "Category_CategoryId");
            CreateIndex("dbo.Headings", "Category_CategoryId");
            AddForeignKey("dbo.Headings", "Category_CategoryId", "dbo.Categories", "CategoryId");
        }
    }
}
