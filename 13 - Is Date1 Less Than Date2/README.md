# Date Comparison Program (C#)

This C# console application compares two dates and determines whether the first date is earlier than the second.

## 📌 Features

- Prompts the user to enter two full dates (day, month, and year).
- Compares the two dates.
- Displays whether the first date is less than (i.e., comes before) the second.

---

##  Program Structure

### 1. `sDate` Struct

Defines a structure to represent a date with three `short` fields:

```csharp
struct sDate {
    public short year;
    public short month;
    public short day;
}
```

### 2. Input Functions

These functions prompt the user for day, month, and year values and return them:

- `ReadDay()`
- `ReadMonth()`
- `ReadYear()`
- `ReadFulDate()` – collects a complete date from the user and returns an `sDate` object.

### 3. Date Comparison Function

```csharp
static bool IsDate1BeforeDate2(sDate date1, sDate date2)
```

Checks if `date1` is earlier than `date2` by comparing year, then month, then day.

### 4. `Main()` Method

- Reads two dates from the user.
- Calls `IsDate1BeforeDate2` to compare them.
- Prints the result to the console.

---

## 🧪 Sample Output

```
Please enter a Day? 5
Please enter a Month? 4
Please enter a Year? 2023

Please enter a Day? 6
Please enter a Month? 4
Please enter a Year? 2023

Yes, Date1 is less than Date2.
```

---

## ✅ Summary

This simple program demonstrates the use of structs, input handling, and logical comparisons to solve a real-world problem: comparing two dates. It's an excellent exercise for beginners learning how to structure and manage basic input/output in C#.


