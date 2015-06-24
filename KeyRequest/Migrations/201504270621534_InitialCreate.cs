namespace KeyRequest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Keys",
                c => new
                    {
                        KeyID = c.Int(nullable: false, identity: true),
                        Tag = c.String(),
                        RoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeyID)
                .ForeignKey("dbo.Rooms", t => t.RoomID, cascadeDelete: true)
                .Index(t => t.RoomID);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Location = c.String(),
                        Available = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RoomID);
            
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
                "dbo.Requests",
                c => new
                    {
                        RequestID = c.Int(nullable: false, identity: true),
                        EmployeeNo = c.String(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        RequestDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequestID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestSets", "RoomID", "dbo.Rooms");
            DropForeignKey("dbo.RequestSets", "RequestID", "dbo.Requests");
            DropForeignKey("dbo.Keys", "RoomID", "dbo.Rooms");
            DropIndex("dbo.RequestSets", new[] { "RoomID" });
            DropIndex("dbo.RequestSets", new[] { "RequestID" });
            DropIndex("dbo.Keys", new[] { "RoomID" });
            DropTable("dbo.Requests");
            DropTable("dbo.RequestSets");
            DropTable("dbo.Rooms");
            DropTable("dbo.Keys");
        }
    }
}
