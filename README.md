# Advanced .NET Application with JWT Authentication and CQRS Design

This project is an advanced .NET application demonstrating key software development principles and patterns, including JWT authentication, CQRS design, and a range of modern technologies. It is built to showcase a clean, scalable, and maintainable architecture.

## Key Features

- Implements **JWT authentication** and **Identity** for secure and stateless user authentication.
- Adopts the **CQRS (Command Query Responsibility Segregation)** design pattern for clear separation of read and write operations.
- Uses the **Generic Repository** pattern to standardize data access operations.
- Incorporates **MediatR** for handling commands and queries in a decoupled manner.
- Leverages **EF Core** for efficient database operations.
- Includes a **Worker Service** for background processing.
- Implements **Fluent Validation** for ensuring clean and reliable data input.
- Provides a **Global Exception Handler** for robust error management.
- Configures **SeriLog** for structured and detailed logging.

## Technologies Used

- **Generic Repository**
- **CQRS Patterns Design**
- **MediatR**
- **Worker Service**
- **Entity Framework Core (EF Core)**
- **JWT Authentication and Identity**
- **Fluent Validation**
- **Global Exception Handler**
- **SeriLog**

## Prerequisites

Before running the application, make sure you have:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- SQL Server (or an equivalent database configured with EF Core)

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/movie-recommendation-app.git
   cd movie-recommendation-app
