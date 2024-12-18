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
    public TestView a()
    {
        Console.WriteLine("Hello World! I am home controller!");
        Console.WriteLine($"Left = {Left}, Operator = {Operator}, Right = {Right}");
        return new TestView(new TestModel());
    }
    
    [Action]
    public TestView b()
    {
        Console.WriteLine("Its is second action of HomeController!");
        return new TestView(new TestModel());
    }
}