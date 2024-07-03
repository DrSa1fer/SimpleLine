using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions("file")]
    public class FileCommands
    {
        [Command]
        [Description("Group of file interaction commands")]
        public void aFile()
        {
            System.Console.WriteLine("Use --help for more info");
        }


        [Command("read")]
        public void ReadFile(string path)
        {
            if(!File.Exists(path))
            {
                throw new Exception("File no exists");
            }

            Console.WriteLine(File.ReadAllText(path));
        }
    }
}