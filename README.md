# Contact Manager CRUD Application

This project is a Contact Manager application developed with ASP.NET and C#. It allows users to create, read, update, and delete (CRUD) contact information. The application is designed with a user-friendly interface and provides a simple solution for managing contact details.

## Features

- **Create Contacts**: Add new contacts with details such as name, phone number, and email.
- **Read Contacts**: View a list of all contacts and individual contact details.
- **Update Contacts**: Modify existing contact information.
- **Delete Contacts**: Remove contacts from the system.

## Technologies Used

- **ASP.NET**: For building the web framework and backend logic.
- **C#**: Primary programming language for backend functionality.
- **Entity Framework**: For database operations and ORM (optional if used).
- **SQL Server**: Database to store contact information (optional if used).

## Setup Instructions

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/Contact-Manager.git

    Open in Visual Studio: Open the project folder, then open the solution file (.sln) in Visual Studio.

    Restore Dependencies: Go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution in Visual Studio, and restore any required packages.

    Configure the Database:
        Update the connection string in appsettings.json to connect to your SQL Server.
        If using Entity Framework, run migrations with:

    dotnet ef database update

Run the Application: Press F5 in Visual Studio to start the application and open it in your default browser.
