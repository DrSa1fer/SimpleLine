using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.User.Commands
{
    [Command("test")]
    public class TestCommand
    {
        [Handler("--test")]
        public void Test(
            [CustomKeys("-t", "--tt")] string test)
        {
            Console.WriteLine("Hello world! and " + test);
        }
    }
}
