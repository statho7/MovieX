namespace MovieX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeinDatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "SubDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "SubDate", c => c.DateTime(nullable: false));
        }
    }
}
