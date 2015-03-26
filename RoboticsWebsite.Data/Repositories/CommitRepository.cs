using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoboticsWebsite.Core.Models;

namespace RoboticsWebsite.Data.Repositories
{
	public class CommitRepository : IRepository<long, Commit>
	{
		private readonly RoboticsContext _context;

		public DbSet<Commit> Set
		{
			get { return _context.Commits; }
			set { _context.Commits = value; }
		}

		public CommitRepository(RoboticsContext context)
		{
			_context = context;
		}

		public async Task Add(Commit add)
		{
			_context.Commits.Add(add);
			await _context.SaveChangesAsync();
		}

		public Task Remove(long remove)
		{
			throw new System.NotImplementedException();
		}

		public async Task Update(Commit update)
		{
			_context.Commits.Attach(update);
			_context.Entry(update).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		async Task<Commit> IRepository<long, Commit>.Fetch(long id)
		{
			return await _context.Commits.FindAsync(id);
		}

		Task<Commit[]> IRepository<long, Commit>.Search(Dictionary<string, object> values)
		{
			throw new System.NotImplementedException();
		}

		Task<Commit[]> IRepository<long, Commit>.Search(string key, object value)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> Contains(long key)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> Contains(Commit Object)
		{
			throw new System.NotImplementedException();
		}

		public async Task<bool> Contains(string key, object value)
		{
			return (await _context.Tickets.Where(c => c.GetType().GetProperty(key).GetValue(c, null) == value).ToArrayAsync()).Length != 0;
		}

		Task<Commit[]> IRepository<long, Commit>.All()
		{
			throw new System.NotImplementedException();
		}
	}
}
