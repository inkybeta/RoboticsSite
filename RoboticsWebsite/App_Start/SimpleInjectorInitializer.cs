using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RoboticsWebsite.Business.Interfaces;
using RoboticsWebsite.Business.Services;
using RoboticsWebsite.Core.Models;
using RoboticsWebsite.Data;
using RoboticsWebsite.Data.Repositories;

[assembly: WebActivator.PostApplicationStartMethod(typeof(RoboticsWebsite.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace RoboticsWebsite.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;

    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    
    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            // Did you know the container can diagnose your configuration? Go to: https://bit.ly/YE8OJj.
            var container = new Container();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
			var lifestyle = new WebRequestLifestyle(true);

			// Register IdentityDbContext
	        container.Register<RoboticsContext>(lifestyle);

			// Register the repositories
			container.Register<IRepository<long, Order>>(() => new OrderRepository(container.GetInstance<RoboticsContext>()), lifestyle);
			container.Register<IRepository<string, Team>>(() => new TeamRepository(container.GetInstance<RoboticsContext>()), lifestyle);
			container.Register<IRepository<string, Ticket>>(() => new TicketRepository(container.GetInstance<RoboticsContext>()), lifestyle);
			container.Register<IRepository<long, Commit>>(() => new CommitRepository(container.GetInstance<RoboticsContext>()), lifestyle);

			// Register the user and the manager
			container.Register(() => new UserStore<User>(container.GetInstance<RoboticsContext>()), lifestyle);
			container.Register(() => new UserManager<User>(container.GetInstance<UserStore<User>>()), lifestyle);

			// Register the services
			container.Register<IOrderService>(() => new OrderService(container.GetInstance<IRepository<long, Order>>()), lifestyle);
			container.Register<ITeamService>(() => new TeamService(container.GetInstance<IRepository<string, Team>>()), lifestyle);
			container.Register<ITicketService>(() => new TicketService(container.GetInstance<IRepository<string, Ticket>>()), lifestyle);
        }
    }
}