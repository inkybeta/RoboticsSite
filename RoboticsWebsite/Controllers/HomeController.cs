using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RoboticsWebsite.Business.Services;
using RoboticsWebsite.Core.Models;

namespace RoboticsWebsite.Controllers
{
	public class HomeController : Controller
	{
		private OrderService _service;
		private UserManager<User> _manager; 
		public HomeController(OrderService service, UserManager<User> manager)
		{
			_service = service;
			_manager = manager;
		}
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[Authorize]
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}