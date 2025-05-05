# Count Overlap Days Between Two Periods

## Overview

This C# console application calculates the number of overlapping days between two date periods. The user inputs two periods (each defined by a start and end date), and the program determines how many days both periods intersect.

---

## Features

* Custom structures for representing dates and periods.
* Full support for date comparison and increment logic.
* Leap year handling and valid days-per-month calculation.
* Accurate day-by-day overlap counting between two date ranges.

---

## Data Structures

* **stDate**: A structure with `day`, `month`, and `year` fields.
* **stPeriod**: A structure containing two `stDate` fields: `startDate` and `endDate`.

---

## Core Functions

### Input Functions

* `ReadDay()`, `ReadMonth()`, `ReadYear()`: Get date parts from the user.
* `ReadFulDate()`: Reads a complete `stDate`.
* `ReadPeriod()`: Reads start and end dates for a `stPeriod`.

### Date Logic

* `IsDate1BeforeDate2(date1, date2)`: Checks chronological order.
* `IsDate1EqualDate2(date1, date2)`: Checks if two dates are identical.
* `IsDate1AfterDate2(date1, date2)`: Determines if one date is later.
* `CompareDates(date1, date2)`: Enum-based comparison result.
* `IncreaseDateByOneDay(date)`: Returns the next calendar day.
* `IsLeapYear(year)`: Detects leap years.
* `NumberOfDaysInAMonth(month, year)`: Returns correct day count for a given month.

### Period and Overlap Functions

* `GetDifferenceInDays(date1, date2, includeEndDay)`: Computes days between two dates.
* `GetPeriodLengthInDays(period, includeEndDate)`: Duration of a period.
* `IsOverlapPeriods(period1, period2)`: Checks if two periods overlap.
* `IsDateInPeriod(period, date)`: Checks if a date lies within a period.
* `CountOverlapDays(period1, period2)`: Core logic to count overlapping days by incrementally checking each day in the shorter period against the longer.

---

## Example Output

```
Enter Period 1:
Enter Start Date:
Please enter a Day? 1
Please enter a Month? 1
Please enter a Year? 2024
Enter End Date:
Please enter a Day? 10
Please enter a Month? 1
Please enter a Year? 2024

Enter Period 2:
Enter Start Date:
Please enter a Day? 5
Please enter a Month? 1
Please enter a Year? 2024
Enter End Date:
Please enter a Day? 15
Please enter a Month? 1
Please enter a Year? 2024

Overlap Days Count is: 6
```

---

## Notes

* Includes the end date in overlap count (inclusive range).
* Properly swaps date inputs if given out of order.
* The program uses manual date handling rather than `DateTime` class for educational clarity.

---

## How to Use

1. Compile and run the application.
2. Follow the prompts to enter two periods (start and end dates).
3. The output will show how many days overlap between both periods.

