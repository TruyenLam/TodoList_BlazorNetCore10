# Project Architecture

## Solution Structure

- TodoListBlazor.API: ASP.NET Core API (backend)
- TodoListBlazorWasm: Blazor WebAssembly client (frontend)

## Middleware & Packages

- Swashbuckle.AspNetCore.SwaggerUI has been installed.
- Microsoft.EntityFrameworkCore: EF Core runtime for data access and LINQ queries.
- Microsoft.EntityFrameworkCore.SqlServer: EF Core provider for SQL Server.
- Microsoft.EntityFrameworkCore.Design: EF Core design-time services for scaffolding and migrations.
- Microsoft.EntityFrameworkCore.Tools: EF Core tooling for migrations and database updates.
- Microsoft.AspNetCore.Identity: ASP.NET Core Identity for user management.
- Microsoft.AspNetCore.Identity.EntityFrameworkCore: EF Core stores and integration for ASP.NET Core Identity (user, role, claims persisted in database).

## Tools

- EF Core Power Tools (ErikEJ, sqlcompact.dk): Useful design-time `DbContext` and database features, added to the Visual Studio Solution Explorer context menu. When right-clicking on a C# project, the following context menu functions are available: Reverse Engineer - generates POCO classes, derived `DbContext` and Code First.
