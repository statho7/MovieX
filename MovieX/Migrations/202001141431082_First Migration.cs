namespace MovieX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Chats", "ReceiverId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Chats", "SenderId", "dbo.AspNetUsers");
            DropIndex("dbo.Chats", new[] { "SenderId" });
            DropIndex("dbo.Chats", new[] { "ReceiverId" });
            DropTable("dbo.Chats");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SenderId = c.String(nullable: false, maxLength: 128),
                        ReceiverId = c.String(nullable: false, maxLength: 128),
                        SentTime = c.DateTime(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 255),
                        Message = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Chats", "ReceiverId");
            CreateIndex("dbo.Chats", "SenderId");
            AddForeignKey("dbo.Chats", "SenderId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Chats", "ReceiverId", "dbo.AspNetUsers", "Id");
        }
    }
}
