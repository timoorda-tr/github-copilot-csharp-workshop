using CopilotSportsApi.Models;
using CopilotSportsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopilotSportsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        // GET: api/games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {
            var games = await _gameService.GetAllGamesWithTeamsAsync();
            return Ok(games);
        }

        // GET: api/games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            
            if (game == null)
            {
                return NotFound();
            }
            
            return Ok(game);
        }

        // GET: api/games/5/details
        [HttpGet("{id}/details")]
        public async Task<ActionResult<Game>> GetGameWithDetails(int id)
        {
            var game = await _gameService.GetGameWithDetailsAsync(id);
            
            if (game == null)
            {
                return NotFound();
            }
            
            return Ok(game);
        }

        // GET: api/games/team/5
        [HttpGet("team/{teamId}")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesByTeamId(int teamId)
        {
            var games = await _gameService.GetGamesByTeamIdAsync(teamId);
            return Ok(games);
        }

        // GET: api/games/daterange
        [HttpGet("daterange")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesByDateRange(
            [FromQuery] DateTime startDate, 
            [FromQuery] DateTime endDate)
        {
            var games = await _gameService.GetGamesByDateRangeAsync(startDate, endDate);
            return Ok(games);
        }

        // GET: api/games/status/completed
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Game>>> GetGamesByStatus(string status)
        {
            var games = await _gameService.GetGamesByStatusAsync(status);
            return Ok(games);
        }

        // POST: api/games
        [HttpPost]
        public async Task<ActionResult<Game>> CreateGame(Game game)
        {
            var createdGame = await _gameService.CreateGameAsync(game);
            return CreatedAtAction(nameof(GetGame), new { id = createdGame.Id }, createdGame);
        }

        // PUT: api/games/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, Game game)
        {
            var updatedGame = await _gameService.UpdateGameAsync(id, game);
            
            if (updatedGame == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        // PATCH: api/games/5/score
        [HttpPatch("{id}/score")]
        public async Task<IActionResult> UpdateGameScore(int id, [FromBody] ScoreUpdateModel scoreUpdate)
        {
            var updatedGame = await _gameService.UpdateGameScoreAsync(id, scoreUpdate.HomeTeamScore, scoreUpdate.AwayTeamScore);
            
            if (updatedGame == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        // PATCH: api/games/5/status
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateGameStatus(int id, [FromBody] StatusUpdateModel statusUpdate)
        {
            var updatedGame = await _gameService.UpdateGameStatusAsync(id, statusUpdate.Status);
            
            if (updatedGame == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        // DELETE: api/games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var result = await _gameService.DeleteGameAsync(id);
            
            if (!result)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }

    public class ScoreUpdateModel
    {
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
    }

    public class StatusUpdateModel
    {
        public string Status { get; set; }
    }
}
