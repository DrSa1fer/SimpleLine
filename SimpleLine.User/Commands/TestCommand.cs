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
    [Description("group of config commands")]
    public class ConfigCommand
    {
        [Handler]
        public void Test1(
            [CustomKeys("-a", "--args")] string[] args,
            [CustomKeys("-b", "--bargs")] bool key)
        {
            Console.WriteLine(">| {0} |<", string.Join(", ", args));
            Console.WriteLine(key.ToString());
        }

        [Handler("--c")]
        public void Test2(
            [CustomKeys("-a", "--args")] string[] args,
            [CustomKeys("-b", "--bargs")] bool key)
        {
            Console.WriteLine(">| {0} |<", string.Join(", ", args));
            Console.WriteLine(key.ToString());
        }

        [Handler("--meow")]
        [Description("Meow meow")]
        public void Meow()
        {
            Console.WriteLine("MEOW!!!");
        }
    }
}
