using SimpleLineLibrary.Setup.Attributes;

namespace SimpleLineLibrary.Example.Commands
{
    [Command("test")]
    public class TestCommand
    {
        [Handler("sub")]
        public void Test(
            [CustomKeys("-t", "--tt")] string[] test)
        {
            Console.WriteLine("Hello world! and " + string.Join(":", test));
        }
    }
}
