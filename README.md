# ClienteApi

API REST desarrollada en Visual Basic .NET (ASP.NET Core Web API) para administrar los clientes de una empresa. Permite registrar, consultar, modificar y eliminar clientes, utilizando SQL Server como mecanismo de persistencia y Entity Framework Core como ORM.

# Tecnologías utilizadas

- Visual Basic .NET
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core 8
- SQL Server
- Swagger / Swashbuckle
- Inyección de Dependencias nativa de ASP.NET Core

# Estructura del proyecto

ClienteApi/
├── Controllers/
│   └── ClientesController.vb   # Endpoints REST (CRUD)
├── Services/
│   ├── IClienteService.vb
│   └── ClienteService.vb       # Lógica de negocio
├── Repositories/
│   ├── IClienteRepository.vb
│   └── ClienteRepository.vb    # Acceso a datos vía EF Core
├── Models/
│   └── Cliente.vb              # Entidad Cliente
├── Data/
│   └── EmpresaDBContext.vb     # DbContext de EF Core
├── Program.vb                  # Configuración de la app y DI
├── appsettings.json            # Cadena de conexión a SQL Server
└── ClienteApi.vbproj

EmpresaDB.sql                   # Script de creación de BD y tabla


# Modelo de datos

Base de datos: EmpresaDB
Tabla: Clientes

| Campo    | Tipo          |
|----------|---------------|
| Id       | INT, PK, identity |
| Nombre   | VARCHAR(100)  |
| Apellido | VARCHAR(100)  |
| Email    | VARCHAR(150)  |
| Telefono | VARCHAR(30)   |

El script completo de creación se encuentra en EmpresaDB.sql

# Descripción de los endpoints

Ruta base: api/clientes

| Método | Ruta                 | Descripción                                                       | Body de ejemplo                 |
---------------------------------------------------------------------------------------------------------------------------------------
| GET    | /api/clientes        | Devuelve la lista de todos los clientes                           | —                               |
| GET    | /api/clientes/{id}   | Devuelve un cliente por su Id (404 si no existe)                  | —                               |
| POST   | /api/clientes        | Registra un nuevo cliente (201 Created)                           | { "nombre": "Ana",
                                                                                                        "apellido": "López",
                                                                                                        "email":  "ana@correo.com",
                                                                                                        "telefono": "0981000000" }    |
| PUT    | /api/clientes/{id}   | Modifica un cliente existente (204 No Content, 404 si no existe)  | { "nombre": "Ana",
                                                                                                        "apellido": "López García",
                                                                                                        "email": "ana@correo.com",
                                                                                                        "telefono": "0981000000" }    |
| DELETE | /api/clientes/{id}   | Elimina un cliente (204 No Content, 404 si no existe)             | —                               |

# Instrucciones para ejecutar el proyecto

# 1. Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/es-es/download/dotnet/8.0)
- SQL Server (local, LocalDB o Docker)
- (Opcional) Visual Studio 2022 o superior

# 2. Crear la base de datos

Ejecutar el script EmpresaDB.sql en SQL Server

# 3. Configurar la cadena de conexión

Editar appsettings.json y ajustar ConnectionStrings:EmpresaDBConnection según el servidor de SQL Server a utilizar


"ConnectionStrings": {
  "EmpresaDBConnection": "Server=.\\SQLEXPRESS;Database=EmpresaDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

# 4. Restaurar dependencias y ejecutar

Desde la carpeta ClienteApi:

dotnet restore
dotnet run

La API quedará disponible en la URL indicada en consola (por ejemplo https://localhost:5001), y la documentación Swagger en https://localhost:5001/swagger.

# 5. Probar los endpoints

Se puede utilizar Swagger UI, Postman o curl, por ejemplo:

curl -X GET https://localhost:5001/api/clientes