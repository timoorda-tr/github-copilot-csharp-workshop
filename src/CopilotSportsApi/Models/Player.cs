using System;

namespace CopilotSportsApi.Models
{
    /// <summary>
    /// Represents a player in a sports team
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Unique identifier for the player
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// First name of the player
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Last name of the player
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Player's jersey number
        /// </summary>
        public int JerseyNumber { get; set; }
        
        /// <summary>
        /// Player's position in the team
        /// </summary>
        public string Position { get; set; }
        
        /// <summary>
        /// Player's date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        
        /// <summary>
        /// Player's height in centimeters
        /// </summary>
        public int HeightInCm { get; set; }
        
        /// <summary>
        /// Player's weight in kilograms
        /// </summary>
        public int WeightInKg { get; set; }
        
        /// <summary>
        /// The team that the player belongs to
        /// </summary>
        public int TeamId { get; set; }
        
        /// <summary>
        /// Navigation property for the team
        /// </summary>
        public Team Team { get; set; }
    }
}
