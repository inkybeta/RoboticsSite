using System.Linq;
using System.Threading.Tasks;
using RoboticsWebsite.Business.Interfaces;
using RoboticsWebsite.Core;
using RoboticsWebsite.Core.Models;
using RoboticsWebsite.Data;

namespace RoboticsWebsite.Business.Services
{
    public class OrderService : IOrderService
    {
	    private readonly IRepository<long, Order> _repository; 
	    public OrderService(IRepository<long, Order> context)
	    {
		    _repository = context;
	    }

	    public async Task<Order[]> NotOrdered()
	    {
		    return await _repository.Search("IsOrdered", false);
	    }

	    public async Task<Order[]> Ordered()
	    {
		    return (await _repository.Search("IsOrdered", true)).OrderByDescending(c => c.DateOrdered).ToArray();
	    }

	    public async Task<Order[]> OrderedByUser(User user)
	    {
		    return await _repository.Search("OrderedByUser", user);
	    }

	    public async Task AddOrder(Order order)
	    {
		    await _repository.Add(order);
	    }

	    public async Task DeleteOrder(Order order)
	    {
		    await _repository.Remove(order.Identity);
	    }

	    public async Task UpdateOrder(Order newOrder)
	    {
		    await _repository.Update(newOrder);
	    }
    }
}
