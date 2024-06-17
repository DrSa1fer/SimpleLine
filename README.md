# SimpleLine

___
## About
**Simple Line** an open source library that targets to simplify command line interaction.  
Allows you to define new commands without having to think about getting values, type conversion, 
calling a specific type, and a lot of other troubles.
It s written in c# language.

___
## Installation
**NuGet:**

Install library via "Package Manager"
```powershell copy
PM> NuGet\Install-Package Simple-Line -Version 0.0.1
```
___
## Usage

### Define Command
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


### Run Library
```csharp copy
internal class Program
{
    static void Main(string[] args)
    {
        SimpleLine
            .Build(new Configuration())
            .Run(args, typeof(Program).Assembly));
    }
}
```

### Invoke
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
