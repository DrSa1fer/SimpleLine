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
    [Flag(["h", "help"])] public bool Help0;
    [Flag(["j"])] public bool Help1;
    [Flag(["k"])] public bool Help2;
    [Flag(["g"])] public bool Help3;

    [Action]
    public void a()
    {
        Console.WriteLine("Hello World! I am home controller!");
        Console.WriteLine($"Left = {Left}, Operator = {Operator}, Right = {Right}");
        Console.WriteLine($"Flag = {Help0}, {Help1}, {Help2}, {Help3}");
        //Render(
        new TestView(new TestModel());
        //);
    }
    
     
}