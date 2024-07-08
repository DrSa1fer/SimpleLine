using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [Command("")]
    public class RootCommand
    {
        private readonly TextWriter _writer;

        public RootCommand(TextWriter writer)
        {
            _writer = writer;
        }

        [CommandAction]
        public void Root()
        {
           // _writer.WriteLine("Hello World!");
           // _writer.WriteLine(":)");
        }

        [CommandHelp]
        public static string Help()
        {
            return "";
        }
    }
}