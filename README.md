# EventSphere

## Introduction

**EventSphere** is a modern web-based blogging platform designed with a focus on clean architecture and modularity. The project aims to provide a flexible, scalable, and maintainable solution for content creation and management.

**This project is implemented using ASP.NET Core and follows the principles of Clean Architecture**, which promote separation of concerns, testability, and long-term maintainability.

---

## Features

- User registration and authentication
- Create, edit, and delete blog posts
- Categorized post listing
- Layered architecture with strict separation of concerns
- Follows SOLID principles
- Implements Repository Pattern, Dependency Injection, and AutoMapper

---

## Tech Stack

- **.NET 8 (ASP.NET Core MVC)**
- **Entity Framework Core**
- **SQL Server**
- **AutoMapper**
- **FluentValidation**
- **Bootstrap / jQuery**
- **Clean Architecture**

---

## Project Structure

The project is organized into multiple layers:

- `Mqeb.Domain`: Contains domain models and interfaces
- `Mqeb.Application`: Business logic, DTOs, and application services
- `Mqeb.Infra.Data`: Data access logic, EF Core DbContext, repositories
- `Mqeb.Infra.IoC`: Dependency injection configuration
- `Mqeb.Web`: Presentation layer and user interface (ASP.NET MVC)

---

## How to Run Locally

### 1. Clone the Repository

```bash
git clone https://github.com/mahdizargarzadeh/EventSphere.git
cd EventSphere
```

### 2. Configure the Connection String

Open `Mqeb.Web/appsettings.json` and set your connection string under `ConnectionStrings`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=EventSphereDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

**If using SQL Authentication:**

```json
"DefaultConnection": "Server=.;Database=EventSphereDB;User Id=sa;Password=your_password;"
```

### 3. Apply Migrations and Create the Database

1. Set `Mqeb.Web` as the **startup project** in Visual Studio.
2. Open the **Package Manager Console**.
3. Run the following command:

```bash
Update-Database
```

> This will create the database and all necessary tables based on the EF Core migrations.

### 4. Run the Project

Start the application from Visual Studio:

```bash
Ctrl + F5
```

It should be available at:

```
https://localhost:5001
```

---

## Contribution

Contributions are welcome!

- Fork the repository
- Create a new branch for your feature/fix
- Commit your changes
- Submit a Pull Request

---

## License

This project is licensed under the **MIT License**. See the `LICENSE` file for more information.
