using CopilotSportsApi.Models;
using CopilotSportsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopilotSportsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams()
        {
            var teams = await _teamService.GetAllTeamsAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Team>> GetTeam(int id)
        {
            var team = await _teamService.GetTeamByIdAsync(id);
            
            if (team == null)
            {
                return NotFound();
            }
            
            return Ok(team);
        }

        [HttpGet("{id}/players")]
        public async Task<ActionResult<Team>> GetTeamWithPlayers(int id)
        {
            var team = await _teamService.GetTeamWithPlayersAsync(id);
            
            if (team == null)
            {
                return NotFound();
            }
            
            return Ok(team);
        }

        [HttpGet("sport/{sport}")]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeamsBySport(string sport)
        {
            var teams = await _teamService.GetTeamsBySportAsync(sport);
            return Ok(teams);
        }

        [HttpPost]
        public async Task<ActionResult<Team>> CreateTeam(Team team)
        {
            var createdTeam = await _teamService.CreateTeamAsync(team);
            return CreatedAtAction(nameof(GetTeam), new { id = createdTeam.Id }, createdTeam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeam(int id, Team team)
        {
            var updatedTeam = await _teamService.UpdateTeamAsync(id, team);
            
            if (updatedTeam == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeam(int id)
        {
            var result = await _teamService.DeleteTeamAsync(id);
            
            if (!result)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
