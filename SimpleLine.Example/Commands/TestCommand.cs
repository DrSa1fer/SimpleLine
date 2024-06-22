using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions("test")]
    public class TestSubCommand
    {
        [Command("sub")]
        public static void Bar()
        {
            Console.WriteLine("Bye world!");
        }
    }
}