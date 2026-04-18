# CQRSMediaTr — Employee Management API

ASP.NET Core 8 Web API implementing **CQRS pattern** with **MediatR**, **Entity Framework Core**, and **MySQL**.

## Tech Stack

- .NET 8 / ASP.NET Core 8
- MediatR 14.1
- Entity Framework Core 8 + Pomelo (MySQL)
- Swagger (Swashbuckle)

## API Endpoints

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/api/Employees` | Get all employees |
| GET | `/api/Employees/{id}` | Get by ID |
| GET | `/api/Employees/GetEmployeesByName?name=` | Search by name |
| POST | `/api/Employees` | Create employee |
| PUT | `/api/Employees/{id}` | Update employee |
| DELETE | `/api/Employees/{id}` | Delete employee |

## Setup

1. Install [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) and MySQL
2. Update connection string in `appsettings.json`
3. Run migrations: `dotnet ef database update`
4. Start the app: `dotnet run`
5. Open Swagger UI at `https://localhost:7083/swagger`
