# Increase Date by One Day - C# Console Application

## Overview
This C# program allows the user to input a specific date and then increases that date by one day. It correctly handles edge cases such as the end of a month and the end of a year, including leap years.

---

## Features
- Reads a date from the user.
- Increments the date by one day.
- Takes leap years and month lengths into account.
- Handles transitions between months and years.

---

## Program Structure

### 1. `struct stDate`
A structure that stores a date with three fields:
```csharp
public short year;
public short month;
public short day;
```

### 2. Input Functions
- **`ReadDay()`**: Reads the day from the user.
- **`ReadMonth()`**: Reads the month from the user.
- **`ReadYear()`**: Reads the year from the user.
- **`ReadFullDate()`**: Combines the above inputs into a `stDate` object.

### 3. Leap Year and Month Days Functions
- **`IsLeapYear(year)`**: Determines if a year is a leap year.
- **`NumberOfDaysInAMonth(month, year)`**: Returns the number of days in the given month, accounting for leap years.
- **`IsLastDayInMonth(date)`**: Checks if the given day is the last in the month.
- **`IsLastMonthInYear(month)`**: Checks if the given month is December.

### 4. `IncreaseDateByOneDay(stDate date)`
This function adds one day to the given date and updates the month and year as needed.
```csharp
if (IsLastDayInMonth(date))
{
    if (IsLastMonthInYear(date.month))
    {
        date.day = 1;
        date.month = 1;
        date.year++;
    }
    else
    {
        date.day = 1;
        date.month++;
    }
}
else
{
    date.day++;
}
```

### 5. `Main()`
- Reads the date from the user.
- Increments it by one day.
- Displays the new date.

---

## Sample Output
```
Enter a Day? 28
Enter a Month? 2
Enter a Year? 2024

Date after adding one day is: 29/2/2024
```

---

## Use Case
This application is helpful for learning how to manipulate dates manually in C#, especially for understanding control flow and handling special cases like leap years.

---

## Author
This project is part of a C# console application series designed to practice date handling and logic implementation.


