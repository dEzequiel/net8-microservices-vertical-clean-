# mandatory-applied-architecture-net8

- Servicio micro del catálogo que incluye:
  - ASP.NET Core Minimal APIs y las últimas características de .NET 8 y C# 12
  - Implementación de la arquitectura de Vertical Slice.
  - Implementación de CQRS utilizando la biblioteca MediatR
  - Comportamientos de canalización de validación de CQRS con MediatR y FluentValidation
  - Uso de la biblioteca Marten para la base de datos de documentos transaccionales .NET en PostgreSQL
  - Uso de Carter para la definición de minimal endpoints.
  - Aspectos transversales (crosscuting) de logging, manejo global de excepciones y health checks.
    
# Desarrollo

- Capitulo 1 - Servicio `Catalog`
  - Lanzar proyecto                       0:00
  - Dominio                                2:22
  - Quick: Crosscutting                   5:00
  - Quick: CQRS, MediatR y su coexistencia 7:19
  - Abstracción CQRS de Query             10:47
  - Abstracción CQRS de Command           14:31
  - Abstracción CQRS de QueryHandler      16:48
  - Abstracción CQRS de CommandHandler    21:03
  - Implementación de mensajes tipo Query 24:53
  - Implementación de mensajes tipo Command 28:49
  - Registrar mínimal endpoints y libreria Carter 34:38
  - Minimal Endpoint FindProductById con Carter 36:23
  - Query Handler FindProductById con MediatR 43:23
  - Minimal Endpoint AddProduct con Carter 49:01
  - Command Handler AddProduct con MediatR 55:14
  - Quick: Popular base de datos en desarrollo 58:55
  - Quick: Crear migraciones 1:07:32
  - Quick: Prueba rapida de Endpoints 1:11:36
  - MediatR y los PipelineBehaviours 1:13:33
  - RequestPerformanceBehaviour con 1:16:24
  - PreRequestLoggingBehaviour con MediatR
  - PostRequestLoggingBehaviour con MediatR
  - global_usings        
