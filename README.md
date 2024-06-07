# InvoiceNumberGenerator

InvoiceNumberGenerator is a simple C# library for generating invoice numbers with a customizable prefix and a date part.

## Installation

You can install the InvoiceNumberGenerator library via NuGet Package Manager Console by running the following command:

```csharp
Install-Package Nlabs.InvoiceNumberGenerator
```

```csharp
dotnet add package Nlabs.InvoiceNumberGenerator
```

## Usage

```csharp
using Nlabs.InvoiceNumberGenerator;

class Program
{
    static void Main(string[] args)
    {
        string prefix = "INV_";
        string currentMaxNumber = "INV_20240607000000000005"; // Example of the current maximum number

        string newNumber = InvoiceNumberGenerator.GenerateInvoiceNumber(prefix, currentMaxNumber);
        Console.WriteLine(newNumber); // Example output: "INV_20240607000000000006"
    }
}

```
