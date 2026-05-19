<div align="center">

# 🏢 HR Management App

A modern, enterprise-style **Human Resources Management System** built with **ASP.NET Core MVC**, **.NET 10**, and **Entity Framework Core 10**.

The application helps organizations efficiently manage departments, employees, salary budgets, and workforce limitations through a clean layered architecture.

---

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF%20Core-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

</div>

---

# 📌 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Architecture](#architecture)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)
- [Database](#database)
- [Seed Data](#seed-data)
- [Validation Rules](#validation-rules)
- [Build & Run](#build--run)
- [Contributing](#contributing)
- [License](#license)

---

# 📖 Overview

HR Management App is a web-based HR management platform designed to simplify employee and department administration.

The system allows organizations to:

- Manage departments
- Manage employees
- Enforce salary budget rules
- Control department worker limits
- Perform advanced searching & filtering
- Maintain clean HR data with validation rules

The application follows a clean **N-Tier / Layered Architecture** for scalability and maintainability.

---

# ✨ Features

## 🏛️ Department Management

| Feature | Description |
|---|---|
| ➕ Create Department | Add departments with worker & salary limits |
| 📋 Department Listing | View departments with employee statistics |
| ✏️ Rename Department | Automatically re-links employees |
| 🗑️ Delete Department | Cascade deletes all related employees |
| 🔍 Department Search | Search departments in real time |

---

## 👤 Employee Management

| Feature | Description |
|---|---|
| ➕ Add Employee | Register employees into departments |
| 📋 Employee Listing | View all employees |
| ✏️ Edit Employee | Update salary & position |
| 🗑️ Remove Employee | Delete employee records |
| 🔍 Employee Search | Search by name, ID, department, or position |

---

## 🔒 Business Rule Enforcement

- Department worker limits cannot be exceeded
- Salary budgets are validated before employee creation/update
- Department names must be unique
- Employee IDs are automatically generated

Example employee IDs:

```text
IT1001
HR1003
MA1004
```

---

# 🏗️ Architecture

The project follows a clean layered architecture:

```text
Presentation Layer
│
├── ASP.NET Core MVC
│   ├── Controllers
│   ├── Views
│   └── ViewModels
│
Business Layer
│
├── Services
├── DTOs
└── Validators
│
Data Access Layer
│
├── DbContext
├── Migrations
└── Service Registrations
│
Core Layer
│
├── Entities
└── Interfaces
```

---

## 🔹 Core Layer

Contains:

- Domain entities
- Interfaces
- Shared abstractions

Main entities:

- `Department`
- `Employee`

---

## 🔹 Business Layer

Contains:

- DTOs
- Services
- FluentValidation validators
- Business logic rules

---

## 🔹 Data Access Layer

Responsible for:

- Entity Framework Core
- Database migrations
- Dependency registrations
- SQL Server integration

---

## 🔹 Presentation Layer

Contains:

- MVC Controllers
- Razor Views
- ViewModels
- Routing & UI logic

---

# ⚙️ Tech Stack

| Technology | Version | Purpose |
|---|---|---|
| .NET | 10.0 | Runtime & SDK |
| ASP.NET Core MVC | 10.0 | Web Framework |
| Entity Framework Core | 10.0.7 | ORM |
| SQL Server | Latest | Relational Database |
| FluentValidation | 12.1.1 | Validation |
| AutoMapper | 16.1.1 | Object Mapping |
| OpenAPI | 10.0.5 | API Documentation |

---

# 📂 Project Structure

```text
HRManagementApp/
└── Backend/
    └── HRManagementApp/
        ├── HRManagementApp/                  # Presentation Layer
        ├── HRManagementApp.Core/             # Core Layer
        ├── HRManagementApp.Business/         # Business Layer
        └── HRManagementApp.DataAccess/       # Data Access Layer
```

---

# 🚀 Getting Started

## Prerequisites

Make sure the following are installed:

- .NET 10 SDK
- SQL Server (LocalDB, Express, or full edition)
- Visual Studio 2022+ or VS Code

---

## 1️⃣ Clone the Repository

```bash
git clone https://github.com/Smr-25/HRManagementApp.git
cd HRManagementApp
```

---

## 2️⃣ Configure the Database

Update the connection string inside:

```text
Backend/HRManagementApp/HRManagementApp/appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=HRManagementDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

For SQL Server LocalDB:

```json
"Server=(localdb)\\mssqllocaldb;Database=HRManagementDb;Trusted_Connection=True;"
```

---

## 3️⃣ Apply Migrations

```bash
cd Backend/HRManagementApp

dotnet ef database update \
  --project HRManagementApp.DataAccess \
  --startup-project HRManagementApp
```

---

## 4️⃣ Run the Application

```bash
cd HRManagementApp

dotnet run
```

The application will be available at:

```text
https://localhost:5001
```

or the URL displayed in the terminal.

---

# 🗄️ Database

The application uses:

- SQL Server
- Entity Framework Core Code-First Migrations

---

## Entity Relationship

```text
Department (1) ──────── (Many) Employee
```

### Department

| Field | Type |
|---|---|
| Name | Primary Key |
| WorkerLimit | int |
| SalaryLimit | double |

---

### Employee

| Field | Type |
|---|---|
| No | Primary Key |
| FullName | string |
| Position | string |
| Salary | double |
| DepartmentName | Foreign Key |

---

## Migration Commands

```bash
# Create migration
dotnet ef migrations add <MigrationName> \
  --project HRManagementApp.DataAccess \
  --startup-project HRManagementApp

# Apply migration
dotnet ef database update \
  --project HRManagementApp.DataAccess \
  --startup-project HRManagementApp
```

---

# 🌱 Seed Data

The application ships with sample data.

---

## Departments

| Name | Worker Limit | Salary Limit |
|---|---|---|
| IT | 10 | $25,000 |
| HR | 5 | $10,000 |
| Marketing | 8 | $12,000 |

---

## Employees

| ID | Full Name | Position | Salary | Department |
|---|---|---|---|---|
| IT1001 | Samir Həsənov | Senior Backend Developer | $3,500 | IT |
| IT1002 | Leyla Əliyeva | Frontend Developer | $2,000 | IT |
| HR1003 | Vüqar Kərimov | HR Specialist | $1,500 | HR |
| MA1004 | Nigar Rüstəmova | Marketing Manager | $2,500 | Marketing |

---

# ✅ Validation Rules

## Employee Validation

| Field | Rule |
|---|---|
| FullName | Required |
| Position | Minimum 2 characters |
| Salary | Must be ≥ 250 |
| DepartmentName | Required |

---

## Business Logic Rules

| Rule | Description |
|---|---|
| Worker Limit | Cannot exceed department limit |
| Salary Budget | Cannot exceed salary cap |
| Unique Department Names | Duplicate names are not allowed |

---

# 🧑‍💻 Build & Run

## Build Project

```bash
dotnet build
```

---

## Run Application

```bash
dotnet run
```

---

## Run Tests

```bash
dotnet test
```

---

# 🤝 Contributing

Contributions are welcome!

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Open a Pull Request

---

# 📄 License

This project is open-source and available under the MIT License.

---

<div align="center">

Made with ❤️ using ASP.NET Core MVC · .NET 10 · EF Core 10

</div>
