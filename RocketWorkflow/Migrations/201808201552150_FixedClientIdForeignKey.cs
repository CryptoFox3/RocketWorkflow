namespace RocketWorkflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedClientIdForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accountants",
                c => new
                    {
                        AccountantId = c.String(nullable: false, maxLength: 128),
                        ApplicationUserId = c.String(maxLength: 128),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        OfficeUserName = c.String(),
                    })
                .PrimaryKey(t => t.AccountantId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.String(nullable: false, maxLength: 128),
                        ApplicationUserId = c.String(maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        SpouseId = c.String(),
                        HouseNumber = c.Int(nullable: false),
                        StreetName = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.String(nullable: false, maxLength: 128),
                        ClientId = c.String(maxLength: 128),
                        JobName = c.String(),
                        AssignedEmployee = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        CompleteTime = c.DateTime(nullable: false),
                        Fee = c.Double(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                        IsArchived = c.Boolean(nullable: false),
                        BillingComplete = c.Boolean(nullable: false),
                        SomeProp = c.String(),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.OfficeAdmins",
                c => new
                    {
                        OfficeAdminId = c.String(nullable: false, maxLength: 128),
                        ApplicationUserId = c.String(maxLength: 128),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        OfficeUserName = c.String(),
                    })
                .PrimaryKey(t => t.OfficeAdminId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.String(nullable: false, maxLength: 128),
                        AssignedEmployee = c.String(),
                        DueDate = c.DateTime(nullable: false),
                        CompleteTime = c.DateTime(nullable: false),
                        IsComplete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficeAdmins", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Clients", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Accountants", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.OfficeAdmins", new[] { "ApplicationUserId" });
            DropIndex("dbo.Jobs", new[] { "ClientId" });
            DropIndex("dbo.Clients", new[] { "ApplicationUserId" });
            DropIndex("dbo.Accountants", new[] { "ApplicationUserId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.OfficeAdmins");
            DropTable("dbo.Jobs");
            DropTable("dbo.Clients");
            DropTable("dbo.Accountants");
        }
    }
}
