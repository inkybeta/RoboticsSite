namespace RoboticsWebsite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Commits",
                c => new
                    {
                        Identity = c.Long(nullable: false, identity: true),
                        IsOrdered = c.Boolean(nullable: false),
                        IsRecieved = c.Boolean(nullable: false),
                        FootNotes = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Identity);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Commits");
        }
    }
}
