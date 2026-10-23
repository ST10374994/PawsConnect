# 🐾 PawsConnect

PawsConnect is a web-based animal adoption and community platform developed for the **INSY7315 Information Systems 3E 2026** implementation project.

The application allows users to browse dogs, view their information, submit adoption applications, and access community features. Authorised administrators can manage dog listings and review adoption applications.

## 👤 Student Information

- **Student:** Morné Viljoen
- **Student Number:** ST10374994
- **Module:** INSY7315 – Information Systems 3E
- **Assessment:** Formative Assessment Task 2
- **Year:** 2026

## 🎥 Project Demonstration

[▶️ Watch the PawsConnect Demonstration on YouTube](https://youtu.be/yRBfw6nX7Bo)

## 🛠️ Technology Stack

- **Framework:** ASP.NET Core MVC
- **Language:** C#
- **Target Framework:** .NET 10
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Front end:** Razor Views, HTML, CSS and Bootstrap
- **API:** ASP.NET Core REST endpoints returning JSON
- **Testing:** xUnit and .NET test tooling
- **CI:** GitHub Actions
- **Containerisation:** Docker support

## ✨ Features

### 🏠 Home and Dog Listings

- Home page with navigation to the main application sections.
- Browse dogs available for adoption.
- View dog details, including name, breed, age, gender, description, status and images.
- Responsive layouts using Bootstrap.

### ❤️ Adoption Applications

- Submit an adoption application for a selected dog.
- Validate application information.
- Track application status.
- Allow administrators to approve or reject pending applications.
- Mark a dog's status as adopted when an application is approved.
- Prevent approval or rejection of applications that are not pending.
- Prevent approval when the associated dog is no longer available.

### 💬 Community

The application includes a community forum area intended for pet-related discussions.

### 👑 Administration

Authorised administrators can manage dog listings and review adoption applications. Administrative actions are protected by authorisation checks.

### 🔐 Authentication and Authorisation

The application uses custom cookie-based authentication and role-based authorisation. Protected operations require the appropriate authenticated user or administrator permissions.

> Note: Authentication is implemented using the application's custom cookie-based approach; this project does not claim to use ASP.NET Core Identity.

## 🏗️ Application Architecture

PawsConnect uses the Model–View–Controller (MVC) pattern.

```text
PawsConnect
├── Controllers
│   ├── MVC controllers
│   ├── AdoptionApiController.cs
│   └── DogsApiController.cs
├── Data
│   └── ApplicationDbContext.cs
├── Models
├── ViewModels
├── Repositories
│   ├── IAdoptionRepository.cs
│   └── AdoptionRepository.cs
├── Services
│   └── AdoptionService.cs
├── Views
├── Migrations
└── wwwroot
```

- **Controllers** handle incoming requests and coordinate application operations.
- **Services** contain adoption workflow and business rules.
- **Repositories** isolate adoption data-access operations from the service.
- **Models** represent domain entities.
- **ViewModels** carry and validate data used by the user interface.
- **Views** render the Razor-based web interface.
- **ApplicationDbContext** provides Entity Framework Core database access.
- **Migrations** support database schema changes.
- **wwwroot** contains static resources and website assets.

## 🌐 REST API

The application includes dedicated API controllers for dog listings and adoption-related operations. These endpoints provide a JSON-based interface in addition to the MVC user interface.

API controller files:

- `PawsConnect/Controllers/DogsApiController.cs`
- `PawsConnect/Controllers/AdoptionApiController.cs`

The exact routes and supported HTTP methods are defined by the controller route attributes and actions. Refer to those files for the current endpoint definitions.

## 🗄️ Database

PawsConnect uses Microsoft SQL Server with Entity Framework Core.

The database supports application data such as dog listings and adoption applications. Entity Framework Core provides object-relational mapping, querying, persistence and migration support.

Database connection strings and other sensitive local configuration should be provided through development secrets or environment-specific configuration. Credentials must not be committed to source control.

## 🧪 Automated Testing

The solution includes an xUnit test project:

`PawsConnect.Tests`

The tests cover adoption service behaviour, including application submission, approval, rejection and invalid application states, as well as registration ViewModel validation.

**Latest locally verified results:**

- Release build: successful
- Automated tests: 11 passed
- Failed tests: 0

Run the tests from the repository root:

```powershell
dotnet test .\PawsConnect.Tests\PawsConnect.Tests.csproj --configuration Release
```

Build the solution:

```powershell
dotnet build .\PawsConnect.slnx --configuration Release
```

## ⚙️ Continuous Integration

GitHub Actions is configured in:

`.github/workflows/dotnet.yml`

The workflow restores dependencies, builds the solution in Release configuration, and runs the automated test suite. It runs on pushes to configured branches and pull requests targeting `main` or `develop`.

The latest observed GitHub Actions run for the build-and-test workflow completed successfully.

This workflow provides **continuous integration**. It does not, by itself, deploy the application to a live hosting environment.

## 🐳 Docker

The project includes Docker support to help run the application in a containerised environment. Database connectivity and configuration must be set up appropriately for the selected environment.

## 🚀 Running Locally

### Prerequisites

- Visual Studio with .NET development support
- .NET 10 SDK
- Microsoft SQL Server
- Git
- Docker Desktop, if using containers

### Steps

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Restore NuGet dependencies.
4. Configure the database connection string securely using User Secrets or environment variables.
5. Ensure the SQL Server instance is running and the required database is available.
6. Apply any required Entity Framework Core migrations.
7. Build and run the application.

Do not commit passwords, API keys or other credentials to GitHub.

## 🔒 Security Considerations

Security measures include authentication, role-based authorisation, server-side validation and protected administrative operations.

Security work should also include protecting credentials, reviewing authentication and request-rate controls, and verifying that production configuration differs appropriately from development configuration.

## 📋 Project Summary

PawsConnect demonstrates an ASP.NET Core MVC animal adoption platform with a SQL Server database, an adoption service/repository layer, JSON REST API controllers, automated tests and a GitHub Actions continuous integration workflow.

The project is developed for the INSY7315 2026 implementation assessment.

**Demonstration:** [Watch on YouTube](https://youtu.be/yRBfw6nX7Bo)
