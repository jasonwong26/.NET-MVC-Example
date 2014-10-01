namespace KeyRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        EmployeeNo = c.String(maxLength: 4000),
                        LastName = c.String(maxLength: 4000),
                        FirstName = c.String(maxLength: 4000),
                        RequestDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID);
            
            CreateTable(
                "dbo.RequestSets",
                c => new
                    {
                        RequestID = c.Int(nullable: false),
                        RoomID = c.Int(nullable: false),
                        Sets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RequestID, t.RoomID })
                .ForeignKey("dbo.Requests", t => t.RequestID, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.RequestID)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 4000),
                        Location = c.String(maxLength: 4000),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoomID);
            
            CreateTable(
                "dbo.Keys",
                c => new
                    {
                        KeyID = c.Int(nullable: false, identity: true),
                        Tag = c.String(maxLength: 4000),
                        RoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeyID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.RoomID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Keys", new[] { "RoomID" });
            DropIndex("dbo.RequestSets", new[] { "RoomID" });
            DropIndex("dbo.RequestSets", new[] { "RequestID" });
            DropForeignKey("dbo.Keys", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.RequestSets", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.RequestSets", "RequestID", "dbo.Requests");
            DropTable("dbo.Keys");
            DropTable("dbo.Rooms");
            DropTable("dbo.RequestSets");
            DropTable("dbo.Requests");
        }
    }
}
