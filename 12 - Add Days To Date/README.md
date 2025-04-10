# 📅 Add Days to a Date - C# Console App

This project is a simple C# console application that allows the user to input a date and add a specified number of days to it. The program calculates the resulting date manually without using the built-in `DateTime` class, making it useful for understanding how date arithmetic works behind the scenes.

---

## 🔧 Features

- Accepts user input for a date (day, month, year).
- Asks for a number of days to add.
- Correctly calculates the resulting date.
- Accounts for leap years.

---

## 🧠 How It Works

### 1. User Input
- The user is prompted to enter the day, month, and year.
- Then, the user enters the number of days to add.

### 2. Leap Year Check
- The method `IsLeapYear()` determines if a year is a leap year based on these rules:
  - Divisible by 400 ✅
  - Or divisible by 4 and not divisible by 100 ✅

### 3. Days Calculation
- `NumOfDaysFromBeginningTheYear()` calculates how many days have passed from January 1st to the entered date.
- `DateAddDays()` adds the new days and loops through months and years to find the new date.

### 4. Output
- The resulting date after adding the specified number of days is printed to the console.

---

## 🧾 Example

```
Please enter a Day? 28
Please enter a Month? 2
Please enter a Year? 2024

How many days to add? 3

Date after adding [3] days is: 2/3/2024
```

---

## 🗂️ Code Breakdown

### `ReadDay()`, `ReadMonth()`, `ReadYear()`
Prompts user input for the day, month, and year.

### `IsLeapYear(year)`
Checks if the given year is a leap year.

### `NumberOfDaysInAMonth(month, year)`
Returns the number of days in a month, accounting for leap years in February.

### `NumOfDaysFromBeginningTheYear(year, month, day)`
Returns how many days have passed from Jan 1st to the given date.

### `sDate`
A `struct` that represents a date with `day`, `month`, and `year`.

### `DateAddDays(days, date)`
Adds the given number of days to a date and returns the resulting date.

### `Main()`
Runs the program: collects input, processes the addition, and prints the new date.

---

## 💡 Educational Purpose
This program is built from scratch without relying on .NET's `DateTime` class, making it a perfect learning tool to:
- Understand control structures
- Practice working with structs
- Handle logical loops and conditions
- Manage user input and validation

---

## 🏃‍♂️ How to Run
1. Open in Visual Studio or any C# IDE.
2. Build and run the project.
3. Follow the console prompts.

Using .NET CLI:
```bash
dotnet run
```
