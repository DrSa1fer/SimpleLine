using SimpleLineLibrary.Setup.Help;
using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandsDefinitions("test")]
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

    [CommandsDefinitions]
    public class RootCommands
    {
        [Command]
        [Description("Root command of project")]
        [DocsLink("https://docs.com?com=root")]
        public static void Root(
            [Description("left operand") ] bool x, 
            [Description("right operand")] int y)
        {
            Console.WriteLine("| " + " |");
        }

        [Command("file")]
        [Description("Method. group of file interaction commands")]
        public static void A() { }
    }
}