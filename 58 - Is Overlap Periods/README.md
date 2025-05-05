# Is Overlap Periods - C# Console Application

## Overview

This C# console application allows the user to determine whether two date periods (ranges) overlap. It requests two date ranges from the user, each consisting of a start and end date, and then checks if the periods intersect.

## Features

* User input for specific day, month, and year.
* Validates if one date is before, after, or equal to another.
* Uses structured `stDate` and `stPeriod` to represent individual dates and periods respectively.
* Compares two periods and determines if they overlap.

## Key Concepts

* **stDate**: A struct that holds `day`, `month`, and `year` as `short`.
* **stPeriod**: A struct that holds a `startDate` and an `endDate`, both of type `stDate`.
* **CompareDates**: Returns whether one date is before, equal to, or after another.
* **IsOverlapPeriods**: Returns true if two periods intersect in any way.

## How It Works

1. Prompts user to enter the first period (start and end date).
2. Prompts user to enter the second period (start and end date).
3. Compares the periods using `CompareDates` function:

   * If period2 ends before period1 starts, or period2 starts after period1 ends, the periods do not overlap.
   * Otherwise, they do overlap.
4. Outputs whether the periods overlap or not.

## Example

```
Enter Period 1:
Enter Start Date:
Please enter a Day? 10
Please enter a Month? 4
Please enter a Year? 2024

Enter End Date:
Please enter a Day? 20
Please enter a Month? 4
Please enter a Year? 2024

Enter Period 2:
Enter Start Date:
Please enter a Day? 15
Please enter a Month? 4
Please enter a Year? 2024

Enter End Date:
Please enter a Day? 25
Please enter a Month? 4
Please enter a Year? 2024

Yes, Periods Overlap.

```

## Usage

This application is helpful in scheduling systems, booking apps, or any domain where managing and validating overlapping time intervals is necessary.

---

**Note**: This application assumes valid user input and does not include error handling for invalid or logically incorrect dates (e.g., 30th February).
