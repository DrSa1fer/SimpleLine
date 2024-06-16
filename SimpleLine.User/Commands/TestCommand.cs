using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.User.Commands
{
    [Command("test")]
    public class TestCommand
    {
        [Handler("--test")]
        public void Test(
            [CustomKeys("-m", "--meow")] string meow)
        {
            Console.WriteLine("Hello world! and " + meow);
        }
    }

    [Command("conf")]
    public class ConfigCommand
    {
        [Handler("--edit")]
        public void Test()
        {
            Console.WriteLine("Edit config");
        }
    }
}
