# mandatory-applied-architecture-net8

- Servicio micro del catálogo que incluye:
  - ASP.NET Core Minimal APIs y las últimas características de .NET 8 y C# 12
  - Implementación de la arquitectura de Vertical Slice.
  - Implementación de CQRS utilizando la biblioteca MediatR
  - Comportamientos de canalización de validación de CQRS con MediatR y FluentValidation
  - Uso de la biblioteca Marten para la base de datos de documentos transaccionales .NET en PostgreSQL
  - Uso de Carter para la definición de minimal endpoints.
  - Aspectos transversales (crosscuting) de logging, manejo global de excepciones y health checks.
    
- Capitulo 1 - Servicio `Catalog`
  00:00 - Lanzar proyecto
  02:22 - Dominio
  05:00 - Quick: Crosscutting
  07:19 - Quick: CQRS, MediatR y su coexistencia
  10:47 - Abstracción CQRS de Query
  14:31 - Abstracción CQRS de Command
  16:48 - Abstracción CQRS de QueryHandler
  21:03 - Abstracción CQRS de CommandHandler
  24:53 - Implementación de mensajes tipo Query
  28:49 - Implementación de mensajes tipo Command
  34:38 - Registrar mínimal endpoints y libreria Carter
  36:23 - Minimal Endpoint FindProductById con Carter
  43:23 - Query Handler FindProductById con MediatR
  49:01 - Minimal Endpoint AddProduct con Carter
  55:14 - Command Handler AddProduct con MediatR
  58:55 - Quick: Popular base de datos en desarrollo
  1:07:32 - Quick: Crear migraciones
  1:11:36 - Quick: Prueba rapida de endpoints y handlers
  1:13:33 - MediatR y los Behaviours
  1:16:24 - RequestPerformanceBehaviour con MediatR

