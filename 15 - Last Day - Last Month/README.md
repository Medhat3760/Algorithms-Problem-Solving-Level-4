# Last Day & Last Month Check - C# Console Application

## Overview
This C# console application allows the user to input a specific date and then checks:
1. Whether the day is the **last day of the month**.
2. Whether the month is **the last month of the year**.

---

## Features
- Takes day, month, and year input from the user.
- Determines if the given day is the last in that month.
- Determines if the given month is December (the last month of the year).

---

## Program Structure

### 1. `struct stDate`
Defines a simple structure to hold a date with day, month, and year as `short` values.
```csharp
struct stDate {
    public short year;
    public short month;
    public short day;
}
```

### 2. Input Functions
- **`ReadDay()`**: Reads a day from the user.
- **`ReadMonth()`**: Reads a month from the user.
- **`ReadYear()`**: Reads a year from the user.
- **`ReadFullDate()`**: Collects the full date using the above methods.

### 3. Leap Year & Month-Day Logic
- **`IsLeapYear(year)`**: Determines if a year is a leap year.
- **`NumberOfDaysInAMonth(month, year)`**: Returns the correct number of days in a given month, accounting for leap years.

### 4. Date Checks
- **`IsLastDayInMonth(date)`**: Checks if the given day is the last day of the month.
- **`IsLastMonthInYear(month)`**: Checks if the month is December.

### 5. `Main()`
- Reads the date from the user.
- Outputs whether it's the last day of the month and/or the last month of the year.

---

## Sample Output
```
Enter a Day? 31
Enter a Month? 12
Enter a Year? 2024

Yes, Day is Last Day in Month.
Yes, Month is Last Month in Year.
```

---

## Use Case
Great for practicing:
- Working with dates
- Conditional logic
- Handling leap years
- Using structures in C#

---

## Author
This program is part of a collection of beginner-friendly C# applications for learning date operations and basic programming logic.


