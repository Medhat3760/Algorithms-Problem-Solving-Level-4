# Vacation Return Date Calculator

This C# console application calculates the return date after a vacation, excluding weekends (Fridays and Saturdays). It simulates basic date operations using a custom date structure (`stDate`) instead of built-in libraries like `DateTime`.

## Features

- Manually input a starting date and number of vacation days.
- Skips weekends when calculating vacation days.
- Returns the first business day after the vacation ends.
- Custom logic for date handling (e.g., increasing a day, checking leap years, month boundaries).

## Program Structure

### Structs
- **`stDate`**: Custom date structure with `day`, `month`, and `year`.

### Core Functions
- **ReadFullDate**: Prompts the user to enter a full date.
- **ReadVacationDays**: Prompts the user for the number of vacation days.
- **IsLeapYear**: Determines whether a given year is a leap year.
- **NumberOfDaysInAMonth**: Returns number of days in a specific month, taking leap years into account.
- **IsWeekEnd**: Returns true if the date is a Friday or Saturday.
- **IsBusinessDay**: Returns true if the date is Sunday through Thursday.
- **IncreaseDateByOneDay**: Increments the current date by one day.
- **CalculateVacationReturnDate**: Calculates the correct return date after skipping weekends.
- **GetDayShortName**: Returns the short weekday name (Sun, Mon, etc.).

## How Return Date is Calculated
1. Skips any initial weekend days before vacation begins.
2. Iteratively increases the date, counting only business days until the vacation day limit is met.
3. If the resulting date falls on a weekend, it is skipped until the next business day.

## Example Output
```
Vacation Starts:
Enter a Day? 1
Enter a Month? 5
Enter a Year? 2025
Please Enter Vacation Days? 5

Return Date: Sun , 11/5/2025
```

## Notes
- The week is assumed to start on Sunday.
- Weekends are hardcoded as Friday (5) and Saturday (6).

## Limitations
- Does not account for public holidays.
- No input validation (e.g., invalid date values will throw an exception).

## Author
This project is an educational exercise in handling date calculations manually in C#.


