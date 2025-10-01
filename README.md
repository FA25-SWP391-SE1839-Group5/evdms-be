# evdms-be

Backend for Electric Vehicle Dealer Management System

---

## Project Overview

`evdms-be` is the backend service for the Electric Vehicle Dealer Management System. It provides robust APIs and business logic to manage customers, vehicles, sales, inventory, and more for electric vehicle dealerships.

## Features

- Customer management (CRUD)
- Vehicle inventory management
- Sales and order processing
- Dealer and staff management
- Role-based authentication and authorization
- Data seeding and migration support
- RESTful API endpoints
- Automated testing and CI-ready
- Git hooks for code quality ([Husky.Net](https://alirezanet.github.io/Husky.Net/guide/getting-started))

## Technology Stack

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **PostgreSQL**
- **Husky.Net** (Git hooks)
- **xUnit** (Testing)
- **Testcontainers** (Integration Testing)

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Docker](https://www.docker.com/get-started) (required for integration tests with Testcontainers)
- [Git](https://git-scm.com/downloads)

### Installation Steps

1. **Clone the repository**
   ```sh
   git clone https://github.com/FA25-SWP391-SE1839-Group5/evdms-be.git
   cd evdms-be
   ```

2. **Restore .NET dependencies**
   ```sh
   dotnet restore
   ```

3. **Restore .NET tools (including Husky.Net)**
   ```sh
   dotnet tool restore
   ```

4. **Install Husky.Net Git hooks**
   ```sh
   dotnet husky install
   ```

---

## Configuration

### Using ASP.NET Core User Secrets

To keep sensitive information (like connection strings, API keys, JWT secrets) out of source control, use ASP.NET Core User Secrets for local development.

#### How to Set Up User Secrets

1. **Initialize User Secrets for the EVDMS.API project:**
   Run this command in the project directory (where the `.csproj` file is):
   ```sh
   dotnet user-secrets init
   ```

2. **Add secrets using the CLI:**
   For example:
   ```sh
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "your-connection-string"
   dotnet user-secrets set "Jwt:Secret" "your-jwt-secret"
   dotnet user-secrets set "ApiKeys:SomeService" "your-api-key"
   ```

3. **Access secrets in code as usual:**
   Use the standard configuration API, e.g.:
   ```csharp
   var connStr = Configuration["ConnectionStrings:DefaultConnection"];
   var jwtSecret = Configuration["Jwt:Secret"];
   ```

#### Notes
- User Secrets are only for development. Use environment variables or a secrets manager for production.
- Do not commit secrets to any `appsettings*.json` file.

### Database Setup

- Update your connection string using User Secrets as described above.
- Apply migrations:
   ```sh
   dotnet ef database update --project src/EVDMS.DataAccessLayer --startup-project src/EVDMS.API
   ```

---

## Running the Application

```sh
dotnet run --project src/EVDMS.API
```

- The API will be available at `http://localhost:5197/api`.
- Use tools like Postman or [Swagger UI](http://localhost:5197/swagger/index.html) to interact with the endpoints.

---

## Testing

Integration tests use [Testcontainers](https://github.com/testcontainers/testcontainers-dotnet) to spin up a real PostgreSQL database in Docker.
**Docker must be installed and running** for integration tests to work.

To run all tests:
```sh
dotnet test
```

---

## Customizing Git Hooks

You can configure hooks in the `.husky` directory.  
Example: To run tests before each commit, add the following to `.husky/pre-commit`:
```sh
dotnet test
```

---

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Open a pull request

---

## License

This project is licensed under the AGPL 3.0 License.

---

