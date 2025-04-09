# 📅 Date From Day Order In A Year (C# Console Application)

This C# console application determines the number of days passed since the beginning of the year for a given date and also finds the corresponding date from a given day order in that year.

---

## 🧠 Program Overview

The application performs two main operations:

1. **Calculate the Day Order** (i.e., how many days have passed from January 1st to the given date).
2. **Get the Date from Day Order** (i.e., reverse the above operation).

---

## 🔧 Key Functions

### 1. `ReadDay()`, `ReadMonth()`, `ReadYear()`
- Reads the user's input for the day, month, and year.
- Returns the respective values as `short` integers.

### 2. `IsLeapYear(short year)`
- Checks whether the given year is a leap year.
- Returns `true` if it's a leap year, otherwise `false`.

### 3. `NumberOfDaysInAMonth(short month, short year)`
- Returns the number of days in a given month of a given year.
- Considers leap years for February.

### 4. `NumOfDaysFromBeginningTheYear(short year, short month, short day)`
- Sums the number of days in all months up to the given month.
- Adds the provided day to get the total days from the year's beginning.

### 5. `GetDateFromDayOrderInAYear(short dayOrderInAYear, short year)`
- Takes a day order (e.g., 45th day of the year) and returns the actual date.
- Iteratively subtracts month lengths to determine the month and day.
- Returns a struct `sDate` with `day`, `month`, and `year`.

---

## 📌 Struct Definition

```csharp
struct sDate
{
    public short year;
    public short month;
    public short day;
}
```

Used to return a full date from the `GetDateFromDayOrderInAYear()` function.

---

## 📤 Sample Output

```
Please enter a Day? 15
Please enter a Month? 2
Please enter a year? 2024

Number Of Days From The Beginning Of The Year is 46

Date for [46] is: 15/2/2024
```

---

## 📎 Notes

- The application correctly handles leap years.
- Provides both forward (date → day order) and reverse (day order → date) functionalities.
- Validates month and day input ranges.

---

## 🛠️ How to Run

1. Copy the code into a `.cs` file (e.g., `Program.cs`).
2. Compile and run it with the .NET CLI or an IDE like Visual Studio.

```bash
dotnet run
```

---

## ✅ Use Cases

- Useful for building calendar apps.
- Can be extended to support scheduling or time-tracking systems.
- Great learning tool for date arithmetic and struct handling in C#.

---

