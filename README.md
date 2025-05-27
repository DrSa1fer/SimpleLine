# SimpleLine  

## 📝 About  
**SimpleLine** is an open-source library designed to simplify command-line interaction.  

## 📊 Why?  
The **SimpleLine** library makes it easy to write command-line applications with:  
- ⚡ High performance  
- 🔥 Simple usage  
- 🎨 Flexible customization  

## 💾 Installation  
### .NET CLI  
```powershell copy  
> dotnet add package SimpleLine --version 0.2.1-beta  
```  
### Package Manager  
```powershell copy  
PM> NuGet\Install-Package SimpleLine -Version 0.2.1-beta  
```  
### Package Reference  
```powershell copy  
<PackageReference Include="SimpleLine" Version="0.2.1-beta" />  
```  

> Requires [.NET SDK](https://dotnet.microsoft.com/en-us/download) 6.0+  

## ⚙️ Usage  
To use the library, follow these steps:  

### 1. Define a handler  
```csharp copy  
using SimpleLine.App;  

[Handler("x2")]  
public class MyHandler  
{  
    [Action]  
    public void MyAction(int x) {
        Consile.WriteLine($"result: {x * 2}");
    }  
}  
```  

### 2. Run it in `Main`  
```csharp copy  
SimpleLineApp.Run();  
```  

### 3. Invoke the program  
```powershell copy  
> program x2 10
result: 20
```  

## 📄 Documentation  
For full project documentation, visit:  
[docs link](https://drsa1fer.github.io/SimpleLine/)  

## ⚖️ License  
This project is licensed under:  
[GNU GPL-3.0](https://www.gnu.org/licenses/gpl-3.0.en.html)  

## 💡 Feedback or Suggestions  
- [GitHub](https://github.com/DrSa1fer)  
- [Telegram](https://t.me/DanilKucherenko)  
- [Discord](https://discord.com/invite/XmQqXuHQ)  
