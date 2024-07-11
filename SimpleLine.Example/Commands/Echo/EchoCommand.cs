using SimpleLineLibrary.Setup;
using SimpleLineLibrary.Setup.Help;

namespace SimpleLineLibrary.Example.Commands.Echo
{
    [Command("echo")]
    [Description("Display your text")]
    [DocsLink("https://github.com/")]
    public class EchoCommand
    {
        private readonly TextWriter _writer;

        public EchoCommand(TextWriter writer)
        {
            _writer = writer;
        }

        [CommandAction]
        public void Echo(string message)
        {
            _writer.WriteLine(message);
        }
    }
}