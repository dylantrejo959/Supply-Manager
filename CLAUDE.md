# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

**Supply Manager** is a Windows Forms desktop application (C# / .NET Framework 4.7.2) for managing supplies, inventory, and procurement. All UI labels, form names, and database identifiers are in Spanish.

## Build & Run

Open `Supply Manager.sln` in Visual Studio 2022 and press **F5** (Debug) or **Ctrl+F5** (Run without debugging). There is no CLI build command — this is MSBuild/Visual Studio only.

Entry point: `Program.cs` → launches `FrmLogin`. Default credentials: `admin` / `123`.

## Database Setup

1. Install SQL Server or SQL Server Express with Windows Authentication.
2. Execute `Supply Manager/Database/DiseñoBD.sql` against your SQL Server instance. This creates the `DBInsumos` database with all tables, stored procedures, and seed data.
3. If your SQL Server instance name differs from `localhost`, update the connection string in `Supply Manager/App.config`:
   ```xml
   <add name="DefaultConnection" connectionString="Data Source=localhost;Initial Catalog=DBInsumos;Integrated Security=True" .../>
   ```

## Architecture

The project follows a strict 3-tier architecture:

```
UI (Forms)  →  BLL (Services)  →  DAL (Repositories / UnitOfWork)  →  SQL Server
```

**`UI/Forms/`** — Windows Forms. Each form has a `.cs`, `Designer.cs`, and `.resx` file.

**`BLL/Services/`** — Business logic. Services receive entities/primitives and delegate to DAL. `AuthService` calls `sp_Login` stored procedure via the repository.

**`DAL/Data/Repositories/`** — Repository pattern. `IInsumoRepository` defines the contract; `InsumoRepository` implements it with raw ADO.NET (`SqlCommand`, `SqlDataReader`). Update and Delete methods exist but are currently empty stubs.

**`DAL/Data/UnitOfWork/`** — `IUnitOfWork` / `UnitOfWork` aggregate repositories so services take a single dependency.

**`Factory/`** — `IRepositoryFactory` creates `UnitOfWork` instances (dependency injection seam).

**`Entities/`** — Plain C# classes: `Usuario`, `Insumo`, `Movimiento`, `Proveedor`, `Area`, `Rol`.

**`Utils/`** — `DbConnectionSingleton` wraps the single `SqlConnection` read from `App.config`. `SesionUsuario` is a static session holder (current user and role check).

## Key Conventions

- New forms go in `UI/Forms/` and follow the `Frm` prefix naming convention.
- New entity types go in `Entities/` and have a matching repository interface in `DAL/Data/Repositories/`.
- Database interaction always goes through a repository — never open `SqlConnection` directly from a Form or Service.
- Stored procedures are the preferred data-access mechanism; the connection string uses `Integrated Security=True`.
- `SesionUsuario.UsuarioActual` is set at login and read throughout the session to enforce role-based access.
