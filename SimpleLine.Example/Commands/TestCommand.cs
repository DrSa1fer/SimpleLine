using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions("test")]
    public class TestCommands
    {
        [Command]
        [Description("abc")]

        [DocsLink("https://docs.com?com=test")]
        public static void Test(string g)
        {
            Console.WriteLine("It is test command");
        }

        [Command("foo")]
        [Description("it foo command")]
        [DocsLink("https://docs.com?com=foo")]
        public static void Foo(string[] msgs)
        {
            Console.WriteLine(string.Join(';', msgs));
        }
    }

    [CommandDefinitions]
    public class RootCommands
    {
        [Command]
        [Description("Root command of project")]
        [DocsLink("https://docs.com?com=root")]
        public static void Root(
            [Description("left operand") ] int x, 
            [Description("right operand")] int y = 1)
        {
            Console.WriteLine("| " + (x + y) + " |");
        }

        
    }
}