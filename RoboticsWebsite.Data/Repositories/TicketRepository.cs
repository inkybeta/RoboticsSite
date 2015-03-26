using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboticsWebsite.Core.Models;

namespace RoboticsWebsite.Data.Repositories
{
	public class TicketRepository : IRepository<string, Ticket>
	{
		private readonly RoboticsContext _context;

		public DbSet<Ticket> Set
		{
			get { return _context.Tickets; }
			set { _context.Tickets = value; }
		}

		public TicketRepository(RoboticsContext context)
		{
			_context = context;
		}

		public async Task<bool> Contains(string key, object value)
		{
			return (await _context.Tickets.Where(c => c.GetType().GetProperty(key).GetValue(c, null) == value).ToArrayAsync()).Length != 0;
		}

		public async Task<Ticket[]> All()
		{
			return await _context.Tickets.Where(c => true).ToArrayAsync();
		}

		public async Task Add(Ticket add)
		{
			_context.Tickets.Add(add);
			await _context.SaveChangesAsync();
		}

		public async Task Update(Ticket update)
		{
			_context.Tickets.Attach(update);
			_context.Entry(update).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task Remove(string remove)
		{
			_context.Tickets.Remove(await Fetch(remove));
			await _context.SaveChangesAsync();
		}

		public async Task<bool> Contains(Ticket Object)
		{
			return await _context.Tickets.ContainsAsync(Object);
		}

		public async Task<bool> Contains(string key)
		{
			return (await _context.Tickets.Where(c => c.Code == key).ToArrayAsync()).Length != 0;
		}

		public async Task<Ticket> Fetch(string id)
		{
			return await _context.Tickets.FindAsync(id);
		}

		public async Task<Ticket[]> Search(Dictionary<string, object> values)
		{
			IQueryable<Ticket> tracker = null;
			foreach (var kvp in values)
			{
				KeyValuePair<string, object> local = kvp;
				if (tracker == null)
				{
					tracker = _context.Tickets.Where(c => c.GetType().GetProperty(local.Key).GetValue(c, null) == local.Value);
					continue;
				}
				tracker = tracker.Where(c => c.GetType().GetProperty(local.Key).GetValue(c, null) == local.Value);
			}
			return await tracker.ToArrayAsync();
		}

		public async Task<Ticket[]> Search(string key, object value)
		{
			return await _context.Tickets.Where(c => c.GetType().GetProperty(key).GetValue(c) == value).ToArrayAsync();
		}
	}
}
