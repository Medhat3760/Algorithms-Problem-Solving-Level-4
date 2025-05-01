# Compare Date Function (C#)

This project demonstrates how to compare two dates in C# using a custom structure and a comparison function. The program allows users to input two dates and determines if the first date is before, equal to, or after the second date.

## 🧾 Features
- Reads user input for two dates.
- Compares the two dates using a custom comparison method.
- Returns whether the first date is before, equal to, or after the second date.

## 📁 Structure
- `stDate` struct: Represents a date using `day`, `month`, and `year`.
- `ReadFulDate()` and helpers: Collects date input from the user.
- Comparison functions:
  - `IstDate1BeforeDate2()`: Checks if Date1 is before Date2.
  - `IstDate1EqualDate2()`: Checks if Date1 is equal to Date2.
  - `CompareDates()`: Uses the above two to determine if Date1 is before, equal, or after Date2.

## 🧠 Enum Used
```csharp
enum enDateCompare { Before = -1, Equal = 0, After = 1 }
```

## 🖥️ How It Works
1. User is prompted to enter Date1 and Date2.
2. `CompareDates()` evaluates the relationship between the two dates.
3. The result is printed to the console.

## 🏃‍♂️ Sample Output
```
Enter Date1:
Please enter a Day? 5
Please enter a Month? 3
Please enter a Year? 2025

Enter Date2:
Please enter a Day? 5
Please enter a Month? 3
Please enter a Year? 2025

Compare Result = Equal
```

## 📌 Use Case
Useful in applications that involve:
- Scheduling and appointments
- Validating deadlines
- Calendar-based comparisons

---
**Project:** `_57___Compare_Date_Function`

**Language:** C#

**Category:** Date Handling / Comparisons


