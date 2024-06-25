using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions("test")]
    public class TestCommand
    {
        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test")]
    public class TestCommand2
    {
        [Command("@")]
        public static void Foo(string message)
        {
            Console.WriteLine("| " + message + " |");
        }
    }
}