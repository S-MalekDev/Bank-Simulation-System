# Bank-Simulation-System

[![.NET Framework](https://img.shields.io/badge/.NET-Framework-blue)](https://dotnet.microsoft.com/en-us/download/dotnet-framework)  
[![C#](https://img.shields.io/badge/language-C%23-blue)](https://docs.microsoft.com/en-us/dotnet/csharp/)  
[![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-green)](https://www.microsoft.com/en-us/sql-server)

---

## Description

Bank-Simulation-System is a project that simulates basic daily banking transactions reflecting real-world banking operations.  
The system supports opening multiple accounts in different currencies (USD, GBP, EUR), allows internal and external transfers, as well as deposit and withdrawal operations.  
It provides detailed tracking of each transaction including timestamp and the user who performed it, with a comprehensive permission system allowing easy and flexible user rights management.  
The project is developed using WinForms and C# on the .NET Framework with a SQL Server database.

---

## Features

- Open new bank accounts for clients with different currencies (USD, GBP, EUR).  
- Internal transfers between bank accounts with automatic currency conversion.  
- External transfers between banks (simulation only).  
- Full client management.  
- User management with precise permission settings.  
- Flexible permission system defining what each user can perform.  
- Deposit and withdrawal operations on accounts.  
- Tracking and displaying transaction history of all types (deposit, withdrawal, internal and external transfers).  
- Secure login system with encrypted user data.  

---

## Technologies Used

- Programming Language: C#  
- Application Type: WinForms  
- Framework: .NET Framework  
- Database: SQL Server  
- Implemented OOP principles with a layered architecture:  
  - UI Layer  
  - Business Layer  
  - Data Access Layer  

---

## Project Structure

The project is organized in a layered architecture that supports scalability and maintainability:  

- **UI Layer:** Contains WinForms interfaces and user interaction.  
- **Business Layer:** Contains business logic and rules.  
- **Data Access Layer:** Handles database interactions with SQL Server.  
- **Models:** Represents system entities and data using classes.  

---

## Installation

### Prerequisites

- Install [.NET Framework](https://dotnet.microsoft.com/en-us/download/dotnet-framework) (compatible version).  
- Install [SQL Server](https://www.microsoft.com/en-us/sql-server).  

### Setup and Running Instructions

1. Restore the database using the `.bak` backup file located in the `DataBase` folder within the project, or run the provided database script in the same folder.  
2. Modify the **Connection String** in the Data Access Layer to match your SQL Server configuration.  
3. Open the project in Visual Studio and run it.  
4. Log in using the default admin account:  
   - **Username:** `admin`  
   - **Password:** `admin`  

---

## Screenshots

> Screenshots of the application UI will be added later to enhance documentation.

---

## License

This project is **without an official license** (All rights reserved).  
Use or distribution of this project is not permitted without explicit permission from the author.

---
