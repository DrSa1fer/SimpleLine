using simpleline.attributes;
using simpleline.user.models;
using simpleline.user.views;

namespace simpleline.user.controllers;

[Command]
[Route("")]
public class HomeController
{
    [Argument(0)] public int Operator;

    [Argument(1)] public string Name;

    [Parameter(["l", "left"])] public int Left;

    //
    // [Parameter(["r", "right"])]
    //
    [Argument(2)] public int Right;

    //
    [Flag(["h", "help"])] public bool Help;

    [Action]
    public void a()
    {
        Console.WriteLine("Hello World! I am home controller!");
        Console.WriteLine($"Left = {Left}, Operator = {Operator}, Right = {Right}");
        Console.WriteLine($"Flag = {Help}");
        //Render(
        new TestView(new TestModel());
        //);
    }
}