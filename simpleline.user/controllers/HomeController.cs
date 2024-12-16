using simpleline.attributes;
using simpleline.user.models;
using simpleline.user.views;

namespace simpleline.user.controllers;

[Route("")]
public class HomeController
{
    [Flag(["h", "help"])] public bool Help;

    [Parameter(["l", "left"])] public int Left;

    [Argument(0)] public int Operator;

    [Parameter(["l", "left"])] public int Right;

    [Action]
    public TestView Invoke()
    {
        Console.WriteLine("Hello World! I am home controller!");
        return new TestView(new TestModel());
    }
}

// Создать экземпляр
// Назначить поля
// Вызвать обработчик