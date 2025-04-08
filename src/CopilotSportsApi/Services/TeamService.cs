using CopilotSportsApi.Data.Repositories;
using CopilotSportsApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopilotSportsApi.Services
{
    /// <summary>
    /// Service interface for team operations
    /// </summary>
    public interface ITeamService
    {
        /// <summary>
        /// Gets all teams
        /// </summary>
        /// <returns>Collection of all teams</returns>
        Task<IEnumerable<Team>> GetAllTeamsAsync();
        
        /// <summary>
        /// Gets a team by ID
        /// </summary>
        /// <param name="id">ID of the team</param>
        /// <returns>Team with the specified ID, or null if not found</returns>
        Task<Team> GetTeamByIdAsync(int id);
        
        /// <summary>
        /// Gets a team by ID including its players
        /// </summary>
        /// <param name="id">ID of the team</param>
        /// <returns>Team with the specified ID including its players, or null if not found</returns>
        Task<Team> GetTeamWithPlayersAsync(int id);
        
        /// <summary>
        /// Gets teams by sport
        /// </summary>
        /// <param name="sport">Sport to filter by</param>
        /// <returns>Collection of teams for the specified sport</returns>
        Task<IEnumerable<Team>> GetTeamsBySportAsync(string sport);
        
        /// <summary>
        /// Creates a new team
        /// </summary>
        /// <param name="team">Team to create</param>
        /// <returns>Created team</returns>
        Task<Team> CreateTeamAsync(Team team);
        
        /// <summary>
        /// Updates an existing team
        /// </summary>
        /// <param name="id">ID of the team to update</param>
        /// <param name="team">Updated team data</param>
        /// <returns>Updated team, or null if the team was not found</returns>
        Task<Team> UpdateTeamAsync(int id, Team team);
        
        /// <summary>
        /// Deletes a team
        /// </summary>
        /// <param name="id">ID of the team to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        Task<bool> DeleteTeamAsync(int id);
    }

    /// <summary>
    /// Service implementation for team operations
    /// </summary>
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ILogger<TeamService> _logger;

        /// <summary>
        /// Constructor for TeamService
        /// </summary>
        /// <param name="teamRepository">Team repository</param>
        /// <param name="logger">Logger</param>
        public TeamService(ITeamRepository teamRepository, ILogger<TeamService> logger)
        {
            _teamRepository = teamRepository;
            _logger = logger;
        }

        /// <summary>
        /// Gets all teams
        /// </summary>
        /// <returns>Collection of all teams</returns>
        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            try
            {
                return await _teamRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all teams");
                throw;
            }
        }

        /// <summary>
        /// Gets a team by ID
        /// </summary>
        /// <param name="id">ID of the team</param>
        /// <returns>Team with the specified ID, or null if not found</returns>
        public async Task<Team> GetTeamByIdAsync(int id)
        {
            try
            {
                return await _teamRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting team with ID {TeamId}", id);
                throw;
            }
        }

        /// <summary>
        /// Gets a team by ID including its players
        /// </summary>
        /// <param name="id">ID of the team</param>
        /// <returns>Team with the specified ID including its players, or null if not found</returns>
        public async Task<Team> GetTeamWithPlayersAsync(int id)
        {
            try
            {
                return await _teamRepository.GetTeamWithPlayersAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting team with players for team ID {TeamId}", id);
                throw;
            }
        }

        /// <summary>
        /// Gets teams by sport
        /// </summary>
        /// <param name="sport">Sport to filter by</param>
        /// <returns>Collection of teams for the specified sport</returns>
        public async Task<IEnumerable<Team>> GetTeamsBySportAsync(string sport)
        {
            try
            {
                return await _teamRepository.GetTeamsBySportAsync(sport);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting teams for sport {Sport}", sport);
                throw;
            }
        }

        /// <summary>
        /// Creates a new team
        /// </summary>
        /// <param name="team">Team to create</param>
        /// <returns>Created team</returns>
        public async Task<Team> CreateTeamAsync(Team team)
        {
            try
            {
                return await _teamRepository.AddAsync(team);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating team {TeamName}", team.Name);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing team
        /// </summary>
        /// <param name="id">ID of the team to update</param>
        /// <param name="team">Updated team data</param>
        /// <returns>Updated team, or null if the team was not found</returns>
        public async Task<Team> UpdateTeamAsync(int id, Team team)
        {
            try
            {
                var existingTeam = await _teamRepository.GetByIdAsync(id);
                if (existingTeam == null)
                {
                    return null;
                }

                team.Id = id;
                return await _teamRepository.UpdateAsync(team);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating team with ID {TeamId}", id);
                throw;
            }
        }

        /// <summary>
        /// Deletes a team
        /// </summary>
        /// <param name="id">ID of the team to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public async Task<bool> DeleteTeamAsync(int id)
        {
            try
            {
                return await _teamRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting team with ID {TeamId}", id);
                throw;
            }
        }
    }
}
