using CopilotSportsApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopilotSportsApi.Data.Repositories
{
    /// <summary>
    /// Repository interface for Team entities
    /// </summary>
    public interface ITeamRepository : IRepository<Team>
    {
        /// <summary>
        /// Gets a team by ID including its players
        /// </summary>
        /// <param name="id">ID of the team</param>
        /// <returns>Team with the specified ID including its players, or null if not found</returns>
        Task<Team> GetTeamWithPlayersAsync(int id);
        
        /// <summary>
        /// Gets all teams including their players
        /// </summary>
        /// <returns>Collection of all teams including their players</returns>
        Task<IEnumerable<Team>> GetAllTeamsWithPlayersAsync();
        
        /// <summary>
        /// Gets teams by sport
        /// </summary>
        /// <param name="sport">Sport to filter by</param>
        /// <returns>Collection of teams for the specified sport</returns>
        Task<IEnumerable<Team>> GetTeamsBySportAsync(string sport);
    }

    /// <summary>
    /// Repository implementation for Team entities
    /// </summary>
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        /// <summary>
        /// Constructor for TeamRepository
        /// </summary>
        /// <param name="context">Database context</param>
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }

        /// <summary>
        /// Gets a team by ID including its players
        /// </summary>
        /// <param name="id">ID of the team</param>
        /// <returns>Team with the specified ID including its players, or null if not found</returns>
        public async Task<Team> GetTeamWithPlayersAsync(int id)
        {
            return await _context.Teams
                .Include(t => t.Players)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        /// Gets all teams including their players
        /// </summary>
        /// <returns>Collection of all teams including their players</returns>
        public async Task<IEnumerable<Team>> GetAllTeamsWithPlayersAsync()
        {
            return await _context.Teams
                .Include(t => t.Players)
                .ToListAsync();
        }

        /// <summary>
        /// Gets teams by sport
        /// </summary>
        /// <param name="sport">Sport to filter by</param>
        /// <returns>Collection of teams for the specified sport</returns>
        public async Task<IEnumerable<Team>> GetTeamsBySportAsync(string sport)
        {
            return await _context.Teams
                .Where(t => t.Sport == sport)
                .ToListAsync();
        }
    }
}
