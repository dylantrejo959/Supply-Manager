CREATE DATABASE ControlInsumosDB;
GO

USE ControlInsumosDB;
GO

CREATE TABLE Roles (
    IdRol INT PRIMARY KEY IDENTITY(1,1),
    NombreRol NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL UNIQUE,
    Clave NVARCHAR(100) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    IdRol INT NOT NULL,

    CONSTRAINT FK_Usuarios_Roles
        FOREIGN KEY (IdRol)
        REFERENCES Roles(IdRol)
);
GO

CREATE TABLE Areas (
    IdArea INT PRIMARY KEY IDENTITY(1,1),
    NombreArea NVARCHAR(100) NOT NULL UNIQUE,
    Descripcion NVARCHAR(255)
);
GO

CREATE TABLE Proveedores (
    IdProveedor INT PRIMARY KEY IDENTITY(1,1),
    NombreEmpresa NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20),
    Correo NVARCHAR(100),
    Direccion NVARCHAR(200),
    Estado BIT NOT NULL DEFAULT 1
);
GO

CREATE TABLE Insumos (
    IdInsumo INT PRIMARY KEY IDENTITY(1,1),
    NombreInsumo NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(255),
    UnidadMedida NVARCHAR(50) NOT NULL,
    StockActual INT NOT NULL DEFAULT 0,
    Estado BIT NOT NULL DEFAULT 1,

    IdProveedor INT NOT NULL,

    CONSTRAINT FK_Insumos_Proveedores
        FOREIGN KEY (IdProveedor)
        REFERENCES Proveedores(IdProveedor),

    CONSTRAINT CK_Insumos_Stock
        CHECK (StockActual >= 0)
);
GO

CREATE TABLE StockMinimo (
    IdStockMinimo INT PRIMARY KEY IDENTITY(1,1),
    CantidadMinima INT NOT NULL,
    FechaActualizacion DATE NOT NULL DEFAULT GETDATE(),

    IdInsumo INT NOT NULL UNIQUE,

    CONSTRAINT FK_StockMinimo_Insumos
        FOREIGN KEY (IdInsumo)
        REFERENCES Insumos(IdInsumo),

    CONSTRAINT CK_StockMinimo_Cantidad
        CHECK (CantidadMinima >= 0)
);
GO

CREATE TABLE Movimientos (
    IdMovimiento INT PRIMARY KEY IDENTITY(1,1),

    TipoMovimiento NVARCHAR(20) NOT NULL,
    Cantidad INT NOT NULL,
    FechaMovimiento DATETIME NOT NULL DEFAULT GETDATE(),
    Observacion NVARCHAR(255),

    IdInsumo INT NOT NULL,
    IdArea INT NOT NULL,
    IdUsuario INT NOT NULL,

    CONSTRAINT FK_Movimientos_Insumos
        FOREIGN KEY (IdInsumo)
        REFERENCES Insumos(IdInsumo),

    CONSTRAINT FK_Movimientos_Areas
        FOREIGN KEY (IdArea)
        REFERENCES Areas(IdArea),

    CONSTRAINT FK_Movimientos_Usuarios
        FOREIGN KEY (IdUsuario)
        REFERENCES Usuarios(IdUsuario),

    CONSTRAINT CK_Movimientos_Cantidad
        CHECK (Cantidad > 0),

    CONSTRAINT CK_Movimientos_Tipo
        CHECK (TipoMovimiento IN ('Entrada', 'Salida'))
);
GO

INSERT INTO Roles (NombreRol)
VALUES 
('Administrador'),
('Almacenista'),
('Supervisor');
GO

INSERT INTO Areas (NombreArea, Descripcion)
VALUES
('Laboratorio', 'Area principal de laboratorio'),
('Produccion', 'Area de produccion'),
('Almacen', 'Area de almacenamiento');
GO