# Вложенные команды 
---

Команды могут быть вложенными в другую команду для примера возьмем ``math``, мы хотим добавить в нее вложенную команду, чтобы получить ``math sum``. Для этого нам понадобится при объявлении команды передать имена команд через пробел:
```csharp
[Command("math sum")]
public void Sum(int x, int y) { ... }
```