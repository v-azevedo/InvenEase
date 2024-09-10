# InvenEase

InvenEase is a web application that allows users to keep track of their inventory and the requisitions of items. Has role based access control for the different type of users with a permission system. For authentication, it uses JWT tokens. The application is built using .NET Core 8.0 and was constructed with Clean Architecture principles in mind.

- [InvenEase](#invenease)
  - [Domain Overview](#domain-overview)
    - [Manager](#manager)
    - [Stockist](#stockist)
    - [Requester](#requester)
  - [Technologies](#technologies)
  - [Getting Started](#getting-started)
  - [API Documentation](#api-documentation)

## Domain Overview

The system has three main entities: Items, Requisitions and Orders. Items are the consumables that the company has in stock. Requisitions are requests for items that are made by employees. The system has three main roles: Manager, Requester and Stockist.

### Manager

- Can view all items, requisitions and orders.
- Can create, update and delete items.
- Can create, update and delete requisitions.
- Can create, update, approve and delete orders.

### Stockist

- Can view all items, requisitions and orders.
- Mainly responsible for updating the stock of items and keeping track of requisitions.

### Requester

- Can only view own requisitions.
- Can create and delete own requisitions if not started.

## Technologies

- .NET Core 8.0
- Entity Framework Core
- PostgreSQL
- MediatR
- JwtBearer Authentication
- FluentValidation
- Mapster
- ErrorOr

## Getting Started

.NET CLI:

```console
dotnet build && dotnet run --project src/InvenEase.Api/InvenEase.Api.csproj
```

Docker:

```console
docker compose up
```

## API Documentation

The API documentation can be found inside the `docs` folder.
