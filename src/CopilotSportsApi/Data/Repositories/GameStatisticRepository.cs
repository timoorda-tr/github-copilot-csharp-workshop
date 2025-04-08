using CopilotSportsApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopilotSportsApi.Data.Repositories
{
    /// <summary>
    /// Repository interface for GameStatistic entities
    /// </summary>
    public interface IGameStatisticRepository : IRepository<GameStatistic>
    {
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
        Task<IEnumerable<GameStatistic>> GetStatisticsByGameIdWithDetailsAsync(int gameId);
    }

    /// <summary>
    /// Repository implementation for GameStatistic entities
    /// </summary>
    public class GameStatisticRepository : Repository<GameStatistic>, IGameStatisticRepository
    {
        /// <summary>
        /// Constructor for GameStatisticRepository
        /// </summary>
        /// <param name="context">Database context</param>
        public GameStatisticRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets statistics for a specific game
        /// </summary>
        /// <param name="gameId">ID of the game</param>
        /// <returns>Collection of statistics for the specified game</returns>
        public async Task<IEnumerable<GameStatistic>> GetStatisticsByGameIdAsync(int gameId)
        {
            return await _context.GameStatistics
                .Where(gs => gs.GameId == gameId)
                .ToListAsync();
        }

        /// <summary>
        /// Gets statistics for a specific player
        /// </summary>
        /// <param name="playerId">ID of the player</param>
        /// <returns>Collection of statistics for the specified player</returns>
        public async Task<IEnumerable<GameStatistic>> GetStatisticsByPlayerIdAsync(int playerId)
        {
            return await _context.GameStatistics
                .Where(gs => gs.PlayerId == playerId)
                .ToListAsync();
        }

        /// <summary>
        /// Gets a specific statistic by game ID and player ID
        /// </summary>
        /// <param name="gameId">ID of the game</param>
        /// <param name="playerId">ID of the player</param>
        /// <returns>Statistic for the specified game and player, or null if not found</returns>
        public async Task<GameStatistic> GetStatisticByGameAndPlayerAsync(int gameId, int playerId)
        {
            return await _context.GameStatistics
                .FirstOrDefaultAsync(gs => gs.GameId == gameId && gs.PlayerId == playerId);
        }        /// <summary>
        /// Gets statistics by game ID including player and game details
        /// </summary>
        /// <param name="gameId">ID of the game</param>
        /// <returns>Collection of statistics with player and game details</returns>
        public async Task<IEnumerable<GameStatistic>> GetStatisticsByGameIdWithDetailsAsync(int gameId)
        {
            // Intentionally inefficient query for workshop task 8 - optimization exercise
            var allStatistics = await _context.GameStatistics
                .Include(gs => gs.Player)
                .Include(gs => gs.Game)
                    .ThenInclude(g => g.HomeTeam)
                .Include(gs => gs.Game)
                    .ThenInclude(g => g.AwayTeam)
                .ToListAsync();

            // Introduce additional inefficiency by filtering in memory multiple times
            var filteredStatistics = allStatistics.Where(gs => gs.GameId == gameId).ToList();
            var redundantFilter = filteredStatistics.Where(gs => gs.GameId == gameId).ToList();

            // Perform unnecessary data processing with redundant object creation
            var processedStatistics = redundantFilter.Select(gs => new GameStatistic
            {
                Id = gs.Id,
                GameId = gs.GameId,
                PlayerId = gs.PlayerId,
                Points = gs.Points,
                Assists = gs.Assists,
                Rebounds = gs.Rebounds,
                Steals = gs.Steals,
                Blocks = gs.Blocks,
                Turnovers = gs.Turnovers,
                MinutesPlayed = gs.MinutesPlayed,
                Player = gs.Player,
                Game = gs.Game
            }).ToList();


            var additionalFilteredStatistics = processedStatistics.Where(gs => gs.Points > 0).ToList();
            
            return additionalFilteredStatistics;
        }
    }
}
