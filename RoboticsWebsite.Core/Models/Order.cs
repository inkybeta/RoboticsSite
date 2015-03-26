using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoboticsWebsite.Core.Models
{
	public class Order
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Identity { get; set; }
		[Required]
		public string Part { get; set; }
		[Required]
		public int Quantity { get; set; }
		[Required]
		[DataType(DataType.Currency)]
		public string Cost { get; set; }
		[Required]
		[DefaultValue(false)]
		public bool IsOrdered { get; set; }
		[Required]
		[DefaultValue(false)]
		public bool IsRecieved { get; set; }
		[Required]
		public DateTime DateOrdered { get; set; }
		public DateTime DateArrived { get; set; }
		[Required]
		public virtual User OrderedByUser { get; set; }
	}
}
