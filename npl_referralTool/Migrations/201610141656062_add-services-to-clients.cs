namespace npl_referralTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addservicestoclients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceCategories", "RegisteredClient_RegisteredClientID", c => c.Int());
            AlterColumn("dbo.ServiceCategories", "ServiceDescription", c => c.String());
            CreateIndex("dbo.ServiceCategories", "RegisteredClient_RegisteredClientID");
            AddForeignKey("dbo.ServiceCategories", "RegisteredClient_RegisteredClientID", "dbo.RegisteredClients", "RegisteredClientID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceCategories", "RegisteredClient_RegisteredClientID", "dbo.RegisteredClients");
            DropIndex("dbo.ServiceCategories", new[] { "RegisteredClient_RegisteredClientID" });
            AlterColumn("dbo.ServiceCategories", "ServiceDescription", c => c.String(nullable: false));
            DropColumn("dbo.ServiceCategories", "RegisteredClient_RegisteredClientID");
        }
    }
}
