using SimpleLineLibrary.Setup.Help;
using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands.Test
{
    [Command("test")]
    [Description("abc")]
    [DocsLink("https://docs.com?com=test")]
    public class TestCommands
    {
        private readonly TextWriter _writer;

        public TestCommands(TextWriter writer)
        {
            _writer = writer;
        }

        [CommandAction]
        public void Test()
        {
            _writer.WriteLine("It is test command");
        }
    }
}