using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions("test")]
    public class TestCommand
    {

        public TestCommand(int i) {}

        [Command("foo")]
        public static void Foo(int[] msgs)
        {
            Console.WriteLine(string.Join(";", msgs));
        }
    }

    [CommandDefinitions("test")]
    public class TestCommand2
    {
        [Command("@")]
        [Description("meow")]
        public static void Foo(int x, int y)
        {
            Console.WriteLine("| " + (x + y) + " |");
        }
    }
}