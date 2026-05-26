IF DB_ID('DBInsumos') IS NOT NULL
BEGIN
    ALTER DATABASE DBInsumos SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE DBInsumos;
END;
GO

CREATE DATABASE DBInsumos;
GO

USE DBInsumos;
GO

-- ============================================================
-- TABLAS
-- ============================================================

CREATE TABLE Roles (
    IdRol INT IDENTITY(1,1) PRIMARY KEY,
    NombreRol NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Usuarios (
    IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
    Usuario NVARCHAR(50) NOT NULL UNIQUE,
    Clave NVARCHAR(100) NOT NULL,
    IdRol INT NOT NULL,
    Estado BIT NOT NULL CONSTRAINT DF_Usuarios_Estado DEFAULT (1),
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
);
GO

CREATE TABLE Insumos (
    IdInsumo INT IDENTITY(1,1) PRIMARY KEY,
    NombreInsumo NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255) NULL,
    StockActual INT NOT NULL CONSTRAINT DF_Insumos_StockActual DEFAULT (0),
    StockMinimo INT NOT NULL CONSTRAINT DF_Insumos_StockMinimo DEFAULT (0),
    UnidadMedida NVARCHAR(50) NOT NULL,
    Estado BIT NOT NULL CONSTRAINT DF_Insumos_Estado DEFAULT (1),
    CONSTRAINT CK_Insumos_StockActual CHECK (StockActual >= 0),
    CONSTRAINT CK_Insumos_StockMinimo CHECK (StockMinimo >= 0)
);
GO

CREATE TABLE Areas (
    IdArea INT IDENTITY(1,1) PRIMARY KEY,
    NombreArea NVARCHAR(100) NOT NULL UNIQUE
);
GO

CREATE TABLE Proveedores (
    IdProveedor INT IDENTITY(1,1) PRIMARY KEY,
    NombreProveedor NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NULL,
    Correo NVARCHAR(100) NULL,
    Direccion NVARCHAR(200) NULL
);
GO

CREATE TABLE Movimientos (
    IdMovimiento INT IDENTITY(1,1) PRIMARY KEY,
    TipoMovimiento NVARCHAR(20) NOT NULL,
    FechaMovimiento DATETIME NOT NULL CONSTRAINT DF_Movimientos_Fecha DEFAULT (GETDATE()),
    Cantidad INT NOT NULL,
    Observacion NVARCHAR(255) NULL,
    IdInsumo INT NOT NULL,
    IdArea INT NOT NULL,
    IdUsuario INT NOT NULL,
    CONSTRAINT FK_Movimientos_Insumos FOREIGN KEY (IdInsumo) REFERENCES Insumos(IdInsumo),
    CONSTRAINT FK_Movimientos_Areas FOREIGN KEY (IdArea) REFERENCES Areas(IdArea),
    CONSTRAINT FK_Movimientos_Usuarios FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
    CONSTRAINT CK_Movimientos_Tipo CHECK (TipoMovimiento IN ('Entrada', 'Salida')),
    CONSTRAINT CK_Movimientos_Cantidad CHECK (Cantidad > 0)
);
GO

-- ============================================================
-- DATOS INICIALES
-- ============================================================

INSERT INTO Roles (NombreRol) VALUES ('Administrador'), ('Almacenista'), ('Supervisor');
GO

INSERT INTO Usuarios (Usuario, Clave, IdRol, Estado)
VALUES ('admin', '123', 1, 1), ('almacen', '123', 2, 1), ('supervisor', '123', 3, 1);
GO

INSERT INTO Areas (NombreArea) VALUES ('Laboratorio'), ('Produccion'), ('Almacen');
GO

INSERT INTO Proveedores (NombreProveedor, Telefono, Correo, Direccion)
VALUES ('Proveedor General', '0000000000', 'proveedor@demo.com', 'Sin direccion');
GO

INSERT INTO Insumos (NombreInsumo, Descripcion, StockActual, StockMinimo, UnidadMedida, Estado)
VALUES
    ('Guantes', 'Guantes de latex', 100, 20, 'Caja', 1),
    ('Alcohol', 'Alcohol antiseptico', 50, 10, 'Litro', 1),
    ('Mascarillas', 'Mascarillas N95', 5, 15, 'Unidad', 1);
GO

-- ============================================================
-- PROCEDIMIENTOS ALMACENADOS
-- ============================================================

-- Autenticacion
CREATE OR ALTER PROCEDURE sp_Login
    @Usuario NVARCHAR(50),
    @Clave NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.IdUsuario, u.Usuario, r.NombreRol
    FROM Usuarios u
    INNER JOIN Roles r ON r.IdRol = u.IdRol
    WHERE u.Usuario = @Usuario AND u.Clave = @Clave AND u.Estado = 1;
END;
GO

-- Insumos
CREATE OR ALTER PROCEDURE sp_InsertarInsumo
    @NombreInsumo NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @StockActual INT,
    @StockMinimo INT,
    @UnidadMedida NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Insumos WHERE NombreInsumo = @NombreInsumo AND Estado = 1)
        THROW 50001, 'Ya existe un insumo activo con ese nombre.', 1;
    INSERT INTO Insumos (NombreInsumo, Descripcion, StockActual, StockMinimo, UnidadMedida)
    VALUES (@NombreInsumo, @Descripcion, @StockActual, @StockMinimo, @UnidadMedida);
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarInsumo
    @IdInsumo INT,
    @NombreInsumo NVARCHAR(100),
    @Descripcion NVARCHAR(255),
    @StockMinimo INT,
    @UnidadMedida NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Insumos WHERE NombreInsumo = @NombreInsumo AND IdInsumo <> @IdInsumo AND Estado = 1)
        THROW 50002, 'Ya existe otro insumo con ese nombre.', 1;
    UPDATE Insumos
    SET NombreInsumo = @NombreInsumo, Descripcion = @Descripcion,
        StockMinimo = @StockMinimo, UnidadMedida = @UnidadMedida
    WHERE IdInsumo = @IdInsumo;
END;
GO

CREATE OR ALTER PROCEDURE sp_DesactivarInsumo
    @IdInsumo INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Insumos SET Estado = 0 WHERE IdInsumo = @IdInsumo;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerInsumos
    @Nombre NVARCHAR(100) = NULL,
    @UnidadMedida NVARCHAR(50) = NULL,
    @SoloStockCritico BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdInsumo, NombreInsumo, Descripcion, StockActual, StockMinimo, UnidadMedida, Estado
    FROM Insumos
    WHERE Estado = 1
      AND (@Nombre IS NULL OR NombreInsumo LIKE '%' + @Nombre + '%')
      AND (@UnidadMedida IS NULL OR UnidadMedida = @UnidadMedida)
      AND (@SoloStockCritico = 0 OR StockActual <= StockMinimo)
    ORDER BY NombreInsumo;
END;
GO

-- Movimientos: regla de negocio en SP — salida valida stock y actualiza en transaccion
CREATE OR ALTER PROCEDURE sp_RegistrarMovimiento
    @TipoMovimiento NVARCHAR(20),
    @Cantidad INT,
    @Observacion NVARCHAR(255),
    @IdInsumo INT,
    @IdArea INT,
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        IF @TipoMovimiento = 'Salida'
        BEGIN
            DECLARE @StockActual INT;
            SELECT @StockActual = StockActual FROM Insumos WHERE IdInsumo = @IdInsumo;
            IF @StockActual < @Cantidad
                THROW 50010, 'Stock insuficiente para realizar la salida.', 1;
            UPDATE Insumos SET StockActual = StockActual - @Cantidad WHERE IdInsumo = @IdInsumo;
        END
        ELSE
            UPDATE Insumos SET StockActual = StockActual + @Cantidad WHERE IdInsumo = @IdInsumo;

        INSERT INTO Movimientos (TipoMovimiento, Cantidad, Observacion, IdInsumo, IdArea, IdUsuario)
        VALUES (@TipoMovimiento, @Cantidad, @Observacion, @IdInsumo, @IdArea, @IdUsuario);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerMovimientos
    @IdInsumo INT = NULL,
    @IdArea INT = NULL,
    @TipoMovimiento NVARCHAR(20) = NULL,
    @FechaDesde DATETIME = NULL,
    @FechaHasta DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT m.IdMovimiento, m.TipoMovimiento, m.FechaMovimiento, m.Cantidad, m.Observacion,
           i.NombreInsumo, a.NombreArea, u.Usuario AS NombreUsuario
    FROM Movimientos m
    INNER JOIN Insumos i ON i.IdInsumo = m.IdInsumo
    INNER JOIN Areas a ON a.IdArea = m.IdArea
    INNER JOIN Usuarios u ON u.IdUsuario = m.IdUsuario
    WHERE (@IdInsumo IS NULL OR m.IdInsumo = @IdInsumo)
      AND (@IdArea IS NULL OR m.IdArea = @IdArea)
      AND (@TipoMovimiento IS NULL OR m.TipoMovimiento = @TipoMovimiento)
      AND (@FechaDesde IS NULL OR m.FechaMovimiento >= @FechaDesde)
      AND (@FechaHasta IS NULL OR m.FechaMovimiento < DATEADD(DAY, 1, @FechaHasta))
    ORDER BY m.FechaMovimiento DESC;
END;
GO

-- Proveedores
CREATE OR ALTER PROCEDURE sp_InsertarProveedor
    @NombreProveedor NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @Correo NVARCHAR(100),
    @Direccion NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Proveedores (NombreProveedor, Telefono, Correo, Direccion)
    VALUES (@NombreProveedor, @Telefono, @Correo, @Direccion);
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarProveedor
    @IdProveedor INT,
    @NombreProveedor NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @Correo NVARCHAR(100),
    @Direccion NVARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Proveedores
    SET NombreProveedor = @NombreProveedor, Telefono = @Telefono,
        Correo = @Correo, Direccion = @Direccion
    WHERE IdProveedor = @IdProveedor;
END;
GO

CREATE OR ALTER PROCEDURE sp_EliminarProveedor
    @IdProveedor INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Proveedores WHERE IdProveedor = @IdProveedor;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerProveedores
    @Nombre NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdProveedor, NombreProveedor, Telefono, Correo, Direccion
    FROM Proveedores
    WHERE @Nombre IS NULL OR NombreProveedor LIKE '%' + @Nombre + '%'
    ORDER BY NombreProveedor;
END;
GO

-- Areas
CREATE OR ALTER PROCEDURE sp_InsertarArea
    @NombreArea NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Areas WHERE NombreArea = @NombreArea)
        THROW 50020, 'Ya existe un area con ese nombre.', 1;
    INSERT INTO Areas (NombreArea) VALUES (@NombreArea);
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarArea
    @IdArea INT,
    @NombreArea NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Areas WHERE NombreArea = @NombreArea AND IdArea <> @IdArea)
        THROW 50021, 'Ya existe otra area con ese nombre.', 1;
    UPDATE Areas SET NombreArea = @NombreArea WHERE IdArea = @IdArea;
END;
GO

CREATE OR ALTER PROCEDURE sp_EliminarArea
    @IdArea INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Movimientos WHERE IdArea = @IdArea)
        THROW 50022, 'No se puede eliminar el area porque tiene movimientos asociados.', 1;
    DELETE FROM Areas WHERE IdArea = @IdArea;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerAreas
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdArea, NombreArea FROM Areas ORDER BY NombreArea;
END;
GO

-- Usuarios
CREATE OR ALTER PROCEDURE sp_InsertarUsuario
    @Usuario NVARCHAR(50),
    @Clave NVARCHAR(100),
    @IdRol INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Usuarios WHERE Usuario = @Usuario)
        THROW 50030, 'Ya existe un usuario con ese nombre.', 1;
    INSERT INTO Usuarios (Usuario, Clave, IdRol, Estado) VALUES (@Usuario, @Clave, @IdRol, 1);
END;
GO

CREATE OR ALTER PROCEDURE sp_ActualizarUsuario
    @IdUsuario INT,
    @Usuario NVARCHAR(50),
    @IdRol INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Usuarios WHERE Usuario = @Usuario AND IdUsuario <> @IdUsuario)
        THROW 50031, 'Ya existe otro usuario con ese nombre.', 1;
    UPDATE Usuarios SET Usuario = @Usuario, IdRol = @IdRol WHERE IdUsuario = @IdUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_DesactivarUsuario
    @IdUsuario INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Usuarios SET Estado = 0 WHERE IdUsuario = @IdUsuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerUsuarios
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.IdUsuario, u.Usuario, r.NombreRol, u.Estado
    FROM Usuarios u
    INNER JOIN Roles r ON r.IdRol = u.IdRol
    ORDER BY u.Usuario;
END;
GO

CREATE OR ALTER PROCEDURE sp_ObtenerRoles
AS
BEGIN
    SET NOCOUNT ON;
    SELECT IdRol, NombreRol FROM Roles ORDER BY NombreRol;
END;
GO

-- ============================================================
-- REPORTES
-- ============================================================

CREATE OR ALTER PROCEDURE sp_ReporteStockCritico
AS
BEGIN
    SET NOCOUNT ON;
    SELECT NombreInsumo, UnidadMedida, StockActual, StockMinimo,
           (StockMinimo - StockActual) AS Deficit
    FROM Insumos
    WHERE Estado = 1 AND StockActual <= StockMinimo
    ORDER BY Deficit DESC, NombreInsumo;
END;
GO

CREATE OR ALTER PROCEDURE sp_ReporteConsumo
    @FechaDesde DATETIME,
    @FechaHasta DATETIME,
    @IdArea INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT i.NombreInsumo, i.UnidadMedida, a.NombreArea,
           SUM(CASE WHEN m.TipoMovimiento = 'Salida' THEN m.Cantidad ELSE 0 END) AS TotalConsumo,
           SUM(CASE WHEN m.TipoMovimiento = 'Entrada' THEN m.Cantidad ELSE 0 END) AS TotalEntradas
    FROM Movimientos m
    INNER JOIN Insumos i ON i.IdInsumo = m.IdInsumo
    INNER JOIN Areas a ON a.IdArea = m.IdArea
    WHERE m.FechaMovimiento >= @FechaDesde
      AND m.FechaMovimiento < DATEADD(DAY, 1, @FechaHasta)
      AND (@IdArea IS NULL OR m.IdArea = @IdArea)
    GROUP BY i.NombreInsumo, i.UnidadMedida, a.NombreArea
    ORDER BY TotalConsumo DESC;
END;
GO

-- Funcion diferencial: proyeccion de reabastecimiento basada en consumo promedio diario (30 dias)
CREATE OR ALTER PROCEDURE sp_ProyeccionReabastecimiento
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @FechaCorte DATETIME = DATEADD(DAY, -30, GETDATE());

    SELECT
        i.NombreInsumo,
        i.UnidadMedida,
        i.StockActual,
        i.StockMinimo,
        ISNULL(c.TotalConsumo30, 0) AS ConsumoUltimos30Dias,
        CAST(ISNULL(c.TotalConsumo30, 0) / 30.0 AS DECIMAL(10,2)) AS ConsumoPromedioDiario,
        CASE
            WHEN ISNULL(c.TotalConsumo30, 0) = 0 THEN 999
            WHEN i.StockActual <= i.StockMinimo THEN 0
            ELSE CAST((i.StockActual - i.StockMinimo) / (CAST(c.TotalConsumo30 AS DECIMAL) / 30.0) AS INT)
        END AS DiasHastaNivelMinimo,
        CASE
            WHEN ISNULL(c.TotalConsumo30, 0) = 0 THEN i.StockMinimo * 2
            ELSE CAST(ISNULL(c.TotalConsumo30, 0) / 30.0 * 30.0 + i.StockMinimo AS INT)
        END AS CantidadSugeridaReorden
    FROM Insumos i
    LEFT JOIN (
        SELECT m.IdInsumo, SUM(m.Cantidad) AS TotalConsumo30
        FROM Movimientos m
        WHERE m.TipoMovimiento = 'Salida' AND m.FechaMovimiento >= @FechaCorte
        GROUP BY m.IdInsumo
    ) c ON c.IdInsumo = i.IdInsumo
    WHERE i.Estado = 1
    ORDER BY DiasHastaNivelMinimo, i.NombreInsumo;
END;
GO
