# DotnetAPI

**DotnetAPI** is a lightweight **.NET 8 Web API** application designed to handle **user authentication**, **post management**, and **user management** using a combination of **Dapper**, **JWT Authentication**, and **SQL Server Stored Procedures**.

The project is designed with **clean architecture principles**, making it easy to scale and maintain.

---

## Features

- User registration, login, and password reset with secure **JWT authentication**.
- Create, retrieve, update, and delete **Posts**.
- Manage complete **User** profiles.
- Database interaction using **Dapper** for high performance and control.
- Business logic encapsulated in **SQL Server Stored Procedures**.
- Secure password hashing and salting.
- Modular and scalable project structure.

---

## Project Structure

```plaintext
DotnetAPI
│
├── Controllers
│    ├── AuthController.cs
│    ├── PostController.cs
│    └── UserCompleteController.cs
│
├── Data
│    ├── DataContextDapper.cs
│    └── ReusableSql.cs
│
├── Dtos
│    └── [Data Transfer Objects]
│
├── Helpers
│    └── AuthHelper.cs
│
├── Models
│    └── [Database Models]
│
├── Program.cs
└── appsettings.json
```

---

## Technologies Used

- **.NET 8** — for building a modern and scalable Web API.
- **Dapper** — lightweight ORM for direct and efficient SQL queries.
- **JWT (JSON Web Tokens)** — for secure and stateless authentication.
- **AutoMapper** — for clean mapping between DTOs and models.
- **SQL Server** — database engine with **Stored Procedures**.
- **Dependency Injection (DI)** — for clean service management.
- **Microsoft IdentityModel Tokens** — for token creation and validation.
- **MSSQL** — database backend for storing users, posts, and auth data.

---
