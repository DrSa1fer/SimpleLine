using SimpleLineLibrary.Setup.Attributes;

namespace SimpleLineLibrary.User.Commands
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
