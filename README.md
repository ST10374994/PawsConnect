# 🐾 PawsConnect

PawsConnect is a web-based animal adoption and community platform developed for the INSY7315 Information Systems 3E 2026 implementation project.

The system provides users with a simple and accessible way to browse dogs available for adoption, view dog information, submit adoption applications, and participate in a community forum. Administrative functionality allows authorised users to manage dogs and adoption-related information.

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

- Browse dogs currently available for adoption.
- View information about individual dogs.
- Submit adoption applications.
- Participate in a community forum.
- Register and log into the application.
- Access functionality appropriate to their user role.

Administrators have additional functionality for managing dogs and maintaining the adoption system.

The application focuses on usability, responsive design, accessibility, authentication, database integration, validation, and secure role-based functionality.

---

# ✨ Key Features

## 🏠 Home Page

The home page introduces PawsConnect and provides navigation to the main areas of the application.

Users can quickly access:

- Find a Dog
- Community
- About
- Login/Register functionality

---

## 🐕 Find a Dog

The Find a Dog section allows users to browse dogs currently available for adoption.

Dog information can include:

- Dog name
- Breed
- Age
- Gender
- Description
- Adoption status
- Dog images

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

- Register an account.
- Log into the application.
- Log out.
- Access functionality based on their permissions.

Authentication is used to protect functionality that should only be available to logged-in users.

---

## 👑 Administrator Functionality

Authorised administrators have access to additional functionality.

Administrator functionality includes managing dogs within the system.

This includes functionality such as:

- Adding dogs.
- Updating dog information.
- Managing dog images.
- Managing adoption-related information.

Administrative functionality is protected using role-based authorisation.

---

# 🎨 Front End

The front end was designed with usability, consistency, responsiveness, and accessibility in mind.

## Look and Feel

The application uses a consistent visual design throughout the main pages.

Bootstrap is used to assist with:

- Responsive layouts.
- Navigation.
- Cards.
- Forms.
- Buttons.
- Alerts.
- Spacing.
- Grid layouts.

The PawsConnect branding uses an animal-adoption theme to make the purpose of the application clear to users.

---

## Usability

The interface is designed to make common tasks straightforward.

Users can easily navigate between:

- Home
- Find a Dog
- Community
- About
- Authentication
- Administration functionality where authorised

Buttons and navigation links are labelled according to their purpose.

Forms provide validation and feedback when information is missing or invalid.

---

## Responsive Design

The application uses responsive Bootstrap layouts so that pages can adapt to:

- Desktop screens.
- Tablet screens.
- Mobile screens.

Cards, forms, navigation elements, and content areas are designed to resize and reorganise appropriately for different screen sizes.

---

## Accessibility

Accessibility considerations include:

- Clear labels for form fields.
- Meaningful button and link text.
- Readable typography.
- Structured page layouts.
- Appropriate colour contrast.
- Responsive content.
- Keyboard-accessible standard HTML controls.

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
