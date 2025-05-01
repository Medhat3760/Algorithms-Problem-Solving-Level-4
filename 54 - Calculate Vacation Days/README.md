# Vacation Days Calculator - C# Console App

## Overview
This C# console application calculates the actual number of **business days** (excluding weekends) between two dates representing the start and end of a vacation.

It uses a custom `stDate` struct and functions to handle:
- Date reading and validation
- Date arithmetic (e.g., adding one day)
- Business day filtering (excluding Fridays and Saturdays)
- Leap year handling

---

## Features
- Input two dates interactively from the user
- Calculate only business days (Sunday to Thursday)
- Proper date validation and handling of leap years
- Returns total vacation days excluding weekends

---

## How It Works

### 1. **Date Struct**
```csharp
struct stDate {
    public short year;
    public short month;
    public short day;
}
```

### 2. **Reading Dates from User**
The program reads the day, month, and year using helper methods like `ReadDay()`, `ReadMonth()`, `ReadYear()`.

### 3. **Date Validation and Navigation**
- `IsLeapYear()`: Checks leap year
- `NumberOfDaysInAMonth()`: Returns the number of days in a given month
- `IncreaseDateByOneDay()`: Advances the date, handling month and year wrap-arounds

### 4. **Weekend Checking**
```csharp
bool IsWeekEnd(stDate date) => GetDayOfWeekOrder(date) == 5 || GetDayOfWeekOrder(date) == 6;
```
- Friday (5) and Saturday (6) are considered weekends

### 5. **Calculating Business Days**
```csharp
short CalculateVacationDays(stDate dateFrom, stDate dateTo) {
    while (IsDate1BeforeDate2(dateFrom, dateTo)) {
        if (IsBusinessDay(dateFrom)) daysCount++;
        dateFrom = IncreaseDateByOneDay(dateFrom);
    }
    return daysCount;
}
```

---

## Sample Output
```
Vacation Starts:
Enter a Day? 1
Enter a Month? 5
Enter a Year? 2025

Vacation Ends:
Enter a Day? 10
Enter a Month? 5
Enter a Year? 2025

Vacation From: Thu , 1/5/2025
Vacation To: Sat , 10/5/2025

Actual Vacation Days is: 6
```

---

## Notes
- Dates are assumed to be valid; no invalid date checks are included.
- If you want to include the end date, the logic can be adjusted with a flag.
- Business days include Sunday to Thursday.

---

## How to Run
1. Clone the repository or copy the source code.
2. Compile and run in Visual Studio or any C# IDE.
3. Enter two valid dates.

---

