# Is Date1 After Date2?

This C# console application compares two dates and determines whether the first date is after the second.

## 📋 Features
- Allows user input of two dates
- Compares the two dates:
  - If Date1 is after Date2 → outputs confirmation
  - Otherwise → indicates that Date1 is not after Date2
- Checks include:
  - Year
  - Month
  - Day

## 📌 Key Concepts Demonstrated
- Structs (`stDate`) to represent date values
- Custom comparison logic between two dates
- Basic I/O operations via the console

## 📦 Program Structure
### `struct stDate`
Represents a date with `year`, `month`, and `day`.

### Input Functions:
- `ReadDay()`
- `ReadMonth()`
- `ReadYear()`
- `ReadFulDate()` - calls the above three to construct a `stDate`

### Date Comparison Functions:
- `IstDate1BeforeDate2(date1, date2)`
- `IstDate1EqualDate2(date1, date2)`
- `IstDate1AfterDate2(date1, date2)`
  - Returns true only if Date1 is **neither** before **nor** equal to Date2

### Main Execution
- Prompts the user to enter `Date1` and `Date2`
- Compares both using `IstDate1AfterDate2`
- Displays result to the user

## ▶️ Example Usage
```
Enter Date1:
Please enter a Day? 2
Please enter a Month? 5
Please enter a Year? 2025

Enter Date2:
Please enter a Day? 1
Please enter a Month? 5
Please enter a Year? 2025

Yes, Date1 is After Date2.
```

## ✅ Summary
This app is useful for basic date comparisons and is a good exercise in:
- Struct handling
- Input validation
- Logical condition building

Feel free to expand this by adding date validation, formatting, or integrating with `DateTime` for more robust handling!


