# SimpleLine


## About
**SimpleLine** an open source library that targets to simplify command line interaction.  
Allows you to define new commands without having to think about getting values, type conversion, 
calling a specific type, and a lot of other troubles.
It s written in C# language.

## Why?
**SimpleLine** library makes it easy to write command-line applications
- Facilitates development
- Fairly easy to use 
- Easy enough to embed
- Does not affect the testability of the system

## Installation
.NET CLI
```powershell copy
> dotnet add package SimpleLine --version 0.1.0-beta
```
Package Manager
```powershell copy
PM> NuGet\Install-Package SimpleLine -Version 0.1.0-beta
```
Package Reference
```powershell copy
<PackageReference Include="SimpleLine" Version="0.1.0-beta" />
```

> Required [.NET SDK](https://dotnet.microsoft.com/en-us/download) 6.0+


## Usage
To use the library, you need to complete several steps

### 1. Define commands
```csharp copy
using SimpleLineLibrary.Setup;

[CommandDefinitions]
public class Example
{
    [Command("example")]
    public void Foo(int x)
    {
        Console.WriteLine($"result: {x * 2}");
    }
}
```

### 2. Set run library
```csharp copy
using SimpleLineLibrary;

internal class Program
{
    static void Main(string[] args)
    {
        var conf = Configuration.Default(typeof(Program).Assembly);

        SimpleLine.Build(conf).Run(args);
    }
}
```

### 3. Invoke
```powershell copy
C:\> dotnet program.dll example -x 10
result: 20
```

## Feedback or Suggestion
- [Github](https://github.com/DrSa1fer)
- [Telegram](https://t.me/DanilKucherenko)
- [Discord](https://discord.com/invite/XmQqXuHQ)


## Docs
You can find fully documentation about project
[docs link](https://drsa1fer.github.io/SimpleLine/)


## License
[GNU GPL-3.0](https://www.gnu.org/licenses/gpl-3.0.en.html)
