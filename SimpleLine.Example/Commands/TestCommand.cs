using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions("test")]
    public class TestCommand
    {
        [Command("foo")]
        public static void Foo()
        {
            Console.WriteLine("Hello world!");
        }
    }
}