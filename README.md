# BookVaultApi

BookVaultApi is a modern RESTful Web API built with .NET 10. It serves as a backend service for managing a collection of books, allowing clients to perform standard CRUD (Create, Read, Update, Delete) operations.

## Technologies Used

*   **Framework:** .NET 10.0 Web API
*   **Data Access:** Entity Framework Core (EF Core 10)
*   **Object Mapping:** AutoMapper
*   **API Documentation:** Scalar / OpenAPI
*   **Language:** C#

## Architecture & Design Patterns

The project follows a clean, layered architecture to promote maintainability and separation of concerns:

1.  **Controllers:** Handle incoming HTTP requests, validate input, and return appropriate HTTP responses.
2.  **Services:** Encapsulate business logic. Controllers interact with services (e.g., `IBookService`) rather than directly with the database.
3.  **Data Access:** Uses EF Core's `DbContext` (`AppDbContext`) to interact with the database.
4.  **DTOs (Data Transfer Objects):** Separate data shapes for input/output from internal business models, mapped using AutoMapper.

## Project Structure

*   **/Controllers:** Contains the API endpoints (e.g., `BooksController.cs`).
*   **/Data:** Contains the EF Core `DbContext` and database configurations.
*   **/Models:** Represents the core domain entities mapping to the database tables.
*   **/DTOs:** Data Transfer Objects used to shape the data sent and received by the API.
*   **/Services:** Contains the business logic and interfaces (e.g., `BookService.cs`).
*   **/Migrations:** EF Core database migration files.
*   **MappingProfile.cs:** Configuration for AutoMapper to map between Models and DTOs.

## API Endpoints

The primary resource is `/api/Books`.

| Method | Endpoint | Description |
| :--- | :--- | :--- |
| `GET` | `/api/Books` | Retrieves a list of all books. |
| `GET` | `/api/Books/{id}` | Retrieves a specific book by its ID. |
| `POST` | `/api/Books` | Creates a new book using `CreateBookDto`. |
| `PUT` | `/api/Books/{id}` | Updates an existing book using `UpdateBookDto`. |
| `DELETE` | `/api/Books/{id}` | Deletes a book by its ID. |

## Getting Started

### Prerequisites

*   [.NET 10 SDK](https://dotnet.microsoft.com/download)
*   An IDE like Visual Studio, Visual Studio Code, or Rider.
*   A SQL Server instance (connection string defined in `appsettings.json`, though InMemory can be used for testing).

### Running Locally

1.  **Clone the repository.**
2.  **Navigate to the project directory:**
    ```bash
    cd BookVaultApi
    ```
3.  **Update Database Connection (Optional):**
    Ensure the `DefaultConnection` in `appsettings.json` points to your active database, or use the in-memory database configuration if preferred.
4.  **Apply Migrations:**
    ```bash
    dotnet ef database update
    ```
5.  **Run the application:**
    ```bash
    dotnet run
    ```

### API Documentation

When running in the Development environment, the API documentation is automatically generated and accessible. Simply navigate to the base URL (e.g., `https://localhost:xxxx/scalar`) to interact with the API using the Scalar interface.
