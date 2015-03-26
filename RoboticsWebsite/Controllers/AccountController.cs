using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using RoboticsWebsite.Business.Interfaces;
using RoboticsWebsite.Core;
using RoboticsWebsite.Core.Models;
using RoboticsWebsite.Models;

namespace RoboticsWebsite.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<User> _manager;
		private readonly IOrderService _orderService;
		private readonly ITeamService _teamService;

		public AccountController(UserManager<User> manager, IOrderService service, ITeamService teamService)
		{
			_manager = manager;
			_orderService = service;
			_teamService = teamService;
		}

		[HttpGet]
		[RequireHttps]
		[AllowAnonymous]
		public ActionResult Login(string callBackUrl)
		{
			if (String.IsNullOrWhiteSpace(callBackUrl))
				if (Request.Url != null)
					callBackUrl = String.Concat(Request.Url.Scheme, System.Uri.SchemeDelimiter, Request.Url.Host,
						(Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port));
			return View(new LoginViewModel()
			{
				ReturnLocation = callBackUrl
			});
		}

		[HttpPost]
		[RequireHttps]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Login(LoginViewModel user)
		{
			if (!ModelState.IsValid)
				return View(user);
			var _user = await _manager.FindAsync(user.UserName, user.Password);
			if (_user == null)
			{
				ModelState.AddModelError("FormError", "Incorrect username and password combination.");
				return View(user);
			}
			await SignInAsync(_user, user.RememberMe);
			return View();
		}

		private async Task SignInAsync(User user, bool isPersistent)
		{
			
		}

		[HttpGet]
		[RequireHttps]
		[AllowAnonymous]
		public async Task<ActionResult> Register()
		{
			var teams = await _teamService.All();
			var model = new RegisterViewModel()
			{
				Teams = teams
			};
			return View(model);
		}

		[HttpPost]
		[RequireHttps]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Register(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);
			var team = await _teamService.Fetch(model.Team.TeamName);
			if (team == null)
			{
				ModelState.AddModelError("Team",
					@"No such team exists. Why are you tampering with the page? You realize that the page is cached locally right?" +
					@"and doesn't affect anything? On the flip side, if you think you are being a sneaky hacker by doing this.... *slow clap*");
				return View(model);
			}
			var newUser = new User()
			{
				TeamName = team,
				UserName = model.UserName,
				Email = model.Email,
				Name = model.Name
			};
			return RedirectToAction("Activate");
		}

		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult> Activate()
		{
			return View();
		}
	}
}