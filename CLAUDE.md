# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project state

This is a freshly scaffolded ASP.NET Core MVC app (`dotnet new mvc` template) targeting **.NET 10** (`net10.0`), with `Nullable` and `ImplicitUsings` enabled. Despite the `_be` ("backend") name, it is still mostly the template's MVC + Razor views setup. Data access is EF Core with MySQL (see below); no API controllers, authentication, or tests exist yet. The single project lives in `student_management_be_dotnet/` and is referenced by `student_management_be_dotnet.sln` (the VS Code default solution).

## Commands

Run from the repo root:

```bash
dotnet build                                                        # build the solution
dotnet run --project student_management_be_dotnet                   # http://localhost:5071 ("http" profile)
dotnet run --project student_management_be_dotnet --launch-profile https   # https://localhost:7204
dotnet watch --project student_management_be_dotnet                 # run with hot reload
```

EF Core migrations use the repo-local `dotnet-ef` tool (`dotnet-tools.json`; run `dotnet tool restore` first — a global dotnet-ef 8.x may also be installed and is too old):

```bash
dotnet ef migrations add <Name> --project student_management_be_dotnet --output-dir Migrations
dotnet ef database update --project student_management_be_dotnet
```

There is no test project yet. If one is added (e.g. `dotnet new xunit`, then `dotnet sln add`), run tests with `dotnet test` and a single test with `dotnet test --filter "FullyQualifiedName~TestName"`.

## Architecture

- `Program.cs` uses minimal hosting: registers `AddControllersWithViews()`, then the pipeline is exception handler/HSTS (non-Development only) → HTTPS redirection → routing → authorization → `MapStaticAssets()` → conventional route `{controller=Home}/{action=Index}/{id?}`. New services (DbContext, auth, etc.) are registered here.
- Controllers in `Controllers/` return Razor views from `Views/<Controller>/<Action>.cshtml`; shared layout and error page are in `Views/Shared/`. Root namespace is `student_management_be_dotnet`.
- Data: `Data/AppDbContext.cs` (EF Core `DbContext`, registered in `Program.cs` via `UseMySQL`) with entities in `Models/` and migrations in `Migrations/`. Provider is Oracle's `MySql.EntityFrameworkCore` 10.x (note `UseMySQL`, capital SQL) because Pomelo has no EF Core 10 release. Connection string `ConnectionStrings:DefaultConnection` in `appsettings.json`; the local MySQL 8.4 server runs via `docker compose up -d` (root `docker-compose.yml`, container `sms-mysql`, host port 3307 to avoid clashing with another MySQL on 3306).
- Static client libraries (Bootstrap, jQuery, jQuery Validation) are vendored under `wwwroot/lib/` rather than installed via a package manager.
- Config: `appsettings.json` with `appsettings.Development.json` overrides; launch profiles set `ASPNETCORE_ENVIRONMENT=Development`.

