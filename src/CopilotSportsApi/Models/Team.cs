using System;
using System.Collections.Generic;

namespace CopilotSportsApi.Models
{
    /// <summary>
    /// Represents a sports team in the system
    /// </summary>
    public class Team
    {
        /// <summary>
        /// Unique identifier for the team
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Name of the team
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// City where the team is based
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// Sport that the team plays
        /// </summary>
        public string Sport { get; set; }
        
        /// <summary>
        /// Year the team was founded
        /// </summary>
        public int FoundedYear { get; set; }
        
        /// <summary>
        /// Current mascot of the team
        /// </summary>
        public string Mascot { get; set; }
        
        /// <summary>
        /// Team's home stadium or arena
        /// </summary>
        public string HomeStadium { get; set; }
        
        /// <summary>
        /// Collection of players belonging to this team
        /// </summary>
        public ICollection<Player> Players { get; set; }
    }
}
