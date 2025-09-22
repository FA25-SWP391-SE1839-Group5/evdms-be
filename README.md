# evdms-be

Backend for Electric Vehicle Dealer Management System

## Project Overview

`evdms-be` is the backend service for the Electric Vehicle Dealer Management System. It provides robust APIs and business logic to manage customers, vehicles, sales, inventory, and more for electric vehicle dealerships.

## Detailed Description

This backend is built with .NET 8 and follows a modular architecture, separating concerns into API, Business Logic, Data Access, and Common libraries. It is designed for scalability, maintainability, and ease of integration with frontend and third-party services.

## Features

- Customer management (CRUD)
- Vehicle inventory management
- Sales and order processing
- Dealer and staff management
- Role-based authentication and authorization
- Data seeding and migration support
- RESTful API endpoints
- Automated testing and CI-ready
- Git hooks for code quality (Husky.Net)

## Technology Stack

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **PostgreSQL**
- **Husky.Net** (Git hooks)
- **xUnit** (Testing)

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- Git

### Installation

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

5. **Set up your database**
   - Update your connection string in `appsettings.json`.
   - Apply migrations:
```sh
dotnet ef database update --project EVDMS.DataAccessLayer
```

6. **Run the application**
```sh
dotnet run --project EVDMS.API
```

### Customizing Git Hooks

You can configure hooks in the `.husky` directory.  
Example: To run tests before each commit, add the following to `.husky/pre-commit`:
```sh
dotnet test
```

## Usage

- The API will be available at `https://localhost:5001` (or as configured).
- Use tools like Postman or Swagger UI to interact with the endpoints.

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -am 'Add new feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Open a pull request

## License

This project is licensed under the AGPL 3.0 License.
