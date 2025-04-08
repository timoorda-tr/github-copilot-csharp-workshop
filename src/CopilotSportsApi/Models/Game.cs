using System;
using System.Collections.Generic;

namespace CopilotSportsApi.Models
{
    /// <summary>
    /// Represents a game between two teams
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Unique identifier for the game
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Date and time when the game is scheduled
        /// </summary>
        public DateTime GameDateTime { get; set; }
        
        /// <summary>
        /// ID of the home team
        /// </summary>
        public int HomeTeamId { get; set; }
        
        /// <summary>
        /// Navigation property for the home team
        /// </summary>
        public Team HomeTeam { get; set; }
        
        /// <summary>
        /// ID of the away team
        /// </summary>
        public int AwayTeamId { get; set; }
        
        /// <summary>
        /// Navigation property for the away team
        /// </summary>
        public Team AwayTeam { get; set; }
        
        /// <summary>
        /// Score of the home team
        /// </summary>
        public int HomeTeamScore { get; set; }
        
        /// <summary>
        /// Score of the away team
        /// </summary>
        public int AwayTeamScore { get; set; }
        
        /// <summary>
        /// Stadium where the game is played
        /// </summary>
        public string Stadium { get; set; }
        
        /// <summary>
        /// Status of the game (Scheduled, InProgress, Completed, Postponed, Cancelled)
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// Collection of player statistics for this game
        /// </summary>
        public ICollection<GameStatistic> Statistics { get; set; }
    }
}
