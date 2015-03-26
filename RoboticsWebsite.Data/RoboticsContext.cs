using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using RoboticsWebsite.Core;
using RoboticsWebsite.Core.Models;

namespace RoboticsWebsite.Data
{
	public class RoboticsContext : IdentityDbContext<User>, IRepository<long, Order>, IRepository<string, Team>, IRepository<string, Ticket>
	{
		public DbSet<Team> Teams { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public RoboticsContext()
			: base("RoboticsDatabase")
		{
		}

		public async Task Add(Order add)
		{
			Orders.AddOrUpdate(add);
			await SaveChangesAsync();
		}

		public async Task Remove(long remove)
		{
			Orders.Remove(Orders.Find(remove));
			await SaveChangesAsync();
		}

		public async Task Update(Order update)
		{
			Orders.Attach(update);
			Entry(update).State = EntityState.Modified;
			await SaveChangesAsync();
		}

		public async Task<Order> Fetch(long id)
		{
			return await Orders.FindAsync(id);
		}

		async Task<Ticket> IRepository<string, Ticket>.Fetch(string id)
		{
			return await Tickets.FindAsync(id);
		}

		public Task<Ticket[]> Search(Dictionary<string, object> values)
		{
			throw new System.NotImplementedException();
		}

		public Task<Ticket[]> Search(string key, object value)
		{
			throw new System.NotImplementedException();
		}

		async Task<Order[]> IRepository<long, Order>.Search(Dictionary<string, object> values)
		{
			IQueryable<Order> tracker = null;
			foreach (var kvp in values)
			{
				KeyValuePair<string, object> local = kvp;
				if (tracker == null)
				{
					tracker = Orders.Where(c => c.GetType().GetProperty(local.Key).GetValue(c, null) == local.Value);
					continue;
				}
				tracker = tracker.Where(c => c.GetType().GetProperty(local.Key).GetValue(c, null) == local.Value);
			}
			return await tracker.ToArrayAsync();
		}

		async Task<Order[]> IRepository<long, Order>.Search(string key, object value)
		{
			return await Orders.Where(c => c.GetType().GetProperty(key).GetValue(c, null) == value).ToArrayAsync();
		}


		public async Task<bool> Contains(long key)
		{
			return (await Orders.Where(c => c.Identity == key).ToArrayAsync()).Length == 0;
		}

		public async Task<bool> Contains(Order Object)
		{
			return await Orders.ContainsAsync(Object);
		}

		public async Task<bool> Contains(Ticket Object)
		{
			return await Tickets.ContainsAsync(Object);
		}

		public async Task<bool> Contains(string key, object value)
		{
			return (await Tickets.Where(c => c.GetType().GetProperty(key).GetValue(c, null) == value).ToArrayAsync()).Length != 0;
		}

		public Task<Ticket[]> All()
		{
			throw new System.NotImplementedException();
		}

		DbSet<Ticket> IRepository<string, Ticket>.Set()
		{
			throw new System.NotImplementedException();
		}

		async Task<bool> IRepository<long, Order>.Contains(string key, object value)
		{
			return (await Orders.Where(c => c.GetType().GetProperty(key).GetValue(c, null) == value).ToArrayAsync()).Length != 0;
		}

		async Task<Order[]> IRepository<long, Order>.All()
		{
			return (await Orders.Where(c => true).ToArrayAsync());
		}

		public DbSet<Order> Set()
		{
			return Orders;
		}


		// For the teams repository
		public async Task Add(Team add)
		{
			Teams.AddOrUpdate(add);
			await SaveChangesAsync();
		}

		public async Task Add(Ticket add)
		{
			Tickets.Add(add);
			await SaveChangesAsync();
		}

		public async Task Remove(string remove)
		{
			Team teamToBeRemoved = await Teams.FindAsync(remove);
			Teams.Remove(teamToBeRemoved);
			await SaveChangesAsync();
		}

		public Task Update(Ticket update)
		{
			throw new System.NotImplementedException();
		}

		public async Task Update(Team update)
		{
			Teams.Attach(update);
			Entry(update).State = EntityState.Modified;
			await SaveChangesAsync();
		}

		public async Task<Team> Fetch(string id)
		{
			return await Teams.FindAsync(id);
		}

		public async Task<bool> Contains(string key)
		{
			return (await Teams.Where(c => c.TeamName == key).ToArrayAsync()).Length == 0;
		}

		public async Task<bool> Contains(Team Object)
		{
			return (await Teams.ContainsAsync(Object));
		}


		async Task<Team[]> IRepository<string, Team>.Search(string key, object value)
		{
			return await Teams.Where(c => c.GetType().GetProperty(key).GetValue(c, null) == value).ToArrayAsync();
		}

		async Task<Team[]> IRepository<string, Team>.Search(Dictionary<string, object> values)
		{
			IQueryable<Team> tracker = null;
			foreach (var kvp in values)
			{
				KeyValuePair<string, object> local = kvp;
				if (tracker == null)
				{
					tracker = Teams.Where(c => c.GetType().GetProperty(local.Key).GetValue(c, null) == local.Value);
					continue;
				}
				tracker = tracker.Where(c => c.GetType().GetProperty(local.Key).GetValue(c, null) == local.Value);
			}
			return await tracker.ToArrayAsync();
		}

		DbSet<Team> IRepository<string, Team>.Set()
		{
			return Teams;
		}

		async Task<bool> IRepository<string, Team>.Contains(string key, object value)
		{
			return (await Teams.Where(c => c.GetType().GetProperty(key).GetValue(c, null) == value).ToArrayAsync()).Length != 0;
		}

		async Task<Team[]> IRepository<string, Team>.All()
		{
			return await Teams.Where(c => true).ToArrayAsync();
		}
	}
}
