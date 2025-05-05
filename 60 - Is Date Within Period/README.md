# Is Date Within Period

## Overview

This C# console application determines whether a specific date falls within a user-defined date period. Users input a start date, an end date, and a date to check. The program then reports if the checked date is inside the period, including boundary dates.

---

## Features

* Structured user input for start and end dates.
* Date comparison logic using custom date structure.
* Handles exact match and boundaries.
* Clear user interaction prompts.

---

## Data Structures

* **stDate**: A structure holding `day`, `month`, and `year`.
* **stPeriod**: A structure holding `startDate` and `endDate` of type `stDate`.

---

## Core Functions

### Input Functions

* `ReadYear()`, `ReadMonth()`, `ReadDay()`: Prompt for individual date components.
* `ReadFullDate()`: Gathers a complete date from the user.
* `ReadPeriod()`: Reads both start and end dates of the period.

### Date Comparison

* `IsDate1BeforeDate2(date1, date2)`: Checks if one date is earlier than another.
* `IsDate1EqualDate2(date1, date2)`: Checks for date equality.
* `IsDate1AfterDate2(date1, date2)`: Determines if a date is after another.
* `IsDateInPeriod(period, date)`: Core logic that returns `true` if `date` is between `startDate` and `endDate` (inclusive).

---

## Sample Execution

```
Enter Period 1:
Enter Start Date:
Enter a Day? 1
Enter a Month? 1
Enter a Year? 2023

Enter End Date:
Enter a Day? 31
Enter a Month? 12
Enter a Year? 2023

Enter Date to Check:
Enter a Day? 15
Enter a Month? 6
Enter a Year? 2023

Yes, Date is Within Period.
```

---

## Notes

* The check includes both the start and end dates.
* Basic validation is assumed but not explicitly implemented (e.g., invalid dates or leap year handling).

---

## Usage

Compile and run the application. Follow prompts to enter the start and end of the period, and a date to test. The program will tell you if the date lies within the range.

