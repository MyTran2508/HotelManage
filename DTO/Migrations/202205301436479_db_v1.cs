namespace DTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employees",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EmployeeName = c.String(nullable: false),
                        Phonenumber = c.String(),
                        Address = c.String(),
                        Username = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.kind_of_rooms",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Max = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.rooms",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        KindOfRoomId = c.String(nullable: false, maxLength: 128),
                        RoomStatusId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.kind_of_rooms", t => t.KindOfRoomId, cascadeDelete: true)
                .ForeignKey("dbo.rom_status", t => t.RoomStatusId, cascadeDelete: true)
                .Index(t => t.KindOfRoomId)
                .Index(t => t.RoomStatusId);
            
            CreateTable(
                "dbo.rom_status",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.services",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        Name = c.String(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.rooms", "RoomStatusId", "dbo.rom_status");
            DropForeignKey("dbo.rooms", "KindOfRoomId", "dbo.kind_of_rooms");
            DropIndex("dbo.rooms", new[] { "RoomStatusId" });
            DropIndex("dbo.rooms", new[] { "KindOfRoomId" });
            DropIndex("dbo.employees", new[] { "Username" });
            DropTable("dbo.services");
            DropTable("dbo.rom_status");
            DropTable("dbo.rooms");
            DropTable("dbo.kind_of_rooms");
            DropTable("dbo.employees");
        }
    }
}
