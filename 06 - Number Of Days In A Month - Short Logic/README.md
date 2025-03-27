# Number of Days in a Month - Short Logic

## Overview
This C# program calculates the number of days in a given month of a specific year. It accounts for leap years to determine if February has 28 or 29 days.

## Features
- Reads a year and a month from the user.
- Checks if the given year is a leap year.
- Determines the number of days in the specified month.
- Displays the result.

## Code Explanation

### 1. **Reading Input**
The program defines two functions to read the year and month from the user:

```csharp
static short ReadYear()
{
    short year = 0;
    Console.Write("\nPlease enter a year to check? ");
    year = short.Parse(Console.ReadLine());
    return year;
}

static short ReadMonth()
{
    short month = 0;
    Console.Write("\nPlease enter a month to check? ");
    month = short.Parse(Console.ReadLine());
    return month;
}
```

### 2. **Checking Leap Year**
The function `IsLeapYear()` determines whether the given year is a leap year:

```csharp
static bool IsLeapYear(short year)
{
    return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
}
```
A leap year occurs if:
- It is divisible by 400, or
- It is divisible by 4 but not by 100.

### 3. **Determining Days in a Month**
The function `NumberOfDaysInAMonth()` calculates the number of days:

```csharp
static short NumberOfDaysInAMonth(short month, short year)
{
    if (month < 1 || month > 12)
    {
        return 0;
    }

    short[] arrNumberOfDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    return (month == 2) ? (IsLeapYear(year) ? (short)29 : (short)28) : arrNumberOfDays[month - 1];
}
```
- It uses an array `arrNumberOfDays` to store the number of days for each month.
- If the month is February (2), it checks if the year is a leap year and assigns 29 or 28 days accordingly.

### 4. **Main Execution**
The `Main()` function:
- Calls `ReadYear()` and `ReadMonth()`.
- Calls `NumberOfDaysInAMonth()`.
- Prints the result.

```csharp
static void Main(string[] args)
{
    short year = ReadYear();
    short month = ReadMonth();
    Console.WriteLine($"\nNumber of days in month [{month}] is {NumberOfDaysInAMonth(month, year)}");
}
```

## Example Run
### **Input:**
```
Please enter a year to check? 2024
Please enter a month to check? 2
```
### **Output:**
```
Number of days in month [2] is 29
```

## Conclusion
This program efficiently determines the number of days in a month while correctly handling leap years. 


