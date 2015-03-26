using System.Threading.Tasks;
using RoboticsWebsite.Core;
using RoboticsWebsite.Core.Models;
using RoboticsWebsite.Data;

namespace RoboticsWebsite.Business.Services
{
	public class TicketService : ITicketService
	{
		private readonly IRepository<string, Ticket> _repository; 
		public TicketService(IRepository<string, Ticket> repo)
		{
			_repository = repo;
		}

		public async Task<TicketState> Validate(string code, string authenticationLevel)
		{
			var ticket = await _repository.Fetch(code);
			if (ticket == null)
			{
				return TicketState.NotFound;
			}
			if (ticket.AuthenticationLevel == authenticationLevel)
			{
				await _repository.Remove(code);
				return TicketState.Valid;
			}
			return TicketState.Invalid;
		}

		public async Task Update(string code, Ticket newTicket)
		{
			await _repository.Update(newTicket);
		}

		public async Task Add(Ticket newTicket)
		{
			await _repository.Add(newTicket);
		}

		public async Task Remove(Ticket ticket)
		{
			await _repository.Remove(ticket.Code);
		}
	}

	public enum TicketState
	{
		Invalid,
		NotFound,
		Valid
	}
}
