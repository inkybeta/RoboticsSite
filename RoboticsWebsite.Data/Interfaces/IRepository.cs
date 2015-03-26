using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace RoboticsWebsite.Data
{
	public interface IRepository<in TKey, TObject> where TObject : class
	{
		Task Add(TObject add);
		Task Remove(TKey remove);
		Task Update(TObject update);
		Task<TObject> Fetch(TKey id);
		Task<TObject[]> Search(Dictionary<string, object> values);
		Task<TObject[]> Search(string key, object value);
		Task<bool> Contains(TKey key);
		Task<bool> Contains(TObject Object);
		Task<bool> Contains(string key, object value);
		Task<TObject[]> All();
		DbSet<TObject> Set();
	}
}