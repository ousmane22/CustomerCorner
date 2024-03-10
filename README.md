CUSTOMERCORNER CLEAN ARCHITECTURE DOCUMENTATION

This document provides an overview of the CUSTOMERCORNER project, detailing its architecture, environments, libraries, and technologies used. The project follows the Clean Architecture style, emphasizing separation of concerns and maintainability.

Environments
Visual Studio 2022: Integrated Development Environment (IDE) used for development.
ASP .NET Core 8: Web framework for building cross-platform web applications.
.NET 8 SDK: Software Development Kit (SDK) for building .NET applications.
Data Access EF Core 8: Entity Framework Core 8 for data access.
Class Libraries
The project is structured into the following class libraries:

API: Contains controllers, routes, and middleware for exposing endpoints to clients.
Core: Houses the application logic and domain models.
Infrastructure: Handles data persistence and external dependencies.
Style
The project follows the principles of Clean Architecture, which promotes separation of concerns and independence of frameworks. It consists of concentric circles with the innermost layer representing the core domain logic, followed by application-specific logic, and finally, infrastructure concerns.

Packages
The project utilizes the following packages and libraries:

MediatR: Library for implementing the mediator pattern, facilitating communication between application components.
AutoMapper: Mapping library for transforming data between different models and entities.
CQRS: Command Query Responsibility Segregation pattern for separating read and write operations.
Fluent Validation: Library for defining and applying validation rules.
SQL Server: Relational database management system used for data storage.
Entity Framework Tools: Command-line tools for Entity Framework Core migrations and database operations.
Swashbuckle.AspNetCore.Swagger: Library for generating Swagger documentation for API endpoints.
Serilog: Logging library for structured logging and log management.
Components
The project consists of the following components:

API: Exposes HTTP endpoints for interacting with the application.
Core: Contains application logic, use cases, and domain models.
Infrastructure: Handles data persistence using Entity Framework Core and interacts with external services and resources.
