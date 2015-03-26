using System.Threading.Tasks;
using RoboticsWebsite.Business.Interfaces;
using RoboticsWebsite.Core;
using RoboticsWebsite.Core.Models;
using RoboticsWebsite.Data;

namespace RoboticsWebsite.Business.Services
{
	public class TeamService : ITeamService
	{
		private readonly IRepository<string, Team> _teamRepository;

		public TeamService(IRepository<string, Team> teamRepository)
		{
			_teamRepository = teamRepository;
		}

		public async Task Add(Team model)
		{
			await _teamRepository.Add(model);
		}

		public async Task Update(Team model)
		{
			await _teamRepository.Update(model);
		}

		public async Task<bool> Contains(string teamName)
		{
			return await _teamRepository.Contains(teamName);
		}

		public async Task Delete(Team team)
		{
			await _teamRepository.Remove(team.TeamName);
		}

		public async Task Delete(string teamName)
		{
			await _teamRepository.Remove(teamName);
		}

		public async Task<Team> Fetch(string teamName)
		{
			return await _teamRepository.Fetch(teamName);
		}

		public async Task<Team[]> All()
		{
			return await _teamRepository.All();
		}
	}
}
