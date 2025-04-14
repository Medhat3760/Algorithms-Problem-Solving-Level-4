# Are Dates Equal - C# Console Application

## Overview
This C# program determines whether two dates entered by the user are exactly equal. It compares the **day**, **month**, and **year** of both dates to check for equality.

---

## Features
- Prompts user to enter two full dates.
- Compares both dates using a custom method.
- Outputs whether the dates are equal or not.

---

## Program Structure

### 1. `struct stDate`
Defines a structure to store a date with `day`, `month`, and `year` as `short` data types.
```csharp
struct stDate
{
    public short year;
    public short month;
    public short day;
}
```

### 2. Input Functions
- **`ReadDay()`**: Prompts the user to enter a day.
- **`ReadMonth()`**: Prompts the user to enter a month.
- **`ReadYear()`**: Prompts the user to enter a year.
- **`ReadFulDate()`**: Uses the above three functions to build and return an `stDate` object.

### 3. `IsDate1EqualDate2(stDate date1, stDate date2)`
Compares two dates and returns `true` if the day, month, and year of both are equal.
```csharp
return (date1.year == date2.year && date1.month == date2.month && date1.day == date2.day);
```

### 4. `Main()`
- Reads two dates from the user.
- Compares them using `IsDate1EqualDate2()`.
- Outputs the result.

---

## Sample Output
```
Please enter a Day? 12
Please enter a Month? 4
Please enter a Year? 2024

Please enter a Day? 12
Please enter a Month? 4
Please enter a Year? 2024

Yes, Date1 is Equal To Date2.
```

---

## Use Case
This program is ideal for learning basic C# structures, conditional logic, and working with dates in a simple and structured manner.

---

## Author
This project is part of a series of small C# console applications focused on understanding date manipulation.


