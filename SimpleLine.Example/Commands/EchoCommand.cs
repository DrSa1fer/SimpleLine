using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions]
    public class EchoCommand
    {
        [Command("echo")]
        [Description("Display your text")]
        [DocsLink("https://github.com/")]
        public void Echo(string message)
        {
            Console.WriteLine(message);
        }
    }
}