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

		public TicketRepository(RoboticsContext context)
		{
			_context = context;
		}

		public Task<bool> Contains(string key, object value)
		{
			throw new NotImplementedException();
		}

		public async Task<Ticket[]> All()
		{
			return await _context.Tickets.Where(c => true).ToArrayAsync();
		}

		public DbSet<Ticket> Set()
		{
			return _context.Tickets;
		}

		public async Task Add(Ticket add)
		{
			_context.Tickets.Add(add);
			await _context.SaveChangesAsync();
		}

		public Task Update(Ticket update)
		{
			throw new System.NotImplementedException();
		}

		public Task Remove(string remove)
		{
			throw new System.NotImplementedException();
		}

		public async Task<bool> Contains(Ticket Object)
		{
			return await _context.Tickets.ContainsAsync(Object);
		}

		public Task<bool> Contains(string key)
		{
			throw new System.NotImplementedException();
		}

		async Task<Ticket> IRepository<string, Ticket>.Fetch(string id)
		{
			return await _context.Tickets.FindAsync(id);
		}

		public Task<Ticket[]> Search(Dictionary<string, object> values)
		{
			throw new System.NotImplementedException();
		}

		public Task<Ticket[]> Search(string key, object value)
		{
			throw new System.NotImplementedException();
		}
	}
}
