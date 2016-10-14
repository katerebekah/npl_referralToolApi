namespace npl_referralTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agencies",
                c => new
                    {
                        AgencyID = c.Int(nullable: false, identity: true),
                        AgencyName = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        AreaCode = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        PrimaryContactLastName = c.String(nullable: false),
                        PrimaryContactFirstName = c.String(nullable: false),
                        AltContactLastName = c.String(),
                        AltContactFirstName = c.String(),
                        AgencyActiveIndicator = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AgencyID);
            
            CreateTable(
                "dbo.ServiceCategories",
                c => new
                    {
                        ServiceCategoryID = c.Int(nullable: false, identity: true),
                        ServiceCategoryName = c.String(nullable: false),
                        ServiceDescription = c.String(nullable: false),
                        ActiveIndicator = c.Boolean(nullable: false),
                        Agency_AgencyID = c.Int(),
                        AgencyEmployee_EmployeeID = c.Int(),
                    })
                .PrimaryKey(t => t.ServiceCategoryID)
                .ForeignKey("dbo.Agencies", t => t.Agency_AgencyID)
                .ForeignKey("dbo.AgencyEmployees", t => t.AgencyEmployee_EmployeeID)
                .Index(t => t.Agency_AgencyID)
                .Index(t => t.AgencyEmployee_EmployeeID);
            
            CreateTable(
                "dbo.AgencyEmployees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        EmailAddress = c.String(nullable: false),
                        AreaCode = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 8),
                        Agency_AgencyID = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Agencies", t => t.Agency_AgencyID)
                .Index(t => t.Agency_AgencyID);
            
            CreateTable(
                "dbo.Referrals",
                c => new
                    {
                        ReferralID = c.Int(nullable: false, identity: true),
                        DateRequested = c.DateTime(nullable: false),
                        DateServiceRendered = c.DateTime(nullable: false),
                        ServiceRendered = c.Boolean(nullable: false),
                        ServiceInProgress = c.Boolean(nullable: false),
                        Agency_AgencyID = c.Int(),
                        AgencyEmployee_EmployeeID = c.Int(),
                        RegisteredClient_RegisteredClientID = c.Int(nullable: false),
                        ServiceCategory_ServiceCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReferralID)
                .ForeignKey("dbo.Agencies", t => t.Agency_AgencyID)
                .ForeignKey("dbo.AgencyEmployees", t => t.AgencyEmployee_EmployeeID)
                .ForeignKey("dbo.RegisteredClients", t => t.RegisteredClient_RegisteredClientID, cascadeDelete: true)
                .ForeignKey("dbo.ServiceCategories", t => t.ServiceCategory_ServiceCategoryID, cascadeDelete: true)
                .Index(t => t.Agency_AgencyID)
                .Index(t => t.AgencyEmployee_EmployeeID)
                .Index(t => t.RegisteredClient_RegisteredClientID)
                .Index(t => t.ServiceCategory_ServiceCategoryID);
            
            CreateTable(
                "dbo.RegisteredClients",
                c => new
                    {
                        RegisteredClientID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(),
                        AreaCode = c.Int(nullable: false),
                        PhoneNumber1 = c.String(nullable: false, maxLength: 8),
                        AreaCode2 = c.Int(nullable: false),
                        PhoneNumber2 = c.String(maxLength: 8),
                        EmailAddress = c.String(),
                        StreetAddress = c.String(),
                        HouseNumber = c.String(),
                        ZipCode = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.RegisteredClientID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsAdministrator = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Referrals", "ServiceCategory_ServiceCategoryID", "dbo.ServiceCategories");
            DropForeignKey("dbo.Referrals", "RegisteredClient_RegisteredClientID", "dbo.RegisteredClients");
            DropForeignKey("dbo.Referrals", "AgencyEmployee_EmployeeID", "dbo.AgencyEmployees");
            DropForeignKey("dbo.Referrals", "Agency_AgencyID", "dbo.Agencies");
            DropForeignKey("dbo.ServiceCategories", "AgencyEmployee_EmployeeID", "dbo.AgencyEmployees");
            DropForeignKey("dbo.AgencyEmployees", "Agency_AgencyID", "dbo.Agencies");
            DropForeignKey("dbo.ServiceCategories", "Agency_AgencyID", "dbo.Agencies");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Referrals", new[] { "ServiceCategory_ServiceCategoryID" });
            DropIndex("dbo.Referrals", new[] { "RegisteredClient_RegisteredClientID" });
            DropIndex("dbo.Referrals", new[] { "AgencyEmployee_EmployeeID" });
            DropIndex("dbo.Referrals", new[] { "Agency_AgencyID" });
            DropIndex("dbo.AgencyEmployees", new[] { "Agency_AgencyID" });
            DropIndex("dbo.ServiceCategories", new[] { "AgencyEmployee_EmployeeID" });
            DropIndex("dbo.ServiceCategories", new[] { "Agency_AgencyID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RegisteredClients");
            DropTable("dbo.Referrals");
            DropTable("dbo.AgencyEmployees");
            DropTable("dbo.ServiceCategories");
            DropTable("dbo.Agencies");
        }
    }
}
