using SimpleLineLibrary.Setup.Help;
using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandsDefinitions]
    public class EchoCommand
    {
        [Command("echo")]
        [Description("Display your text")]
        [DocsLink("https://github.com/")]
        public static void Echo(string message)
        {
            throw new Exception(message);
        }
    }
}