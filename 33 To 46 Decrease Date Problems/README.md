# Date Decrement Utility - C# Console Application

## Overview

This console application provides a suite of functions to decrement a given date by various time units: days, weeks, months, years, decades, centuries, and millennia. It handles month lengths (including leap years) to ensure valid resulting dates.

---

## Features

- **Read Input Date**: Prompts user for day, month, and year components.
- **Leap Year Handling**: Correctly calculates February length.
- **Date Decrement Methods**:
  - `DecreaseDateByOneDay`
  - `DecreaseDateByXDays`
  - `DecreaseDateByOneWeek`
  - `DecreaseDateByXWeeks`
  - `DecreaseDateByOneMonth`
  - `DecreaseDateByXMonths`
  - `DecreaseDateByOneYear`
  - `DecreaseDateByXYears` and a faster variant
  - `DecreaseDateByOneDecade`
  - `DecreaseDateByXDecades` and a faster variant
  - `DecreaseDateByOneCentury`
  - `DecreaseDateByOneMillennium`

- **Main Demo**: Sequentially applies each decrement function to the input date and prints results.

---

## Key Components

### `struct stDate`
Represents a date with three `short` fields: `year`, `month`, and `day`.

### Input Functions
- `ReadDay()`, `ReadMonth()`, `ReadYear()`: Prompt and parse each component from console.
- `ReadFullDate()`: Combines the above into an `stDate` object.

### Date Utilities
- **Leap Year Check**: `IsLeapYear(year)` returns `true` for valid leap years.
- **Days in Month**: `NumberOfDaysInAMonth(month, year)` returns correct length, adjusting February for leap years.

### Decrement Methods
Each method takes an `stDate` and returns a new `stDate`:

- **By One Unit**: Single-day (`DecreaseDateByOneDay`), week, month, year, decade, century, millennium.
- **By Multiple Units**: Loops a single-unit method (e.g. `DecreaseDateByXDays`, `DecreaseDateByXWeeks`, etc.).
- **Faster Variants**: For years and decades, adjusts the `year` field directly and corrects `day` if it exceeds month length.

---

## Sample Run
```
Enter a Year? 2025
Enter a Month? 3
Enter a Day? 1

Date After:

01-Subtracting one day is: 28/2/2025
02-Subtracting 10 days is: 18/2/2025
03-Subtracting one week is: 11/2/2025
04-Subtracting 10 weeks is: 3/12/2024
05-Subtracting one month is: 3/11/2024
... (additional steps shown) ...
```

---

## Usage
1. Compile and run the project.
2. Input the desired date when prompted.
3. Observe the sequence of decremented dates printed in the console.

---

## License
MIT © Abdelrahman Medhat


