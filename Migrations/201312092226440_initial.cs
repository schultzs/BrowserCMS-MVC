namespace BrowserCMS_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        AddressType_Id = c.Int(),
                        Contact_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressType", t => t.AddressType_Id)
                .ForeignKey("dbo.Contact", t => t.Contact_Id, cascadeDelete: true)
                .Index(t => t.AddressType_Id)
                .Index(t => t.Contact_Id);
            
            CreateTable(
                "dbo.AddressType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 40),
                        DateLastContacted = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Company_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.Company_Id, cascadeDelete: true)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Contact_Id = c.Int(nullable: false),
                        EmailType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.Contact_Id, cascadeDelete: true)
                .ForeignKey("dbo.EmailType", t => t.EmailType_Id)
                .Index(t => t.Contact_Id)
                .Index(t => t.EmailType_Id);
            
            CreateTable(
                "dbo.EmailType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Contact_Id = c.Int(nullable: false),
                        PhoneType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.Contact_Id, cascadeDelete: true)
                .ForeignKey("dbo.PhoneType", t => t.PhoneType_Id)
                .Index(t => t.Contact_Id)
                .Index(t => t.PhoneType_Id);
            
            CreateTable(
                "dbo.PhoneType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneTypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "Contact_Id", "dbo.Contact");
            DropForeignKey("dbo.Phone", "PhoneType_Id", "dbo.PhoneType");
            DropForeignKey("dbo.Phone", "Contact_Id", "dbo.Contact");
            DropForeignKey("dbo.Email", "EmailType_Id", "dbo.EmailType");
            DropForeignKey("dbo.Email", "Contact_Id", "dbo.Contact");
            DropForeignKey("dbo.Contact", "Company_Id", "dbo.Company");
            DropForeignKey("dbo.Address", "AddressType_Id", "dbo.AddressType");
            DropIndex("dbo.Address", new[] { "Contact_Id" });
            DropIndex("dbo.Phone", new[] { "PhoneType_Id" });
            DropIndex("dbo.Phone", new[] { "Contact_Id" });
            DropIndex("dbo.Email", new[] { "EmailType_Id" });
            DropIndex("dbo.Email", new[] { "Contact_Id" });
            DropIndex("dbo.Contact", new[] { "Company_Id" });
            DropIndex("dbo.Address", new[] { "AddressType_Id" });
            DropTable("dbo.PhoneType");
            DropTable("dbo.Phone");
            DropTable("dbo.EmailType");
            DropTable("dbo.Email");
            DropTable("dbo.Company");
            DropTable("dbo.Contact");
            DropTable("dbo.AddressType");
            DropTable("dbo.Address");
        }
    }
}
