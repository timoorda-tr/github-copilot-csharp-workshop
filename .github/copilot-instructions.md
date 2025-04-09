# GitHub Copilot Instructions for C# Backend Development

When providing assistance for this C# Backend Developer Workshop, please follow these guidelines:

## Code Style & Conventions
- Prioritize async/await patterns for all I/O operations to maximize performance and scalability
- Always follow SOLID principles with a focus on dependency injection and interface-based design
- Use proper exception handling patterns with try/catch blocks and logging
- Include XML documentation comments before all public methods
- Use meaningful variable and method names that clearly express intent
- Implement consistent error handling with appropriate HTTP status codes and response models

## ASP.NET Core Specific
- Prefer attribute routing over conventional routing
- Use dependency injection container for service registration
- Implement proper validation using data annotations or FluentValidation
- Utilize appropriate status codes in API responses (200, 201, 204, 400, 404, etc.)
- Incorporate telemetry and logging in all suggestions related to API endpoints and services

## Entity Framework Core
- Avoid blocking database calls by using async methods (ToListAsync, FirstOrDefaultAsync, etc.)
- Optimize database queries by using Include statements appropriately to avoid N+1 problems
- Consider adding pagination for endpoints that return collections
- Use migrations for database schema changes
- Consider query performance and indexing strategies

## Testing
- Suggest unit tests for service methods using xUnit
- Use Moq or NSubstitute for mocking dependencies
- Create integration tests for API endpoints and database operations
- Focus on testing edge cases and error scenarios

## Security
- Implement proper input validation and sanitization
- Use parameterized queries to prevent SQL injection
- Implement authentication and authorization where appropriate
- Avoid storing sensitive information in code or configuration files

When answering questions about this workshop, please refer to the above guidelines to ensure that all suggestions align with best practices for C# and ASP.NET Core development.
