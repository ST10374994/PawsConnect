# 🐾 PawsConnect

PawsConnect is a web-based animal adoption and community platform developed for the INSY7315 Information Systems 3E 2026 implementation project.

The system provides users with a simple and accessible way to browse dogs available for adoption, view dog information, submit adoption applications, and participate in a community forum. Administrative functionality allows authorised users to manage dogs and adoption-related information.

---

## 👤 Student Information

**Student Name:** Morné Viljoen
**Student Number:** ST10374994

**Project:** PawsConnect
**Module:** INSY7315 – Information Systems 3E
**Year:** 2026

### 🎥 Project Demonstration

The PawsConnect application demonstration is available on YouTube:

**[▶️ Watch the PawsConnect Demonstration](https://youtu.be/yRBfw6nX7Bo)**

---

## 📌 Project Information

**Project Name:** PawsConnect
**Module:** INSY7315 – Information Systems 3E
**Assessment:** Formative Assessment Task 2 – Coding, Design, GitHub, Implementation
**Year:** 2026
**Platform:** Web Application
**Framework:** ASP.NET Core MVC
**Language:** C#
**Database:** Microsoft SQL Server / SQL Server LocalDB
**ORM:** Entity Framework Core
**UI Framework:** Bootstrap
**Authentication:** ASP.NET Core Identity
**Testing:** .NET automated tests
**Containerisation:** Docker

---

# 🐶 About PawsConnect

PawsConnect is designed as a fictional animal shelter and adoption platform.

The purpose of the system is to provide an easy-to-use website where users can:

* Browse dogs currently available for adoption.
* View information about individual dogs.
* Submit adoption applications.
* Participate in a community forum.
* Register and log into the application.
* Access functionality appropriate to their user role.

Administrators have additional functionality for managing dogs and maintaining the adoption system.

The application focuses on usability, responsive design, accessibility, authentication, database integration, validation, and secure role-based functionality.

---

# ✨ Key Features

## 🏠 Home Page

The home page introduces PawsConnect and provides navigation to the main areas of the application.

Users can quickly access:

* Find a Dog
* Community
* About
* Login/Register functionality

---

## 🐕 Find a Dog

The Find a Dog section allows users to browse dogs currently available for adoption.

Dog information can include:

* Dog name
* Breed
* Age
* Gender
* Description
* Adoption status
* Dog images

Available dogs are displayed using a responsive card-based layout.

---

## ❤️ Adoption Applications

Users can submit an adoption application for a selected dog.

The adoption process collects relevant applicant information and validates submitted data.

The system provides feedback to the user after an application is submitted.

---

## 💬 Community Forum

PawsConnect includes a community area where users can participate in discussions.

The forum is intended to provide a place for users to interact and share information related to pets and adoption.

---

## 🔐 Authentication

PawsConnect uses ASP.NET Core Identity for authentication.

Users can:

* Register an account.
* Log into the application.
* Log out.
* Access functionality based on their permissions.

Authentication is used to protect functionality that should only be available to logged-in users.

---

## 👑 Administrator Functionality

Authorised administrators have access to additional functionality.

Administrator functionality includes managing dogs within the system.

This includes functionality such as:

* Adding dogs.
* Updating dog information.
* Managing dog images.
* Managing adoption-related information.

Administrative functionality is protected using role-based authorisation.

---

# 🎨 Front End

The front end was designed with usability, consistency, responsiveness, and accessibility in mind.

## Look and Feel

The application uses a consistent visual design throughout the main pages.

Bootstrap is used to assist with:

* Responsive layouts.
* Navigation.
* Cards.
* Forms.
* Buttons.
* Alerts.
* Spacing.
* Grid layouts.

The PawsConnect branding uses an animal-adoption theme to make the purpose of the application clear to users.

---

## Usability

The interface is designed to make common tasks straightforward.

Users can easily navigate between:

* Home
* Find a Dog
* Community
* About
* Authentication
* Administration functionality where authorised

Buttons and navigation links are labelled according to their purpose.

Forms provide validation and feedback when information is missing or invalid.

---

## Responsive Design

The application uses responsive Bootstrap layouts so that pages can adapt to:

* Desktop screens.
* Tablet screens.
* Mobile screens.

Cards, forms, navigation elements, and content areas are designed to resize and reorganise appropriately for different screen sizes.

---

## Accessibility

Accessibility considerations include:

* Clear labels for form fields.
* Meaningful button and link text.
* Readable typography.
* Structured page layouts.
* Appropriate colour contrast.
* Responsive content.
* Keyboard-accessible standard HTML controls.

---

# ⚙️ Back End

PawsConnect uses ASP.NET Core MVC and C# for the application back end.

The application follows a structured MVC architecture consisting of:

```text
PawsConnect
│
├── Controllers
├── Data
├── Migrations
├── Models
├── ViewModels
├── Views
└── wwwroot
```

The **Controllers** handle application requests and coordinate between the models and views.

The **Models** represent the application's data and domain entities.

The **ViewModels** are used to transfer and validate data between the user interface and application logic where required.

The **Views** provide the Razor-based user interface.

The **Data** layer contains the Entity Framework Core database context and related database configuration.

The **Migrations** folder contains Entity Framework Core database migrations.

The **wwwroot** folder contains static resources such as CSS, JavaScript, and uploaded/static website assets.

---

# 🗄️ Database

PawsConnect uses Microsoft SQL Server with Entity Framework Core.

During local development, SQL Server LocalDB can be used to provide the database environment.

Entity Framework Core is responsible for:

* Database access.
* Object-relational mapping.
* Database migrations.
* Persisting application data.
* Querying application entities.

The database stores information required for functionality such as users, dogs, dog images, adoption applications, and forum-related data.

---

# 🧪 Testing

PawsConnect includes automated .NET testing to help verify that important application functionality operates correctly.

Tests can be accessed through **Visual Studio Test Explorer**:

**Test → Test Explorer**

The automated tests are intended to help identify problems during development and provide confidence that core functionality continues to work after changes are made.

---

# 🐳 Docker

PawsConnect also includes Docker support for containerisation.

Docker allows the application to be packaged into a consistent environment, helping to reduce differences between development and deployment environments.

Containerisation supports the project's implementation requirements and provides an additional method for running the application.

---

# 🔒 Security

Security considerations have been incorporated into the application through ASP.NET Core Identity and role-based authorisation.

The system uses:

* User authentication.
* Password-based account security through ASP.NET Core Identity.
* Authorised access to administrative functionality.
* Role-based authorisation.
* Server-side validation.
* Model validation.
* Protected administrator functionality.

Administrative actions are restricted to users assigned the appropriate role.

---

# 🚀 Running the Application

## Prerequisites

Before running PawsConnect, ensure that the following are installed:

* Visual Studio
* .NET SDK
* SQL Server LocalDB or SQL Server
* Git
* Docker Desktop (for containerised execution)

## Running Locally

1. Clone the PawsConnect repository.
2. Open the solution in Visual Studio.
3. Restore the NuGet packages.
4. Ensure the database connection string is correctly configured.
5. Apply the Entity Framework Core migrations if required.
6. Build the solution.
7. Run the application using Visual Studio.

The application will open using the configured ASP.NET Core development URL.

---

# 📁 Project Structure

```text
PawsConnect
│
├── Controllers
│   ├── AdminController.cs
│   ├── AdoptionController.cs
│   ├── DogsController.cs
│   ├── ForumController.cs
│   └── ...
│
├── Data
│   └── ApplicationDbContext.cs
│
├── Migrations
│   └── Entity Framework Core migrations
│
├── Models
│   ├── Dog.cs
│   ├── DogImage.cs
│   ├── AdoptionApplication.cs
│   └── ...
│
├── ViewModels
│   ├── CreateDogViewModel.cs
│   └── ...
│
├── Views
│   ├── Home
│   ├── Dogs
│   ├── Adoption
│   ├── Forum
│   ├── Admin
│   └── Shared
│
├── wwwroot
│   ├── css
│   ├── js
│   └── images
│
├── Program.cs
├── appsettings.json
└── PawsConnect.csproj
```

---

# 📋 Project Summary

PawsConnect demonstrates the development of a complete web-based animal adoption platform using modern Microsoft web development technologies.

The project incorporates:

* ASP.NET Core MVC
* C#
* Entity Framework Core
* SQL Server
* ASP.NET Core Identity
* Bootstrap
* Responsive web design
* Form validation
* Role-based authorisation
* Automated te
