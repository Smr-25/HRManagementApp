<div align="center">

# 🏢 HR Management App

**A modern, full-featured Human Resources Management System**  
built with **ASP.NET Core MVC** on **.NET 10** and **Entity Framework Core 10**

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)

</div>

---

## 📋 Table of Contents

- [About](#-about)
- [Features](#-features)
- [Architecture](#-architecture)
- [Tech Stack](#-tech-stack)
- [Project Structure](#-project-structure)
- [Getting Started](#-getting-started)
- [Database](#-database)
- [Seed Data](#-seed-data)
- [Validation Rules](#-validation-rules)
- [Screenshots](#-screenshots)

---

## 📖 About

**HR Management App** is a web-based Human Resources system that allows organizations to efficiently manage their **departments** and **employees**. The application enforces business rules such as worker limits per department and total salary budget caps, ensuring clean and compliant HR data at all times.

---

## ✨ Features

### 🏛️ Department Management
| Feature | Description |
|---|---|
| ➕ Create Department | Add a new department with a worker limit and salary budget |
| 📋 List Departments | View all departments with their employee count and salary average |
| ✏️ Rename Department | Update the department name (employees are automatically re-linked) |
| 🗑️ Delete Department | Remove a department (cascades to all its employees) |
| 🔍 Search Departments | Filter departments by name in real time |

### 👤 Employee Management
| Feature | Description |
|---|---|
| ➕ Add Employee | Register a new employee to an existing department |
| 📋 List Employees | View all employees across all departments |
| ✏️ Edit Employee | Update an employee's position and/or salary |
| 🗑️ Remove Employee | Delete an employee record |
| 🔍 Search Employees | Search by name, ID number, position, or department |

### 🔒 Business Rule Enforcement
- **Worker Limit** — A department cannot exceed its configured maximum headcount
- **Salary Budget Cap** — The total salary of all employees in a department cannot exceed the department's salary limit
- **Unique Department Names** — Duplicate department names are not allowed
- **Auto-generated Employee IDs** — Each employee receives a unique ID based on their department prefix (e.g., `IT1001`, `HR1003`)

---

## 🏗️ Architecture

The project follows a clean **N-Tier / Layered Architecture** with clear separation of concerns:

```
┌─────────────────────────────────────────┐
│         Presentation Layer              │
│   HRManagementApp (ASP.NET Core MVC)    │
│   Controllers · Views · Models          │
└──────────────────┬──────────────────────┘
                   │ depends on
┌──────────────────▼──────────────────────┐
│           Business Layer                │
│        HRManagementApp.Business         │
│   Services · DTOs · FluentValidators    │
└──────────────────┬──────────────────────┘
                   │ depends on
┌──────────────────▼──────────────────────┐
│          Data Access Layer              │
│       HRManagementApp.DataAccess        │
│   AppDbContext · Migrations · Extensions│
└──────────────────┬──────────────────────┘
                   │ depends on
┌──────────────────▼──────────────────────┐
│             Core Layer                  │
│          HRManagementApp.Core           │
│       Entities · Interfaces             │
└─────────────────────────────────────────┘
```

> ✅ The **Core** layer has **zero external dependencies** — it is the innermost layer containing domain entities and interfaces.

---

## 🛠️ Tech Stack

| Technology | Version | Purpose |
|---|---|---|
| [.NET](https://dotnet.microsoft.com/) | **10.0** | Runtime & SDK |
| [ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc) | 10.0 | Web framework |
| [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/) | **10.0.7** | ORM & migrations |
| [SQL Server](https://www.microsoft.com/en-us/sql-server) | Latest | Relational database |
| [FluentValidation](https://docs.fluentvalidation.net/) | 12.1.1 | Model validation |
| [AutoMapper](https://automapper.org/) | 16.1.1 | Object mapping |
| [Microsoft.AspNetCore.OpenApi](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/openapi) | 10.0.5 | OpenAPI support |

---

## 📁 Project Structure

```
HRManagementApp/
└── Backend/
    └── HRManagementApp/
        │
        ├── HRManagementApp/                  # 🌐 Presentation Layer
        │   ├── Controllers/
        │   │   ├── HomeController.cs
        │   │   ├── DepartmentController.cs
        │   │   └── EmployeeController.cs
        │   ├── Views/
        │   │   ├── Department/
        │   │   ├── Employee/
        │   │   └── Shared/
        │   ├── Models/                       # ViewModels
        │   ├── Program.cs
        │   └── appsettings.json
        │
        ├── HRManagementApp.Core/             # 🔵 Core / Domain Layer
        │   ├── Entities/
        │   │   ├── Department.cs
        │   │   └── Employee.cs
        │   └── Interfaces/
        │       └── IHumanResourceManager.cs
        │
        ├── HRManagementApp.Business/         # 🟡 Business Layer
        │   ├── DTOs/
        │   │   ├── DepartmentDto.cs
        │   │   └── EmployeeDto.cs
        │   ├── Services/
        │   │   └── HumanResourceManager.cs
        │   └── Validators/
        │       ├── DepartmentDtoValidator.cs
        │       └── EmployeeDtoValidator.cs
        │
        └── HRManagementApp.DataAccess/       # 🟢 Data Access Layer
            ├── Context/
            │   └── AppDbContext.cs
            ├── Extensions/
            │   └── DataAccessServiceRegistration.cs
            └── Migrations/
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB, Express, or full)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) with C# extension

### 1. Clone the Repository

```bash
git clone https://github.com/Smr-25/HRManagementApp.git
cd HRManagementApp
```

### 2. Configure the Database Connection

Open `Backend/HRManagementApp/HRManagementApp/appsettings.json` (or create `appsettings.Development.json`) and set your SQL Server connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=HRManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

> 💡 For **SQL Server LocalDB**, use:
> `"Server=(localdb)\\mssqllocaldb;Database=HRManagementDb;Trusted_Connection=True;"`

### 3. Apply Migrations

```bash
cd Backend/HRManagementApp
dotnet ef database update --project HRManagementApp.DataAccess --startup-project HRManagementApp
```

### 4. Run the Application

```bash
cd HRManagementApp
dotnet run
```

The application will be available at `https://localhost:5001` (or the port shown in the terminal).

---

## 🗄️ Database

The application uses **SQL Server** with **Entity Framework Core Code-First** migrations.

### Entity Relationship Diagram

```
┌─────────────────────────┐        ┌──────────────────────────┐
│       Department        │        │         Employee          │
├─────────────────────────┤        ├──────────────────────────┤
│ Name (PK)    string     │◄──┐    │ No (PK)       string     │
│ WorkerLimit  int        │   └────│ DepartmentName (FK)      │
│ SalaryLimit  double     │        │ FullName      string     │
│ Employees    List<Emp>  │        │ Position      string     │
└─────────────────────────┘        │ Salary        double     │
                                   └──────────────────────────┘
```

- **One Department → Many Employees** (cascade delete)
- Department `Name` is the primary key
- Employee `No` is the primary key (auto-generated: `{DeptPrefix}{Number}`)

### Run Migrations

```bash
# Create a new migration
dotnet ef migrations add <MigrationName> --project HRManagementApp.DataAccess --startup-project HRManagementApp

# Apply migrations
dotnet ef database update --project HRManagementApp.DataAccess --startup-project HRManagementApp
```

---

## 🌱 Seed Data

The database is pre-populated with sample data on first run:

**Departments:**
| Name | Worker Limit | Salary Limit |
|---|---|---|
| IT | 10 | $25,000 |
| HR | 5 | $10,000 |
| Marketing | 8 | $12,000 |

**Employees:**
| ID | Full Name | Position | Salary | Department |
|---|---|---|---|---|
| IT1001 | Samir Həsənov | Senior Backend Developer | $3,500 | IT |
| IT1002 | Leyla Əliyeva | Frontend Developer | $2,000 | IT |
| HR1003 | Vüqar Kərimov | HR Specialist | $1,500 | HR |
| MA1004 | Nigar Rüstəmova | Marketing Manager | $2,500 | Marketing |

---

## ✅ Validation Rules

### Employee Validation (`EmployeeDtoValidator`)
| Field | Rule |
|---|---|
| `FullName` | Required, cannot be empty |
| `Position` | Required, minimum 2 characters |
| `Salary` | Must be ≥ **250** |
| `DepartmentName` | Required, must be specified |

### Business Logic Validations
| Rule | Description |
|---|---|
| Worker limit | Employee count cannot exceed the department's `WorkerLimit` |
| Salary budget | New salary cannot push the department's total over `SalaryLimit` |
| Unique names | Department names must be unique (case-insensitive) |

---

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).

---

<div align="center">

Made with ❤️ using **.NET 10** · **Entity Framework Core 10** · **ASP.NET Core MVC**

</div>
