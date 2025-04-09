using CopilotSportsApi.Models;
using CopilotSportsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopilotSportsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayersController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        // GET: api/players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            var players = await _playerService.GetAllPlayersAsync();
            return Ok(players);
        }

        // GET: api/players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
            
            if (player == null)
            {
                return NotFound();
            }
            
            return Ok(player);
        }

        // GET: api/players/5/team
        [HttpGet("{id}/team")]
        public async Task<ActionResult<object>> GetPlayerWithTeam(int id)
        {
            var player = await _playerService.GetPlayerWithTeamAsync(id);
            
            if (player == null)
            {
                return NotFound();
            }
            
            // This will fail when Team is null due to the missing Include in the repository
            // Task 6 will require fixing the GetPlayerWithTeamAsync method in PlayerRepository
            var result = new
            {
                Player = new
                {
                    player.Id,
                    player.FirstName,
                    player.LastName,
                    player.Position,
                    player.JerseyNumber
                },
                Team = player.Team != null ? new
                {
                    player.Team.Id,
                    player.Team.Name,
                    player.Team.City,
                    player.Team.Sport
                } : null
            };
            
            return Ok(result);
        }

        // GET: api/players/team/5
        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersByTeamId(int teamId)
        {
            var players = await _playerService.GetPlayersByTeamIdAsync(teamId);
            return Ok(players);
        }

        // GET: api/players/position/forward
        [HttpGet("position/{position}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersByPosition(string position)
        {
            var players = await _playerService.GetPlayersByPositionAsync(position);
            return Ok(players);
        }

        // POST: api/players
        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(Player player)
        {
            var createdPlayer = await _playerService.CreatePlayerAsync(player);
            return CreatedAtAction(nameof(GetPlayer), new { id = createdPlayer.Id }, createdPlayer);
        }

        // PUT: api/players/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(int id, Player player)
        {
            var updatedPlayer = await _playerService.UpdatePlayerAsync(id, player);
            
            if (updatedPlayer == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        // DELETE: api/players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(int id)
        {
            var result = await _playerService.DeletePlayerAsync(id);
            
            if (!result)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
