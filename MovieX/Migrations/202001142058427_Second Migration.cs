namespace MovieX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "RootToDb", c => c.String());
            AddColumn("dbo.Movies", "ImagePath", c => c.String());
            AddColumn("dbo.AspNetUsers", "SubDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "IsPaid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "IsPaid");
            DropColumn("dbo.AspNetUsers", "SubDate");
            DropColumn("dbo.Movies", "ImagePath");
            DropColumn("dbo.Movies", "RootToDb");
        }
    }
}
