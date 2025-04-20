
# Increase Date Operations in C#

This C# console application demonstrates various techniques for incrementing a date by different time units, including days, weeks, months, years, decades, centuries, and millennia.

## Features

- Increase a date by:
  - One day
  - X days
  - One week
  - X weeks
  - One month
  - X months
  - One year
  - X years (standard and fast method)
  - One decade
  - X decades (standard and fast method)
  - One century
  - One millennium

## Date Handling Logic

The program uses a custom `stDate` struct to represent dates and handles:
- Leap years
- Month-end boundaries
- Year-end transitions

## Key Methods

- `IncreaseDateByOneDay`
- `IncreaseDateByXDays`
- `IncreaseDateByOneWeek`
- `IncreaseDateByXWeeks`
- `IncreaseDateByOneMonth`
- `IncreaseDateByXMonths`
- `IncreaseDateByOneYear`
- `IncreaseDateByXYears`
- `IncreaseDateByXYearsFaster`
- `IncreaseDateByOneDecade`
- `IncreaseDateByXDecades`
- `IncreaseDateByXDecadesFaster`
- `IncreaseDateByOneCentury`
- `IncreaseDateByOneMillennium`

## Example Usage

After the user inputs a date, the program successively displays the results of applying various increments to that date.

## Sample Output

```
Enter a Day? 15
Enter a Month? 4
Enter a Year? 2024

Date After:

01-Adding one day is: 16/4/2024
02-Adding 10 days is: 26/4/2024
03-Adding one week is: 3/5/2024
...
14-Adding Century is: 3/5/3124
```

## Purpose

This program is designed for educational purposes, particularly for learning how to manipulate dates without relying on built-in C# `DateTime` methods, thus understanding the internal logic behind date arithmetic.

---

*Note: This program does not validate date inputs rigorously; users are assumed to input valid Gregorian calendar dates.*

