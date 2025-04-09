using CopilotSportsApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopilotSportsApi.Data.Repositories
{
    /// <summary>
    /// Repository interface for Player entities
    /// </summary>
    public interface IPlayerRepository : IRepository<Player>
    {
        /// <summary>
        /// Gets a player by ID including their team
        /// </summary>
        /// <param name="id">ID of the player</param>
        /// <returns>Player with the specified ID including their team, or null if not found</returns>
        Task<Player> GetPlayerWithTeamAsync(int id);
        
        /// <summary>
        /// Gets all players including their teams
        /// </summary>
        /// <returns>Collection of all players including their teams</returns>
        Task<IEnumerable<Player>> GetAllPlayersWithTeamsAsync();
        
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
    }

    /// <summary>
    /// Repository implementation for Player entities
    /// </summary>
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        /// <summary>
        /// Constructor for PlayerRepository
        /// </summary>
        /// <param name="context">Database context</param>
        public PlayerRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets a player by ID including their team
        /// </summary>
        /// <param name="id">ID of the player</param>
        /// <returns>Player with the specified ID including their team, or null if not found</returns>
        public async Task<Player> GetPlayerWithTeamAsync(int id)
        {
            // Intentional bug for workshop task 6 - missing Include for Team
            return await _context.Players
                .SingleAsync(p => p.Id == id);
        }

        /// <summary>
        /// Gets all players including their teams
        /// </summary>
        /// <returns>Collection of all players including their teams</returns>
        public async Task<IEnumerable<Player>> GetAllPlayersWithTeamsAsync()
        {
            return await _context.Players
                .Include(p => p.Team)
                .ToListAsync();
        }

        /// <summary>
        /// Gets players by team ID
        /// </summary>
        /// <param name="teamId">ID of the team</param>
        /// <returns>Collection of players for the specified team</returns>
        public async Task<IEnumerable<Player>> GetPlayersByTeamIdAsync(int teamId)
        {
            return await _context.Players
                .Where(p => p.TeamId == teamId)
                .ToListAsync();
        }

        /// <summary>
        /// Gets players by position
        /// </summary>
        /// <param name="position">Position to filter by</param>
        /// <returns>Collection of players with the specified position</returns>
        public async Task<IEnumerable<Player>> GetPlayersByPositionAsync(string position)
        {
            return await _context.Players
                .Where(p => p.Position == position)
                .ToListAsync();
        }
    }
}
