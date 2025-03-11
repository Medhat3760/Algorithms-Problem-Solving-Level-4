# Number To Text Converter

## Overview
This C# console application converts a numerical input into its English text representation. It supports numbers ranging from 1 to billions.

## Features
- Converts numbers from 1 to billions into words.
- Handles special cases such as numbers between 11-19 and multiples of ten.
- Uses recursion to process large numbers.

## How It Works
1. **User Input**: The program prompts the user to enter a number.
2. **Processing**:
   - The `NumberToText` function recursively breaks down the number into words.
   - It uses predefined arrays for numbers up to 19 and multiples of ten.
   - It handles different ranges (hundreds, thousands, millions, billions) appropriately.
3. **Output**: The number's text representation is displayed.

## Code Breakdown
- `ReadNumber()`: Reads and parses user input.
- `NumberToText(long number)`: Converts a number to its English text representation using recursion.
- `Main()`: Reads input, calls `NumberToText()`, and prints the result.

## Example Usage
```
Enter a number? 12345
Twelve Thousands Three Hundreds Fourty-Five
```

## Possible Improvements
- Handle negative numbers.
- Improve formatting (e.g., removing extra spaces or hyphens).
- Support decimal numbers.

## Running the Program
1. Compile the C# program using an IDE or command line.
2. Run the executable and enter a number to see its text representation.


