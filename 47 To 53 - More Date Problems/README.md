# More Date Problems in C#

## Overview
This project demonstrates handling dates manually in C#. It avoids heavy reliance on the built-in `DateTime` operations and focuses on implementing fundamental date operations manually. This is educational for understanding date computations.

---

## Features
- Retrieve the current system date
- Determine the day of the week
- Check if a date is:
  - End of the week (Saturday)
  - Weekend (Friday or Saturday)
  - Business day (Sunday to Thursday)
- Calculate days remaining until:
  - End of the week
  - End of the month
  - End of the year
- Detect leap years
- Determine the number of days in a month
- Increase date by one day manually
- Compare two dates
- Calculate the number of days between two dates

---

## Code Structure

### `stDate` Struct
A structure to hold date components manually:
```csharp
struct stDate
{
    public short year;
    public short month;
    public short day;
}
```

### Main Functions

- `GetSystemDate()`: Fetches the current system date into `stDate` format.
- `GetDayOfWeekOrder(day, month, year)`: Calculates the weekday index manually (0=Sunday, 1=Monday, ..., 6=Saturday).
- `GetDayShortName(dayOfWeekOrder)`: Returns the short name for a day index.
- `IsEndOfWeek(date)`: Checks if a date falls on Saturday.
- `IsWeekEnd(date)`: Checks if a date falls on Friday or Saturday.
- `IsBusinessDay(date)`: Checks if a date is a business day (Sunday to Thursday).
- `IsLeapYear(year)`: Checks whether a year is a leap year.
- `NumberOfDaysInAMonth(month, year)`: Returns number of days in a month.
- `GetDaysUntilEndOfWeek(date)`: Days left until Saturday.
- `GetDaysUntilEndOfMonth(date)`: Days left until end of month.
- `GetDaysUntilEndOfYear(date)`: Days left until end of year.
- `IncreaseDateByOneDay(date)`: Increments the date by one day, accounting for month/year transitions.
- `GetDifferenceDays(date1, date2, includeEndDay)`: Calculates the difference between two dates.
- `GetDaysUntilEndOfMonth_v2(date)` and `GetDaysUntilEndOfYear_v2(date)`: Alternative calculation methods using manual day counting.

### Helper Functions

- `IsDate1BeforeDate2(date1, date2)`: Compares two dates.
- `IsLastDayInMonth(date)`: Checks if a date is the last day of the month.
- `NumberOfDaysFromBeginningTheYear(date)`: Calculates how many days have passed since the start of the year.

---

## Sample Program Flow
The `Main()` method:
1. Retrieves the current date.
2. Displays:
   - Today's day name and full date.
   - Whether it is the end of the week, weekend, or business day.
   - Days left until the end of the week, month, and year.
   - Alternative calculation results for end of month and year.

### Example Output
```
Today is Sun , 27/4/2025

Is it End of Week?
No NOT end of week.

Is it Weekend?
No today is Sun, NOT a weekend.

Is it a Business Day?
Yes it is a business day.

Days until end of week : 6 Day(s)
Days until end of month : 3 Day(s)
Days until end of year : 248 Day(s)

Version2:
Days until end of month (version 2) : 3 Day(s)
Days until end of year (version 2) : 248 Day(s)
```

---

## Purpose
This project is designed for educational purposes, helping you understand:
- Manual date handling
- Structs and basic algorithms
- Control flow and conditionals in C#

---

## How to Run
1. Open the project in Visual Studio or another C# IDE.
2. Build and run the project.

---

## Author
This project is intended as an educational exercise for learning how dates work internally without relying heavily on built-in .NET libraries.


