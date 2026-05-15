# Supply Manager

Sistema de escritorio para el control de insumos, inventario y abastecimiento. El proyecto esta desarrollado en C# con Windows Forms y utiliza SQL Server como base de datos.

## Estado del proyecto

Prototipo inicial en desarrollo. Actualmente incluye inicio de sesion, estructura por capas y una base para gestionar insumos.

## Tecnologias

- C#
- Windows Forms
- .NET Framework 4.7.2
- SQL Server
- ADO.NET

## Funcionalidades iniciales

- Inicio de sesion con usuario
- Registro y consulta de insumos.
- Estructura para movimientos de entrada y salida.
- Base de datos con tablas principales para usuarios, roles, areas, proveedores, insumos y movimientos.

## Estructura general

- `UI/Forms`: pantallas de la aplicacion.
- `BLL/Services`: logica de negocio.
- `DAL/Data`: acceso a datos y repositorios.
- `Entities`: modelos principales del sistema.
- `Utils`: utilidades como conexion a base de datos y sesion.
- `Database`: script de creacion de la base de datos.

## Requisitos

- Visual Studio 2022 o compatible.
- .NET Framework 4.7.2.
- SQL Server o SQL Server Express.

## Instalacion rapida

1. Clonar el repositorio.
2. Abrir la solucion `Supply Manager.sln` en Visual Studio.
3. Ejecutar el script SQL incluido en la carpeta `Database` para crear la base de datos `DBInsumos`.
4. Revisar la cadena de conexion en `App.config` si se usa una instancia diferente de SQL Server.
5. Compilar y ejecutar el proyecto.

## Usuario de prueba

El script de base de datos incluye un usuario inicial:

- Usuario: `admin`
- Clave: `123`

## Notas

Este README es una version inicial y puede ampliarse a medida que el proyecto avance, por ejemplo agregando capturas, instrucciones de despliegue, pruebas y una descripcion mas detallada de los modulos.
