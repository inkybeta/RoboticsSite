namespace RoboticsWebsite.Data.Migrations
{
	using System.Data.Entity.Migrations;
    
    public partial class addTickets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Code = c.String(nullable: false, maxLength: 128),
                        AuthenticationLevel = c.String(nullable: false),
                        Assigner = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tickets");
        }
    }
}
