using CopilotSportsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CopilotSportsApi.Data
{
    /// <summary>
    /// Database context for the Sports Statistics API
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor for the ApplicationDbContext
        /// </summary>
        /// <param name="options">Database context options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Collection of teams in the database
        /// </summary>
        public DbSet<Team> Teams { get; set; }
        
        /// <summary>
        /// Collection of players in the database
        /// </summary>
        public DbSet<Player> Players { get; set; }
        
        /// <summary>
        /// Collection of games in the database
        /// </summary>
        public DbSet<Game> Games { get; set; }
        
        /// <summary>
        /// Collection of game statistics in the database
        /// </summary>
        public DbSet<GameStatistic> GameStatistics { get; set; }

        /// <summary>
        /// Configures the database model
        /// </summary>
        /// <param name="modelBuilder">Model builder for configuring the database</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany()
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.AwayTeam)
                .WithMany()
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GameStatistic>()
                .HasOne(gs => gs.Game)
                .WithMany(g => g.Statistics)
                .HasForeignKey(gs => gs.GameId);

            modelBuilder.Entity<GameStatistic>()
                .HasOne(gs => gs.Player)
                .WithMany()
                .HasForeignKey(gs => gs.PlayerId);

            // Add seed data (to be implemented with intentional issues for workshop)
        }
    }
}
