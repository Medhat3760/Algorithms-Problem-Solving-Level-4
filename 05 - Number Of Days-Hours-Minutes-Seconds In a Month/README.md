# Number of Days, Hours, Minutes, and Seconds in a Month

This C# program calculates and displays the number of days, hours, minutes, and seconds in a given month of a specified year. It also accounts for leap years when determining the number of days in February.

## How It Works

1. **Reading Input**
   - The user is prompted to enter a year.
   - The user is then prompted to enter a month.

2. **Leap Year Calculation**
   - A function `IsLeapYear(short year)` determines whether the given year is a leap year based on the following rules:
     - A year is a leap year if it is divisible by 400.
     - A year is also a leap year if it is divisible by 4 but not by 100.

3. **Determining Days in a Month**
   - The function `NumberOfDaysInAMonth(short month, short year)` calculates the number of days in the specified month:
     - If the month is February (2), it checks if the year is a leap year and returns 29 days; otherwise, it returns 28 days.
     - For months with 31 days (January, March, May, July, August, October, December), it returns 31.
     - All other months (April, June, September, November) return 30.

4. **Calculating Hours, Minutes, and Seconds**
   - `NumberOfHoursInAMonth(short month, short year)` multiplies the number of days in the month by 24.
   - `NumberOfMinutesInAMonth(short month, short year)` multiplies the number of hours by 60.
   - `NumberOfSecondsInAMonth(short month, short year)` multiplies the number of minutes by 60.

5. **Displaying the Results**
   - The program outputs the calculated number of days, hours, minutes, and seconds for the given month and year.

## Example Output

```
Please enter a year to check? 2024
Please enter a month to check? 2

Number of Days    in month [2] is 29
Number of Hours   in month [2] is 696
Number of Minutes in month [2] is 41760
Number of Seconds in month [2] is 2505600
```

## Code Structure

- `ReadYear()`: Reads a year from user input.
- `ReadMonth()`: Reads a month from user input.
- `IsLeapYear(year)`: Determines if a year is a leap year.
- `NumberOfDaysInAMonth(month, year)`: Determines the number of days in a given month.
- `NumberOfHoursInAMonth(month, year)`: Calculates hours in a month.
- `NumberOfMinutesInAMonth(month, year)`: Calculates minutes in a month.
- `NumberOfSecondsInAMonth(month, year)`: Calculates seconds in a month.
- `Main()`: The program's entry point, calling all necessary functions and displaying the results.

## Notes
- The program ensures that only valid month values (1-12) are accepted.
- Leap years are correctly accounted for.
- The program correctly handles months with 28, 29, 30, or 31 days.


