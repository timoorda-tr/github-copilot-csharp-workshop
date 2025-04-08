using CopilotSportsApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopilotSportsApi.Data.Repositories
{
    /// <summary>
    /// Repository interface for Game entities
    /// </summary>
    public interface IGameRepository : IRepository<Game>
    {
        /// <summary>
        /// Gets a game by ID including teams and statistics
        /// </summary>
        /// <param name="id">ID of the game</param>
        /// <returns>Game with the specified ID including teams and statistics, or null if not found</returns>
        Task<Game> GetGameWithDetailsAsync(int id);
        
        /// <summary>
        /// Gets all games including teams
        /// </summary>
        /// <returns>Collection of all games including teams</returns>
        Task<IEnumerable<Game>> GetAllGamesWithTeamsAsync();
        
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
    }

    /// <summary>
    /// Repository implementation for Game entities
    /// </summary>
    public class GameRepository : Repository<Game>, IGameRepository
    {
        /// <summary>
        /// Constructor for GameRepository
        /// </summary>
        /// <param name="context">Database context</param>
        public GameRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets a game by ID including teams and statistics
        /// </summary>
        /// <param name="id">ID of the game</param>
        /// <returns>Game with the specified ID including teams and statistics, or null if not found</returns>
        public async Task<Game> GetGameWithDetailsAsync(int id)
        {
            return await _context.Games
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .Include(g => g.Statistics)
                    .ThenInclude(s => s.Player)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        /// <summary>
        /// Gets all games including teams
        /// </summary>
        /// <returns>Collection of all games including teams</returns>
        public async Task<IEnumerable<Game>> GetAllGamesWithTeamsAsync()
        {
            return await _context.Games
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .ToListAsync();
        }

        /// <summary>
        /// Gets games by team ID (either home or away)
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Collection of games for the specified team</returns>
        public async Task<IEnumerable<Game>> GetGamesByTeamIdAsync(int teamId)
        {
            return await _context.Games
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .Where(g => g.HomeTeamId == teamId || g.AwayTeamId == teamId)
                .ToListAsync();
        }

        /// <summary>
        /// Gets games by date range
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <returns>Collection of games within the specified date range</returns>
        public async Task<IEnumerable<Game>> GetGamesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Games
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .Where(g => g.GameDateTime >= startDate && g.GameDateTime <= endDate)
                .ToListAsync();
        }

        /// <summary>
        /// Gets games by status
        /// </summary>
        /// <param name="status">Status to filter by</param>
        /// <returns>Collection of games with the specified status</returns>
        public async Task<IEnumerable<Game>> GetGamesByStatusAsync(string status)
        {
            return await _context.Games
                .Include(g => g.HomeTeam)
                .Include(g => g.AwayTeam)
                .Where(g => g.Status == status)
                .ToListAsync();
        }
    }
}
