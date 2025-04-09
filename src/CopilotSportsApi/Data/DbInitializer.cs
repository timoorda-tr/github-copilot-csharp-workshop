using CopilotSportsApi.Models;
using System;
using System.Linq;

namespace CopilotSportsApi.Data
{
    /// <summary>
    /// Database initializer for seeding application data
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// Seeds the database with initial data
        /// </summary>
        /// <param name="context">Database context</param>
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed teams if not already populated
            if (!context.Teams.Any())
            {
                SeedTeams(context);
            }

            // Seed players if not already populated
            if (!context.Players.Any())
            {
                SeedPlayers(context);
            }

            // Seed games if not already populated
            if (!context.Games.Any())
            {
                SeedGames(context);
            }

            // Seed game statistics if not already populated
            if (!context.GameStatistics.Any())
            {
                SeedGameStatistics(context);
            }
        }

        private static void SeedTeams(ApplicationDbContext context)
        {
            var teams = new[]
            {
                new Team
                {
                    Name = "Lakers",
                    City = "Los Angeles",
                    Sport = "Basketball",
                    FoundedYear = 1947,
                    Mascot = "None",
                    HomeStadium = "Crypto.com Arena"
                },
                new Team
                {
                    Name = "Celtics",
                    City = "Boston",
                    Sport = "Basketball",
                    FoundedYear = 1946,
                    Mascot = "Lucky the Leprechaun",
                    HomeStadium = "TD Garden"
                },
                new Team
                {
                    Name = "Warriors",
                    City = "Golden State",
                    Sport = "Basketball",
                    FoundedYear = 1946,
                    Mascot = "Thunder",
                    HomeStadium = "Chase Center"
                },
                new Team
                {
                    Name = "Bulls",
                    City = "Chicago",
                    Sport = "Basketball",
                    FoundedYear = 1966,
                    Mascot = "Benny the Bull",
                    HomeStadium = "United Center"
                }
            };

            context.Teams.AddRange(teams);
            context.SaveChanges();
        }

        private static void SeedPlayers(ApplicationDbContext context)
        {
            var players = new[]
            {
                // Lakers players
                new Player
                {
                    FirstName = "LeBron",
                    LastName = "James",
                    JerseyNumber = 23,
                    Position = "Forward",
                    DateOfBirth = new DateTime(1984, 12, 30),
                    HeightInCm = 206,
                    WeightInKg = 113,
                    TeamId = context.Teams.Single(t => t.Name == "Lakers").Id
                },
                new Player
                {
                    FirstName = "Anthony",
                    LastName = "Davis",
                    JerseyNumber = 3,
                    Position = "Center",
                    DateOfBirth = new DateTime(1993, 3, 11),
                    HeightInCm = 208,
                    WeightInKg = 115,
                    TeamId = context.Teams.Single(t => t.Name == "Lakers").Id
                },
                // Celtics players
                new Player
                {
                    FirstName = "Jayson",
                    LastName = "Tatum",
                    JerseyNumber = 0,
                    Position = "Forward",
                    DateOfBirth = new DateTime(1998, 3, 3),
                    HeightInCm = 203,
                    WeightInKg = 95,
                    TeamId = context.Teams.Single(t => t.Name == "Celtics").Id
                },
                new Player
                {
                    FirstName = "Jaylen",
                    LastName = "Brown",
                    JerseyNumber = 7,
                    Position = "Guard",
                    DateOfBirth = new DateTime(1996, 10, 24),
                    HeightInCm = 198,
                    WeightInKg = 101,
                    TeamId = context.Teams.Single(t => t.Name == "Celtics").Id
                },
                // Warriors players
                new Player
                {
                    FirstName = "Stephen",
                    LastName = "Curry",
                    JerseyNumber = 30,
                    Position = "Guard",
                    DateOfBirth = new DateTime(1988, 3, 14),
                    HeightInCm = 188,
                    WeightInKg = 84,
                    TeamId = context.Teams.Single(t => t.Name == "Warriors").Id
                },
                new Player
                {
                    FirstName = "Klay",
                    LastName = "Thompson",
                    JerseyNumber = 11,
                    Position = "Guard",
                    DateOfBirth = new DateTime(1990, 2, 8),
                    HeightInCm = 198,
                    WeightInKg = 98,
                    TeamId = context.Teams.Single(t => t.Name == "Warriors").Id
                },
                // Bulls players
                new Player
                {
                    FirstName = "Zach",
                    LastName = "LaVine",
                    JerseyNumber = 8,
                    Position = "Guard",
                    DateOfBirth = new DateTime(1995, 3, 10),
                    HeightInCm = 196,
                    WeightInKg = 91,
                    TeamId = context.Teams.Single(t => t.Name == "Bulls").Id
                },
                new Player
                {
                    FirstName = "Nikola",
                    LastName = "Vucevic",
                    JerseyNumber = 9,
                    Position = "Center",
                    DateOfBirth = new DateTime(1990, 10, 24),
                    HeightInCm = 213,
                    WeightInKg = 120,
                    TeamId = context.Teams.Single(t => t.Name == "Bulls").Id
                }
            };

            context.Players.AddRange(players);
            context.SaveChanges();
        }

        private static void SeedGames(ApplicationDbContext context)
        {
            var games = new[]
            {
                new Game
                {
                    GameDateTime = DateTime.Now.AddDays(-10),
                    HomeTeamId = context.Teams.Single(t => t.Name == "Lakers").Id,
                    AwayTeamId = context.Teams.Single(t => t.Name == "Celtics").Id,
                    HomeTeamScore = 105,
                    AwayTeamScore = 98,
                    Stadium = "Crypto.com Arena",
                    Status = "Completed"
                },
                new Game
                {
                    GameDateTime = DateTime.Now.AddDays(-5),
                    HomeTeamId = context.Teams.Single(t => t.Name == "Warriors").Id,
                    AwayTeamId = context.Teams.Single(t => t.Name == "Bulls").Id,
                    HomeTeamScore = 120,
                    AwayTeamScore = 110,
                    Stadium = "Chase Center",
                    Status = "Completed"
                },
                new Game
                {
                    GameDateTime = DateTime.Now.AddDays(5),
                    HomeTeamId = context.Teams.Single(t => t.Name == "Celtics").Id,
                    AwayTeamId = context.Teams.Single(t => t.Name == "Warriors").Id,
                    HomeTeamScore = 0,
                    AwayTeamScore = 0,
                    Stadium = "TD Garden",
                    Status = "Scheduled"
                },
                new Game
                {
                    GameDateTime = DateTime.Now.AddDays(10),
                    HomeTeamId = context.Teams.Single(t => t.Name == "Bulls").Id,
                    AwayTeamId = context.Teams.Single(t => t.Name == "Lakers").Id,
                    HomeTeamScore = 0,
                    AwayTeamScore = 0,
                    Stadium = "United Center",
                    Status = "Scheduled"
                }
            };

            context.Games.AddRange(games);
            context.SaveChanges();
        }

        private static void SeedGameStatistics(ApplicationDbContext context)
        {
            // Get the first completed game (Lakers vs Celtics)
            var lakersVsCelticsGame = context.Games
                .Where(g => g.Status == "Completed")
                .FirstOrDefault(g => g.HomeTeamId == context.Teams.Single(t => t.Name == "Lakers").Id 
                                  && g.AwayTeamId == context.Teams.Single(t => t.Name == "Celtics").Id);

            if (lakersVsCelticsGame != null)
            {
                var gameStats = new[]
                {
                    // LeBron James stats
                    new GameStatistic
                    {
                        GameId = lakersVsCelticsGame.Id,
                        PlayerId = context.Players.Single(p => p.LastName == "James").Id,
                        MinutesPlayed = 38,
                        Points = 32,
                        Assists = 8,
                        Rebounds = 7,
                        Steals = 2,
                        Blocks = 1,
                        Turnovers = 3
                    },
                    // Anthony Davis stats
                    new GameStatistic
                    {
                        GameId = lakersVsCelticsGame.Id,
                        PlayerId = context.Players.Single(p => p.LastName == "Davis").Id,
                        MinutesPlayed = 36,
                        Points = 24,
                        Assists = 3,
                        Rebounds = 12,
                        Steals = 1,
                        Blocks = 3,
                        Turnovers = 2
                    },
                    // Jayson Tatum stats
                    new GameStatistic
                    {
                        GameId = lakersVsCelticsGame.Id,
                        PlayerId = context.Players.Single(p => p.LastName == "Tatum").Id,
                        MinutesPlayed = 40,
                        Points = 30,
                        Assists = 5,
                        Rebounds = 6,
                        Steals = 2,
                        Blocks = 0,
                        Turnovers = 4
                    },
                    // Jaylen Brown stats
                    new GameStatistic
                    {
                        GameId = lakersVsCelticsGame.Id,
                        PlayerId = context.Players.Single(p => p.LastName == "Brown").Id,
                        MinutesPlayed = 38,
                        Points = 22,
                        Assists = 4,
                        Rebounds = 5,
                        Steals = 1,
                        Blocks = 1,
                        Turnovers = 2
                    }
                };

                context.GameStatistics.AddRange(gameStats);
            }

            // Get the second completed game (Warriors vs Bulls)
            var warriorsVsBullsGame = context.Games
                .Where(g => g.Status == "Completed")
                .FirstOrDefault(g => g.HomeTeamId == context.Teams.Single(t => t.Name == "Warriors").Id 
                                  && g.AwayTeamId == context.Teams.Single(t => t.Name == "Bulls").Id);

            if (warriorsVsBullsGame != null)
            {
                var gameStats = new[]
                {
                    // Stephen Curry stats
                    new GameStatistic
                    {
                        GameId = warriorsVsBullsGame.Id,
                        PlayerId = context.Players.Single(p => p.LastName == "Curry").Id,
                        MinutesPlayed = 36,
                        Points = 35,
                        Assists = 7,
                        Rebounds = 4,
                        Steals = 3,
                        Blocks = 0,
                        Turnovers = 2
                    },
                    // Klay Thompson stats
                    new GameStatistic
                    {
                        GameId = warriorsVsBullsGame.Id,
                        PlayerId = context.Players.Single(p => p.LastName == "Thompson").Id,
                        MinutesPlayed = 34,
                        Points = 23,
                        Assists = 2,
                        Rebounds = 5,
                        Steals = 1,
                        Blocks = 1,
                        Turnovers = 1
                    },
                    // Zach LaVine stats
                    new GameStatistic
                    {
                        GameId = warriorsVsBullsGame.Id,
                        PlayerId = context.Players.Single(p => p.LastName == "LaVine").Id,
                        MinutesPlayed = 38,
                        Points = 28,
                        Assists = 6,
                        Rebounds = 4,
                        Steals = 1,
                        Blocks = 1,
                        Turnovers = 3
                    },
                    // Nikola Vucevic stats
                    new GameStatistic
                    {
                        GameId = warriorsVsBullsGame.Id,
                        PlayerId = context.Players.Single(p => p.LastName == "Vucevic").Id,
                        MinutesPlayed = 35,
                        Points = 18,
                        Assists = 3,
                        Rebounds = 14,
                        Steals = 0,
                        Blocks = 2,
                        Turnovers = 2
                    }
                };

                context.GameStatistics.AddRange(gameStats);
            }

            context.SaveChanges();
        }
    }
}
