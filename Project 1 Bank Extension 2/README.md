# Bank Management System (Console App)

This project is a **console-based Bank Management System** written in **C#**. It allows users and admins to manage client accounts and user permissions through a structured menu interface. The system is based on file handling and does not use any database backend, making it easy to deploy and understand.

## Features

### 🔐 User Authentication

* Login system with username and password validation.
* Permissions-based access control using bit flags.

### 👥 Client Management

* Add, delete, update, and find clients.
* View all clients in a tabular list.
* Clients are stored in a plain text file (`Clients.txt`).

### 💰 Transactions

* Deposit and withdraw money.
* Show total balances across all accounts.
* Transaction confirmations and balance checks.

### 👨‍💻 User Management (Admin Only)

* Add, delete, update, and find users.
* View all users.
* Assign specific permissions or full access.
* Users are stored in a plain text file (`Users.txt`).

## File Structure

* `Clients.txt` – Stores client account details.
* `Users.txt` – Stores system user credentials and permissions.

## Getting Started

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download) installed
* A code editor like **Visual Studio** or **VS Code**

### Running the App

1. Clone or download the project.
2. Open the solution or `.cs` file in your editor.
3. Build and run the project.
4. Use the login screen to access the system.

## Usage Flow

1. **Login** using a valid user account.
2. Choose from:

   * Client operations
   * Transactions
   * User management (if admin)
3. Interact via command-line prompts.

## Code Highlights

* Uses structured enums for menu options and permissions.
* Modular function design for readability and reusability.
* File I/O for persistent data storage.
* Uses structs for user and client data modeling.

## Screenshots

*Coming soon*

## License

This project is open for educational use and modification. Not recommended for production use without security enhancements.

---

Feel free to customize the interface and extend features such as encryption, logging, or database integration.

