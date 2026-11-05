# PawsConnect 🐾

PawsConnect is an animal shelter web application developed using ASP.NET Core MVC and C#. The application allows users to browse dogs available for adoption, submit adoption applications and participate in a community forum. It also provides administrator functionality for managing dog listings and reviewing adoption applications.

## Features

- **Dog listings:** Browse available dogs and view their details and photographs.
- **Adoption applications:** Submit applications to adopt available dogs.
- **Application management:** Administrators can review, approve or reject adoption applications.
- **User authentication:** Cookie-based authentication and role-based access control.
- **Community forum:** Access community discussions and forum functionality.
- **REST API:** JSON endpoints for dog listings and adoption-related operations.
- **Database persistence:** Store application data using SQL Server and Entity Framework Core.
- **Automated testing:** xUnit tests covering application functionality, including adoption service behaviour.
- **Continuous integration:** GitHub Actions builds the solution and runs automated tests.

## Technology Stack

| Component | Technology |
|---|---|
| Backend | C#, ASP.NET Core MVC, .NET 10 |
| Frontend | Razor Views, HTML, CSS, JavaScript, Bootstrap |
| Database | Microsoft SQL Server |
| ORM | Entity Framework Core |
| API | ASP.NET Core REST controllers |
| Testing | xUnit |
| Version control | Git and GitHub |
| Continuous integration | GitHub Actions |
| Containerisation | Docker |

## Application Architecture

PawsConnect follows the Model–View–Controller (MVC) pattern. Service and repository layers are also used to separate business logic from database operations.

### Project structure

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

*This is an overview of the main project structure. The ellipsis represents additional files that are not listed individually.*

### Architecture components

- **Controllers:** Handle incoming HTTP requests and coordinate application operations. They return Razor views or API responses.
- **Models:** Represent the application's entities and domain data.
- **ViewModels:** Provide the data required by the presentation layer.
- **Services:** Contain business logic and application operations, including adoption application processing.
- **Repositories:** Separate adoption-related data access from the service layer.
- **Data:** Contains `ApplicationDbContext`, which manages database access through Entity Framework Core.
- **Views:** Provide the user interface using Razor.
- **Migrations:** Track database schema changes through Entity Framework Core.
- **wwwroot:** Contains static resources and uploaded dog images.
- **PawsConnect.Tests:** Contains automated tests.
- **GitHub Actions:** Runs automated build and test checks when changes are pushed or pull requests are opened.

This structure keeps the different responsibilities separate and makes the application easier to maintain.

## REST API

PawsConnect includes dedicated API controllers that provide application data in JSON format.

| Controller | Purpose |
|---|---|
| `DogsApiController` | Provides API operations for dog listings. |
| `AdoptionApiController` | Provides API operations related to adoption applications. |

The dog listings endpoint can be accessed at:

`http://pawsconnect-st10374994.runasp.net/api/dogs`

It returns available dog listing information as JSON.

The exact HTTP methods, route templates, request formats and response codes are defined in the API controllers.

## Database

PawsConnect uses Microsoft SQL Server for persistent data storage. Entity Framework Core manages database operations and schema migrations through `ApplicationDbContext`.

The local development database was run using Docker.

Database connection strings and sensitive configuration details should be supplied through .NET User Secrets during development or environment variables in deployment environments. These values should not be committed to source control.

## Security

The application includes the following security-related features:

- Cookie-based authentication manages user sessions.
- Role-based access restrictions protect administrator functionality.
- Sensitive local database configuration is kept outside committed application settings.
- Adoption operations check application status and dog availability before processing approval or rejection.
- Antiforgery protection is used for applicable form submissions.

## Testing and Continuous Integration

The `PawsConnect.Tests` project uses xUnit to test application behaviour.

The latest verified local Release test run completed with:

- **11 tests passed**
- **0 tests failed**
- **0 tests skipped**

The solution also built successfully in Release configuration.

GitHub Actions is configured in `.github/workflows/dotnet.yml` to perform the following steps:

1. Check out the repository.
2. Install the .NET 10 SDK.
3. Restore NuGet dependencies.
4. Build the solution in Release configuration.
5. Run the automated tests.

The workflow provides automated build and test validation. Deployment to the hosting provider is currently performed manually.

## Running Locally

### Prerequisites

Before running PawsConnect locally, make sure the following software is installed:

- .NET 10 SDK.
- Visual Studio with the ASP.NET and web development workload.
- Docker Desktop.
- SQL Server running locally through Docker.

### Setup instructions

1. Clone the repository:

   ```bash
   git clone https://github.com/ST10374994/PawsConnect.git
   ```

2. Open the downloaded project folder.

3. Open `PawsConnect.slnx` in Visual Studio.

4. Allow Visual Studio to restore the required NuGet packages.

5. Start Docker Desktop and make sure the SQL Server container is running.

6. Configure the `DefaultConnection` connection string using .NET User Secrets. The connection details must match the local SQL Server configuration.

7. Confirm that the `PawsConnectDb` database is available. Apply any pending Entity Framework Core migrations if required.

8. Select the HTTPS launch profile in Visual Studio.

9. Press **F5** to run the application with debugging, or **Ctrl + F5** to run without debugging.

The local development addresses are:

- HTTPS: `https://localhost:7121/`
- HTTP: `http://localhost:5284/`

The actual address depends on the selected launch profile.

### Running automated tests

From the repository root, run:

```bash
dotnet test ./PawsConnect.Tests/PawsConnect.Tests.csproj --configuration Release
```

### Building the solution

To build the solution in Release configuration, run:

```bash
dotnet build ./PawsConnect.slnx --configuration Release
```

## Live Application

The hosted application is available at:

http://pawsconnect-st10374994.runasp.net/

Users can access the website through a browser without setting up the local development environment.

## Version Control and CI

Development is managed using Git and GitHub. Feature branches and pull requests support development and code integration.

GitHub Actions provides automated build and test validation when changes are pushed or pull requests are opened.

The application is deployed to the hosting provider manually rather than through an automated deployment pipeline.

## Project Demonstration

**Video demonstration:**  
https://youtu.be/yRBfw6nX7Bo

## Author

**Morné Viljoen**

Student project developed for the INSY7315 application development assignment.
