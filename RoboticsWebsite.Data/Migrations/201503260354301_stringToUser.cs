namespace RoboticsWebsite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Assigner_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Tickets", "Assigner_Id");
            AddForeignKey("dbo.Tickets", "Assigner_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Tickets", "Assigner");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Assigner", c => c.String(nullable: false));
            DropForeignKey("dbo.Tickets", "Assigner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Tickets", new[] { "Assigner_Id" });
            DropColumn("dbo.Tickets", "Assigner_Id");
        }
    }
}
