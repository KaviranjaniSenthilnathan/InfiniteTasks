# Employee Management API

## Overview

Employee Management API is a RESTful Web API built using ASP.NET Core, Entity Framework Core, and SQL Server. The project follows a layered architecture consisting of Controllers, Services, Repositories, Models, and Data layers.

It performs complete CRUD operations with validation and exception handling.

---

## Technologies Used

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Dependency Injection

---

## Project Architecture

- Controllers
- Services
- Repositories
- Models
- Data
- Migrations

---

## Features

- Get All Employees
- Get Employee By ID
- Add Employee
- Update Employee
- Delete Employee
- Model Validation
- Exception Handling
- Dependency Injection
- Entity Framework Core

---

## Setup Instructions

### Prerequisites

- Visual Studio 2022
- .NET SDK (Latest LTS)
- SQL Server

### Steps

1. Clone the repository.

2. Open the solution in Visual Studio.

3. Update the connection string in appsettings.json.

Example

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```



4. Press F5.

5. Swagger opens automatically.

---

## API Endpoints

### Get All Employees

GET /api/Employee

---

### Get Employee By ID

GET /api/Employee/{id}

---

### Create Employee

POST /api/Employee

---

### Update Employee

PUT /api/Employee

---

### Delete Employee

DELETE /api/Employee/{id}

---

## Validation

- Name is Required
- Valid Email Address
- Department is Required
- Salary Range Validation

---

## Exception Handling

- 400 Bad Request
- 404 Not Found
- 500 Internal Server Error

---

## Learning Outcomes

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- CRUD Operations
- Layered Architecture
- Repository Pattern
- Dependency Injection
- Model Validation
- Exception Handling

---

## Author

Kavi Ranjani