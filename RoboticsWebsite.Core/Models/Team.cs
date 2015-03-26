using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RoboticsWebsite.Core.Models
{
	public class Team
	{
		[Key]
		[Required]
		public string TeamName { get; set; }
		public virtual IQueryable<Order> OrdersPlaced { get; set; }
		public virtual IQueryable<Order> Recieved { get; set; }
		public virtual IQueryable<User> Members { get; set; } 
	}
}
