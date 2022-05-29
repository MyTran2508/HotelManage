namespace DTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee_v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.employee",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        EmployeeName = c.String(nullable: false, maxLength: 100),
                        Phonenumber = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.employee");
        }
    }
}
