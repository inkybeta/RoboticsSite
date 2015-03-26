namespace RoboticsWebsite.Data.Migrations
{
	using System.Data.Entity.Migrations;
    
    public partial class addqueryable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Team_TeamName", "dbo.Teams");
            DropForeignKey("dbo.Orders", "Team_TeamName1", "dbo.Teams");
            DropIndex("dbo.Orders", new[] { "Team_TeamName" });
            DropIndex("dbo.Orders", new[] { "Team_TeamName1" });
            DropColumn("dbo.Orders", "Team_TeamName");
            DropColumn("dbo.Orders", "Team_TeamName1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Team_TeamName1", c => c.String(maxLength: 128));
            AddColumn("dbo.Orders", "Team_TeamName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Orders", "Team_TeamName1");
            CreateIndex("dbo.Orders", "Team_TeamName");
            AddForeignKey("dbo.Orders", "Team_TeamName1", "dbo.Teams", "TeamName");
            AddForeignKey("dbo.Orders", "Team_TeamName", "dbo.Teams", "TeamName");
        }
    }
}
