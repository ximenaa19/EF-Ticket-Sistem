# Sistema de Gestión de Tiquetes Aéreos

API REST completa para gestionar reservas de vuelos, aerolíneas, pasajeros y toda la operativa de una agencia de tiquetes aéreos.

## Descripción del Proyecto

Este sistema permite:
- **Gestión de vuelos**: Crear y administrar vuelos con información de salida, destino, capacidad y estado
- **Reservas de pasajeros**: Crear reservas asociadas a vuelos específicos
- **Gestión de pasajeros**: Registrar pasajeros con información personal, documentos y contacto
- **Tarifas dinámicas**: Establecer precios según el tipo de cabina y tipo de pasajero
- **Aeropuertos y rutas**: Administrar rutas entre aeropuertos con distancia
- **Usuarios y permisos**: Control de acceso mediante roles y permisos
- **Estado de vuelos**: Seguimiento de estado de vuelos (programado, despegado, etc.)
- **Check-in**: Gestión de check-in de pasajeros

## Características Principales

-  Arquitectura en capas (Clean Architecture)
-  Patrón Repository para acceso a datos
-  Entity Framework Core 10 con PostgreSQL
-  Validaciones con FluentValidation
-  Mapping con Mapster
-  MediatR para orquestación
-  Swagger/OpenAPI integrado
-  Migraciones versionadas de base de datos

## Requisitos Previos

- **.NET 10.0 SDK** [Descargar](https://dotnet.microsoft.com/download)
- **PostgreSQL 14+** [Descargar](https://www.postgresql.org/download/)
- **Git** (opcional, para clonar el repo)
- **VS Code o Visual Studio** (recomendado)
- **Entity Framework CLI**: `dotnet tool install -g dotnet-ef --version 10.0.7`

## Estructura del Proyecto

```
SistemaGestionTiquetesAereos/
├── Api/                              # Capa de presentación
│   ├── Controllers/                  # Controladores REST
│   ├── Dtos/                         # Data Transfer Objects
│   ├── Middlewares/                  # Middleware personalizado
│   └── Program.cs                    # Configuración de startup
│
├── Application/                      # Capa de lógica de negocio
│   ├── UseCases/                     # Casos de uso (handlers MediatR)
│   ├── Abstractions/                 # Interfaces y contratos
│   └── DependencyInjection.cs        # Inyección de dependencias
│
├── Domain/                           # Capa de dominio
│   ├── Entities/                     # Modelos de negocio
│   ├── ValueObjects/                 # Objetos de valor
│   └── Exceptions/                   # Excepciones de negocio
│
└── Infrastructure/                   # Capa de infraestructura
    ├── Context/                      # DbContext de EF Core
    ├── Repositories/                 # Implementación de repositorios
    ├── Migrations/                   # Migraciones de base de datos
    └── UnitOfWork/                   # Patrón Unit of Work
```

## Instalación y Setup

### 1. Clonar el repositorio
```bash
git clone <repo-url>
cd SistemaGestionTiquetesAereos
```

### 2. Configurar la Base de Datos
Edita `Api/appsettings.Development.json` con tu conexión PostgreSQL:

```json
{
  "ConnectionStrings": {
    "AirlineTicketSystemDb": "Host=localhost;Port=5432;Database=airline_db;Username=postgres;Password=tu_password"
  }
}
```

### 3. Restaurar dependencias y compilar
```bash
dotnet restore SistemaGestionTiquetesAereos.sln
dotnet build SistemaGestionTiquetesAereos.sln
```

### 4. Aplicar migraciones
Desde la raíz del proyecto:
```bash
dotnet ef database update --project Infrastructure\Infrastructure.csproj --startup-project Api\Api.csproj
```

Si estás en `Api/`:
```bash
dotnet ef database update --project ..\Infrastructure\Infrastructure.csproj --startup-project .
```

### 5. Ejecutar la API
```bash
cd Api
dotnet run
```

**Salida esperada:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5273
```

## Acceder a la API

| Recurso | URL |
|---------|-----|
| **API Base** | http://localhost:5273 |
| **Swagger UI** | http://localhost:5273/swagger |
| **OpenAPI JSON** | http://localhost:5273/swagger/v1/swagger.json |
| **Salud de API** | http://localhost:5273/health (si está configurado) |



## Entidades Principales de la Base de Datos

### Gestión de Vuelos
| Tabla | Descripción |
|-------|-------------|
| **airlines** | Aerolíneas (Aeromexico, United, etc.) |
| **airports** | Aeropuertos con código IATA (JFK, MEX, etc.) |
| **routes** | Rutas entre dos aeropuertos |
| **aircraft** | Aviones de las aerolíneas con capacidad |
| **flights** | Vuelos específicos con horarios y capacidad |
| **fares** | Tarifas según cabina y tipo de pasajero |

### Gestión de Reservas
| Tabla | Descripción |
|-------|-------------|
| **reservations** | Reservas de vuelos con código único |
| **reservation_flights** | Relación entre reservas y vuelos |
| **reservation_passengers** | Pasajeros asociados a la reserva |
| **reservation_statuses** | Estados de reserva (Confirmada, Cancelada, etc.) |

### Pasajeros y Personas
| Tabla | Descripción |
|-------|-------------|
| **people** | Datos de personas (nombre, documento, etc.) |
| **passengers** | Pasajeros asociados a una reserva |
| **person_emails** | Emails de personas |
| **person_phones** | Teléfonos de personas |
| **clients** | Clientes que hacen reservas |

### Catálogos
| Tabla | Descripción |
|-------|-------------|
| **document_types** | Tipos de documento (Pasaporte, ID Nacional, etc.) |
| **passenger_types** | Tipos de pasajero (Adulto, Niño, Bebé) |
| **cabin_types** | Tipos de cabina (Economy, Business, First) |
| **flight_statuses** | Estados de vuelo (Programado, En vuelo, Aterrizó) |
| **availability_statuses** | Disponibilidad de aviones (Disponible, Mantenimiento) |
| **phone_codes** | Códigos de país (+1, +52, etc.) |
| **email_domains** | Dominios de email (gmail.com, hotmail.com) |
| **continents, countries, regions, cities** | Geografía para ubicar aeropuertos |

### Control de Acceso
| Tabla | Descripción |
|-------|-------------|
| **users** | Usuarios del sistema |
| **roles** | Roles de usuario (Admin, Staff, etc.) |
| **permissions** | Permisos del sistema |
| **role_permissions** | Permisos asociados a roles |

## Endpoints Principales

### Vuelos
```
GET    /api/flights              - Listar todos los vuelos
GET    /api/flights/{id}         - Obtener detalles de un vuelo
POST   /api/flights              - Crear nuevo vuelo
PUT    /api/flights/{id}         - Actualizar vuelo
DELETE /api/flights/{id}         - Eliminar vuelo
```

### Reservas
```
GET    /api/reservations         - Listar reservas
GET    /api/reservations/{id}    - Obtener detalles de reserva
POST   /api/reservations         - Crear nueva reserva
PUT    /api/reservations/{id}    - Actualizar reserva
DELETE /api/reservations/{id}    - Cancelar reserva
```

### Pasajeros
```
GET    /api/passengers           - Listar pasajeros
POST   /api/passengers           - Crear pasajero
GET    /api/passengers/{id}      - Obtener detalles de pasajero
PUT    /api/passengers/{id}      - Actualizar pasajero
```

### Aerolíneas y Aeropuertos
```
GET    /api/airlines             - Listar aerolíneas
GET    /api/airports             - Listar aeropuertos
GET    /api/routes               - Listar rutas disponibles
```

**Nota:** Ver Swagger en `/swagger` para la documentación completa de todos los endpoints.

## Base de Datos

- **Motor**: PostgreSQL 14+
- **Inicialización**: Automática mediante migraciones
- **Configuración**: `appsettings.Development.json`

Para crear una nueva migración después de cambiar modelos:
```bash
dotnet ef migrations add NombreMigracion --project Infrastructure\Infrastructure.csproj --startup-project Api\Api.csproj
```

## Datos de Prueba

### Insertar Datos Iniciales

1. Abre PostgreSQL con tu cliente preferido (pgAdmin, DBeaver, etc.)
2. Conecta a la base de datos `airline_db`
3. Ejecuta el script SQL con datos de ejemplo para llenar tablas de catálogos

Los datos de prueba incluyen:
- Continentes, países, ciudades
- Aerolíneas y aeropuertos
- Rutas de vuelos
- Tipos de pasajeros y cabinas
- Estados de reservas y vuelos
- Y más...

Encontrarás scripts de ejemplo en la documentación.

## Estructura de Respuestas API

### Respuesta exitosa (200 OK)
```json
{
  "id": "uuid",
  "flightCode": "AMX100",
  "departureDate": "2026-06-01T10:00:00Z",
  "estimatedArrivalDate": "2026-06-01T17:30:00Z",
  "totalCapacity": 180,
  "availableSeats": 175,
  "isActive": true
}
```

### Error (400 Bad Request)
```json
{
  "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "FlightCode": ["FlightCode is required"]
  }
}
```

## Solución de Problemas

### ❌ Error: "Unable to retrieve project metadata"
**Solución**: Asegúrate de estar en la raíz del proyecto y usa rutas relativas correctas:
```bash
dotnet ef database update --project Infrastructure\Infrastructure.csproj --startup-project Api\Api.csproj
```

### ❌ Error: "Database connection refused"
**Solución**: Verifica que PostgreSQL esté corriendo y que `appsettings.Development.json` tenga los datos correctos:
```bash
psql -U postgres -d airline_db  # Prueba la conexión
```

### ❌ Error de Puerto: "Address already in use"
**Solución**: Cambia el puerto en `launchSettings.json` o mata el proceso:
```bash
netstat -ano | findstr :5273  # Windows
lsof -i :5273                  # Mac/Linux
```

### ❌ Migraciones pendientes
**Solución**: Ejecuta la actualización de BD:
```bash
dotnet ef database update
```

## Desarrollo

### Tecnologías usadas
- **Framework**: ASP.NET Core 10
- **ORM**: Entity Framework Core 10.0.7
- **Base de datos**: PostgreSQL 14+
- **Validación**: FluentValidation 12
- **Mapping**: Mapster 10
- **Orquestación**: MediatR 14
- **Documentación**: Swagger/OpenAPI

### Crear una nueva entidad
1. Define la entidad en `Domain/Entities/`
2. Configura el mapeo en `Infrastructure/Configuration/`
3. Crea un repositorio en `Infrastructure/Repositories/`
4. Agrega casos de uso en `Application/UseCases/`
5. Implementa el controlador en `Api/Controllers/`
6. Crea una migración: `dotnet ef migrations add NombreEntidad`

## Soporte

Para reportar issues o sugerencias:
1. Abre un issue en el repositorio
2. Describe el problema detalladamente
3. Incluye logs de error si es relevante

---

**Versión**: 1.0  
**Última actualización**: Mayo 2026  
**Desarrollado por**: Equipo de desarrollo
