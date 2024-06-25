# Группировка

SimpleLine обладает возможностью группировки команд. 

Для этого у атрибута ``CommandDefinitions`` есть перегрузка, 
которая принимает имя корневой команды

```csharp
[CommandDefinitions("command")]
```

## Примеры
Расмотрим примеры, где это может пригодиться

Здесь мы группируем команды внутри блока math
```csharp
[CommandDefinitions("math")]
public class MathCommands
{
    [Command("sum")]
    public void Sum(int x, int y) { ... }

    [Command("substract")]
    public void Substract(int x, int y) { ... }

    [Command("multiply")]
    public void Multiply(int x, int y) { ... }

    [Command("divive")]
    public void Divive(int x, int y) { ... }
}
```

по итогу этой группировки комманды будут зарегистрированы и доступны по таким именам
```csharp
dotnet program.dll math sum 
dotnet program.dll math substract
dotnet program.dll math divive
dotnet program.dll math multiply
```