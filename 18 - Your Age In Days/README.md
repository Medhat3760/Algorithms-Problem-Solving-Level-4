
# Your Age in Days - C# Console Application

## Overview
This C# console application calculates a person's age in **days** by comparing their **date of birth** to the **current system date**. It uses manual date calculations to account for leap years and date increments without relying on built-in `DateTime` arithmetic for learning purposes.

---

## Features
- User inputs their date of birth.
- System retrieves the current date.
- Calculates total days between the two dates.
- Accounts for leap years and varying month lengths.

---

## Program Structure

### 1. `struct stDate`
Defines a custom structure to hold the date in day, month, and year format.
```csharp
struct stDate {
    public short year;
    public short month;
    public short day;
}
```

### 2. Input Functions
- `ReadDay()`, `ReadMonth()`, `ReadYear()` – Prompt the user to enter parts of a date.
- `ReadFullDate()` – Combines the above into a full `stDate` object.

### 3. Date Utilities
- `IsLeapYear(year)` – Determines if a year is a leap year.
- `NumberOfDaysInAMonth(month, year)` – Returns days in a month, considering leap years.
- `IsLastDayInMonth(date)` and `IsLastMonthInYear(month)` – Boolean checks.
- `IcreaseDateByOneDay(date)` – Increments the date manually by one day.
- `GetSystemDate()` – Retrieves the current system date and converts it to `stDate`.

### 4. Date Comparison
- `IsDate1BeforeDate2(date1, date2)` – Checks if one date comes before another.

### 5. Core Function: `GetDifferenceInDays(date1, date2, includeEndDay)`
- Increments date1 by one day until it reaches date2.
- Tracks the number of days passed.
- Optionally includes the end date in the count.

### 6. `Main()`
- Prompts the user for their birth date.
- Gets the current date from the system.
- Displays the difference in days as the user's age.

---

## Sample Output
```
Please Enter Your Date of Birth:
Enter a Day? 5
Enter a Month? 4
Enter a Year? 2000

Your Age is : 9132 Day(s).
```

---

## Use Case
This program is educational and demonstrates how to perform basic date arithmetic manually, including leap year handling and counting days between two dates.

---

## Author
Part of a series of beginner-friendly C# console applications focusing on date and time calculations.

