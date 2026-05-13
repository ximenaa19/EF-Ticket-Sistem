# Sistema de Gestión de Tiquetes Aéreos

API REST completa para gestionar reservas de vuelos, aerolíneas, pasajeros y toda la operativa de una agencia de tiquetes aéreos.

## 📋 Descripción del Proyecto

Este sistema permite:
- **Gestión de vuelos**: Crear y administrar vuelos con información de salida, destino, capacidad y estado
- **Reservas de pasajeros**: Crear reservas asociadas a vuelos específicos
- **Gestión de pasajeros**: Registrar pasajeros con información personal, documentos y contacto
- **Tarifas dinámicas**: Establecer precios según el tipo de cabina y tipo de pasajero
- **Aeropuertos y rutas**: Administrar rutas entre aeropuertos con distancia
- **Usuarios y permisos**: Control de acceso mediante roles y permisos
- **Estado de vuelos**: Seguimiento de estado de vuelos (programado, despegado, etc.)
- **Check-in**: Gestión de check-in de pasajeros

## ✨ Características Principales

- ✅ Arquitectura en capas (Clean Architecture)
- ✅ Patrón Repository para acceso a datos
- ✅ Entity Framework Core 10 con PostgreSQL
- ✅ Validaciones con FluentValidation
- ✅ Mapping con Mapster
- ✅ MediatR para orquestación
- ✅ Swagger/OpenAPI integrado
- ✅ Migraciones versionadas de base de datos

## 🛠️ Requisitos Previos

- **.NET 10.0 SDK** [Descargar](https://dotnet.microsoft.com/download)
- **PostgreSQL 14+** [Descargar](https://www.postgresql.org/download/)
- **Git** (opcional, para clonar el repo)
- **VS Code o Visual Studio** (recomendado)
- **Entity Framework CLI**: 
  ```bash
  dotnet tool install -g dotnet-ef --version 10.0.7
  ```

## 🚀 Inicio Rápido

### 1. Clonar el repositorio
```bash
git clone <repo-url>
cd Ticketes_Aereos
```

### 2. Configurar la Base de Datos
Edita `SistemaGestionTiquetesAereos/Api/appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "AirlineTicketSystemDb": "Host=localhost;Port=5432;Database=airline_db;Username=postgres;Password=tu_password"
  }
}
```

### 3. Restaurar dependencias y compilar
```bash
cd SistemaGestionTiquetesAereos
dotnet restore SistemaGestionTiquetesAereos.sln
dotnet build SistemaGestionTiquetesAereos.sln
```

### 4. Aplicar migraciones
```bash
dotnet ef database update --project Infrastructure\Infrastructure.csproj --startup-project Api\Api.csproj
```

### 5. Ejecutar la API
```bash
cd Api
dotnet run
```

**La API estará en**: http://localhost:5273

## 📚 Documentación

- **Swagger UI**: http://localhost:5273/swagger
- **README Detallado**: [Ver aquí](./SistemaGestionTiquetesAereos/README.md)

## 📁 Estructura del Proyecto

```
Ticketes_Aereos/
└── SistemaGestionTiquetesAereos/
    ├── Api/                      # Capa de presentación (Controllers, DTOs)
    ├── Application/              # Capa de lógica de negocio (UseCases)
    ├── Domain/                   # Capa de dominio (Entities, ValueObjects)
    ├── Infrastructure/           # Capa de infraestructura (DbContext, Repositories)
    └── README.md                 # Documentación detallada del proyecto
```

## 🗄️ Base de Datos Principal

| Tabla | Propósito |
|-------|-----------|
| **flights** | Vuelos con horarios y capacidad |
| **reservations** | Reservas de pasajeros |
| **passengers** | Datos de pasajeros |
| **airlines** | Información de aerolíneas |
| **airports** | Aeropuertos con códigos IATA |
| **routes** | Rutas entre aeropuertos |
| **users** | Usuarios del sistema |

Para lista completa de tablas, ver [README detallado](./SistemaGestionTiquetesAereos/README.md).

## 🔗 Endpoints Principales

### Vuelos
```
GET    /api/flights              - Listar vuelos
POST   /api/flights              - Crear vuelo
GET    /api/flights/{id}         - Obtener detalles
PUT    /api/flights/{id}         - Actualizar vuelo
DELETE /api/flights/{id}         - Eliminar vuelo
```

### Reservas
```
GET    /api/reservations         - Listar reservas
POST   /api/reservations         - Crear reserva
GET    /api/reservations/{id}    - Obtener detalles
```

### Pasajeros
```
GET    /api/passengers           - Listar pasajeros
POST   /api/passengers           - Crear pasajero
```

**Nota:** Ver Swagger para documentación completa.

## 📊 Tecnologías

- **Framework**: ASP.NET Core 10
- **ORM**: Entity Framework Core 10.0.7
- **BD**: PostgreSQL 14+
- **Validación**: FluentValidation 12
- **Mapping**: Mapster 10
- **Orquestación**: MediatR 14
- **Documentación**: Swagger/OpenAPI

## ❓ Problemas Comunes

### Error: "Database connection refused"
```bash
psql -U postgres -d airline_db  # Verifica la conexión
```

### Error de Puerto: "Address already in use"
```bash
netstat -ano | findstr :5273  # Windows
lsof -i :5273                  # Mac/Linux
```

### Migraciones pendientes
```bash
dotnet ef database update
```

Ver [troubleshooting completo](./SistemaGestionTiquetesAereos/README.md#solución-de-problemas).

## 👤 Autor

Equipo de desarrollo - Mayo 2026

## 📄 Licencia

Este proyecto está bajo licencia MIT.

---

**Para más información**, consulta el [README detallado del proyecto](./SistemaGestionTiquetesAereos/README.md).
