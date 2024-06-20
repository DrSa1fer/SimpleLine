using SimpleLineLibrary.Setup.Attributes;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions]
    public class TestCommand
    {
        [Command("sub")]
        [Description("Hello world!")]
        public void Test([CustomKeys("-t", "--tt")] [Description("meow")] int[] test)
        {
            Console.WriteLine("Hello world! and " + test.Sum());
        }
    }
}