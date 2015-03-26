using System.Threading.Tasks;
using RoboticsWebsite.Core.Models;

namespace RoboticsWebsite.Business.Interfaces
{
	public interface ITeamService
	{
		Task Add(Team model);
		Task Update(Team model);
		Task<bool> Contains(string teamName);
		Task Delete(Team team);
		Task Delete(string teamName);
		Task<Team> Fetch(string teamName);
		Task<Team[]> All();
	}
}