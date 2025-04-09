using CopilotSportsApi.Data.Repositories;
using CopilotSportsApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopilotSportsApi.Services
{
    /// <summary>
    /// Service interface for player operations
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Gets all players
        /// </summary>
        /// <returns>Collection of all players</returns>
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        
        /// <summary>
        /// Gets a player by ID
        /// </summary>
        /// <param name="id">ID of the player</param>
        /// <returns>Player with the specified ID, or null if not found</returns>
        Task<Player> GetPlayerByIdAsync(int id);
        
        /// <summary>
        /// Gets a player by ID including their team
        /// </summary>
        /// <param name="id">ID of the player</param>
        /// <returns>Player with the specified ID including their team, or null if not found</returns>
        Task<Player> GetPlayerWithTeamAsync(int id);
        
        /// <summary>
        /// Gets players by team ID
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Collection of players for the specified team</returns>
        Task<IEnumerable<Player>> GetPlayersByTeamIdAsync(int teamId);
        
        /// <summary>
        /// Gets players by position
        /// </summary>
        /// <param name="position">Position to filter by</param>
        /// <returns>Collection of players with the specified position</returns>
        Task<IEnumerable<Player>> GetPlayersByPositionAsync(string position);
        
        /// <summary>
        /// Creates a new player
        /// </summary>
        /// <param name="player">Player to create</param>
        /// <returns>Created player</returns>
        Task<Player> CreatePlayerAsync(Player player);
        
        /// <summary>
        /// Updates an existing player
        /// </summary>
        /// <param name="id">ID of the player to update</param>
        /// <param name="player">Updated player data</param>
        /// <returns>Updated player, or null if the player was not found</returns>
        Task<Player> UpdatePlayerAsync(int id, Player player);
        
        /// <summary>
        /// Deletes a player
        /// </summary>
        /// <param name="id">ID of the player to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        Task<bool> DeletePlayerAsync(int id);
    }

    /// <summary>
    /// Service implementation for player operations
    /// </summary>
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ILogger<PlayerService> _logger;

        /// <summary>
        /// Constructor for PlayerService
        /// </summary>
        /// <param name="playerRepository">Player repository</param>
        /// <param name="logger">Logger</param>
        public PlayerService(IPlayerRepository playerRepository, ILogger<PlayerService> logger)
        {
            _playerRepository = playerRepository;
            _logger = logger;
        }

        /// <summary>
        /// Gets all players
        /// </summary>
        /// <returns>Collection of all players</returns>
        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            try
            {
                return await _playerRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all players");
                throw;
            }
        }

        /// <summary>
        /// Gets a player by ID
        /// </summary>
        /// <param name="id">ID of the player</param>
        /// <returns>Player with the specified ID, or null if not found</returns>
        public async Task<Player> GetPlayerByIdAsync(int id)
        {
            try
            {
                return await _playerRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting player with ID {PlayerId}", id);
                throw;
            }
        }

        /// <summary>
        /// Gets a player by ID including their team
        /// </summary>
        /// <param name="id">ID of the player</param>
        /// <returns>Player with the specified ID including their team, or null if not found</returns>
        public async Task<Player> GetPlayerWithTeamAsync(int id)
        {
            try
            {
                return await _playerRepository.GetPlayerWithTeamAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting player with team for player ID {PlayerId}", id);
                throw;
            }
        }

        /// <summary>
        /// Gets players by team ID
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Collection of players for the specified team</returns>
        public async Task<IEnumerable<Player>> GetPlayersByTeamIdAsync(int teamId)
        {
            try
            {
                return await _playerRepository.GetPlayersByTeamIdAsync(teamId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting players for team ID {TeamId}", teamId);
                throw;
            }
        }

        /// <summary>
        /// Gets players by position
        /// </summary>
        /// <param name="position">Position to filter by</param>
        /// <returns>Collection of players with the specified position</returns>
        public async Task<IEnumerable<Player>> GetPlayersByPositionAsync(string position)
        {
            try
            {
                return await _playerRepository.GetPlayersByPositionAsync(position);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting players for position {Position}", position);
                throw;
            }
        }

        /// <summary>
        /// Creates a new player
        /// </summary>
        /// <param name="player">Player to create</param>
        /// <returns>Created player</returns>
        public async Task<Player> CreatePlayerAsync(Player player)
        {
            try
            {
                return await _playerRepository.AddAsync(player);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating player {PlayerName}", $"{player.FirstName} {player.LastName}");
                throw;
            }
        }

        /// <summary>
        /// Updates an existing player
        /// </summary>
        /// <param name="id">ID of the player to update</param>
        /// <param name="player">Updated player data</param>
        /// <returns>Updated player, or null if the player was not found</returns>
        public async Task<Player> UpdatePlayerAsync(int id, Player player)
        {
            try
            {
                var existingPlayer = await _playerRepository.GetByIdAsync(id);
                if (existingPlayer == null)
                {
                    return null;
                }

                player.Id = id;
                return await _playerRepository.UpdateAsync(player);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating player with ID {PlayerId}", id);
                throw;
            }
        }

        /// <summary>
        /// Deletes a player
        /// </summary>
        /// <param name="id">ID of the player to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public async Task<bool> DeletePlayerAsync(int id)
        {
            try
            {
                return await _playerRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting player with ID {PlayerId}", id);
                throw;
            }
        }
    }
}
