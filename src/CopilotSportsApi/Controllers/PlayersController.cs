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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            var players = await _playerService.GetAllPlayersAsync();
            return Ok(players);
        }

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

        [HttpGet("{id}/team")]
        public async Task<ActionResult<object>> GetPlayerWithTeam(int id)
        {
            var player = await _playerService.GetPlayerWithTeamAsync(id);
            
            if (player == null)
            {
                return NotFound();
            }
            
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

        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersByTeamId(int teamId)
        {
            var players = await _playerService.GetPlayersByTeamIdAsync(teamId);
            return Ok(players);
        }

        [HttpGet("position/{position}")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayersByPosition(string position)
        {
            var players = await _playerService.GetPlayersByPositionAsync(position);
            return Ok(players);
        }

        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(Player player)
        {
            var createdPlayer = await _playerService.CreatePlayerAsync(player);
            return CreatedAtAction(nameof(GetPlayer), new { id = createdPlayer.Id }, createdPlayer);
        }

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
