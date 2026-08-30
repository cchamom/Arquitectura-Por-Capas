```markdown
# ArquitecturaCapas - API REST con ASP.NET Core y SQLite

Una aplicación web desarrollada bajo una **Arquitectura en Capas** estricta con **ASP.NET Core 8**, aplicando el Patrón Repository, Inyección de Dependencias, Entity Framework Core y persistencia de datos local con **SQLite**.

---

##  Configuración de la Arquitectura

El proyecto se encuentra organizado modularmente para garantizar la separación de responsabilidades y un bajo acoplamiento:

1. **`Controllers` (Capa de Presentación / API):** Expone los endpoints HTTP (`GET`, `POST`, etc.) y maneja las respuestas hacia los clientes.
2. **`Services` (Capa de Lógica de Negocio):** Centraliza las reglas de negocio y procesa las peticiones recibidas desde los controladores antes de interactuar con los datos.
3. **`Repos` (Capa de Acceso a Datos):** Implementa el patrón Repositorio a través de interfaces (`IProductoRepository`) y clases concretas (`ProductoRepository`) para desacoplar el almacenamiento.
4. **`Data` (Capa de Contexto / EF Core):** Contiene el `TiendaDbContext` encargado del mapeo objeto-relacional (ORM) mediante Entity Framework Core.
5. **`Models` (Capa de Entidades):** Define las estructuras de datos y modelos de dominio (por ejemplo, la entidad `Producto`).

---

## Configuración (`appsettings.json`)

El archivo de configuración define la cadena de conexión para el archivo local de base de datos SQLite (`arquitectura.db`):

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=arquitectura.db"
  },
  "AllowedHosts": "*"
}

```

---

## Cómo Ejecutar el Proyecto

Sigue estos pasos para compilar y poner en marcha la API en tu equipo local:

### Prerrequisitos

* Tener instalado **.NET 8 SDK**.
* Editor de código (Visual Studio Code o Visual Studio).

### Pasos de ejecución

1. Abre tu terminal y navega hasta la carpeta raíz del proyecto donde se encuentra el archivo `.csproj`:
```bash
cd ArquitecturaCapas/ArquitecturaCapas

```


2. Restaura los paquetes NuGet y compila la solución:
```bash
dotnet restore
dotnet build

```


3. Ejecuta la aplicación:
```bash
dotnet run

```


4. La consola indicará el puerto en el que está corriendo (por ejemplo, `http://localhost:5073`).

---

## Pruebas y Documentación Interactiva (Swagger)

La API cuenta con soporte para **Swagger UI**, permitiendo probar los endpoints de forma visual en tiempo real. Abre tu navegador e ingresa a:
👉 `http://localhost:5073/swagger/index.html`

### Vista General de Endpoints

Se visualizan los controladores disponibles para la gestión de productos bajo la ruta `/api/Productos`.


### Creación de un Producto (Método POST)

Permite enviar un cuerpo JSON estructurado con los atributos del producto (nombre, precio, stock).


### Respuesta Exitosa del Servidor (Código 201 Created)

El servidor procesa el registro a través de la capa de servicios y el repositorio, guardándolo en SQLite y retornando el objeto creado con su ID autoincremental.


### Consulta de Listado General (Método GET)

Permite recuperar todos los registros almacenados en la base de datos de manera asíncrona.


```
