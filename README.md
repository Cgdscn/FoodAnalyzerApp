# FoodAnalyzerApp — Food Product Analysis API

A RESTful backend for a food product analysis application, built with **ASP.NET Core Web API (.NET 8)** and **PostgreSQL**. The API supports user registration and login, product lookup by barcode, and access to product ingredients and their risk information.

> **Repository scope:** The published repository contains the backend API. A mobile client and automated personalized allergy warnings are not demonstrated by the current controllers.

## Features

- **User accounts:** Registration and login endpoints with JWT token issuance.
- **Barcode-based lookup:** Retrieve a product and its associated ingredients using its barcode.
- **Product directory:** Retrieve products stored in the database.
- **Ingredient data:** Access ingredient names, risk levels, and descriptions.
- **Sample data:** Seed a sample product and ingredients through an API endpoint.
- **Interactive API documentation:** Swagger UI in the development environment.
- **Container support:** Dockerfile and Docker Compose configuration for the API.

## Tech Stack

- **Language / Framework:** C#, .NET 8, ASP.NET Core Web API
- **Database:** PostgreSQL
- **Data access:** Entity Framework Core, Npgsql
- **Authentication:** JWT Bearer
- **API documentation:** Swagger / Swashbuckle
- **Deployment tooling:** Docker, Docker Compose

## Main API Endpoints

| Method | Endpoint | Description |
|---|---|---|
| `POST` | `/api/auth/register` | Register an account |
| `POST` | `/api/auth/login` | Log in and receive a JWT |
| `GET` | `/api/products` | List products |
| `GET` | `/api/products/barcode/{barcode}` | Look up a product by barcode |
| `GET` | `/api/products/ingredients` | List ingredients |
| `POST` | `/api/products/seed` | Insert sample product data if the database is empty |

## Getting Started

### Prerequisites

- .NET 8 SDK
- PostgreSQL
- An editor such as Visual Studio or VS Code

### Run Locally

1. Clone the repository:

   ```bash
   git clone https://github.com/Cgdscn/FoodAnalyzerApp.git
   cd FoodAnalyzerApp/source/repos/FoodAnalyzer.API/FoodAnalyzer.API
   ```

2. Configure the **`DefaultConnection`** PostgreSQL connection string and **`Jwt:Issuer`**, **`Jwt:Audience`**, and **`Jwt:Key`** in local configuration or environment variables. Do not commit real secrets.

3. Start the API:

   ```bash
   dotnet restore
   dotnet run
   ```

4. Open the Swagger interface at the address shown by your application's launch configuration (typically `/swagger` in development).

The application calls `Database.Migrate()` on startup, so pending EF Core migrations are applied automatically when database access is available.

## Project Structure

```text
FoodAnalyzer.API/
├── Controllers/          # Authentication and product endpoints
├── Data/                 # Entity Framework Core DbContext
├── Models/               # Users, products, ingredients, and related entities
├── Migrations/           # Database schema migrations
├── Program.cs            # Application setup and middleware
├── Dockerfile
└── docker-compose.yml
```

## Security / Development Notes

This is a learning/development project. **Review the authentication implementation before using it in production:** the current registration and login code stores and compares passwords without hashing. Use a secure password hashing mechanism (e.g. ASP.NET Core Identity) and protect sensitive endpoints with appropriate authorization. Replace development credentials, restrict CORS, and avoid exposing database secrets in Docker Compose.

## Author

[GitHub — Cgdscn](https://github.com/Cgdscn)
