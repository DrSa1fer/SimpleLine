# Группировка
---

Для понимания зачем это нужно нам стоит рассмотреть пример.
Возьмем команду ``math`` и вложенную команду ``sum``:
```csharp
public class MathCommands
{
    public void Math()
    {
        Console.WriteLine("Math is cool!");
    }

    public void Sum(int x, int y)
    {
        Console.WriteLine($"Result: {x + y}");
    }
}
```

Первый вариант решения задачи, вероятнее всего, который вы бы использовали:

```csharp
using SimpleLineLibrary.Setup;

[CommandDefinitions]
public class MathCommands
{
    [Command("math")]
    public void Math() { ... }

    [Command("math sum")]
    public void Sum(int x, int y) { ... }
}
```
В том варианте все верно, но можно упростить. Давайте применим группировку. Для этого в атрибуте ``[CommandDefinitions]`` есть перегрузка, которая принимает имя команды к которой надо прикрепиться. Вот тот же код. работающий точно также, что и в прошлом примере, но на этот раз с использованием группировки:
```csharp
using SimpleLineLibrary.Setup;

[CommandDefinitions("math")]
public class MathCommands
{
    [Command("@")]
    public void Math() { ... }

    [Command("sum")]
    public void Sum(int x, int y) { ... }
}
```
> Это становить более актуальнее, когда глубина вложенности растет

Символ ``@`` - это контекстная функция библиотеки, позволяющая дать определение команде, к которой привязана группа, в данном случае ``math``.