
✅ Todo ASP.NET Core Web API Project

A clean, modular, and scalable Todo API built with ASP.NET Core Web API using advanced architectural patterns and best practices like Onion Architecture, Specification Design Pattern, Repository Pattern, Unit of Work, and Dependency Injection. The project emphasizes SOLID principles, error consistency, and clean separation of concerns.

----------------------------------------
📐 Project Architecture

The application follows a Onion Architecture to achieve a clean separation between concerns.

----------------------------------------
🛠️ Key Features & Patterns  

- Specification Design Pattern: Centralized, reusable, and composable query logic through specifications.
- Repository Pattern + Generic Repository: Provides a clean abstraction over data access logic.
- Unit of Work Pattern: Manages transactional operations and repository interactions.
- Dependency Injection: Decoupled services and repositories using constructor injection.
- Service Manager: Centralized service access point using Lazy<T> to optimize resource usage.


- Fluent API Configurations: Applied per entity class inside OnModelCreating for fine-grained control of database mappings.
- DTOs (Data Transfer Objects): Ensure clean data transfer between API and client.
- Error Handling Middleware: Centralized middleware returning all errors in a unified response shape.
- AutoMapper: Simplifies object mapping between entities and DTOs.
- Secure Controllers: All controllers are protected via abstractions — no direct exposure to infrastructure or domain implementations.

----------------------------------------
📁 Project Structure

/Solution GTS.TodoManagmentApp
 /API
├── GTS.TodoApp.Core.API                    → API Layer (Configure Services, Startup)
├── GTS.TodoApp.Core.API.Controllers   → API Layer (Controllers)
 /Core
├── GTS.TodoApp.Core.Application       		      → Application Layer (Services, Mapping, Specifications, UoW)
├── GTS.TodoApp.Core.Application.Abstraction    → Application Layer (Services)
├── GTS.TodoApp.Domain             → Domain Layer (Entities, Interfaces[Specifications, UoW, GenericRepository])
 /Infrastructure
├── GTS.TodoApp.Infrastructure     → Infrastructure Layer (Repositories, Migrations, DataContext, DI Configuration, Specification Builder)
└── GTS.TodoApp.Shared        →  (DTOs, Helpers, SpecParams)

----------------------------------------
🔐 SOLID Principles in Practice  

- Single Responsibility: Each class/service handles a single concern.
- Open/Closed: System can be extended without modifying existing code via Specifications, DTOs, and fluent configurations.
- Interface Segregation: Specific interfaces per service/repository responsibility.
- Dependency Inversion: High-level modules depend on abstractions, not concrete implementations.

----------------------------------------
⚙️ Technologies Used  

- ASP.NET Core 8 Web API
-Microsoft SQL Server
- Entity Framework Core  
- AutoMapper  
- Specification Pattern  
- Generic Repository + Unit of Work  
- Lazy Initialization  
- Dependency Injection  
- DTOs & Fluent API Configurations

----------------------------------------
📦 Setup & Run  

1. Clone the repository:
  https://github.com/MohamedAtef-SE/GTS.TodoManagmentApp.git

2. Update Database
  
3. Run the API

4. Access the Swagger UI

----------------------------------------
📊 Unified Error Response Example  

{
  "statusCode": 400,
  "ErrorMessage": "Validation failed.",
  "Errors": [
    "Title is required.",
    "DueDate must be valid."
  ]
}

----------------------------------------

🙌 Author  

Mohamed Atef
LinkedIn: https://www.linkedin.com/in/mohamed-atef-b76714331/
GitHub: https://github.com/MohamedAtef-SE/
