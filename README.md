🧪 Reto Técnico – Arquitectura Hexagonal en .NET 8

### Descripción

Esta solución implementa un sistema basado en Microservicios utilizando .NET 8, aplicando los principios de Clean Architecture y el patrón Hexagonal Architecture (Ports & Adapters).
El objetivo de esta arquitectura es desacoplar la lógica de negocio de las dependencias externas, permitiendo que la aplicación sea más mantenible, testeable y extensible.
La solución está compuesta por tres microservicios principales y un Backend for Frontend (BFF) encargado de exponer únicamente los datos necesarios al cliente.

Los servicios implementados son:

- **TokenService** → Genera tokens JWT para autenticación.
- **UserService** → Obtiene información de usuarios desde una API externa.
- **PhotoService** → Obtiene la imagen del usuario y la devuelve en formato Base64.
- **BFF** → Orquesta los servicios internos y expone una respuesta simplificada al cliente.

El BFF se encarga de:

- Unificar información de los microservicios
- Ocultar datos sensibles como el **correo electrónico**
- Validar autenticación mediante **JWT**
- Entregar una respuesta simplificada para el frontend


### Arquitectura

La solución sigue los principios de Clean Architecture implementando el patrón Hexagonal Architecture (Ports & Adapters).
Este enfoque permite separar la lógica de negocio del acceso a infraestructura externa, logrando un sistema desacoplado y fácil de mantener.

Cada microservicio está organizado en las siguientes capas:

- **Api**
- **Application**
- **Domain**
- **Infrastructure**

Responsabilidades:

| Capa | Responsabilidad |
|-----|----------------|
Api | Controllers y configuración HTTP |
Application | Casos de uso, handlers y contratos |
Domain | Entidades del dominio |
Infrastructure | Implementaciones de acceso a APIs externas |

Esta estructura permite:

- Separación de responsabilidades
- Bajo acoplamiento
- Mayor facilidad para pruebas unitarias



### Arquitectura de servicios

Cliente
   |
   |-----> TokenService  (obtener JWT)
   |
   v
BFF Service
   |
   |-----> UserService
   |
   |-----> PhotoService

**TokenService** → Generación de JWT

El cliente interactúa con el **TokenService** para obtener un JWT y posteriormente
consume el **BFF**, el cual se encarga de coordinar los microservicios internos.



### Requisitos previos

Antes de ejecutar la solución es necesario:

1. Contar con **.NET 8 SDK**
2. Crear una API Key en el recurso externo proporcionado

  Sitio: https://reqres.in/api/users

  Para obtener la API Key: https://app.reqres.in/api-keys



### Configuración

1. En el archivo `appsettings.json` del **UserService** y **PhotoService** reemplazar el valor de "ReqResApiKey" por la nueva API key creada previamente:

"ExternalServices": {
  ...
  "ReqResApiKey": "YOUR_API_KEY"
}

2. En el archivo `appsettings.json` del **TokenService** y **BFF** reemplazar el valor de "Key" por una clave secreta aleatoria segura:

"Jwt": {
    "Key": "YOUR_SECRET_KEY",
    ...
  }   



### Cómo ejecutar la solución

1. Clonar el repositorio : git clone https://github.com/AndresEspinoza830/Caso_IBK.git
2. Abrir cada microservicio en Visual Studio

3. Ejecutar los servicios en el siguiente orden:

- TokenService
- UserService
- PhotoService
- BFFService



### Flujo de autenticación

1. Obtener token

   En **TokenService** llamar al endpoint : POST /api/token/generateToken

   Body :{
    "username": "admin",
    "password": "caso_ibk_123"
  }

‼️Es importante usar este mismo body, debido que el **TokenService** espera ese valores para generar el token.

  Response :{
    "token": "JWT_TOKEN"
  }

 2. Consumir endpoint del **BFF**

    En el **BFF** llamar al endpoint : GET /api/profile/{id}

    Header requerido:
    Authorization: Bearer {token}

    Response:{
      "id": 1,
      "name": "George Bluth",
      "photo": "BASE64_IMAGE"
    }
  
El **BFF** agrega información de:

- **UserService**
- **PhotoService**

y elimina datos sensibles como el correo electrónico.   


### Seguridad

La solución utiliza **JWT Authentication** para proteger el acceso al BFF.

Flujo:

1. El cliente obtiene un token en **TokenService**
2. El token se envía en el header **Authorization**
3. El **BFF** valida el token antes de procesar la solicitud



### Rate Limiting

El **PhotoService** implementa un mecanismo de **Rate Limiting** para evitar abuso del endpoint.

Configuración actual:
- 10 solicitudes por minuto


### Pruebas Unitarias

Se implementaron pruebas unitarias básicas utilizando:

- **xUnit**
- **Moq**

Se realizaron pruebas sobre los handlers de la capa Application.  



### Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- MediatR
- JWT Authentication
- Rate Limiting
- xUnit
- Moq



### Posibles mejoras

Algunas mejoras adicionales que podrían implementarse:

- Uso de **FluentValidation** para validación de requests
- Uso de **AutoMapper** para mapeo de DTOs
- Configuración de **HttpClient con BaseAddress**
- Implementación de **API Gateway**
- Implementación de **service-to-service authentication**



### Declaración de uso de IA

Herramienta utilizada:

ChatGPT

Fecha:

2026-03-12

Contexto:

Asistencia en revisión de arquitectura, generación de ejemplos de código y validación de buenas prácticas en el desarrollo de microservicios con .NET y arquitectura hexagonal.
El uso de la herramienta fue únicamente como apoyo técnico durante el desarrollo.
No se utilizaron agentes.
