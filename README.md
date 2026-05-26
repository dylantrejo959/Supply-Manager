# Supply Manager

Sistema de escritorio para el control de insumos, inventario y abastecimiento. Desarrollado en C# con Windows Forms y .NET Framework 4.7.2, con SQL Server como base de datos.

## Estado del proyecto

**Sprint 2 completado.** MVP funcional con autenticación por roles, CRUD de todas las entidades, registro de movimientos con validación de stock y tres tipos de reportes analíticos.

## Tecnologías

- C# / .NET Framework 4.7.2
- Windows Forms
- SQL Server (ADO.NET con procedimientos almacenados)
- Arquitectura de tres capas (UI → BLL → DAL)
- Patrones: Singleton, Factory Method, Repository, Unit of Work

## Módulos implementados

| Módulo          | Administrador | Almacenista | Supervisor |
|-----------------|:---:|:---:|:---:|
| Insumos (CRUD)  | ✅  | ✅  | Solo consulta |
| Movimientos     | ✅  | ✅  | Solo consulta |
| Proveedores     | ✅  | ✅  | Solo consulta |
| Áreas           | ✅  | ✗   | Solo consulta |
| Usuarios        | ✅  | ✗   | ✗  |
| Reportes        | ✅  | ✅  | ✅ |

### Reportes disponibles
- **Stock crítico:** insumos con stock actual ≤ stock mínimo.
- **Consumo por período:** total de entradas y salidas filtrado por fechas y área.
- **Proyección de reabastecimiento:** días estimados hasta nivel mínimo y cantidad sugerida de reorden, basados en el consumo promedio de los últimos 30 días.

## Requisitos

- Visual Studio 2022 o compatible
- .NET Framework 4.7.2
- SQL Server o SQL Server Express con Windows Authentication

## Instalación

1. Clonar el repositorio.
2. Abrir `Supply Manager.sln` en Visual Studio.
3. Ejecutar `Supply Manager/Database/DiseñoBD.sql` en SQL Server Management Studio (crea la base de datos `DBInsumos` con tablas, SPs y datos de prueba).
4. Si la instancia de SQL Server no es `localhost`, ajustar la cadena de conexión en `Supply Manager/App.config`.
5. Compilar y ejecutar con **F5**.

## Credenciales de prueba

| Rol           | Usuario    | Contraseña |
|---------------|------------|------------|
| Administrador | `admin`    | `123`      |
| Almacenista   | `almacen`  | `123`      |
| Supervisor    | `supervisor`| `123`     |

## Estructura del proyecto

```
Supply Manager/
├── BLL/Services/          ← Lógica de negocio y validaciones
├── DAL/Data/
│   ├── Repositories/      ← Interfaces e implementaciones ADO.NET
│   └── UnitOfWork/        ← Agregador de repositorios
├── Database/
│   └── DiseñoBD.sql       ← Script completo (idempotente)
├── Entities/              ← Entidades del dominio y DTOs de reportes
├── Factory/               ← IRepositoryFactory y RepositoryFactory
├── UI/Forms/              ← Formularios WinForms
├── Utils/                 ← DbConnectionSingleton y SesionUsuario
└── App.config             ← Cadena de conexión
```

## Documentación

La documentación completa del Sprint 2 se encuentra en `docs/Documentacion_Sprint2.md`, con los 24 apartados requeridos incluyendo arquitectura, patrones SOLID/GoF, normalización, SPs, casos de prueba y manual de usuario.
