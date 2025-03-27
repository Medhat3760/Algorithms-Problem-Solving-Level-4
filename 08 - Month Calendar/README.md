# Month Calendar Program

## Overview
This C# console application allows users to enter a year and a month to display a formatted monthly calendar. It calculates the number of days in the selected month and aligns them with the correct weekday.

## Features
- Reads a **year** and a **month** from user input.
- Determines if the year is a **leap year**.
- Calculates the **first day of the month** (Sunday - Saturday).
- Displays the **calendar format** for the selected month.

## How It Works
1. The program prompts the user to enter a year.
2. It then asks for the month number (1-12).
3. It determines how many days are in that month, accounting for leap years.
4. It calculates the starting day of the week for the month.
5. It prints a well-formatted **month calendar**.

## Code Breakdown
### 1. Reading User Input
```csharp
static short ReadYear()
{
    Console.Write("\nPlease enter a Year? ");
    return short.Parse(Console.ReadLine());
}

static short ReadMonth()
{
    Console.Write("\nPlease enter a Month? ");
    return short.Parse(Console.ReadLine());
}
```
- These functions prompt the user to enter a **year** and **month**.
- They parse the input and return it as a `short` integer.

### 2. Get Month Name
```csharp
static string GetMonthShortName(short month)
{
    string[] arrMonthNames = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    return arrMonthNames[month - 1];
}
```
- Converts the month number into a **shortened name** (e.g., 1 → "Jan").

### 3. Calculating the First Day of the Month
```csharp
static short GetDayOfWeekOrder(short day, short month, short year)
{
    short a = (short)((14 - month) / 12);
    short y = (short)(year - a);
    short m = (short)(month + 12 * a - 2);
    return (short)((day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7);
}
```
- Determines **which day of the week** the 1st of the month falls on.
- Uses **Zeller’s Congruence Algorithm** to calculate the weekday order (0 = Sunday, 1 = Monday, etc.).

### 4. Checking for Leap Year
```csharp
static bool IsLeapYear(short year)
{
    return (year % 400 == 0 || year % 4 == 0 && year % 100 != 0);
}
```
- Returns `true` if the year is a **leap year**, else returns `false`.

### 5. Getting the Number of Days in a Month
```csharp
static short NumberOfDaysInAMonth(short year, short month)
{
    short[] arrNumberOfDays = { 30, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (month == 2) ? (IsLeapYear(year) ? (short)29 : (short)28) : arrNumberOfDays[month - 1];
}
```
- Returns the number of **days in a given month**.
- February is handled separately for **leap years**.

### 6. Printing the Calendar
```csharp
static void PrintMonthCalender(short year, short month)
{
    short current = GetDayOfWeekOrder(1, month, year);
    short numberOfDays = NumberOfDaysInAMonth(year, month);

    Console.WriteLine($"\n  __________________{GetMonthShortName(month)}____________\n");
    Console.WriteLine("  Sun  Mon  Tue  Wed  Thu  Fri  Sat");

    short i;
    for (i = 0; i < current; i++)
    {
        Console.Write("     ");
    }

    for (short j = 1; j <= numberOfDays; j++)
    {
        Console.Write($"{j,5}");

        if (++i == 7)
        {
            i = 0;
            Console.WriteLine();
        }
    }
    Console.WriteLine("\n  _________________________________\n");
}
```
- **Formats the calendar** layout.
- Starts placing numbers from the **correct weekday**.
- Uses **spacing for alignment**.

### 7. Main Function
```csharp
static void Main(string[] args)
{
    short year = ReadYear();
    short month = ReadMonth();
    PrintMonthCalender(year, month);
}
```
- Calls **functions** in order to read user input, calculate, and print the **calendar**.

## Example Output
```
Please enter a Year? 2024
Please enter a Month? 2

  __________________Feb____________

  Sun  Mon  Tue  Wed  Thu  Fri  Sat
                        1    2    3
    4    5    6    7    8    9   10
   11   12   13   14   15   16   17
   18   19   20   21   22   23   24
   25   26   27   28   29
  _________________________________
```

## Conclusion
- This program is a **basic calendar generator** that prints any month for a given year.
- It correctly aligns **weekdays** and adjusts for **leap years**.
- It demonstrates **input handling, date calculations, and formatted output**.

## Possible Enhancements
- Allow users to **print an entire year** instead of just one month.
- Add support for **different languages** (e.g., month names in Arabic, French, etc.).
- Use **.NET built-in DateTime** methods instead of manual calculations.


