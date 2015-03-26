using System.Threading.Tasks;
using RoboticsWebsite.Core.Models;

namespace RoboticsWebsite.Business.Interfaces
{
	public interface IOrderService
	{
		Task<Order[]> NotOrdered();
		Task<Order[]> Ordered();
		Task<Order[]> OrderedByUser(User user);
		Task AddOrder(Order order);
		Task DeleteOrder(Order order);
		Task UpdateOrder(Order newOrder);
	}
}