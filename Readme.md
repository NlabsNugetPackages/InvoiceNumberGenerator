# InvoiceNumberGenerator

`InvoiceNumberGenerator` is a robust C# library designed for generating invoice or purchase order numbers with customizable prefixes, a date part, and a numeric portion of user-defined width. It supports error handling for invalid input parameters to ensure reliable usage.

## Installation

You can install the `InvoiceNumberGenerator` library via NuGet Package Manager Console by running the following command:

```csharp
Install-Package Nlabs.InvoiceNumberGenerator
```
## Or via .NET CLI:
```csharp
dotnet add package Nlabs.InvoiceNumberGenerator
```
## Features
Customizable Prefix: Specify a prefix for your invoice numbers.
Date Integration: Automatically includes the current date in yyyyMMdd format.
Numeric Width Customization: Control the width of the numeric portion (e.g., 5, 10, or more digits).
Error Handling: Validates input parameters and throws appropriate exceptions for invalid input.
## Usage
### Example Code
```csharp
using Nlabs.InvoiceNumberGenerator;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string prefix = "INV_";
            string currentMaxNumber = "INV_20240607000005"; // Example of the current maximum number
            int numberWidth = 10; // Define the width of the numeric part

            string newNumber = InvoiceNumberGenerator.GenerateInvoiceNumber(prefix, currentMaxNumber, numberWidth);
            Console.WriteLine(newNumber); // Example output: "INV_202406070000000006"
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Argument error: {ex.Message}");
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Out of range error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}
```
### Example Outputs
#### Valid Input:
```csharp
Generated Invoice Number: INV_202406070000000006
```
#### Invalid Prefix:
```csharp
Argument error: Prefix cannot be null, empty, or whitespace.
```
#### Invalid Number Width:
```csharp
Out of range error: Number width must be at least 1.
```
## Method Documentation
### GenerateInvoiceNumber
```csharp
public static string GenerateInvoiceNumber(string prefix, string? currentMaxNumber, int numberWidth)
```
### Parameters
- `prefix` `(string)`: The prefix to include in the invoice number. Must not be null, empty, or whitespace.
- `currentMaxNumber` `(string?)`: The current maximum number. If `null` or empty, the first number starts at `1`.
### Returns
- A newly generated invoice number in the format:
```csharp
[prefix][yyyyMMdd][number (zero-padded to numberWidth)]
```
### Exceptions
- `ArgumentException`:
- - Thrown when the prefix is null, empty, or whitespace.
- `ArgumentOutOfRangeException`:
- - Thrown if numberWidth is less than `1`.
## Error Handling
This library provides comprehensive error handling to prevent invalid usage. Below are some common scenarios:
### Invalid Prefix
If the `prefix` is `null`, empty, or whitespace, an `ArgumentException` is thrown:
```csharp
try
{
    string invalidPrefix = " ";
    string newNumber = InvoiceNumberGenerator.GenerateInvoiceNumber(invalidPrefix, null, 10);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Argument error: {ex.Message}");
}
```
### Output:
```csharp
Argument error: Prefix cannot be null, empty, or whitespace.
```
### Invalid Number Width
If the `numberWidth` is less than `1`, an `ArgumentOutOfRangeException` is thrown:
```csharp
try
{
    int invalidNumberWidth = 0;
    string newNumber = InvoiceNumberGenerator.GenerateInvoiceNumber("INV_", null, invalidNumberWidth);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Out of range error: {ex.Message}");
}
```
### Output:
```csharp
Out of range error: Number width must be at least 1.
```
## Examples
### First Number Generation
If no previous maximum number exists:
```csharp
string newNumber = InvoiceNumberGenerator.GenerateInvoiceNumber("INV_", null, 10);
Console.WriteLine(newNumber);
```
### Output:
```csharp
INV_202406070000000001
```
### Incrementing Numbers
Given the last generated number:
```csharp
string currentMaxNumber = "INV_202406070000000009";
string newNumber = InvoiceNumberGenerator.GenerateInvoiceNumber("INV_", currentMaxNumber, 10);
Console.WriteLine(newNumber);
```
### Output:
```csharp
INV_202406070000000010
```
### Conclusion
The `InvoiceNumberGenerator` library is a flexible and powerful tool for generating invoice numbers in .NET applications. With customizable options and robust error handling, it ensures reliability and ease of use for developers.
