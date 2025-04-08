using CopilotSportsApi.Data.Repositories;
using CopilotSportsApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopilotSportsApi.Services
{
    /// <summary>
    /// Service interface for game operations
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Gets all games
        /// </summary>
        /// <returns>Collection of all games</returns>
        Task<IEnumerable<Game>> GetAllGamesAsync();
        
        /// <summary>
        /// Gets all games including teams
        /// </summary>
        /// <returns>Collection of all games including teams</returns>
        Task<IEnumerable<Game>> GetAllGamesWithTeamsAsync();
        
        /// <summary>
        /// Gets a game by ID
        /// </summary>
        /// <param name="id">ID of the game</param>
        /// <returns>Game with the specified ID, or null if not found</returns>
        Task<Game> GetGameByIdAsync(int id);
        
        /// <summary>
        /// Gets a game by ID including teams and statistics
        /// </summary>
        /// <param name="id">ID of the game</param>
        /// <returns>Game with the specified ID including teams and statistics, or null if not found</returns>
        Task<Game> GetGameWithDetailsAsync(int id);
        
        /// <summary>
        /// Gets games by team ID (either home or away)
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Collection of games for the specified team</returns>
        Task<IEnumerable<Game>> GetGamesByTeamIdAsync(int teamId);
        
        /// <summary>
        /// Gets games by date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Collection of games within the specified date range</returns>
        Task<IEnumerable<Game>> GetGamesByDateRangeAsync(DateTime startDate, DateTime endDate);
        
        /// <summary>
        /// Gets games by status
        /// </summary>
        /// <param name="status">Status to filter by</param>
        /// <returns>Collection of games with the specified status</returns>
        Task<IEnumerable<Game>> GetGamesByStatusAsync(string status);
        
        /// <summary>
        /// Creates a new game
        /// </summary>
        /// <param name="game">Game to create</param>
        /// <returns>Created game</returns>
        Task<Game> CreateGameAsync(Game game);
        
        /// <summary>
        /// Updates an existing game
        /// </summary>
        /// <param name="id">ID of the game to update</param>
        /// <param name="game">Updated game data</param>
        /// <returns>Updated game, or null if the game was not found</returns>
        Task<Game> UpdateGameAsync(int id, Game game);
        
        /// <summary>
        /// Updates the score of a game
        /// </summary>
        /// <param name="id">ID of the game</param>
        /// <param name="homeScore">New home team score</param>
        /// <param name="awayScore">New away team score</param>
        /// <returns>Updated game, or null if the game was not found</returns>
        Task<Game> UpdateGameScoreAsync(int id, int homeScore, int awayScore);
        
        /// <summary>
        /// Updates the status of a game
        /// </summary>
        /// <param name="id">ID of the game</param>
        /// <param name="status">New status</param>
        /// <returns>Updated game, or null if the game was not found</returns>
        Task<Game> UpdateGameStatusAsync(int id, string status);
        
        /// <summary>
        /// Deletes a game
        /// </summary>
        /// <param name="id">ID of the game to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        Task<bool> DeleteGameAsync(int id);
    }

    /// <summary>
    /// Service implementation for game operations
    /// </summary>
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly ILogger<GameService> _logger;

        /// <summary>
        /// Constructor for GameService
        /// </summary>
        /// <param name="gameRepository">Game repository</param>
        /// <param name="logger">Logger</param>
        public GameService(IGameRepository gameRepository, ILogger<GameService> logger)
        {
            _gameRepository = gameRepository;
            _logger = logger;
        }

        /// <summary>
        /// Gets all games
        /// </summary>
        /// <returns>Collection of all games</returns>
        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            try
            {
                return await _gameRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all games");
                throw;
            }
        }

        /// <summary>
        /// Gets all games including teams
        /// </summary>
        /// <returns>Collection of all games including teams</returns>
        public async Task<IEnumerable<Game>> GetAllGamesWithTeamsAsync()
        {
            try
            {
                return await _gameRepository.GetAllGamesWithTeamsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all games with teams");
                throw;
            }
        }

        /// <summary>
        /// Gets a game by ID
        /// </summary>
        /// <param name="id">ID of the game</param>
        /// <returns>Game with the specified ID, or null if not found</returns>
        public async Task<Game> GetGameByIdAsync(int id)
        {
            try
            {
                return await _gameRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting game with ID {GameId}", id);
                throw;
            }
        }

        /// <summary>
        /// Gets a game by ID including teams and statistics
        /// </summary>
        /// <param name="id">ID of the game</param>
        /// <returns>Game with the specified ID including teams and statistics, or null if not found</returns>
        public async Task<Game> GetGameWithDetailsAsync(int id)
        {
            try
            {
                return await _gameRepository.GetGameWithDetailsAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting game with details for game ID {GameId}", id);
                throw;
            }
        }

        /// <summary>
        /// Gets games by team ID (either home or away)
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Collection of games for the specified team</returns>
        public async Task<IEnumerable<Game>> GetGamesByTeamIdAsync(int teamId)
        {
            try
            {
                return await _gameRepository.GetGamesByTeamIdAsync(teamId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting games for team ID {TeamId}", teamId);
                throw;
            }
        }

        /// <summary>
        /// Gets games by date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Collection of games within the specified date range</returns>
        public async Task<IEnumerable<Game>> GetGamesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _gameRepository.GetGamesByDateRangeAsync(startDate, endDate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting games in date range from {StartDate} to {EndDate}", startDate, endDate);
                throw;
            }
        }

        /// <summary>
        /// Gets games by status
        /// </summary>
        /// <param name="status">Status to filter by</param>
        /// <returns>Collection of games with the specified status</returns>
        public async Task<IEnumerable<Game>> GetGamesByStatusAsync(string status)
        {
            try
            {
                return await _gameRepository.GetGamesByStatusAsync(status);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting games with status {Status}", status);
                throw;
            }
        }

        /// <summary>
        /// Creates a new game
        /// </summary>
        /// <param name="game">Game to create</param>
        /// <returns>Created game</returns>
        public async Task<Game> CreateGameAsync(Game game)
        {
            try
            {
                return await _gameRepository.AddAsync(game);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating game between {HomeTeam} and {AwayTeam}", 
                    game.HomeTeamId, game.AwayTeamId);
                throw;
            }
        }

        /// <summary>
        /// Updates an existing game
        /// </summary>
        /// <param name="id">ID of the game to update</param>
        /// <param name="game">Updated game data</param>
        /// <returns>Updated game, or null if the game was not found</returns>
        public async Task<Game> UpdateGameAsync(int id, Game game)
        {
            try
            {
                var existingGame = await _gameRepository.GetByIdAsync(id);
                if (existingGame == null)
                {
                    return null;
                }

                game.Id = id;
                return await _gameRepository.UpdateAsync(game);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating game with ID {GameId}", id);
                throw;
            }
        }

        /// <summary>
        /// Updates the score of a game
        /// </summary>
        /// <param name="id">ID of the game</param>
        /// <param name="homeScore">New home team score</param>
        /// <param name="awayScore">New away team score</param>
        /// <returns>Updated game, or null if the game was not found</returns>
        public async Task<Game> UpdateGameScoreAsync(int id, int homeScore, int awayScore)
        {
            try
            {
                var game = await _gameRepository.GetByIdAsync(id);
                if (game == null)
                {
                    return null;
                }

                game.HomeTeamScore = homeScore;
                game.AwayTeamScore = awayScore;

                return await _gameRepository.UpdateAsync(game);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating score for game with ID {GameId}", id);
                throw;
            }
        }

        /// <summary>
        /// Updates the status of a game
        /// </summary>
        /// <param name="id">ID of the game</param>
        /// <param name="status">New status</param>
        /// <returns>Updated game, or null if the game was not found</returns>
        public async Task<Game> UpdateGameStatusAsync(int id, string status)
        {
            try
            {
                var game = await _gameRepository.GetByIdAsync(id);
                if (game == null)
                {
                    return null;
                }

                game.Status = status;

                return await _gameRepository.UpdateAsync(game);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating status for game with ID {GameId}", id);
                throw;
            }
        }

        /// <summary>
        /// Deletes a game
        /// </summary>
        /// <param name="id">ID of the game to delete</param>
        /// <returns>True if deletion was successful, false otherwise</returns>
        public async Task<bool> DeleteGameAsync(int id)
        {
            try
            {
                return await _gameRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting game with ID {GameId}", id);
                throw;
            }
        }
    }
}
