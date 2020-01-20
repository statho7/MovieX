namespace MovieX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedandApplicationUserchanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "FirstChoice");
            DropColumn("dbo.AspNetUsers", "SecondChoice");
            DropColumn("dbo.AspNetUsers", "ThirdChoice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ThirdChoice", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "SecondChoice", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "FirstChoice", c => c.Int(nullable: false));
        }
    }
}
