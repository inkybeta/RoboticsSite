using System.Threading.Tasks;
using RoboticsWebsite.Core.Models;

namespace RoboticsWebsite.Business.Services
{
	public interface ITicketService
	{
		Task<TicketState> Validate(string code, string authenticationLevel);
		Task Update(string code, Ticket newTicket);
		Task Add(Ticket newTicket);
		Task Remove(Ticket ticket);
	}
}