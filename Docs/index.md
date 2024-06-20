# SimpleLine

___
## About
**Simple Line** an open source library that targets to simplify command line interaction.  
Allows you to define new commands without having to think about getting values, type conversion, 
calling a specific type, and a lot of other troubles.
It s written in C# language.
___

## Why?
**SimpleLine** library makes it easy to write command-line applications.
* Facilitates development
* Fairly easy to use.
* Easy enough to embed. 
* Does not affect the testability of the system. 
___
## Installation
**NuGet:**

Install library via \"Package Manager\"
```powershell copy
PM> NuGet\Install-Package SimpleLine -Version 0.0.1
```
___
## Usage

To use the library, you need to complete several steps

### 1. Define Command
```csharp copy
[Command("example")]
public class Example
{
    [Handler]
    public void Foo(int x)
    {
        Console.WriteLine($"result: {x * 2}");
    }
}
```

### 2. Run Library
```csharp copy
internal class Program
{
    static void Main(string[] args)
    {
        SimpleLine
            .Build(new Configuration(typeof(Program).Assembly)))
            .Run(args);
    }
}
```

---
## Invoke
```powershell copy
C:\> dotnet program.dll example -x 10
result: 20
```
___

## Docs
Fully documentation about project

[docs link](https://google.com)
___

## License
GNU General Public License version 2