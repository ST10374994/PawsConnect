# 🐾 PawsConnect

PawsConnect is a web-based animal shelter management and adoption platform developed as part of the INSY7314 project.

The system provides a platform where users can browse available dogs, view dog information, submit adoption applications, and interact with the shelter community. Administrative functionality allows authorised users to manage shelter content and dogs.

---

## 📌 Project Overview

PawsConnect was developed to provide a simple and user-friendly platform for connecting potential adopters with dogs available for adoption.

The application focuses on:

- 🐶 Browsing available dogs
- 🔎 Viewing dog information
- 📝 Submitting adoption applications
- 👤 User authentication and accounts
- 🔐 Role-based access for administrators
- 🖼️ Dog image management
- 💬 Community/forum functionality
- 🗄️ Database-backed application data
- 🧪 Automated testing
- 🐳 Docker support

---

## 🚀 Main Features

### 🏠 Home Page

The home page provides users with an introduction to PawsConnect and navigation to the main areas of the application.

### 🐕 Find a Dog

Users can browse dogs available for adoption and view information about individual dogs.

### 📝 Adoption Applications

Users can submit applications to adopt available dogs.

The system stores adoption application information in the database.

### 👤 User Authentication

PawsConnect uses ASP.NET Core Identity for user authentication.

Users can:

- Register an account
- Log in
- Access functionality based on their account permissions

### 🔐 Administrator Functionality

Administrator functionality is protected using role-based authorisation.

Administrators can manage dog information through the application.

### 🖼️ Dog Images

Dogs can have associated images that are uploaded and displayed as part of their information.

### 💬 Community

PawsConnect includes a community/forum area where users can interact with the shelter community.

### 🗄️ Database

The application uses Entity Framework Core with SQL Server for persistent data storage.

Database migrations are included in the project.

### 🧪 Automated Testing

A separate `PawsConnect.Tests` project is included for automated testing of application functionality.

### 🐳 Docker

The project includes Docker configuration to allow the application to be containerised and run using Docker.

---

## 🛠️ Technologies Used

The project is built using the following technologies:

- **C#**
- **ASP.NET Core MVC**
- **.NET 10**
- **Entity Framework Core**
- **Microsoft SQL Server / LocalDB**
- **ASP.NET Core Identity**
- **Bootstrap**
- **HTML / CSS**
- **Razor Views**
- **Docker**
- **Git**
- **GitHub**
- **xUnit / .NET testing**

---

## 📁 Project Structure

```text
PawsConnect/
│
├── PawsConnect/
│   ├── Controllers/
│   ├── Data/
│   ├── Migrations/
│   ├── Models/
│   ├── Properties/
│   ├── ViewModels/
│   ├── Views/
│   ├── wwwroot/
│   │
│   ├── Dockerfile
│   ├── PawsConnect.csproj
│   ├── Program.cs
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   └── appsettings.Production.json
│
├── PawsConnect.Tests/
│
├── .dockerignore
├── .gitignore
├── PawsConnect.slnx
└── README.md
