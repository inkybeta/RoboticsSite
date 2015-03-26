using Microsoft.AspNet.Identity;
using RoboticsWebsite.Core.Models;

namespace RoboticsWebsite.Models
{
	public class ApplicationUserManager : UserManager<User>
	{
		public ApplicationUserManager(IUserStore<User> store) :
			base(store)
		{
		}
	}
}
