using simpleline.attributes;

namespace simpleline.user.controllers;

[Command]
[Route("test do")]
public class TestController {
    [Flag(["h", "help"])] public bool Help;

    [Argument(0)] public int Operator;
    
    [Parameter(["l", "left"])] public int Left;
    [Parameter(["r", "right"])] public int Right;
    
    [Env("as")] public string Env;

    [Action]
    public static void Invoke([Argument(1)] int test) {
        Console.WriteLine("Hello World! I am a test controller!");
    }
}