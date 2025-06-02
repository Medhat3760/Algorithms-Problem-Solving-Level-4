# ATM System (Console App)

This project is a **console-based ATM simulation system** developed in **C#**. It allows users to log in using an account number and PIN, and then perform basic ATM operations such as withdrawals, deposits, and balance checks.

## Features

### 🔐 Secure Login

* Requires account number and PIN code.
* Validates client data from `Clients.txt` file.

### 💸 ATM Transactions

* **Quick Withdraw**: Fast access to common withdrawal amounts (20, 50, 100, ..., 1000).
* **Normal Withdraw**: Enter any custom amount (in multiples of 5).
* **Deposit**: Deposit positive amounts.
* **Check Balance**: View current account balance.

### 📁 File-Based Storage

* All client data is stored in `Clients.txt` using a structured delimiter format.
* Updates to balances are reflected in the file after each transaction.

## File Format

Each line in `Clients.txt` looks like this:

```
AccountNumber#//#PinCode#//#Name#//#Phone#//#Balance
```

## Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download) installed
* An editor like **Visual Studio** or **VS Code**

## How to Run

1. Clone or download the project.
2. Open the `.cs` file in your editor.
3. Build and run the application.
4. Use valid credentials from `Clients.txt` to log in.

## Usage Flow

1. Launch the app and enter your **account number** and **PIN code**.
2. Choose from available options:

   * Quick Withdraw
   * Normal Withdraw
   * Deposit
   * Check Balance
   * Logout
3. Confirm each transaction when prompted.

## Highlights

* Uses C# structs and enums to manage clients and menu options.
* Demonstrates file I/O, user input handling, and data validation.
* Realistic ATM experience via console.

## Limitations

* No encryption or data validation beyond basic format.
* File access is not thread-safe or protected.
* Not recommended for real-world banking without enhancements.

---

This project is ideal for **learning file I/O, user interaction, and menu-driven programs** in C#.

