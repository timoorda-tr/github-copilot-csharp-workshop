using CopilotSportsApi.Models;
using CopilotSportsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopilotSportsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IGameStatisticService _statisticService;

        public StatisticsController(IGameStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        // GET: api/statistics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameStatistic>>> GetAllStatistics()
        {
            var statistics = await _statisticService.GetAllGameStatisticsAsync();
            return Ok(statistics);
        }

        // GET: api/statistics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameStatistic>> GetStatistic(int id)
        {
            var statistic = await _statisticService.GetGameStatisticByIdAsync(id);
            
            if (statistic == null)
            {
                return NotFound();
            }
            
            return Ok(statistic);
        }

        // GET: api/statistics/game/5
        [HttpGet("game/{gameId}")]
        public async Task<ActionResult<IEnumerable<GameStatistic>>> GetStatisticsByGame(int gameId)
        {
            var statistics = await _statisticService.GetStatisticsByGameIdAsync(gameId);
            return Ok(statistics);
        }

        // GET: api/statistics/game/5/details
        [HttpGet("game/{gameId}/details")]
        public async Task<ActionResult<IEnumerable<GameStatistic>>> GetGameStatisticsWithDetails(int gameId)
        {
            // This endpoint intentionally uses the inefficient method for task 8
            var statistics = await _statisticService.GetGameStatisticsAsync(gameId);
            return Ok(statistics);
        }

        // GET: api/statistics/player/5
        [HttpGet("player/{playerId}")]
        public async Task<ActionResult<IEnumerable<GameStatistic>>> GetStatisticsByPlayer(int playerId)
        {
            var statistics = await _statisticService.GetStatisticsByPlayerIdAsync(playerId);
            return Ok(statistics);
        }

        // GET: api/statistics/game/5/player/10
        [HttpGet("game/{gameId}/player/{playerId}")]
        public async Task<ActionResult<GameStatistic>> GetStatisticByGameAndPlayer(int gameId, int playerId)
        {
            var statistic = await _statisticService.GetStatisticByGameAndPlayerAsync(gameId, playerId);
            
            if (statistic == null)
            {
                return NotFound();
            }
            
            return Ok(statistic);
        }

        // POST: api/statistics
        [HttpPost]
        public async Task<ActionResult<GameStatistic>> CreateStatistic(GameStatistic statistic)
        {
            var createdStatistic = await _statisticService.CreateGameStatisticAsync(statistic);
            return CreatedAtAction(nameof(GetStatistic), new { id = createdStatistic.Id }, createdStatistic);
        }

        // PUT: api/statistics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStatistic(int id, GameStatistic statistic)
        {
            var updatedStatistic = await _statisticService.UpdateGameStatisticAsync(id, statistic);
            
            if (updatedStatistic == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        // DELETE: api/statistics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatistic(int id)
        {
            var result = await _statisticService.DeleteGameStatisticAsync(id);
            
            if (!result)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
