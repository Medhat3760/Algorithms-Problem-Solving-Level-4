# Add Days to Date - C# Console Application

This project is a simple C# console application that allows users to input a date and a number of days to add to it. The program will calculate and output the new date after adding the specified number of days, correctly handling month lengths and leap years.

---

## Features

- Input day, month, and year from the user
- Input number of days to add
- Correctly calculate the new date
- Handle leap years
- Validate and adjust months and years accordingly

---

## Program Overview

### Struct: `sDate`

A custom struct to store and manage a date composed of:

- `short day`
- `short month`
- `short year`

---

## Main Methods and Their Roles

### `ReadDay()`, `ReadMonth()`, `ReadYear()`

Prompts the user for individual components of a date and returns the value.

### `IsLeapYear(short year)`

Checks if the provided year is a leap year based on the rules:

- Divisible by 400
- Divisible by 4 but not by 100

### `NumberOfDaysInAMonth(short month, short year)`

Returns the number of days in a given month and year, considering leap years for February.

### `NumOfDaysFromBeginningTheYear(short year, short month, short day)`

Calculates how many days have passed from January 1st to the given date.

### `GetDateFromDayOrderInAYear(short dayOrderInAYear, short year)`

Given a day number (e.g., 60th day of the year), returns the actual day and month for that year.

### `DateAddDays(short days, sDate date)`

Main logic of the program:

- Adds days to the given date
- Handles year transitions
- Calculates the final day and month from the resulting day number

### `ReadFulDate()`

Reads a full date from the user by calling `ReadDay()`, `ReadMonth()`, and `ReadYear()`.

### `ReadDaysToAdd()`

Prompts the user for how many days to add to the date.

### `Main()`

Coordinates the user input, date calculation, and output display.

---

## Example

```
Please enter a Day? 28
Please enter a Month? 2
Please enter a Year? 2024
How many days to add? 3

Date after adding [3] days is: 2/3/2024
```

In this example, the program correctly handles February 29, since 2024 is a leap year.

---

## Educational Purpose

This application is useful for:

- Understanding struct usage in C#
- Practicing conditionals and loops
- Working with date logic without using built-in date libraries
- Modular function-based programming

---

## Author

*This application was developed as part of a C# learning exercise.*

---

##


