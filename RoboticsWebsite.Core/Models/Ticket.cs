using System.ComponentModel.DataAnnotations;

namespace RoboticsWebsite.Core.Models
{
	public class Ticket
	{
		[Key]
		[Required]
		public string Code { get; set; }
		[Required]
		public string AuthenticationLevel { get; set; }
		[Required]
		public virtual User Assigner { get; set; }
	}
}
