using simpleline.attributes;

namespace simpleline.user.controllers;

[Command]
[Route("")] // program + -l 100 -r = 80 -h
public class HomeController {
    [Parameter(["l", "left"])] public int Left;

    [Parameter(["r", "right"])] public int Right;

    [Flag(["h", "help"])] public bool Help;

    [Argument(0)] public int Operator;

    [Action]
    public void Action() {
        Console.WriteLine("Hello World! I am home controller!");
        Console.WriteLine($"Left = {Left}, Operator = {Operator}, Right = {Right}");
        Console.WriteLine($"Flag = {Help}");
    }
}