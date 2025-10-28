# 🏨 Hotel Booking System
### A challenge from Waracle.
API for finding available hotels, rooms and creating/referencing bookings.

## How to run
* Open VS or Rider
* Restore nuget packages
* create SQLite DB
  * ```dotnet ef migrations add InitialCreate```
  * ```dotnet ef database update```
* Run in IDE for Swagger UI

## Tech Overview
> ASP.Net 8.0 API with Swagger UI

* Entity Framework 8.0 for Database mapping
* SQLite Database 8.0 for portability and ease of use
  * <font size="+1">⚠️</font> **connection string has been left in appsettings.json and MUST be pulled into an environment variable for live database!**
  * should migrate to SQL Server when scaling, alongside Azure hosting

### Database Schema
![DB Schema](docs/schema.png)