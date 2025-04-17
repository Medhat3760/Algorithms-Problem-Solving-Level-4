# Date Difference Calculator - C# Console Application

## Overview
This C# console application calculates the number of days between two dates. It also optionally includes the end day in the total day count. The logic is implemented without relying on built-in date libraries, giving learners a clearer understanding of date operations.

---

## Features
- Read two full dates from user input.
- Calculates the number of days between the two dates.
- Optionally includes the end day in the total.

---

## Program Structure

### 1. `struct stDate`
Defines a simple date structure with fields for `day`, `month`, and `year`.
```csharp
struct stDate
{
    public short year;
    public short month;
    public short day;
}
```

### 2. Input Functions
- **`ReadDay()`**: Prompts user to enter the day.
- **`ReadMonth()`**: Prompts user to enter the month.
- **`ReadYear()`**: Prompts user to enter the year.
- **`ReadFullDate()`**: Collects all three parts and returns an `stDate` object.

### 3. Date Utility Functions
- **`IsLeapYear(short year)`**: Returns `true` if the year is a leap year.
- **`NumberOfDaysInAMonth(short month, short year)`**: Returns the number of days in a given month and year.
- **`IsLastDayInMonth(stDate date)`**: Checks if the day is the last in the month.
- **`IsLastMonthInYear(short month)`**: Returns `true` if the month is December.
- **`IcreaseDateByOneDay(stDate date)`**: Increments the date by one day.

### 4. Date Comparison
- **`IsDate1BeforeDate2(stDate date1, stDate date2)`**: Returns `true` if `date1` is chronologically before `date2`.

### 5. Main Functionality
- **`GetDifferenceInDays(stDate date1, stDate date2, bool includeEndDay)`**
    - Increments `date1` one day at a time until it reaches `date2`.
    - Returns the total number of days passed.
    - Optionally includes the end day in the result.

### 6. `Main()`
- Gets input dates from the user.
- Calls `GetDifferenceInDays()` twice, once with and once without including the end day.
- Displays the results.

---

## Sample Output
```
Enter a Day? 10
Enter a Month? 4
Enter a Year? 2024

Enter a Day? 15
Enter a Month? 4
Enter a Year? 2024

Difference is: 5 Day(s)
Difference (Including End Day) is: 6 Day(s)
```

---

## Educational Value
This project is perfect for learners exploring:
- Manual date manipulation
- Structs and loops in C#
- Leap year calculations and month boundaries

---

## Author
This program is part of a series of small, educational C# applications focused on understanding core programming concepts through practical examples.


