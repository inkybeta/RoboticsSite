using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using RoboticsWebsite.Core.Models;

namespace RoboticsWebsite.Data
{
	public class RoboticsContext : IdentityDbContext<User>
	{
		public DbSet<Team> Teams { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<Commit> Commits { get; set; }
		public RoboticsContext()
			: base("RoboticsDatabase")
		{
		}
	}
}
