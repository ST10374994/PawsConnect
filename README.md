# 🐾 PawsConnect

PawsConnect is a web-based animal shelter and adoption management application developed using **ASP.NET Core MVC**. The system allows users to browse available dogs, view dog information, submit adoption applications, participate in a community forum, and manage shelter content through an administrator area.

The project was developed as part of the **INSY7315** coursework and focuses on implementing a functional, user-friendly animal adoption platform.

---

## 📌 Project Overview

PawsConnect provides a central platform connecting potential adopters with dogs available for adoption.

The application includes:

- 🏠 Home page
- 🐶 Browse available dogs
- 🔎 Dog information and details
- ❤️ Adoption applications
- 👤 User registration and login
- 🔐 Role-based access control
- 🛠️ Administrator functionality
- 💬 Community forum
- 🖼️ Dog image uploads
- 🗄️ SQL Server database
- 🧪 Automated tests
- 🐳 Docker support
- 📱 Responsive web interface

---

## ✨ Main Features

### 🏠 Home

The home page provides an introduction to PawsConnect and allows users to navigate to the main areas of the application.

---

### 🐶 Find a Dog

Users can browse dogs currently available for adoption.

Dog information includes details such as:

- Name
- Breed
- Age
- Description
- Availability
- Images
- Date added

Dogs are displayed through the `Dogs` section of the application.

---

### ❤️ Adoption Applications

Users can submit adoption applications for dogs they are interested in adopting.

The adoption process allows the application to record information about the selected dog and the applicant.

After successfully submitting an application, the user is directed to a confirmation page.

---

### 👤 User Authentication

PawsConnect uses ASP.NET Core Identity to provide user authentication.

Users can:

- Register an account
- Log in
- Log out
- Access authenticated functionality

Authentication is also used together with role-based authorization.

---

### 🔐 Role-Based Authorization

The application supports different levels of access.

Administrative functionality is restricted to users with the appropriate administrator role.

For example, dog creation functionality is protected using authorization so that only administrators can add dogs.

---

### 🛠️ Admin Functionality

Administrators can manage shelter-related information through the administration functionality.

This includes functionality such as:

- Adding dogs
- Managing dog information
- Uploading dog images
- Accessing administrator features

Administrative functions are protected using authorization.

---

### 💬 Community Forum

PawsConnect includes a community/forum area where users can interact with the application community.

The forum provides an additional area for users to communicate and participate in discussions related to the shelter and adoption community.

---

### 🖼️ Dog Image Uploads

Dogs can have images associated with their profiles.

Uploaded images are stored and displayed as part of the dog information.

This allows potential adopters to visually identify and learn more about dogs available for adoption.

---

## 🏗️ Technology Stack

### Backend

- **C#**
- **ASP.NET Core MVC**
- **.NET 10**
- **Entity Framework Core**
- **ASP.NET Core Identity**

### Frontend

- **Razor Views**
- **HTML**
- **CSS**
- **Bootstrap**
- **JavaScript**

### Database

- **Microsoft SQL Server**
- **SQL Server LocalDB** for local development
- **Entity Framework Core migrations**

### Testing

- **.NET testing framework**
- **PawsConnect.Tests**

### Deployment / Containerisation

- **Docker**
- **Dockerfile**

### Development Environment

- **Visual Studio**
- **Git**
- **GitHub**

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
