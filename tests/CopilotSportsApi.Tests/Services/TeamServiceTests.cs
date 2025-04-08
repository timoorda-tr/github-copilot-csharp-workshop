using CopilotSportsApi.Data.Repositories;
using CopilotSportsApi.Models;
using CopilotSportsApi.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CopilotSportsApi.Tests.Services
{
    public class TeamServiceTests
    {
        private readonly Mock<ITeamRepository> _mockTeamRepository;
        private readonly Mock<ILogger<TeamService>> _mockLogger;
        private readonly TeamService _teamService;

        public TeamServiceTests()
        {
            _mockTeamRepository = new Mock<ITeamRepository>();
            _mockLogger = new Mock<ILogger<TeamService>>();
            _teamService = new TeamService(_mockTeamRepository.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllTeamsAsync_ShouldReturnAllTeams()
        {
            // Arrange
            var expectedTeams = new List<Team>
            {
                new Team { Id = 1, Name = "Lakers", City = "Los Angeles", Sport = "Basketball" },
                new Team { Id = 2, Name = "Celtics", City = "Boston", Sport = "Basketball" }
            };

            _mockTeamRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(expectedTeams);

            // Act
            var result = await _teamService.GetAllTeamsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedTeams.Count, result.Count());
            Assert.Equal(expectedTeams, result);
        }

        [Fact]
        public async Task GetTeamByIdAsync_WithValidId_ShouldReturnTeam()
        {
            // Arrange
            int teamId = 1;
            var expectedTeam = new Team { Id = teamId, Name = "Lakers", City = "Los Angeles", Sport = "Basketball" };

            _mockTeamRepository.Setup(repo => repo.GetByIdAsync(teamId))
                .ReturnsAsync(expectedTeam);

            // Act
            var result = await _teamService.GetTeamByIdAsync(teamId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(teamId, result.Id);
            Assert.Equal(expectedTeam.Name, result.Name);
        }

        [Fact]
        public async Task GetTeamByIdAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            int teamId = 999;

            _mockTeamRepository.Setup(repo => repo.GetByIdAsync(teamId))
                .ReturnsAsync((Team)null);

            // Act
            var result = await _teamService.GetTeamByIdAsync(teamId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateTeamAsync_ShouldReturnCreatedTeam()
        {
            // Arrange
            var newTeam = new Team { Name = "Warriors", City = "Golden State", Sport = "Basketball" };
            var createdTeam = new Team { Id = 3, Name = "Warriors", City = "Golden State", Sport = "Basketball" };

            _mockTeamRepository.Setup(repo => repo.AddAsync(newTeam))
                .ReturnsAsync(createdTeam);

            // Act
            var result = await _teamService.CreateTeamAsync(newTeam);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdTeam.Id, result.Id);
            Assert.Equal(createdTeam.Name, result.Name);
        }

        [Fact]
        public async Task UpdateTeamAsync_WithValidId_ShouldReturnUpdatedTeam()
        {
            // Arrange
            int teamId = 1;
            var existingTeam = new Team { Id = teamId, Name = "Lakers", City = "Los Angeles", Sport = "Basketball" };
            var updatedTeam = new Team { Id = teamId, Name = "LA Lakers", City = "Los Angeles", Sport = "Basketball" };

            _mockTeamRepository.Setup(repo => repo.GetByIdAsync(teamId))
                .ReturnsAsync(existingTeam);
            _mockTeamRepository.Setup(repo => repo.UpdateAsync(It.IsAny<Team>()))
                .ReturnsAsync(updatedTeam);

            // Act
            var result = await _teamService.UpdateTeamAsync(teamId, updatedTeam);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(teamId, result.Id);
            Assert.Equal(updatedTeam.Name, result.Name);
        }

        [Fact]
        public async Task UpdateTeamAsync_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            int teamId = 999;
            var updatedTeam = new Team { Name = "LA Lakers", City = "Los Angeles", Sport = "Basketball" };

            _mockTeamRepository.Setup(repo => repo.GetByIdAsync(teamId))
                .ReturnsAsync((Team)null);

            // Act
            var result = await _teamService.UpdateTeamAsync(teamId, updatedTeam);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task DeleteTeamAsync_WithValidId_ShouldReturnTrue()
        {
            // Arrange
            int teamId = 1;

            _mockTeamRepository.Setup(repo => repo.DeleteAsync(teamId))
                .ReturnsAsync(true);

            // Act
            var result = await _teamService.DeleteTeamAsync(teamId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteTeamAsync_WithInvalidId_ShouldReturnFalse()
        {
            // Arrange
            int teamId = 999;

            _mockTeamRepository.Setup(repo => repo.DeleteAsync(teamId))
                .ReturnsAsync(false);

            // Act
            var result = await _teamService.DeleteTeamAsync(teamId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task GetTeamWithPlayersAsync_ShouldReturnTeamWithPlayers()
        {
            // Arrange
            int teamId = 1;
            var players = new List<Player>
            {
                new Player { Id = 1, FirstName = "LeBron", LastName = "James", TeamId = teamId },
                new Player { Id = 2, FirstName = "Anthony", LastName = "Davis", TeamId = teamId }
            };
            var team = new Team { Id = teamId, Name = "Lakers", City = "Los Angeles", Sport = "Basketball", Players = players };

            _mockTeamRepository.Setup(repo => repo.GetTeamWithPlayersAsync(teamId))
                .ReturnsAsync(team);

            // Act
            var result = await _teamService.GetTeamWithPlayersAsync(teamId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(teamId, result.Id);
            Assert.NotNull(result.Players);
            Assert.Equal(players.Count, result.Players.Count);
        }

        [Fact]
        public async Task GetTeamsBySportAsync_ShouldReturnTeamsForSpecifiedSport()
        {
            // Arrange
            string sport = "Basketball";
            var expectedTeams = new List<Team>
            {
                new Team { Id = 1, Name = "Lakers", City = "Los Angeles", Sport = sport },
                new Team { Id = 2, Name = "Celtics", City = "Boston", Sport = sport }
            };

            _mockTeamRepository.Setup(repo => repo.GetTeamsBySportAsync(sport))
                .ReturnsAsync(expectedTeams);

            // Act
            var result = await _teamService.GetTeamsBySportAsync(sport);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedTeams.Count, result.Count());
            Assert.All(result, team => Assert.Equal(sport, team.Sport));
        }

        [Fact]
        public async Task GetAllTeamsAsync_WhenExceptionOccurs_ShouldThrowException()
        {
            // Arrange
            _mockTeamRepository.Setup(repo => repo.GetAllAsync())
                .ThrowsAsync(new Exception("Database connection failed"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _teamService.GetAllTeamsAsync());
        }
    }
}
