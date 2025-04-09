# GitHub Copilot C# Backend Developer Workshop

This is a workshop designed to demonstrate the power of GitHub Copilot for C# backend developers. The project is a Sports Statistics API built with ASP.NET Core, Entity Framework Core, and follows modern C# development practices.

## Getting Started

First, set up your development environment:

```bash
# Clone the repository
git clone https://github.com/timoorda-tr/github-copilot-csharp-workshop.git

# Navigate to the project directory
cd github-copilot-csharp-workshop

# Restore dependencies
dotnet restore

# Run the application
dotnet run --project src/CopilotSportsApi
```

Open [http://localhost:5089/swagger](http://localhost:5089/swagger) with your browser to see the API documentation.

## App Description

Introducing the Sports Statistics API, a comprehensive backend solution for tracking sports teams, players, and game statistics. This API allows you to manage player information, team details, game results, and performance metrics for various sports leagues.

With efficient data processing and caching capabilities, the Sports Statistics API provides a robust foundation for building sports-related applications, from fan engagement platforms to performance analysis tools for coaches.

## Project Structure

```
github-copilot-csharp-workshop/
├── .github/
│   └── copilot-instructions.md
├── src/
│   └── CopilotSportsApi/
│       ├── Controllers/
│       ├── Data/
│       │   ├── ApplicationDbContext.cs
│       │   ├── DbInitializer.cs
│       │   └── Repositories/
│       ├── Models/
│       ├── Services/
│       ├── Middleware/
│       └── Program.cs
├── tests/
│   └── CopilotSportsApi.Tests/
│       ├── Controllers/
│       ├── Services/
│       └── Repositories/
├── scripts/
├── README.md
└── CopilotSportsApi.sln
```

## Workshop Tasks

### Task 1 - Exploring the Project with GitHub Copilot

1. **Explore the codebase with GitHub Copilot**

   - Open the GitHub repository in VS Code
   - Press on GitHub Copilot icon to open a chat
   - Explore the app by asking questions like:
      - Can you tell me about this repository?
      - What framework is the repository using?
      - How is the database connection configured?
      - What are the main API endpoints?
      - How is authentication implemented?
      - What design patterns are used in this project?

2. **Set up your local environment**
    - Open the repository in Visual Studio or VS Code
    - Install the required .NET SDK version if not already installed
    - Restore NuGet packages by running `dotnet restore`
    - Run the application using `dotnet run --project src/CopilotSportsApi`
    - Test the API using Swagger UI at `http://localhost:5089/swagger`

### Task 2 - Role Prompting with GitHub Copilot

GitHub Copilot Chat role prompting helps define a specific role for Copilot, providing more relevant and context-aware assistance for your C# backend development tasks.
   - Open GitHub Copilot Chat
   - Use the following prompt:
   ```
   You are a senior C# backend developer specializing in ASP.NET Core and Entity Framework Core. You have extensive experience with RESTful API design, performance optimization, and software architecture principles like SOLID and Clean Architecture.

   Responsibilities:
   - API Development: Design and implement robust, scalable RESTful APIs using ASP.NET Core best practices
   - Data Access: Implement efficient data access patterns with Entity Framework Core
   - Authentication/Authorization: Configure secure authentication systems using Identity and JWT tokens
   - Performance Optimization: Identify bottlenecks and optimize query performance
   - Testing: Write comprehensive unit and integration tests using xUnit
   - Error Handling: Implement consistent error handling and logging strategies

   Goals with GitHub Copilot Chat:
   - Code Assistance: Generate boilerplate code, suggest implementation approaches for complex features
   - Architecture Support: Provide guidance on architectural decisions, design patterns, and code organization
   - Troubleshooting: Help diagnose and resolve issues with HTTP requests, database connectivity, and authentication
   - Testing Help: Generate test cases and mock implementations
   - Performance Tips: Suggest optimizations for database queries, API endpoints, and memory usage
   ```

### Task 3 - Explore ASP.NET Core technology with GitHub Copilot

- In VS Code, open GitHub Copilot Chat
- Install Web Search Extenction for CoPilot
- Enter the following prompts:
   - ```#websearch  What is the difference between ASP.NET Core 6 and 7?```
   - ```#websearch  How does dependency injection work in ASP.NET Core?```
   - ```#websearch  What are the best practices for RESTful API design with ASP.NET Core?```
   - ```#websearch  How to implement JWT authentication in ASP.NET Core?```

### Task 4 - Custom Instructions for GitHub Copilot

Enhance Copilot's chat responses by providing context about your C# development workflow and preferences.
- Examine the file `.github/copilot-instructions.md`
- Review the custom instructions that tell Copilot to:
  - Prioritize async/await patterns for all I/O operations
  - Follow SOLID principles with dependency injection and interface-based design
  - Include XML comments with all public methods, properties, and classes
  - Implement consistent error handling with appropriate HTTP status codes
  - Incorporate telemetry and logging in API endpoints and services

### Task 5 - Add Comments to Code with GitHub Copilot

- Open the `src/CopilotSportsApi/Controllers/TeamsController.cs` file
- Use GitHub Copilot Chat to understand the code by selecting it and using the /explain option
- Select the code and press Ctrl+I (Windows) or Cmd+I (MacOS) choose o3-mini and type /doc
- Use Copilot Chat to generate additional documentation with the prompt: ```Add XML documentation comments to my code```

### Task 6 - Fix Code with GitHub Copilot

- Navigate to the Players endpoint at `ttp://localhost:5089/api/Players/999/team`
- You'll notice an error in the response when trying to retrieve a player that doesn't exist
- Open the `src/CopilotSportsApi/Data/Repositories/PlayerRepository.cs` file
- Examine the `GetPlayerWithTeamAsync` method which has a bug
- Select the error in the code, right-click and choose Copilot > Explain this
- Fix the error using Copilot's suggestions
- Enhance the error handling in the service class by selecting the method, pressing Ctrl+I, and asking Copilot to improve error handling with proper exception management

### Task 7 - Optimize Code with GitHub Copilot

- Open the `src/CopilotSportsApi/Data/Repositories/GameStatisticRepository.cs` file
- Examine the `GetStatisticsByGameIdWithDetailsAsync` method which is slow and inefficient
- Select the code and press Ctrl+I, then ask Copilot to optimize the method
- Implement the optimized version
- Run the benchmark with the provided `scripts/run-benchmark.ps1` PowerShell script to compare performance
- Execute the script with: `./scripts/run-benchmark.ps1 -apiUrl "http://localhost:5089/api/statistics/game/1/details" -iterations 10`
- Optimize the method and run the benchmark again to see the improvement

### Task 8 - GitHub Copilot Code Reviews

- Open the `src/CopilotSportsApi/Controllers/StatisticsController.cs` file
- Press Ctrl+Shift+P (Windows) or Cmd+Shift+P (MacOS) to open the command palette
- Type "GitHub Copilot: Review and comment" and press Enter
- Review Copilot's suggestions for improving the code
- Apply the recommended changes

### Task 9 - Generate Unit Tests with GitHub Copilot

- Examine the example unit tests in `tests/CopilotSportsApi.Tests/Services/TeamServiceTests.cs`
- Open the `src/CopilotSportsApi/Services/PlayerService.cs` file
- In GitHub Copilot Chat, use the prompt: ```Generate unit tests for the PlayerService class using xUnit```
- Create a new test file at `tests/CopilotSportsApi.Tests/Services/PlayerServiceTests.cs`
- Implement the generated tests and run them using `dotnet test`
- Use GitHub Copilot to generate additional tests with edge cases and error conditions

### Task 10 - Create a Coach Management Feature

- Open GitHub Copilot Chat
- Use the prompt: ```Create a feature for managing coaches in the sports API. I need a model, controller, service, and repository for storing and retrieving coach information. A coach should have properties like ID, Name, TeamID, YearsOfExperience, and Specialization.```
- Implement the suggested code in the appropriate files
- Update the database context to include the Coach entity
- Test the new API endpoints

### Task 11 - Implement Authentication with JWT

- Open GitHub Copilot Chat
- Use the prompt: ```Help me implement JWT authentication for my ASP.NET Core API. I need user registration, login, and token validation.```
- Create the required files and implement the authentication system
- Apply the [Authorize] attribute to secure endpoints
- Test the authentication flow with Postman or the Swagger UI

### Task 12 - Create a Performance Monitoring Middleware

- Use GitHub Copilot to generate a custom middleware that tracks endpoint performance metrics:
```
Create a performance monitoring middleware that measures the execution time of each API request and logs it. The middleware should also track the number of database queries executed during the request and log that information too.
```
- Implement the middleware and register it in the application pipeline
- Use GitHub Copilot to help you visualize the collected metrics with a simple dashboard

### Task 13 - Build a GitHub Copilot Extension for C# Development

- Create a custom extension that enhances GitHub Copilot's capabilities for C# developers
- Follow the steps to initialize and configure your extension:
  ```
  1. Create a directory for your extension project
  2. Initialize an npm project with `npm init -y`
  3. Install the Copilot Extensions SDK
  4. Create a server that handles C# code generation requests
  5. Deploy and test your extension
  ```
- Register your extension with GitHub and configure it for your account
- Test your extension with C# specific queries

### Task 14 - Build a MCP Server
- Instructions in the Powerpoint Presentation.

## Key Features to Implement

1. Team management
2. Player tracking
3. Game statistics
4. Performance analytics
5. Authentication and authorization
6. Caching strategies
7. Background processing

## Resources

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core)
- [GitHub Copilot Documentation](https://docs.github.com/en/copilot)
- [xUnit Documentation](https://xunit.net/docs/getting-started/netcore/cmdline)