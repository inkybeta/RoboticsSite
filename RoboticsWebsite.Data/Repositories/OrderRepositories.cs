using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using RoboticsWebsite.Core.Models;

namespace RoboticsWebsite.Data.Repositories
{
	public class OrderRepository : IRepository<long, Order>
	{
		private readonly RoboticsContext _context;

		public OrderRepository(RoboticsContext context)
		{
			_context = context;
		}

		public async Task Add(Order add)
		{
			_context.Orders.AddOrUpdate(add);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Order update)
		{
			_context.Orders.Attach(update);
			_context.Entry(update).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task Remove(long remove)
		{
			_context.Orders.Remove(_context.Orders.Find(remove));
			await _context.SaveChangesAsync();
		}

		public async Task<Order> Fetch(long id)
		{
			return await _context.Orders.FindAsync(id);
		}

		public async Task<bool> Contains(string key, object value)
		{
			return (await _context.Orders.Where(c => c.GetType().GetProperty(key).GetValue(c, null) == value).ToArrayAsync()).Length != 0;
		}

		public async Task<bool> Contains(long key)
		{
			return (await _context.Orders.Where(c => c.Identity == key).ToArrayAsync()).Length == 0;
		}

		public async Task<bool> Contains(Order Object)
		{
			return await _context.Orders.ContainsAsync(Object);
		}

		public async Task<Order[]> Search(Dictionary<string, object> values)
		{
			IQueryable<Order> tracker = null;
			foreach (var kvp in values)
			{
				KeyValuePair<string, object> local = kvp;
				if (tracker == null)
				{
					tracker = _context.Orders.Where(c => c.GetType().GetProperty(local.Key).GetValue(c, null) == local.Value);
					continue;
				}
				tracker = tracker.Where(c => c.GetType().GetProperty(local.Key).GetValue(c, null) == local.Value);
			}
			return await tracker.ToArrayAsync();
		}

		public async Task<Order[]> Search(string key, object value)
		{
			return await _context.Orders.Where(c => c.GetType().GetProperty(key).GetValue(c, null) == value).ToArrayAsync();
		}

		public DbSet<Order> Set()
		{
			return _context.Orders;
		}

		public async Task<Order[]> All()
		{
			return (await _context.Orders.Where(c => true).ToArrayAsync());
		}
	}
}
