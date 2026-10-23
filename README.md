# PawsConnect 🐾

PawsConnect is an animal shelter web application developed using ASP.NET Core MVC. It helps users browse available dogs, submit adoption applications, and participate in a community forum. Administrative functionality supports managing dogs and reviewing adoption applications.

## Features

- **Dog listings:** Browse available dogs and view their details and images.
- **Adoption applications:** Submit applications to adopt available dogs.
- **Application management:** Administrators can review, approve, or reject adoption applications.
- **User authentication:** Cookie-based authentication and access control.
- **Community forum:** Access the forum functionality.
- **REST API:** JSON endpoints for dog listings and adoption operations.
- **Database persistence:** Store application data using SQL Server and Entity Framework Core.
- **Automated testing:** Unit tests for adoption service behaviour.
- **Continuous integration:** GitHub Actions builds the solution and runs automated tests.

## Technology Stack

- **Backend:** C#, ASP.NET Core MVC, .NET 10
- **Frontend:** Razor Views, HTML, CSS, JavaScript and Bootstrap
- **Database:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **API:** ASP.NET Core REST controllers returning JSON
- **Testing:** xUnit
- **Version control:** Git and GitHub
- **CI:** GitHub Actions
- **Containerisation:** Docker

## Application Architecture

PawsConnect follows the Model–View–Controller (MVC) pattern, with service and repository layers used to separate business logic and data access.

```text
PawsConnect/
├── .github/
│   └── workflows/
│       └── dotnet.yml
├── PawsConnect/
│   ├── Controllers/
│   │   ├── AccountController.cs
│   │   ├── AdminController.cs
│   │   ├── AdoptionController.cs
│   │   ├── AdoptionApiController.cs
│   │   ├── DogsController.cs
│   │   ├── DogsApiController.cs
│   │   ├── ForumController.cs
│   │   ├── HomeController.cs
│   │   └── ...
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Migrations/
│   ├── Models/
│   ├── Repositories/
│   │   ├── IAdoptionRepository.cs
│   │   └── AdoptionRepository.cs
│   ├── Services/
│   │   └── AdoptionService.cs
│   ├── ViewModels/
│   ├── Views/
│   ├── wwwroot/
│   │   ├── css/
│   │   ├── js/
│   │   ├── lib/
│   │   └── uploads/
│   │       └── dogs/
│   ├── Properties/
│   │   └── launchSettings.json
│   ├── Dockerfile
│   ├── PawsConnect.csproj
│   ├── Program.cs
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   └── appsettings.Production.json
├── PawsConnect.Tests/
│   ├── AdoptionServiceTests.cs
│   └── BasicTests.cs
├── .dockerignore
├── .gitignore
├── PawsConnect.slnx
└── README.md
```

*The structure above highlights the main application components. The ellipsis represents any additional controller files, and the tree should be kept aligned with the files committed to the repository.*

### Architecture components

- **Controllers:** Handle incoming HTTP requests, coordinate application operations, and return views or API responses.
- **Models:** Represent application entities and domain data.
- **ViewModels:** Supply data required by the presentation layer.
- **Services:** Encapsulate business rules and operations, including adoption application processing.
- **Repositories:** Separate adoption data-access operations from the service layer.
- **Data:** Contains `ApplicationDbContext`, which manages database access through Entity Framework Core.
- **Views:** Provide the MVC user interface using Razor.
- **Migrations:** Track Entity Framework Core database schema changes.
- **wwwroot:** Contains static assets and uploaded dog images.
- **PawsConnect.Tests:** Contains automated tests for application functionality.
- **GitHub Actions:** Automates solution builds and test execution when changes are pushed or pull requests are opened.

## REST API

PawsConnect includes dedicated API controllers for returning application data as JSON.

| Controller | Purpose |
|---|---|
| `DogsApiController` | Provides API operations for dog listings. |
| `AdoptionApiController` | Provides API operations related to adoption applications. |

The exact HTTP methods, route templates, request formats, and response codes are defined in the API controllers.

## Database

The application uses Microsoft SQL Server for persistent storage, with Entity Framework Core managing database operations and schema migrations.

Database connection strings and sensitive local configuration should be supplied through development secrets or environment variables rather than committed to source control.

## Security

- Cookie-based authentication manages user sessions.
- Access restrictions are applied to protected functionality.
- Sensitive configuration is kept outside committed application settings.
- Adoption operations validate application status and dog availability before approval or rejection.

## Testing and Continuous Integration

The `PawsConnect.Tests` project uses xUnit to test application behaviour.

GitHub Actions is configured in `.github/workflows/dotnet.yml` to:

1. Check out the repository.
2. Install the .NET 10 SDK.
3. Restore dependencies.
4. Build the solution in Release configuration.
5. Execute automated tests.

The latest verified local test run completed with **11 tests passed and 0 failed**. The GitHub Actions build-and-test workflow also passed.

## Running Locally

### Prerequisites

- .NET 10 SDK
- Microsoft SQL Server
- Visual Studio or another compatible .NET development environment

### Setup

1. Clone the repository:

   ```bash
   git clone https://github.com/ST10374994/PawsConnect.git
   ```

2. Open `PawsConnect.slnx` in Visual Studio.

3. Configure the database connection string securely using .NET User Secrets or an environment variable.

4. Ensure SQL Server is running and the configured database is available.

5. Apply any pending Entity Framework Core migrations if required.

6. Run the `PawsConnect` project using the HTTPS launch profile.

### Run automated tests

From the repository root, execute:

```bash
dotnet test ./PawsConnect.Tests/PawsConnect.Tests.csproj --configuration Release
```

### Build the solution

```bash
dotnet build ./PawsConnect.slnx --configuration Release
```

## Version Control and CI

Development is managed through Git and GitHub. Feature branches and pull requests support code review and integration, while GitHub Actions provides automated build and test validation.

## Project Demonstration

**Video demonstration:** https://youtu.be/yRBfw6nX7Bo

## Author

**Morné Viljoen**

Student project developed for the INSY7315 application development assignment.

