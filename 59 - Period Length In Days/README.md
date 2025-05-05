# Period Length In Days

## Overview

This C# console application calculates the number of days between two dates. It allows users to input a start and end date, and returns the difference in days both with and without including the end date.

---

## Features

* Input validation for year, month, and day.
* Custom date structure (`stDate`) and period structure (`stPeriod`).
* Leap year consideration.
* Accurate day counting using date iteration.
* Optionally includes the end date in the total.

---

## Data Structures

* **stDate**: Holds a date (day, month, year).
* **stPeriod**: Holds a start and end `stDate`.

---

## Core Functions

### Date Input

* `ReadYear()`, `ReadMonth()`, `ReadDay()`: Prompt user for date components.
* `ReadFulDate()`: Combines the three inputs into a full date.

### Period Input

* `ReadPeriod()`: Prompts user for a start and end date.

### Date Utilities

* `IsLeapYear(year)`: Checks for leap years.
* `NumberOfDaysInAMonth(month, year)`: Returns the number of days in a month.
* `IsDate1BeforeDate2(date1, date2)`: Compares two dates.
* `IncreaseDateByOneDay(date)`: Advances the date by one day.

### Period Calculation

* `GetDifferenceInDays(date1, date2, includeEndDay)`: Calculates the difference in days between two dates.
* `GetPeriodLengthInDays(period, includeEndDate)`: Wrapper for date difference using a `stPeriod`.

---

## Sample Execution

```
Enter Period 1:
Enter Start Date:
Enter a Day? 1
Enter a Month? 1
Enter a Year? 2023

Enter End Date:
Enter a Day? 10
Enter a Month? 1
Enter a Year? 2023

Period Length is: 9
Period Length (Including End Date) is: 10
```

---

## How It Works

The program iterates from the start date to the end date, incrementing one day at a time while checking leap years and month boundaries. It ensures correct date progression and accurate day difference regardless of year or month transitions.

---

## Notes

* Two identical functions exist: `IncreaseDateByOneDay()` and `IcreaseDateByOneDay()`. One of them is likely redundant and can be removed.
* Error handling for invalid user input (non-numeric or out-of-range values) is not implemented.

---

## Usage

Compile and run the program in a C# environment. Input the required dates when prompted to receive the calculated period length.

