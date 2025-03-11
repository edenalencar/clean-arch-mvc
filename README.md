[![.NET](https://github.com/edenalencar/clean-arch-mvc/actions/workflows/dotnet.yml/badge.svg)](https://github.com/edenalencar/clean-arch-mvc/actions/workflows/dotnet.yml)
# Clean Architecture MVC API

## Brazilian Portuguese version

Uma aplicação web completa e API REST construída utilizando .NET 7, implementando princípios de Clean Architecture com Domain-Driven Design. Este projeto apresenta um sistema de catálogo de produtos totalmente funcional com gerenciamento de categorias, autenticação e uma arquitetura moderna.

## Visão Geral da Arquitetura

Esta solução está estruturada seguindo os princípios da Clean Architecture, separada em múltiplos projetos:

- **CleanArchMvc.Domain**: Lógica de negócios central e entidades
- **CleanArchMvc.Application**: Serviços de aplicação, DTOs e implementação CQRS
- **CleanArchMvc.Infra.Data**: Contexto de banco de dados, repositórios e migrações
- **CleanArchMvc.Infra.IoC**: Configuração de injeção de dependência
- **CleanArchMvc.WebUI**: Interface de usuário ASP.NET MVC
- **CleanArchMvc.API**: API REST com autenticação JWT
- **CleanArchMvc.Domain.Tests**: Testes unitários para lógica de domínio

## Funcionalidades

- **Gerenciamento de Produtos e Categorias**: Operações CRUD completas
- **Interface Web MVC**: Interface amigável com estilo Bootstrap
- **API REST**: API completa para acesso programático a todas as funcionalidades
- **Autenticação**: Autenticação baseada em Identity para web e API
- **JWT para Segurança da API**: Autenticação baseada em token para API
- **Clean Architecture**: Separação de responsabilidades com design centrado no domínio
- **Padrão CQRS**: Usando MediatR para separação de comandos/consultas
- **Padrão Repository**: Abstração de acesso a dados
- **Injeção de Dependência**: Baixo acoplamento entre componentes
- **Entity Framework Core**: ORM para acesso a dados
- **Documentação Swagger**: Documentação interativa da API

## Começando

### Pré-requisitos

- SDK .NET 7
- SQL Server (ou SQL Server LocalDB)
- Visual Studio 2022 (recomendado) ou qualquer outro IDE que suporte desenvolvimento .NET

### Configuração do Banco de Dados

A aplicação utiliza a abordagem Code First do Entity Framework. Para configurar o banco de dados:

1. Atualize a string de conexão nos arquivos `appsettings.json` (tanto no projeto WebUI quanto no API)
2. Execute as migrações:

```bash
dotnet ef database update --project CleanArchMvc.Infra.Data --startup-project CleanArchMvc.WebUI
```

### Executando a Aplicação

#### Interface Web

```bash
cd CleanArchMvc.WebUI
dotnet run
```

A interface web estará disponível em: https://localhost:7264

#### API

```bash
cd CleanArchMvc.API
dotnet run
```

A API estará disponível em: http://localhost:5298

Interface Swagger: http://localhost:5298/swagger

### Autenticação

#### Login na Interface Web

A aplicação é pré-configurada com usuários padrão:

- Usuário Regular:
  - Email: usuario@localhost
  - Senha: Numsey#2021

- Usuário Administrador:
  - Email: admin@localhost
  - Senha: Numsey#2021

#### Autenticação na API

Para acessar endpoints protegidos da API, obtenha um token JWT:

1. Faça uma requisição POST para `/api/Token/LoginUser` com:
```json
{
  "email": "admin@localhost",
  "password": "Numsey#2021"
}
```
2. Use o token retornado no cabeçalho de Autorização: `Bearer {token}`

## Endpoints da API

A API fornece endpoints para gerenciar categorias e produtos:

### Categorias

- **GET** `/api/Categories` - Listar todas as categorias
- **GET** `/api/Categories/{id}` - Obter uma categoria específica
- **POST** `/api/Categories` - Criar uma nova categoria
- **PUT** `/api/Categories` - Atualizar uma categoria existente
- **DELETE** `/api/Categories/{id}` - Excluir uma categoria

### Produtos

- **GET** `/api/Products` - Listar todos os produtos
- **GET** `/api/Products/{id}` - Obter um produto específico
- **POST** `/api/Products` - Criar um novo produto
- **PUT** `/api/Products/{id}` - Atualizar um produto existente
- **DELETE** `/api/Products/{id}` - Excluir um produto

## Decisões de Design Principais

### Camada de Domínio

- **Modelos de Domínio Ricos**: Entidades com comportamento e validação
- **Validação de Domínio**: Regras de negócio aplicadas no nível do domínio
- **Objetos de Valor**: Objetos imutáveis que representam conceitos sem identidade

### Camada de Aplicação

- **DTOs**: Objetos de transferência de dados para comunicação externa
- **CQRS com MediatR**: Clara separação de operações de leitura e escrita
- **Serviços de Aplicação**: Orquestração de objetos de domínio

### Camada de Infraestrutura

- **Implementação de Repositório**: Abstração de acesso a dados
- **Entity Framework Core**: ORM para operações de banco de dados
- **Identity Framework**: Autenticação e autorização

## Desenvolvimento

### Adicionando Migrações

```bash
# Adicionar uma nova migração
dotnet ef migrations add [NomeDaMigracao] --project CleanArchMvc.Infra.Data --startup-project CleanArchMvc.WebUI
```

### Executando Testes

```bash
dotnet test CleanArchMvc.Domain.Tests
```

## Licença

Este projeto está licenciado sob a GNU General Public License v3.0 - veja o arquivo LICENSE.txt para detalhes.

## Diagrama da Arquitetura

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

Esta arquitetura garante que as dependências apontem apenas para dentro, com a camada de Domínio no núcleo não tendo dependências externas.
# Clean Architecture MVC API


## English version
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


