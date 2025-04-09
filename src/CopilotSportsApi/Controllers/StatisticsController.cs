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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameStatistic>>> GetAllStatistics()
        {
            var statistics = await _statisticService.GetAllGameStatisticsAsync();
            return Ok(statistics);
        }

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

        [HttpGet("game/{gameId}")]
        public async Task<ActionResult<IEnumerable<GameStatistic>>> GetStatisticsByGame(int gameId)
        {
            var statistics = await _statisticService.GetStatisticsByGameIdAsync(gameId);
            return Ok(statistics);
        }

        [HttpGet("game/{gameId}/details")]
        public async Task<ActionResult<IEnumerable<GameStatistic>>> GetGameStatisticsWithDetails(int gameId)
        {
            var statistics = await _statisticService.GetGameStatisticsAsync(gameId);
            return Ok(statistics);
        }

        [HttpGet("player/{playerId}")]
        public async Task<ActionResult<IEnumerable<GameStatistic>>> GetStatisticsByPlayer(int playerId)
        {
            var statistics = await _statisticService.GetStatisticsByPlayerIdAsync(playerId);
            return Ok(statistics);
        }

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

        [HttpPost]
        public async Task<ActionResult<GameStatistic>> CreateStatistic(GameStatistic statistic)
        {
            var createdStatistic = await _statisticService.CreateGameStatisticAsync(statistic);
            return CreatedAtAction(nameof(GetStatistic), new { id = createdStatistic.Id }, createdStatistic);
        }

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
