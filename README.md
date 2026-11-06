# TiendaApp

Aplicación web desarrollada con Blazor Server y .NET 10 para la gestión de productos y marcas. Proyecto del seminario de la Semana 8.

## Estado actual

- Aplicación funcional con operaciones de listado, registro, edición y eliminación de productos.
- Base de datos SQL Server con las tablas `marcas` y `productos`.
- Formulario reutilizable para crear y editar productos.
- Navegación corregida entre las rutas de productos.
- Repositorio Git inicializado en la rama `main`.
- Repositorio remoto: https://github.com/CarlosEvCode/TiendaApp
- Última actualización: 6 de noviembre de 2026.

## Tecnologías

- .NET 10
- Blazor Server / Razor Components
- Entity Framework Core 10
- SQL Server
- Bootstrap

## Requisitos

- .NET 10 SDK
- SQL Server
- Visual Studio con soporte para .NET 10 o la CLI de .NET

## Base de datos

Ejecutar el siguiente script en SQL Server para crear la base de datos, las tablas y los datos iniciales de marcas.

```sql
CREATE DATABASE TIENDA
GO

USE TIENDA
GO

CREATE TABLE marcas
(
	id		INT IDENTITY(1,1) PRIMARY KEY,
	marca	VARCHAR(50) NOT NULL,
	CONSTRAINT uk_nombre_mar UNIQUE (marca)
)
GO

CREATE TABLE productos
(
	id		INT IDENTITY(1,1) PRIMARY KEY,
	idmarca	INT		NOT NULL,
	descripcion	VARCHAR(300)	NOT NULL,
	precio		DECIMAL(8,2)	NOT NULL,
	stock		INT				NOT NULL DEFAULT 0,
	CONSTRAINT fk_idmarca_prd FOREIGN KEY (idmarca) REFERENCES marcas (id)
)
GO

INSERT INTO marcas (marca) VALUES ('Samsung'), ('LG'), ('Logitech')
SELECT * FROM marcas
GO
```

El script crea:

- `marcas`: identificador, nombre de marca único.
- `productos`: identificador, marca, descripción, precio y stock.
- Relación de llave foránea entre `productos.idmarca` y `marcas.id`.
- Marcas de prueba: Samsung, LG y Logitech.

El proyecto no utiliza migraciones de Entity Framework Core. La estructura de la base de datos se crea con el script anterior.

## Configuración de conexión

La cadena de conexión se encuentra en `TiendaApp/appsettings.json`, dentro de `ConnectionStrings:Tienda`.

```json
{
  "ConnectionStrings": {
    "Tienda": "Server=TU_SERVIDOR;Database=TIENDA;User Id=TU_USUARIO;Password=TU_PASSWORD;TrustServerCertificate=true;"
  }
}
```

Ajustar el servidor, usuario y contraseña según el entorno local.

## Ejecución

Desde la carpeta raíz del proyecto:

```bash
dotnet run --project TiendaApp/TiendaApp.csproj
```

También se puede abrir `TiendaApp.slnx` en Visual Studio y ejecutar el proyecto.

## Funcionalidad

- Listar productos con su marca, descripción, precio y stock.
- Registrar nuevos productos.
- Editar productos existentes.
- Eliminar productos con confirmación.
- Cargar las marcas disponibles desde la base de datos.
- Validar campos obligatorios, precio y stock mediante DataAnnotations.
- Actualizar el listado sin realizar una segunda consulta después de eliminar.

## Rutas

| Ruta | Descripción |
|---|---|
| `/productos` | Listado de productos |
| `/productos/crear` | Formulario de nuevo producto |
| `/productos/editar/{id}` | Formulario de edición de producto |

## Estructura del proyecto

```text
TiendaApp/
├── TiendaApp.slnx
└── TiendaApp/
    ├── Components/
    │   ├── Layout/
    │   └── Pages/
    │       └── Productos/
    │           ├── Index.razor
    │           ├── Crear.razor
    │           ├── Editar.razor
    │           └── ProductoForm.razor
    ├── Data/
    │   └── TiendaContext.cs
    ├── Models/
    │   ├── Marca.cs
    │   └── Producto.cs
    ├── Services/
    │   └── ProductoService.cs
    ├── appsettings.json
    └── Program.cs
```

## Modelo de datos

### Marca

| Campo | Tipo | Descripción |
|---|---|---|
| `id` | INT | Llave primaria |
| `marca` | VARCHAR(50) | Nombre de la marca, único |

### Producto

| Campo | Tipo | Descripción |
|---|---|---|
| `id` | INT | Llave primaria |
| `idmarca` | INT | Llave foránea a `marcas.id` |
| `descripcion` | VARCHAR(300) | Descripción del producto |
| `precio` | DECIMAL(8,2) | Precio del producto |
| `stock` | INT | Cantidad disponible |

## Notas

- El proyecto usa `IDbContextFactory<TiendaContext>` para crear contextos de Entity Framework Core bajo demanda.
- `ProductoService` implementa las operaciones CRUD y el listado de marcas.
- Las rutas de los enlaces deben coincidir con las declaraciones `@page` de los componentes Razor.
- La aplicación no incluye autenticación ni autorización.
