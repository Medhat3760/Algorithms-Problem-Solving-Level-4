# Leap Year Checker

## Description
This C# program determines whether a given year is a leap year. A leap year is a year that is evenly divisible by 4, except for years that are evenly divisible by 100. However, years divisible by 400 are also considered leap years.

## Features
- Accepts user input for a year.
- Checks if the entered year is a leap year using a logical condition.
- Outputs whether the given year is a leap year or not.

## How It Works
1. The program prompts the user to enter a year.
2. It reads and converts the input into a `short` integer.
3. The `IsLeapYear()` function determines if the year meets the leap year criteria:
   - If the year is divisible by 400, it is a leap year.
   - If the year is divisible by 4 but not by 100, it is a leap year.
   - Otherwise, it is not a leap year.
4. The result is displayed to the user.

## Code Structure
- **`ReadYear()`**: Prompts and reads a year input from the user.
- **`IsLeapYear(short year)`**: Checks whether the given year is a leap year using the specified conditions.
- **`Main()`**: Calls `ReadYear()`, checks the leap year condition using `IsLeapYear()`, and prints the result.

## Example Output
```
Please enter a year to check ? 2024

Yes, year [ 2024 ] is a leap year.
```
```
Please enter a year to check ? 2023

No, year [ 2023 ] is NOT a leap year.
```

## Usage
1. Compile the program using a C# compiler or run it in an IDE like Visual Studio.
2. Enter a year when prompted.
3. View the result indicating whether it is a leap year.

## Requirements
- .NET framework or .NET Core
- C# compiler

## Author
This program was written as a simple demonstration of conditional logic in C#.


