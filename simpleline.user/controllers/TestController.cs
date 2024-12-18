using simpleline.attributes;
using simpleline.user.models;
using simpleline.user.views;

namespace simpleline.user.controllers;

[Route("test do")]
public class TestController
{
    [Flag(["h", "help"])] public bool Help;

    [Parameter(["l", "left"])] public int Left;

    [Argument(0)] public int Operator;

    [Parameter(["l", "left"])] public int Right;

    [Action]
    public static TestView Invoke()
    {
        Console.WriteLine("Hello World! I am a test controller!");
        return new TestView(new TestModel());
    }
}

// Создать экземпляр
// Назначить поля
// Вызвать обработчик