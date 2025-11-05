# Movie Rental API

A complete ASP.NET Web API for managing movie rentals with user authentication and CRUD operations.

## Features

- User Authentication (Login/Register)
- Complete CRUD operations for movies
- Movie rental and return functionality
- Soft delete implementation
- Separate endpoints for rented and available movies
- Swagger UI Compatible
- In-Memory database with seed data

## Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- In-Memory Database
- C#
- Postman
- Swagger UI

## API Endpoints

### Authentication
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - User login

### Movies
- `GET /api/movies` - Get all non-deleted movies
- `GET /api/movies/available` - Get available movies
- `GET /api/movies/rented` - Get rented movies
- `GET /api/movies/{id}` - Get specific movie
- `POST /api/movies` - Create new movie
- `PUT /api/movies/{id}` - Update movie
- `POST /api/movies/{id}/rent` - Rent a movie
- `POST /api/movies/{id}/return` - Return a movie
- `DELETE /api/movies/{id}` - Delete movie

## Setup Instructions

1. Clone the repository
2. Restore NuGet packages: `dotnet restore`
3. Run the application: `dotnet run`
4. Access Postman `Create a new collection and Set base URL: http://localhost:5248 then use Use {{base_url}} in all your requests`
5. Access Swagger UI in browser: `http://localhost:5248/swagger`

## Testing

**Default Admin Account**

- **Email:** admin@movierentals.com
- **Password:** admin123

**Testing Tools**

- **Postman:** Import the endpoints for API testing
- **Swagger UI:** Available at /swagger when running the application
