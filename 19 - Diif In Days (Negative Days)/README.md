
# 📆 Diff In Days (With Negative Support)

This C# console application calculates the difference in days between two dates. It also supports negative differences (i.e., when the first date is after the second date) and provides an option to include the end day in the calculation.

---

## 📌 Features

- Input two dates from the user.
- Calculate the number of days between the dates.
- Supports negative day differences.
- Optionally includes the end date in the result.

---

## 📥 User Input

The user is prompted to enter:
- Day
- Month
- Year

This input is repeated for two separate dates.

---

## ⚙️ How It Works

1. The program defines a custom `struct` called `stDate` to hold the day, month, and year.
2. It uses helper functions to:
   - Read and validate dates.
   - Determine leap years.
   - Count days in a given month.
   - Increment a date by one day.
3. It compares the two input dates:
   - If the first date is after the second, it swaps them and marks the difference as negative.
4. It then calculates the number of days between the two dates.

---

## 📌 Sample Output

```
Please enter a Day? 10
Please enter a Month? 4
Please enter a Year? 2024

Please enter a Day? 15
Please enter a Month? 4
Please enter a Year? 2024

Difference is: 5 Day(s).
Difference (Including End Day) is: 6 Day(s).
```

If the first date is later than the second:

```
Difference is: -5 Day(s).
Difference (Including End Day) is: -6 Day(s).
```

---

## 🧱 Main Components

- `struct stDate`: Holds day, month, year.
- `IncreaseDateByOneDay`: Adds one day to a date.
- `IsLeapYear`: Checks if a year is a leap year.
- `NumberOfDaysInAMonth`: Gets the number of days in a month.
- `GetDifferenceInDays`: Calculates difference with optional end day inclusion.
- `SwapDates`: Swaps two date structs if needed.

---

## 🚀 How to Run

1. Open the project in Visual Studio or any C# IDE.
2. Build and run the application.
3. Follow the console instructions to input the two dates.
4. View the result in the console.

---

## 🛠️ Possible Improvements

- Add input validation.
- Support time (hours/minutes).
- Localize the date format and prompts.
- Create a graphical UI version (WPF or Windows Forms).

---

## 👨‍💻 Author

Developed as an educational exercise to demonstrate working with dates, structs, and logic in C#.

