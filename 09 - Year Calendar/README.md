# Year Calendar Program in C#

## Overview
This C# program generates and displays a calendar for an entire year. It calculates the number of days in each month, determines the starting day of the month, and prints a formatted calendar for the user-specified year.

## Features
- Reads a year from the user.
- Calculates whether the year is a leap year.
- Determines the number of days in each month.
- Computes the starting day of each month.
- Displays a formatted monthly calendar.
- Prints the full year calendar in a structured format.

## How It Works
1. **Reading Input:** The program prompts the user to enter a year.
2. **Leap Year Calculation:** It determines if the entered year is a leap year.
3. **Day Calculation:** The number of days in each month is computed.
4. **Start Day Calculation:** The starting weekday for each month is determined using a formula.
5. **Month Calendar Display:** A formatted month calendar is printed for each month.
6. **Full Year Calendar Display:** The entire year's calendar is printed in order.

## Code Explanation
### 1. Reading the Year
```csharp
static short ReadYear()
{
    short year = 0;
    Console.Write("\nPlease enter a Year? ");
    year = short.Parse(Console.ReadLine());
    return year;
}
```
This function prompts the user to enter a year and returns the input as a `short` integer.

### 2. Checking Leap Year
```csharp
static bool IsLeapYear(short year)
{
    return (year % 400 == 0 || year % 4 == 0 && year % 100 != 0);
}
```
This function determines whether a given year is a leap year.

### 3. Getting the Month Name
```csharp
static string GetMonthShortName(short month)
{
    string[] arrMonthNames = { "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                               "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    return arrMonthNames[month - 1];
}
```
This function returns the short name of a given month (e.g., "Jan" for January).

### 4. Calculating Days in a Month
```csharp
static short NumberOfDaysInAMonth(short year, short month)
{
    short[] arrNumberOfDays = { 30, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    return (month == 2) ? (IsLeapYear(year) ? (short)29 : (short)28) : arrNumberOfDays[month - 1];
}
```
This function calculates the number of days in a given month, adjusting for leap years.

### 5. Determining the Start Day of a Month
```csharp
static short GetDayOfWeekOrder(short day, short month, short year)
{
    short a = (short)((14 - month) / 12);
    short y = (short)(year - a);
    short m = (short)(month + 12 * a - 2);
    return (short)((day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7);
}
```
This function determines the weekday order (0 = Sunday, 1 = Monday, etc.) for the first day of a given month.

### 6. Printing a Monthly Calendar
```csharp
static void PrintMonthCalender(short year, short month)
{
    short current = GetDayOfWeekOrder(1, month, year);
    short numberOfDays = NumberOfDaysInAMonth(year, month);

    Console.WriteLine($"\n  _______________{GetMonthShortName(month)}_______________\n");
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
This function prints a formatted calendar for a given month, showing weekdays and aligning the days properly.

### 7. Printing the Full Year Calendar
```csharp
static void PrintYearCalendar(short year)
{
    Console.WriteLine("\n  _________________________________\n");
    Console.WriteLine($"\t  Calendar - {year}");
    Console.WriteLine("  _________________________________\n");

    for (short i = 1; i <= 12; i++)
    {
        PrintMonthCalender(year, i);
    }
}
```
This function loops through all 12 months and prints their respective calendars to generate a full year view.

### 8. Main Method
```csharp
static void Main(string[] args)
{
    short year = ReadYear();
    PrintYearCalendar(year);
}
```
The `Main` function calls `ReadYear()` to get the user input and then calls `PrintYearCalendar()` to display the entire year’s calendar.

## How to Run
1. Compile the program using a C# compiler.
2. Run the executable.
3. Enter a year when prompted.
4. View the generated calendar for the entire year.

## Example Output
```
Please enter a Year? 2024
  _________________________________
         Calendar - 2024
  _________________________________

  _______________Jan_______________
  Sun  Mon  Tue  Wed  Thu  Fri  Sat
       1    2    3    4    5    6
   7    8    9   10   11   12   13
  14   15   16   17   18   19   20
  21   22   23   24   25   26   27
  28   29   30   31
  _________________________________
  _______________Feb_______________
  Sun  Mon  Tue  Wed  Thu  Fri  Sat
       1    2    3    4    5    6
   7    8    9   10   11   12   13
  14   15   16   17   18   19   20
  21   22   23   24   25   26   27
  28   29
  _________________________________
```

## Conclusion
This program effectively calculates and displays a yearly calendar, making use of modular functions for various computations like leap year checking, day calculations, and formatted output. It provides an easy way to view any year’s calendar in a structured format.
