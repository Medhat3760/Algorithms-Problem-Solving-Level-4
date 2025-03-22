# Day Name Finder

This C# program calculates the day of the week for a given date by using a mathematical formula. The program prompts the user to enter a year, month, and day, then determines the corresponding weekday and displays it.

## Features
- Reads user input for year, month, and day.
- Uses a mathematical formula to determine the day of the week.
- Displays the calculated day of the week in short format (e.g., "Mon", "Tue").

## How It Works
1. **Reading User Input:**
   - `ReadYear()`: Prompts the user to enter a year and returns it.
   - `ReadMonth()`: Prompts the user to enter a month and returns it.
   - `ReadDay()`: Prompts the user to enter a day and returns it.

2. **Calculating the Day of the Week:**
   - `GetDayOfWeekOrder(day, month, year)`: Uses Zeller's Congruence algorithm to determine the day order (0 for Sunday, 1 for Monday, ..., 6 for Saturday).

3. **Mapping Day Order to Day Name:**
   - `GetDayShortName(dayOrder)`: Converts the numerical day order into a short-form day name (e.g., "Mon", "Tue").

4. **Displaying the Result:**
   - The program prints the entered date, the calculated day order, and the corresponding weekday name.

## Example Run
```
Please enter a Year? 2024
Please enter a Month? 3
Please enter a Day? 1

Date      : 1/3/2024
Day Order : 5
Day Name  : Fri
```

## Formula Explanation
The function `GetDayOfWeekOrder(day, month, year)` applies the following formula:

```
d = (day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7;
```

Where:
- `a` adjusts for months from January and February.
- `y` represents the adjusted year.
- `m` represents the adjusted month.
- `d` is the calculated day order (0 to 6).

## Requirements
- C# compiler (e.g., Visual Studio, .NET SDK)
- Console application execution environment

## Conclusion
This program provides an easy way to find the day of the week for any given date using a well-known mathematical formula.


