using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RoboticsWebsite.Core.Models
{
	public class Commit
	{
		[Key]
		public long Identity { get; set; }
		[Required]
		public bool IsOrdered { get; set; }
		[Required]
		public bool IsRecieved { get; set; }
		[Required]
		public ICollection<string> TrackingIdentities { get; set; }
		[Required]
		public virtual IQueryable<Order> Orders { get; set; }
		[Required]
		[DataType(DataType.Html)]
		[DefaultValue("No notes for commit")]
		public string FootNotes { get; set; }
	}
}
