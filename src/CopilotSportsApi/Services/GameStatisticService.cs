using CopilotSportsApi.Data.Repositories;
using CopilotSportsApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopilotSportsApi.Services
{
    /// <summary>
    /// Service interface for game statistic operations
    /// </summary>
    public interface IGameStatisticService
    {
        /// <summary>
        /// Gets all game statistics
        /// </summary>
        /// <returns>Collection of all game statistics</returns>
        Task<IEnumerable<GameStatistic>> GetAllGameStatisticsAsync();
        
        /// <summary>
        /// Gets a game statistic by ID
        /// </summary>
        /// <param name="id">ID of the game statistic</param>
        /// <returns>Game statistic with the specified ID, or null if not found</returns>
        Task<GameStatistic> GetGameStatisticByIdAsync(int id);
        
        /// <summary>
        /// Gets statistics for a specific game
        /// </summary>
        /// <param name="gameId">ID of the game</param>
        /// <returns>Collection of statistics for the specified game</returns>
        Task<IEnumerable<GameStatistic>> GetStatisticsByGameIdAsync(int gameId);
        
        /// <summary>
        /// Gets statistics for a specific player
        /// </summary>
        /// <param name="playerId">ID of the player</param>
        /// <returns>Collection of statistics for the specified player</returns>
        Task<IEnumerable<GameStatistic>> GetStatisticsByPlayerIdAsync(int playerId);
        
        /// <summary>
        /// Gets a specific statistic by game ID and player ID
        /// </summary>
        /// <param name="gameId">ID of the game</param>
        /// <param name="playerId">ID of the player</param>
        /// <returns>Statistic for the specified game and player, or null if not found</returns>
        Task<GameStatistic> GetStatisticByGameAndPlayerAsync(int gameId, int playerId);
        
        /// <summary>
        /// Gets statistics by game ID including player and game details
        /// </summary>
        /// <param name="gameId">ID of the game</param>
        /// <returns>Collection of statistics with player and game details</returns>
        Task<IEnumerable<GameStatistic>> GetGameStatisticsAsync(int gameId);
        
        /// <summary>
        /// Creates a new game statistic
        /// </summary>
        /// <param name="gameStatistic">Game statistic to create</param>
        /// <returns>Created game statistic</returns>
        Task<GameStatistic> CreateGameStatisticAsync(GameStatistic gameStatistic);
        
        /// <summary>
        /// Updates an existing game statistic
        /// </summary>
        /// <param name="id">ID of the game statistic to update</param>
        /// <param name="gameStatistic">Updated game statistic data</param>
        /// <returns>Updated game statistic, or null if the game statistic was not found</returns>
        Task<GameStatistic> UpdateGameStatisticAsync(int id, GameStatistic gameStatistic);
        
        /// <summary>
        /// Deletes a game statistic
        /// </summary>
        /// <param name="id">ID of the game statistic to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        Task<bool> DeleteGameStatisticAsync(int id);
    }

    /// <summary>
    /// Service implementation for game statistic operations
    /// </summary>
    public class GameStatisticService : IGameStatisticService
    {
        private readonly IGameStatisticRepository _gameStatisticRepository;
        private readonly ILogger<GameStatisticService> _logger;

        /// <summary>
        /// Constructor for GameStatisticService
        /// </summary>
        /// <param name="gameStatisticRepository">Game statistic repository</param>
        /// <param name="logger">Logger</param>
        public GameStatisticService(IGameStatisticRepository gameStatisticRepository, ILogger<GameStatisticService> logger)
        {
            _gameStatisticRepository = gameStatisticRepository;
            _logger = logger;
        }

        /// <summary>
        /// Gets all game statistics
        /// </summary>
        /// <returns>Collection of all game statistics</returns>
        public async Task<IEnumerable<GameStatistic>> GetAllGameStatisticsAsync()
        {
            try
            {
                return await _gameStatisticRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all game statistics");
                throw;
            }
        }

        /// <summary>
        /// Gets a game statistic by ID
        /// </summary>
        /// <param name="id">ID of the game statistic</param>
        /// <returns>Game statistic with the specified ID, or null if not found</returns>
        public async Task<GameStatistic> GetGameStatisticByIdAsync(int id)
        {
            try
            {
                return await _gameStatisticRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting game statistic with ID {StatisticId}", id);
                throw;
            }
        }

        /// <summary>
        /// Gets statistics for a specific game
        /// </summary>
        /// <param name="gameId">ID of the game</param>
        /// <returns>Collection of statistics for the specified game</returns>
        public async Task<IEnumerable<GameStatistic>> GetStatisticsByGameIdAsync(int gameId)
        {
            try
            {
                return await _gameStatisticRepository.GetStatisticsByGameIdAsync(gameId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting statistics for game ID {GameId}", gameId);
                throw;
            }
        }

        /// <summary>
        /// Gets statistics for a specific player
        /// </summary>
        /// <param name="playerId">ID of the player</param>
        /// <returns>Collection of statistics for the specified player</returns>
        public async Task<IEnumerable<GameStatistic>> GetStatisticsByPlayerIdAsync(int playerId)
        {
            try
            {
                return await _gameStatisticRepository.GetStatisticsByPlayerIdAsync(playerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting statistics for player ID {PlayerId}", playerId);
                throw;
            }
        }

        /// <summary>
        /// Gets a specific statistic by game ID and player ID
        /// </summary>
        /// <param name="gameId">ID of the game</param>
        /// <param name="playerId">ID of the player</param>
        /// <returns>Statistic for the specified game and player, or null if not found</returns>
        public async Task<GameStatistic> GetStatisticByGameAndPlayerAsync(int gameId, int playerId)
        {
            try
            {
                return await _gameStatisticRepository.GetStatisticByGameAndPlayerAsync(gameId, playerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting statistic for game ID {GameId} and player ID {PlayerId}", gameId, playerId);
                throw;
            }
        }

        /// <summary>
        /// Gets statistics by game ID including player and game details
        /// </summary>
        /// <param name="gameId">ID of the game</param>
        /// <returns>Collection of statistics with player and game details</returns>
        public async Task<IEnumerable<GameStatistic>> GetGameStatisticsAsync(int gameId)
        {
            try
            {
                // This method is intentionally inefficient for workshop task 8
                return await _gameStatisticRepository.GetStatisticsByGameIdWithDetailsAsync(gameId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting detailed statistics for game ID {GameId}", gameId);
                throw;
            }
        }

        /// <summary>
        /// Creates a new game statistic
        /// </summary>
        /// <param name="gameStatistic">Game statistic to create</param>
        /// <returns>Created game statistic</returns>
        public async Task<GameStatistic> CreateGameStatisticAsync(GameStatistic gameStatistic)
        {
            try
            {
                return await _gameStatisticRepository.AddAsync(gameStatistic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating game statistic for player ID {PlayerId} in game ID {GameId}", 
                    gameStatistic.PlayerId, gameStatistic.GameId);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing game statistic
        /// </summary>
        /// <param name="id">ID of the game statistic to update</param>
        /// <param name="gameStatistic">Updated game statistic data</param>
        /// <returns>Updated game statistic, or null if the game statistic was not found</returns>
        public async Task<GameStatistic> UpdateGameStatisticAsync(int id, GameStatistic gameStatistic)
        {
            try
            {
                var existingStatistic = await _gameStatisticRepository.GetByIdAsync(id);
                if (existingStatistic == null)
                {
                    return null;
                }

                gameStatistic.Id = id;
                return await _gameStatisticRepository.UpdateAsync(gameStatistic);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating game statistic with ID {StatisticId}", id);
                throw;
            }
        }

        /// <summary>
        /// Deletes a game statistic
        /// </summary>
        /// <param name="id">ID of the game statistic to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public async Task<bool> DeleteGameStatisticAsync(int id)
        {
            try
            {
                return await _gameStatisticRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting game statistic with ID {StatisticId}", id);
                throw;
            }
        }
    }
}
