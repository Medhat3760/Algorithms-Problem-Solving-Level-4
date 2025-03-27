# Number Of Days From The Beginning Of The Year

## Description
This C# console application calculates the number of days that have passed since the beginning of a given year up to a specified date (day and month). The program takes user input for the day, month, and year, and determines the total number of days that have elapsed in that year.

## Features
- Reads a valid **day**, **month**, and **year** from the user.
- Checks if the given **year** is a **leap year**.
- Determines the number of days in each month.
- Computes the total number of days elapsed from January 1st to the given date.
- Outputs the computed number of days.

## Code Explanation

### Methods Used:
1. **`ReadDay()`**
   - Prompts the user to enter a day and reads the input.
   - Parses the input as a `short` data type.

2. **`ReadMonth()`**
   - Prompts the user to enter a month and reads the input.
   - Parses the input as a `short` data type.

3. **`ReadYear()`**
   - Prompts the user to enter a year and reads the input.
   - Parses the input as a `short` data type.

4. **`IsLeapYear(short year)`**
   - Determines if a given year is a leap year.
   - Returns `true` if the year is divisible by 400 or divisible by 4 but not by 100.

5. **`NumberOfDaysInAMonth(short month, short year)`**
   - Returns the number of days in a given month.
   - Takes leap years into account when determining February's days (28 or 29).

6. **`NumOfDaysFromBeginningTheYear(short year, short month, short day)`**
   - Iterates through the months from January to the given month.
   - Sums up the number of days for each month.
   - Adds the given day to get the total number of days from the beginning of the year.

7. **`Main(string[] args)`**
   - Calls `ReadDay()`, `ReadMonth()`, and `ReadYear()` to get user input.
   - Calls `NumOfDaysFromBeginningTheYear(year, month, day)` to compute the result.
   - Prints the total number of days elapsed since the beginning of the year.

## Example Output
### Input:
```
Please enter a Day? 15
Please enter a Month? 3
Please enter a year? 2024
```

### Output:
```
Number Of Days From The Beginning Of The Year is 75
```

## Notes
- The program uses **arrays** to store the number of days in each month.
- The `IsLeapYear()` method ensures that leap years are handled correctly.
- The program performs **basic input validation** by ensuring that months are between 1 and 12.
- It calculates days efficiently using a loop to sum up the days for all previous months.

## Usage
Compile and run the program in a C# environment or an IDE that supports C# (e.g., Visual Studio, VS Code with .NET SDK installed). 

## Author
This project is created for educational purposes to demonstrate date calculations in C#.
