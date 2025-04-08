namespace CopilotSportsApi.Models
{
    /// <summary>
    /// Represents statistics for a player in a specific game
    /// </summary>
    public class GameStatistic
    {
        /// <summary>
        /// Unique identifier for the game statistic
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// ID of the game
        /// </summary>
        public int GameId { get; set; }
        
        /// <summary>
        /// Navigation property for the game
        /// </summary>
        public Game Game { get; set; }
        
        /// <summary>
        /// ID of the player
        /// </summary>
        public int PlayerId { get; set; }
        
        /// <summary>
        /// Navigation property for the player
        /// </summary>
        public Player Player { get; set; }
        
        /// <summary>
        /// Minutes played in the game
        /// </summary>
        public int MinutesPlayed { get; set; }
        
        /// <summary>
        /// Points scored by the player
        /// </summary>
        public int Points { get; set; }
        
        /// <summary>
        /// Assists made by the player
        /// </summary>
        public int Assists { get; set; }
        
        /// <summary>
        /// Rebounds secured by the player
        /// </summary>
        public int Rebounds { get; set; }
        
        /// <summary>
        /// Steals made by the player
        /// </summary>
        public int Steals { get; set; }
        
        /// <summary>
        /// Blocks made by the player
        /// </summary>
        public int Blocks { get; set; }
        
        /// <summary>
        /// Turnovers committed by the player
        /// </summary>
        public int Turnovers { get; set; }
    }
}
