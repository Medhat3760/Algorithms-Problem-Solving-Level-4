# Number of Days, Hours, Minutes, and Seconds in a Year

## Overview
This C# program calculates the number of days, hours, minutes, and seconds in a given year. It determines whether the year is a leap year and adjusts the calculations accordingly.

## Features
- Reads a year from the user.
- Determines if the year is a leap year.
- Calculates:
  - The number of days in the year (365 or 366 for leap years).
  - The number of hours in the year.
  - The number of minutes in the year.
  - The number of seconds in the year.
- Displays the results in a structured format.

## Code Explanation
### 1. **Reading the Year**
```csharp
static short ReadYear()
{
    short year;
    Console.Write("Please enter a year to check? ");
    year = short.Parse(Console.ReadLine());
    return year;
}
```
- Prompts the user to enter a year.
- Converts the input string to a `short` integer.

### 2. **Checking for Leap Year**
```csharp
static bool IsLeapYear(short year)
{
    return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
}
```
- A year is a leap year if:
  - It is divisible by 4 and not divisible by 100, OR
  - It is divisible by 400.

### 3. **Calculating Time Units**
```csharp
static short NumberOfDaysInAYear(short year)
{
    return IsLeapYear(year) ? (short)366 : (short)365;
}
```
- Returns 366 days for leap years and 365 otherwise.

```csharp
static short NumberOfHoursInAYear(short year)
{
    return (short)(NumberOfDaysInAYear(year) * 24);
}
```
- Multiplies the number of days by 24 to get hours.

```csharp
static int NumberOfMinutesINAYear(short year)
{
    return (NumberOfHoursInAYear(year) * 60);
}
```
- Multiplies the number of hours by 60 to get minutes.

```csharp
static int NumberOfSecondsInAYear(short year)
{
    return NumberOfMinutesINAYear(year) * 60;
}
```
- Multiplies the number of minutes by 60 to get seconds.

### 4. **Displaying Results**
```csharp
static void Main(string[] args)
{
    short year = ReadYear();
    Console.WriteLine($"\nNumber of Days    in Year [{year}] is {NumberOfDaysInAYear(year)}");
    Console.WriteLine($"Number of Hours   in Year [{year}] is {NumberOfHoursInAYear(year)}");
    Console.WriteLine($"Number of Minutes in Year [{year}] is {NumberOfMinutesINAYear(year)}");
    Console.WriteLine($"Number of Seconds in Year [{year}] is {NumberOfSecondsInAYear(year)}");
}
```
- Calls functions to get the year input and calculate the time units.
- Displays the results using formatted output.

## How to Run
1. Compile the program using a C# compiler (e.g., Visual Studio, .NET CLI).
2. Run the executable and enter a year when prompted.
3. The program will output the number of days, hours, minutes, and seconds in the entered year.

## Example Output
```
Please enter a year to check? 2024

Number of Days    in Year [2024] is 366
Number of Hours   in Year [2024] is 8784
Number of Minutes in Year [2024] is 527040
Number of Seconds in Year [2024] is 31622400
```

## Conclusion
This program provides a simple way to calculate time units in a given year, accounting for leap years. It demonstrates basic C# programming concepts like conditional logic, user input, and formatted output.


