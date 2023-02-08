namespace ICT272.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false),
                        EventTypeId = c.Int(nullable: false),
                        EventTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        Cost = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.EventId);
            
            CreateTable(
                "dbo.EventType",
                c => new
                    {
                        EventTypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.EventTypeId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.User");
            DropForeignKey("dbo.UserRoles", "RoleID", "dbo.Role");
            DropIndex("dbo.UserRoles", new[] { "RoleID" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropTable("dbo.User");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Role");
            DropTable("dbo.EventType");
            DropTable("dbo.Event");
            DropTable("dbo.Employee");
        }
    }
}
