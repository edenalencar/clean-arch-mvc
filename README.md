[![.NET](https://github.com/edenalencar/clean-arch-mvc/actions/workflows/dotnet.yml/badge.svg)](https://github.com/edenalencar/clean-arch-mvc/actions/workflows/dotnet.yml)

# Clean Architecture MVC API

A complete web application and REST API built using .NET 7, implementing Clean Architecture principles with Domain-Driven Design. This project showcases a fully functional product catalog system with category management, authentication, and a modern architecture.

## Architecture Overview

This solution is structured following Clean Architecture principles, separated into multiple projects:

- **CleanArchMvc.Domain**: Core business logic and entities
- **CleanArchMvc.Application**: Application services, DTOs, and CQRS implementation
- **CleanArchMvc.Infra.Data**: Database context, repositories, and migrations
- **CleanArchMvc.Infra.IoC**: Dependency injection configuration
- **CleanArchMvc.WebUI**: ASP.NET MVC user interface
- **CleanArchMvc.API**: REST API with JWT authentication
- **CleanArchMvc.Domain.Tests**: Unit tests for domain logic

## Features

- **Products and Categories Management**: Complete CRUD operations
- **MVC Web Interface**: User-friendly interface with Bootstrap styling
- **REST API**: Full API for programmatic access to all features
- **Authentication**: Identity-based authentication for both web and API
- **JWT for API Security**: Token-based API authentication
- **Clean Architecture**: Separation of concerns with domain-centric design
- **CQRS Pattern**: Using MediatR for command/query separation
- **Repository Pattern**: Abstraction of data access
- **Dependency Injection**: Loose coupling between components
- **Entity Framework Core**: ORM for data access
- **Swagger Documentation**: Interactive API documentation

## Getting Started

### Prerequisites

- .NET 7 SDK
- SQL Server (or SQL Server LocalDB)
- Visual Studio 2022 (recommended) or any other IDE supporting .NET development

### Database Setup

The application uses Entity Framework Code First approach. To set up the database:

1. Update the connection string in `appsettings.json` files (both in WebUI and API projects)
2. Run migrations:

```bash
dotnet ef database update --project CleanArchMvc.Infra.Data --startup-project CleanArchMvc.WebUI
```

### Running the Application

#### Web UI

```bash
cd CleanArchMvc.WebUI
dotnet run
```

The web interface will be available at: https://localhost:7264

#### API

```bash
cd CleanArchMvc.API
dotnet run
```

The API will be available at: http://localhost:5298

Swagger UI: http://localhost:5298/swagger

### Authentication

#### Web UI Login

The application is pre-configured with default users:

- Regular User:
  - Email: usuario@localhost
  - Password: Numsey#2021

- Admin User:
  - Email: admin@localhost
  - Password: Numsey#2021

#### API Authentication

To access protected API endpoints, obtain a JWT token:

1. Make a POST request to `/api/Token/LoginUser` with:
```json
{
  "email": "admin@localhost",
  "password": "Numsey#2021"
}
```
2. Use the returned token in the Authorization header: `Bearer {token}`

## API Endpoints

The API provides endpoints for managing categories and products:

### Categories

- **GET** `/api/Categories` - List all categories
- **GET** `/api/Categories/{id}` - Get a specific category
- **POST** `/api/Categories` - Create a new category
- **PUT** `/api/Categories` - Update an existing category
- **DELETE** `/api/Categories/{id}` - Delete a category

### Products

- **GET** `/api/Products` - List all products
- **GET** `/api/Products/{id}` - Get a specific product
- **POST** `/api/Products` - Create a new product
- **PUT** `/api/Products/{id}` - Update an existing product
- **DELETE** `/api/Products/{id}` - Delete a product

## Key Design Decisions

### Domain Layer

- **Rich Domain Models**: Entities with behavior and validation
- **Domain Validation**: Business rules enforced at the domain level
- **Value Objects**: Immutable objects that represent concepts without identity

### Application Layer

- **DTOs**: Data transfer objects for external communication
- **CQRS with MediatR**: Clear separation of read and write operations
- **Application Services**: Orchestration of domain objects

### Infrastructure Layer

- **Repository Implementation**: Data access abstraction
- **Entity Framework Core**: ORM for database operations
- **Identity Framework**: Authentication and authorization

## Development

### Adding Migrations

```bash
# Add a new migration
dotnet ef migrations add [MigrationName] --project CleanArchMvc.Infra.Data --startup-project CleanArchMvc.WebUI
```

### Running Tests

```bash
dotnet test CleanArchMvc.Domain.Tests
```

## License

This project is licensed under the GNU General Public License v3.0 - see the LICENSE.txt file for details.

## Architecture Diagram

```
┌───────────────┐     ┌───────────────┐     ┌───────────────┐
│     WebUI     │     │      API      │     │ Domain.Tests  │
└───────┬───────┘     └───────┬───────┘     └───────────────┘
        │                     │                      
        │                     │                      
        ▼                     ▼                      
┌─────────────────────────────────────────┐         
│              Infra.IoC                  │         
└─────────────────┬───────────────────────┘         
                  │                                 
                  │                                 
        ┌─────────┴─────────┐                       
        ▼                   ▼                       
┌───────────────┐   ┌───────────────┐               
│  Application  │   │  Infra.Data   │               
└───────┬───────┘   └───────┬───────┘               
        │                   │                       
        │                   │                       
        ▼                   │                       
┌───────────────┐           │                       
│    Domain     │◄──────────┘                       
└───────────────┘                                   
```

This architecture ensures that dependencies only point inward, with the Domain layer at the core having no external dependencies.


