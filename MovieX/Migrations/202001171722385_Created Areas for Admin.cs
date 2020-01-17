namespace MovieX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAreasforAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Thumbnail", c => c.String());
            AlterColumn("dbo.Movies", "Title", c => c.String());
            AlterColumn("dbo.Movies", "Description", c => c.String());
            DropColumn("dbo.Movies", "ImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "ImagePath", c => c.String());
            AlterColumn("dbo.Movies", "Description", c => c.String(maxLength: 255));
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Movies", "Thumbnail");
        }
    }
}
