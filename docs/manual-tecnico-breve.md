## Manual Técnico

### Requisitos del entorno de desarrollo
- **IDE:** Visual Studio 2022 (Community o superior)
- **Framework:** .NET Framework 4.7.2
- **BD:** SQL Server 2019 / SQL Server Express (con Windows Authentication habilitado)
- **Control de versiones:** Git + GitHub

### Estructura del proyecto
```
Supply Manager/
├── BLL/Services/          ← Lógica de negocio (una clase por entidad)
├── DAL/Data/
│   ├── Repositories/      ← Interfaces + implementaciones ADO.NET
│   └── UnitOfWork/        ← IUnitOfWork + UnitOfWork
├── Database/
│   └── DiseñoBD.sql       ← Script completo de BD (recreación idempotente)
├── Entities/              ← POCOs y DTOs de reportes
├── Factory/               ← IRepositoryFactory + RepositoryFactory
├── UI/Forms/              ← Formularios WinForms (.cs + .Designer.cs + .resx)
├── Utils/                 ← DbConnectionSingleton + SesionUsuario
├── App.config             ← Cadena de conexión
└── Supply Manager.sln     ← Solución Visual Studio
```

### Configuración del ambiente
1. Clonar el repositorio: `git clone <url>`
2. Abrir `Supply Manager.sln` en Visual Studio 2022.
3. Ejecutar `Supply Manager/Database/DiseñoBD.sql` en SQL Server Management Studio contra la instancia local.
4. Si la instancia de SQL Server no es `localhost`, editar `App.config`:
   ```xml
   <add name="DefaultConnection"
        connectionString="Data Source=NOMBRE_INSTANCIA;Initial Catalog=DBInsumos;Integrated Security=True"
        providerName="System.Data.SqlClient"/>
   ```
5. Compilar con **F5** (Debug) o **Ctrl+F5** (sin depuración).

### Agregar un nuevo módulo (guía de extensión)
1. Crear la entidad en `Entities/`.
2. Crear la interfaz de repositorio en `DAL/Data/Repositories/IXxxRepository.cs`.
3. Implementar el repositorio en `DAL/Data/Repositories/XxxRepository.cs` usando `DbConnectionSingleton`.
4. Agregar la propiedad al `IUnitOfWork` e instanciarla en `UnitOfWork`.
5. Crear el servicio en `BLL/Services/XxxService.cs`.
6. Crear el formulario en `UI/Forms/FrmXxx.cs` con su Designer.
7. Registrar todos los archivos nuevos en el `.csproj`.

### Convenciones de código
- Prefijo `Frm` para formularios, `I` para interfaces.
- Nombres de SPs con prefijo `sp_`.
- Errores de usuario en SQL Server con código ≥ 50000.
- El repositorio nunca devuelve `null` en métodos de lista; devuelve lista vacía.
- Los formularios nunca abren conexiones directamente.
