## Manual de Usuario

### Manual de Usuario — Supply Manager

#### Nombre del sistema
**Supply Manager** — Sistema de Control de Insumos y Abastecimiento

#### Objetivo
Permitir al personal de la organización registrar, consultar y controlar el inventario de insumos, gestionar movimientos de entrada y salida, administrar proveedores y áreas, y obtener reportes analíticos para la toma de decisiones.

#### Requisitos de instalación
- Sistema operativo: Windows 10 / Windows 11
- .NET Framework 4.7.2 (incluido en Windows 10/11 por defecto; si no está instalado, descargarlo de Microsoft)
- SQL Server Express o superior instalado y en ejecución
- Acceso a la base de datos `DBInsumos` (debe ejecutarse el script de instalación una sola vez)

#### Pasos de ejecución
1. Abrir la carpeta del sistema.
2. Ejecutar `Supply Manager.exe`.
3. En la pantalla de inicio de sesión, ingresar usuario y contraseña.
4. Presionar **Ingresar** para acceder al sistema.

#### Credenciales de prueba
| Rol            | Usuario     | Contraseña | Acceso                                     |
|----------------|-------------|------------|--------------------------------------------|
| Administrador  | `admin`     | `123`      | Acceso completo a todos los módulos         |
| Almacenista    | `almacen`   | `123`      | Insumos, movimientos, proveedores (sin usuarios/áreas) |
| Supervisor     | `supervisor`| `123`      | Solo consulta (sin modificaciones)         |

> **Nota:** Cambiar las contraseñas en producción desde el módulo de Usuarios.

#### Descripción de módulos

**Módulo 1: Inicio de Sesión**
Pantalla inicial del sistema. Validación de credenciales contra la base de datos. Solo usuarios con Estado activo pueden acceder.

**Módulo 2: Menú Principal**
Panel de navegación central. Muestra el nombre y rol del usuario activo. El acceso a cada módulo se habilita o deshabilita según el rol. La opción "Usuarios" es visible solo para el Administrador.

**Módulo 3: Gestión de Insumos**
- Permite crear, editar, buscar y desactivar insumos.
- Campos: Nombre, Descripción, Stock Actual, Stock Mínimo, Unidad de Medida.
- Filtros disponibles: por nombre, por unidad de medida, solo stock crítico.
- **Importante:** El stock solo se modifica registrando movimientos, no editando directamente.
- Acceso: Administrador y Almacenista. Supervisor solo consulta.

**Módulo 4: Registro de Movimientos**
- Registra entradas (reabastecimiento) y salidas (consumo) de insumos.
- Las salidas validan automáticamente que el stock no quede negativo.
- Los movimientos son permanentes: no pueden editarse ni eliminarse (trazabilidad de auditoría).
- Filtros: por insumo, área, tipo de movimiento, rango de fechas.
- Acceso: Administrador y Almacenista.

**Módulo 5: Gestión de Proveedores**
- CRUD de proveedores con datos de contacto (nombre, teléfono, correo, dirección).
- Búsqueda por nombre.
- Acceso: Administrador y Almacenista.

**Módulo 6: Gestión de Áreas**
- Administración de las áreas que consumen insumos (Laboratorio, Producción, etc.).
- Solo el Administrador puede agregar, modificar o eliminar áreas.
- Un área con movimientos registrados no puede ser eliminada.

**Módulo 7: Gestión de Usuarios**
- Exclusivo del Administrador.
- Permite crear usuarios nuevos con rol asignado, actualizar datos y desactivar usuarios.
- Los usuarios desactivados no pueden iniciar sesión pero sus movimientos se conservan.

**Módulo 8: Reportes**
Tres pestañas de análisis:

- **Stock Crítico:** Muestra todos los insumos cuyo stock actual es igual o inferior al stock mínimo, con el déficit calculado. Útil para generar órdenes de compra urgentes.

- **Consumo por Período:** Muestra el total de entradas y salidas por insumo y área en un rango de fechas seleccionable. Se puede filtrar por área específica.

- **Proyección de Reabastecimiento:** Usa el consumo de los últimos 30 días para calcular:
  - Consumo promedio diario
  - Días estimados hasta que el stock llegue al nivel mínimo
  - Cantidad sugerida de reorden para cubrir 30 días adicionales

#### Capturas de pantalla

> **Instrucción:** En el documento Word, insertar capturas de las siguientes pantallas:
> 1. FrmLogin — pantalla de inicio de sesión
> 2. FrmMenuPrincipal — menú con usuario admin (todos los módulos visibles)
> 3. FrmInsumos — listado de insumos con filtros
> 4. FrmMovimientos — registro de movimiento con grid de historial
> 5. FrmReportes — tab de proyección de reabastecimiento con datos

#### Casos básicos de uso

**CU01 — Registrar una entrada de insumos**
1. Acceder al menú "Movimientos".
2. Seleccionar Tipo: **Entrada**.
3. Elegir el insumo de la lista desplegable.
4. Seleccionar el área de origen.
5. Ingresar la cantidad recibida.
6. (Opcional) Escribir una observación.
7. Presionar **Registrar movimiento**.
8. El sistema confirma el registro y actualiza el stock del insumo.

**CU02 — Consultar stock crítico**
1. Acceder al menú "Reportes".
2. Seleccionar la pestaña "Stock Crítico".
3. Presionar **Generar reporte**.
4. La tabla muestra todos los insumos con stock en nivel crítico y el déficit.

**CU03 — Agregar un nuevo proveedor**
1. Acceder al menú "Proveedores".
2. Completar los campos: Nombre (obligatorio), Teléfono, Correo y Dirección.
3. Presionar **Agregar**.
4. El proveedor aparece en la lista inferior.

**CU04 — Cerrar sesión**
1. Desde el menú principal, presionar **Cerrar Sesión**.
2. El sistema cierra la sesión y regresa a la pantalla de inicio de sesión.
