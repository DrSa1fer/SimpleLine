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
        public static void Root() 
        {
            var _writer = Console.Out;

            _writer.WriteLine("Hello World!");
            _writer.WriteLine(":)");
        }

        [CommandHelp]
        public void Help()
        {

        }
    }
}