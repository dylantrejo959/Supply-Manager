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

INSERT INTO Roles (NombreRol)
VALUES ('Administrador'), ('Almacenista'), ('Supervisor');
GO

INSERT INTO Usuarios (Usuario, Clave, IdRol, Estado)
VALUES ('admin', '123', 1, 1);
GO

INSERT INTO Areas (NombreArea)
VALUES ('Laboratorio'), ('Produccion'), ('Almacen');
GO

INSERT INTO Proveedores (NombreProveedor, Telefono, Correo, Direccion)
VALUES ('Proveedor General', '0000000000', 'proveedor@demo.com', 'Sin direccion');
GO

INSERT INTO Insumos (NombreInsumo, Descripcion, StockActual, StockMinimo, UnidadMedida)
VALUES
('Guantes', 'Guantes de latex', 100, 20, 'Caja'),
('Alcohol', 'Alcohol antiséptico', 50, 10, 'Litro');
GO

CREATE OR ALTER PROCEDURE sp_Login
    @Usuario NVARCHAR(50),
    @Clave NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        u.IdUsuario,
        u.Usuario,
        r.NombreRol
    FROM Usuarios u
    INNER JOIN Roles r ON r.IdRol = u.IdRol
    WHERE u.Usuario = @Usuario
      AND u.Clave = @Clave
      AND u.Estado = 1;
END;
GO
