using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RoboticsWebsite.Core.Models
{
    public class User : IdentityUser
    {
		[Required]
		public string Name { get; set; }
		[Required]
		public Team TeamName { get; set; }
		public virtual IQueryable<Order> OrdersPlaced { get; set; }

	    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
	    {
		    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
		    return userIdentity;
	    }
    }
}
