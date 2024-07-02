using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions("test")]
    public class TestCommands
    {
        [Command("@")]
        public static void Test()
        {
            Console.WriteLine("It is test command");
        }

        [Command("foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(';', msgs));
        }
    }

    [CommandDefinitions]
    public class RootCommands
    {
        [Command("@")]
        [Description("meow")]
        public static void Foo(int x, int y = 1)
        {
            Console.WriteLine("| " + (x + y) + " |");
        }
    }
}